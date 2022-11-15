using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class Comment : Entity<Guid>
    {
        public string Text { get; set; }
        public DateTime CreationTime { get; private set; }
        public Guid BlogPostId { get; set; }

        protected Comment()
        {
        }

        public Comment(Guid id, string text) : base(id)
        {
            CreationTime = DateTime.Now;
            Text = Check.NotNullOrWhiteSpace(text, nameof(text), maxLength: CommentConsts.MaxTextLength);
        }
    }
}
