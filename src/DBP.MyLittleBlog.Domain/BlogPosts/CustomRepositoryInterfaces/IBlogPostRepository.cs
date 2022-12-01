using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace DBP.MyLittleBlog.BlogPosts.CustomRepositoryInterfaces
{
    public interface IBlogPostRepository : IRepository<BlogPost, Guid>
    {
        Task<List<BlogPost>> GetPostAsync(ISpecification<BlogPost> spec);
    }
}
