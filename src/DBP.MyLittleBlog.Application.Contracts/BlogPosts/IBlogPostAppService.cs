using System;
using System.Threading.Tasks;
using DBP.MyLittleBlog.BlogPosts.Dtos;
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
   
        public Task<BlogPostDto> CreateCommentAsync(CreateCommentDto input); 
      
        public Task<BlogPostDto> CreateCommentWithLikeAsync(CreateCommentDto input);

        public Task<BlogPostDto> UpdateAddALikeCommentWithLikeAsync(Guid commentId);

    }
}
