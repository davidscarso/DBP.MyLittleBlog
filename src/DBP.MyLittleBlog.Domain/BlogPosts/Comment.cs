using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBP.MyLittleBlog.BlogPosts
{
    [Serializable]
    public class Comment : CommentBase
    {
        protected Comment()
        {
        }

        public Comment(Guid id, string text, Guid blogPostId) : base(id, text, blogPostId)
        {
            commentType = CommentType.Comment;
        }
    }
}
