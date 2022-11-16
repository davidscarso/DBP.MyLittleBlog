using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DBP.MyLittleBlog.BlogPosts
{

    public class BlogPostAppService :
         CrudAppService<BlogPost, BlogPostDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBlogPostDto>,
        IBlogPostAppService
    {
        private readonly IRepository<BlogPost, Guid> _blogPostRepository;

        public BlogPostAppService(IRepository<BlogPost, Guid> repository) : base(repository)
        {
            _blogPostRepository = repository;
        }

        public async Task<BlogPostDto> CreateCommentAsync(CreateUpdateCommentDto input)
        {
            var post = await _blogPostRepository.GetAsync(input.BlogPostId, true);
           
            post.AddComment(input.Text);
           
            var postUpdated = await _blogPostRepository.UpdateAsync(post);

            var blogPostDto = ObjectMapper.Map<BlogPost, BlogPostDto>(postUpdated);
            return blogPostDto;
        }
    }
}
