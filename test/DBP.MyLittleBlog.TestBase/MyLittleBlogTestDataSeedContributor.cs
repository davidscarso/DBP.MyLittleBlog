using DBP.MyLittleBlog.BlogPosts;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace DBP.MyLittleBlog;

public class MyLittleBlogTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<BlogPost, Guid> _blogPostRepository;

    public MyLittleBlogTestDataSeedContributor(IRepository<BlogPost, Guid> blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Seed additional test data... */


        string title = "Lorem ipsum dolor sit amet";
        string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        string author = "John Perez";


        BlogPost blogPost = new BlogPost(
            TestingConstants.BLOGPOST_ID_FROM_TESTING_DATA_SEED,
            title,
            description,
            author,
            Category.Undefined
        );

        await _blogPostRepository.InsertAsync(blogPost, autoSave: true);

    }
}
