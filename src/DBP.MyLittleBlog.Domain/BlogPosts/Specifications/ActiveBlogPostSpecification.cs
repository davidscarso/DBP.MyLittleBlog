
using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace DBP.MyLittleBlog.BlogPosts.Specifications
{
    public class ActiveBlogPostSpecification : Specification<BlogPost>
    {
        public override Expression<Func<BlogPost, bool>> ToExpression()
        {
            var daysAgo30 = DateTime.Now.Subtract(TimeSpan.FromDays(30));

            return p => p.CreationTime >= daysAgo30 && p.Comments.Count >= 1;
        }
    }
}
