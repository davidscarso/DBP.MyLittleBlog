using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBP.MyLittleBlog.BlogPosts.Dtos
{
    public class CreateUpdateBlogPostDto
    {
        [Required]
        public Category Category { get; set; } = Category.Undefined;

        public DateTime CreationTime { get; private set; } = DateTime.Now;

        [Required]
        [StringLength(BlogPostConsts.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(BlogPostConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(BlogPostConsts.MaxAuthorLength)]
        public string Author { get; set; }

    }
}
