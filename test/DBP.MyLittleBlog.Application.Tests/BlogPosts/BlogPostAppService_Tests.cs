using DBP.MyLittleBlog.BlogPosts.Dtos;
using DBP.MyLittleBlog.DomainExceptions;
using Shouldly;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace DBP.MyLittleBlog.BlogPosts
{
    public class BlogPostAppService_Tests : MyLittleBlogApplicationTestBase
    {
        private readonly IBlogPostAppService _blogPostAppService;

        public BlogPostAppService_Tests()
        {
            _blogPostAppService = GetRequiredService<IBlogPostAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Post()
        {
            //Act
            string title = "Dolor sit amet";
            string author = "John Perez";

            var result = await _blogPostAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Title == title &&
                                       b.Author == author);
        }

        [Fact]
        public async Task Should_Get_List_Of_Active_Post()
        {
            //Act
            string title = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED_TITLE;
            string author = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED_AUTHOR;

            var result = await _blogPostAppService.GetActiveAsync();

            //Assert
            result.Count.ShouldBe(1);
            result.ShouldContain(b => b.Id == TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
        }

        [Fact]
        public async Task Should_Get_a_Post()
        {
            //Act
            string title = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED_TITLE;
            string author = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED_AUTHOR;

            var result = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);

            //Assert
            result.Title.ShouldBe(title);
            result.Author.ShouldBe(author);
        }

        [Fact]
        public async Task Should_Create_A_Valid_Post()
        {
            //Act
            string title = "Lorem ipsum dolor sit amet";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            string author = "John Perez";

            var result = await _blogPostAppService.CreateAsync(
                new CreateUpdateBlogPostDto
                {
                    Category = Category.Undefined,
                    Title = title,
                    Description = description,
                    Author = author
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Category.ShouldBe(Category.Undefined);
            result.Title.ShouldBe(title);
            result.Description.ShouldBe(description);
            result.Author.ShouldBe(author);
            result.Comments.Count.ShouldBeEquivalentTo(0);
            result.CreationTime.ShouldBeGreaterThan(DateTime.MinValue);

            var exist = await _blogPostAppService.GetAsync(result.Id);
            exist.Id.ShouldBe(result.Id);
        }

        [Fact]
        public async Task Should_Not_Create_A_Post_Without_Title()
        {
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            string author = "John Perez";

            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _blogPostAppService.CreateAsync(
                    new CreateUpdateBlogPostDto
                    {
                        Category = Category.Undefined,
                        Title = null,
                        Description = description,
                        Author = author
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Title"));
        }

        [Fact]
        public async Task Should_Not_Create_A_Post_Without_Description()
        {
            string title = "Lorem ipsum dolor sit amet";
            string author = "John Perez";

            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _blogPostAppService.CreateAsync(
                    new CreateUpdateBlogPostDto
                    {
                        Category = Category.Undefined,
                        Title = title,
                        Description = null,
                        Author = author
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Description"));
        }


        [Fact]
        public async Task Should_Not_Create_A_Post_Without_Author()
        {
            string title = "Lorem ipsum dolor sit amet";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _blogPostAppService.CreateAsync(
                    new CreateUpdateBlogPostDto
                    {
                        Category = Category.Undefined,
                        Title = title,
                        Description = description,
                        Author = null
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Author"));
        }


        [Fact]
        public async Task Should_Create_A_Valid_Comment()
        {
            //Act
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var result2 = await _blogPostAppService.CreateCommentAsync(
                new CreateCommentDto
                {
                    BlogPostId = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
                    Text = text
                }
            );

            var testPost = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);

            //Assert
            testPost.Id.ShouldBe(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            testPost.Comments.ShouldNotBeNull();
            (testPost.Comments.Where(s => s.commentType == CommentType.Comment)).Count().ShouldBe(1);
        }


        [Fact]
        public async Task Should_Create_A_Valid_Comment_With_Like()
        {
            //Act
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var result2 = await _blogPostAppService.CreateCommentWithLikeAsync(
                new CreateCommentDto
                {
                    BlogPostId = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
                    Text = text
                }
            );

            var testPost = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);

            //Assert
            testPost.Id.ShouldBe(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            testPost.Comments.ShouldNotBeNull();
            (testPost.Comments.Where(s => s.commentType == CommentType.CommentWithLike)).Count().ShouldBe(2);

            (testPost.Comments.Where(s => (s as CommentBaseDto).commentType == CommentType.CommentWithLike).First() as CommentWithLikeDto)
                .LikeCount.ShouldBe(0);
        }

        [Fact]
        public async Task Should_add_A_Like_To_Comment_With_Like()
        {
            //Act
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var result2 = await _blogPostAppService.CreateCommentWithLikeAsync(
                new CreateCommentDto
                {
                    BlogPostId = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
                    Text = text
                }
            );

            var testPost = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);

            var commetWithLikeId = testPost.Comments.Where(s => s.commentType == CommentType.CommentWithLike).First().Id;

            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(commetWithLikeId);

            var testPostUpdated = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);


            //Assert
            testPostUpdated.Id.ShouldBe(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            testPostUpdated.Comments.ShouldNotBeNull();
            (testPostUpdated.Comments.Where(s => s.commentType == CommentType.CommentWithLike)).Count().ShouldBe(2);

            (testPostUpdated.Comments.Where(s => s.commentType == CommentType.CommentWithLike).First() as CommentWithLikeDto)
                .LikeCount.ShouldBe(1);

            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(commetWithLikeId);
            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(commetWithLikeId);
            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(commetWithLikeId);
            testPostUpdated = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            (testPostUpdated.Comments.Where(s => s.commentType == CommentType.CommentWithLike).First() as CommentWithLikeDto)
              .LikeCount.ShouldBe(4);
        }

        [Fact]
        public async Task Should_get_Comment_With_one_or_more_Likes()
        {
            // added 4 commentWithlike, 2 with likes
            // using the test blog post

            var post1 = await _blogPostAppService.CreateCommentWithLikeAsync(
               new CreateCommentDto
               {
                   BlogPostId = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
                   Text = "Bla Bla "
               });

            var post2 = await _blogPostAppService.CreateCommentWithLikeAsync(
              new CreateCommentDto
              {
                  BlogPostId = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
                  Text = "Bla Bla Bla Bla "
              });

            var post3 = await _blogPostAppService.CreateCommentWithLikeAsync(
              new CreateCommentDto
              {
                  BlogPostId = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
                  Text = "Bla Bla Bla Bla Bla Bla Bla"
              });

            var post4 = await _blogPostAppService.CreateCommentWithLikeAsync(
              new CreateCommentDto
              {
                  BlogPostId = TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED,
                  Text = "Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla Bla"
              });


            //ACT


            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(post1.Id);
            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(post1.Id);
            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(post1.Id);
            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(post2.Id);
            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(post2.Id);
            _ = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(post3.Id);



            //Assert
            var testPostUpdated = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);


            (testPostUpdated.Comments.Where(s => s.commentType == CommentType.CommentWithLike)).Count().ShouldBe(5);

            (testPostUpdated.Comments.Where(s => s.Id == post1.Id).First() as CommentWithLikeDto).LikeCount.ShouldBe(3);
            (testPostUpdated.Comments.Where(s => s.Id == post2.Id).First() as CommentWithLikeDto).LikeCount.ShouldBe(2);
            (testPostUpdated.Comments.Where(s => s.Id == post3.Id).First() as CommentWithLikeDto).LikeCount.ShouldBe(1);
            (testPostUpdated.Comments.Where(s => s.Id == post4.Id).First() as CommentWithLikeDto).LikeCount.ShouldBe(0);


            var postWithCommentWitLikes = await _blogPostAppService.GetCommentWihtLikesAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            postWithCommentWitLikes.Count.ShouldBe(3);

        }


        [Fact]
        public async Task Should_Fail_To_Block_A_Open_Post()
        {
            var result2 = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);

            result2.IsClosed.ShouldBeFalse();
            result2.IsLocked.ShouldBeFalse();

            var exception = await Assert.ThrowsAsync<BlogPostStateException>(async () =>
            {
                var result = await _blogPostAppService.UpdateBlockAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            });
        }

        [Fact]
        public async Task Should_Fail_To_ReOpen_A_Blok_Post()
        {

            var result0 = await _blogPostAppService.UpdateCloseAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED, PostCloseReason.ReasonA);
            var result1 = await _blogPostAppService.UpdateBlockAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            var result2 = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);

            result2.IsClosed.ShouldBeTrue();
            result2.IsLocked.ShouldBeTrue();

            var exception = await Assert.ThrowsAsync<BlogPostStateException>(async () =>
            {
                var result = await _blogPostAppService.UpdateOpenAsync(TestingConstants.BLOGPOST_ID1_FROM_TESTING_DATA_SEED);
            });
        }

    }
}

