using DBP.MyLittleBlog.BlogPosts;
using DBP.MyLittleBlog.BlogPosts.CustomRepositoryInterfaces;
using DBP.MyLittleBlog.BlogPosts.Specifications;
using DBP.MyLittleBlog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace DBP.MyLittleBlog.CustomRepositories
{
    public class BlogPostRepository : EfCoreRepository<MyLittleBlogDbContext, BlogPost, Guid>, IBlogPostRepository
    {
        public BlogPostRepository(IDbContextProvider<MyLittleBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<BlogPost>> GetPostAsync(ISpecification<BlogPost> spec)
        {
            // Since ToExpression() method returns an expression, it can be directly passed to the Where method to filter the entities.
            // Finally, we can pass any Specification instance to the GetIssuesAsync method:

            var dbSet = await GetDbSetAsync();
            return await dbSet
                .Where(spec.ToExpression())
                .ToListAsync();
        }
    }
}
