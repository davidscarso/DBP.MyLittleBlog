﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class CommentWithLikeDto : CommentBaseDto
    {
        public int LikeCount { get; private set; }
    }
}
