using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class UpdateCommentDto : EntityDto<Guid>
    {
        [Required]
        [StringLength(CommentConsts.MaxTextLength)]
        public string Text { get; set; }

    }
}
