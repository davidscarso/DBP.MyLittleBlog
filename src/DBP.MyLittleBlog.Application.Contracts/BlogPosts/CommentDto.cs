﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class CommentDto : EntityDto<Guid>
    {
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid BlogPostId { get; set; }
    }
}
