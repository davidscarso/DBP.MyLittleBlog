using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DBP.MyLittleBlog.BlogPosts
{
    public interface IBlogPostAppService :
        ICrudAppService<
            BlogPostDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBlogPostDto>
    {
        // ADD the NEW METHOD
        //TODO: add addmethod
        public Task<BlogPostDto> CreateCommentAsync(CreateUpdateCommentDto input);
    }
}
