using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DBP.MyLittleBlog.BlogPosts
{
    [Serializable]
    public abstract class CommentBase : Entity<Guid>
    {
        public string Text { get; set; }
        public DateTime CreationTime { get; private set; }
        public Guid BlogPostId { get; set; }

        public CommentType commentType { get; set; }

        protected CommentBase()
        {
        }

        public CommentBase(Guid id, string text, Guid blogPostId) : base(id)
        {
            CreationTime = DateTime.Now;
            Text = Check.NotNullOrWhiteSpace(text, nameof(text), maxLength: CommentConsts.MaxTextLength);
            BlogPostId = blogPostId;
        }
    }
}
