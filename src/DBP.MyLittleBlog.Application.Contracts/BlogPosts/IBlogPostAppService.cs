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

    }
}
