using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class BlogPostAppService :
         CrudAppService<
            BlogPost,
            BlogPostDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBlogPostDto>,
        IBlogPostAppService
    {
        public BlogPostAppService(IRepository<BlogPost, Guid> repository) : base(repository)
        {

        }
    }
}
