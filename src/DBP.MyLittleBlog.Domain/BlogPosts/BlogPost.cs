﻿using DBP.MyLittleBlog.BlogPosts.Specifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
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

        public bool IsLocked { get; private set; }
        public bool IsClosed { get; private set; }
        public PostCloseReason? ClosedReason { get; private set; }

        public virtual ICollection<CommentBase> Comments { get; private set; } = new List<CommentBase>();


        protected BlogPost() { }

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

        public bool IsActive()
        {
            return new ActiveBlogPostSpecification().IsSatisfiedBy(this);
        }

        public void AddComment(CommentBase comment)
        {
            if (comment.BlogPostId == Guid.Empty) comment.BlogPostId = this.Id;

            Comments.Add(comment);
        }

        public void UpdateCreationTime(DateTime input)
        {
            CreationTime = input;
        }

        public void Close(PostCloseReason reason)
        {
            IsClosed = true;
            ClosedReason = reason;
        }

        public void ReOpen()
        {
            IsClosed = false;
            ClosedReason = null;
        }

    }
}