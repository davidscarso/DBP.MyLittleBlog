using System;

namespace DBP.MyLittleBlog.BlogPosts
{
    [Serializable]
    public class CommentWithLike : CommentBase
    {
        public int LikeCount { get; private set; } = 0;

        protected CommentWithLike()
        {
        }

        public CommentWithLike(Guid id, string text, Guid blogPostId) : base(id, text, blogPostId)
        {
            LikeCount = 0;
            commentType = CommentType.CommentWithLike;
        }

        public int AddALike()
        {
            LikeCount++;
            return LikeCount;
        }
    }
}
