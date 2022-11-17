using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        private readonly IRepository<CommentBase, Guid> _commentRepository;

        public BlogPostAppService(IRepository<BlogPost, Guid> repository, IRepository<CommentBase, Guid> commentRepository) : base(repository)
        {
            _blogPostRepository = repository;
            _commentRepository = commentRepository;
        }

        public async Task<BlogPostDto> CreateCommentAsync(CreateCommentDto input)
        {
            var post = await _blogPostRepository.GetAsync(input.BlogPostId, true);

            post.AddComment(input.Text);

            var postUpdated = await _blogPostRepository.UpdateAsync(post);

            var blogPostDto = ObjectMapper.Map<BlogPost, BlogPostDto>(postUpdated);
            return blogPostDto;
        }

        public async Task<BlogPostDto> CreateCommentWithLikeAsync(CreateCommentDto input)
        {
            var post = await _blogPostRepository.GetAsync(input.BlogPostId, true);

            post.AddCommentWithLike(input.Text);

            var postUpdated = await _blogPostRepository.UpdateAsync(post);

            var blogPostDto = ObjectMapper.Map<BlogPost, BlogPostDto>(postUpdated);
            return blogPostDto;
        }

        public async Task<BlogPostDto> UpdateAddALikeCommentWithLikeAsync(Guid commentId)
        {

            var comment = await _commentRepository.GetAsync(commentId) as CommentWithLike;

            comment.AddALike();

            var commentUpdated = await _commentRepository.UpdateAsync(comment);

            var postUpdated = await _blogPostRepository.GetAsync(commentUpdated.BlogPostId, true);
            var blogPostDto = ObjectMapper.Map<BlogPost, BlogPostDto>(postUpdated);
            return blogPostDto;
        }
    }
}
