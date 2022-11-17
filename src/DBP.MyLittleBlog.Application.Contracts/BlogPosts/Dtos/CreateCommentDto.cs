using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace DBP.MyLittleBlog.BlogPosts.Dtos
{
    public class CreateCommentDto
    {
        [Required]
        [StringLength(CommentConsts.MaxTextLength)]
        public string Text { get; set; }

        [Required]
        public Guid BlogPostId { get; set; }

        public DateTime CreationTime { get; private set; } = DateTime.Now;
    }
}
