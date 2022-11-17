using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace DBP.MyLittleBlog.BlogPosts
{
    [Serializable]
    public class BlogPost : AggregateRoot<Guid>
    {
        public Category Category { get; set; }
        public DateTime CreationTime { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public virtual ICollection<CommentBase> Comments { get; private set; } = new List<CommentBase>();


        protected BlogPost() { }

        //public BlogPost(Guid id) : base(id) { }

        public BlogPost(Guid id,
                        [Required] string title,
                        [Required] string description,
                        [Required] string author,
                        Category category) : base(id)
        {
            Category = category;
            CreationTime = DateTime.Now;
            Title = Check.NotNullOrWhiteSpace(title, nameof(title), maxLength: BlogPostConsts.MaxTitleLength);
            Description = Check.NotNullOrWhiteSpace(description, nameof(description), maxLength: BlogPostConsts.MaxDescriptionLength);
            Author = Check.NotNullOrWhiteSpace(author, nameof(author), maxLength: BlogPostConsts.MaxAuthorLength);

            Comments = new List<CommentBase>();
        }

        public void AddComment(string text)
        {
            Comments.Add(new Comment(Guid.NewGuid(), text, this.Id));


        }
        public void AddCommentWithLike(string text)
        {
            Comments.Add(new CommentWithLike(Guid.NewGuid(), text, this.Id));
        }

    }
}
