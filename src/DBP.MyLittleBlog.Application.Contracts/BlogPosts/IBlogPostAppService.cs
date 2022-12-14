using System;
using System.Collections.Generic;
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

        public Task<CommentDto> CreateCommentAsync(CreateCommentDto input);

        public Task<CommentWithLikeDto> CreateCommentWithLikeAsync(CreateCommentDto input);

        public Task<CommentWithLikeDto> UpdateAddALikeCommentWithLikeAsync(Guid commentId);

        public Task<ICollection<CommentWithLikeDto>> GetCommentWihtLikesAsync(Guid blogPostId);

        public Task<ICollection<BlogPostDto>> GetActiveAsync();

        public Task<BlogPostDto> UpdateCloseAsync(Guid blogPostId, PostCloseReason reason);
        public Task<BlogPostDto> UpdateBlockAsync(Guid blogPostId);
        public Task<BlogPostDto> UpdateUnBlockAsync(Guid blogPostId);
        public Task<BlogPostDto> UpdateOpenAsync(Guid blogPostId);

    }
}
