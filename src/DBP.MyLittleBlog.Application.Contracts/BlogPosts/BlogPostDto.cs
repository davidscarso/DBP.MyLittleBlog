using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Volo.Abp.Application.Dtos;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class BlogPostDto : EntityDto<Guid>
    {
        public Category Category { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public virtual ICollection<CommentBaseDto> Comments { get; set; }
    }
}
