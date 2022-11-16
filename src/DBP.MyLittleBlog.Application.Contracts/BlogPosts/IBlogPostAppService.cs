using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DBP.MyLittleBlog.BlogPosts
{
    public interface IBlogPostAppService :
        ICrudAppService< //Defines CRUD methods
            BlogPostDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBlogPostDto>
    {
        // ADD the NEW METHOD
        //TODO: add addmethod

    }
}
