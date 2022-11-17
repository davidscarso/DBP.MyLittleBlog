using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;
using Xunit;

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
            string title = "Lorem ipsum dolor sit amet";
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
        public async Task Should_Get_a_Post()
        {
            //Act
            string title = "Lorem ipsum dolor sit amet";
            string author = "John Perez";

            var result = await _blogPostAppService.GetAsync(TestingConstants.BLOGPOST_ID_FROM_TESTING_DATA_SEED);

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

            var rrr = await _blogPostAppService.GetAsync(result.Id);
            rrr.Id.ShouldBe(result.Id);


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


            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var result2 = await _blogPostAppService.CreateCommentAsync(
                new CreateCommentDto
                {
                    BlogPostId = result.Id,
                    Text = text
                }
            );

            //Assert
            result2.Id.ShouldNotBe(Guid.Empty);
            result2.Comments.ShouldNotBeNull();
            result2.Comments.Count.ShouldBeGreaterThan(0);

        }


        [Fact]
        public async Task Should_Create_A_Valid_Comment_With_Like()
        {
            //Act
            string title = "Lorem ipsum dolor sit amet";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            string author = "John Perez";

            var result = await _blogPostAppService.CreateAsync(
                new CreateUpdateBlogPostDto
                {
                    Category = Category.Science,
                    Title = title,
                    Description = description,
                    Author = author
                }
            );


            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var result2 = await _blogPostAppService.CreateCommentWithLikeAsync(
                new CreateCommentDto
                {
                    BlogPostId = result.Id,
                    Text = text
                }
            );

            //Assert
            (result2.Comments.Where(s => (s as CommentBaseDto).commentType == CommentType.commentWithLike).First() as CommentWithLikeDto)
                .LikeCount.ShouldBe(2);
        }

        [Fact]
        public async Task Should_add_A_lLke_To_Comment_With_Like()
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


            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var result2 = await _blogPostAppService.CreateCommentAsync(
                new CreateCommentDto
                {
                    BlogPostId = result.Id,
                    Text = text
                }
            );

            var commetWithLikeId = result2.Comments.First().Id;

            var resul3 = await _blogPostAppService.UpdateAddALikeCommentWithLikeAsync(commetWithLikeId);

            //Assert
            (resul3.Comments.Where(s => (s as CommentBaseDto).commentType == CommentType.commentWithLike).First() as CommentWithLikeDto).LikeCount.ShouldBe(2);

        }

    }
}

