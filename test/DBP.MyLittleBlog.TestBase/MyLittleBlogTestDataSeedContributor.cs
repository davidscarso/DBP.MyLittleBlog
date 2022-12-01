using DBP.MyLittleBlog.BlogPosts;
using DBP.MyLittleBlog.BlogPosts.CustomRepositoryInterfaces;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace DBP.MyLittleBlog;

public class MyLittleBlogTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IBlogPostRepository _blogPostRepository;

    public MyLittleBlogTestDataSeedContributor(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Seed additional test data... */

        BlogPost blogPost1 = new BlogPost(
            TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
            "Dolor sit amet",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            "John Perez",
            Category.Undefined
        );
        blogPost1.UpdateCreationTime(DateTime.Now.Subtract(TimeSpan.FromDays(10)));

        blogPost1.AddComment(new CommentWithLike(Guid.NewGuid(), "Consectetur adipiscing elit, sed do eiusmod.", Guid.Empty));
        await _blogPostRepository.InsertAsync(blogPost1, autoSave: true);


        BlogPost blogPost2 = new BlogPost(
            TestingConstants.BLOGPOST_ID2_FROM_TESTING_DATA_SEED,
            "Lorem ipsum",
            "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            "Fulanito Cosmes",
            Category.Fantastic
        );
        blogPost2.UpdateCreationTime(DateTime.Now.Subtract(TimeSpan.FromDays(40)));
        blogPost2.AddComment(new CommentWithLike(Guid.NewGuid(), "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est.", Guid.Empty));
        await _blogPostRepository.InsertAsync(blogPost2, autoSave: true);
    }
}
