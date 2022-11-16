using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class CreateUpdateCommentDto : EntityDto<Guid>
    {
        [Required]
        [StringLength(CommentConsts.MaxTextLength)]
        public string Text { get; set; }

        [Required]
        public Guid BlogPostId { get; set; }
    }
}
