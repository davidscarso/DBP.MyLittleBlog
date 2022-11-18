using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DBP.MyLittleBlog.BlogPosts.Dtos;
using Scriban.Runtime.Accessors;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace DBP.MyLittleBlog.BlogPosts
{

    public class BlogPostAppService :
         CrudAppService<BlogPost, BlogPostDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBlogPostDto>,
        IBlogPostAppService
    {
        private readonly IRepository<BlogPost, Guid> _blogPostRepository;
        private readonly IRepository<CommentBase, Guid> _commentRepository;

        public BlogPostAppService(IRepository<BlogPost, Guid> repository, IRepository<CommentBase, Guid> commentRepository) : base(repository)
        {
            _blogPostRepository = repository;
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> CreateCommentAsync(CreateCommentDto input)
        {
            var post = await _blogPostRepository.GetAsync(input.BlogPostId, true);

            var newComment = new Comment(Guid.NewGuid(),
                input.Text,
                input.BlogPostId
                );

            post.AddComment(newComment);

            _ = await _blogPostRepository.UpdateAsync(post, true);

            var blogPostDto = ObjectMapper.Map<Comment, CommentDto>(newComment);
            return blogPostDto;
        }

        public async Task<CommentWithLikeDto> CreateCommentWithLikeAsync(CreateCommentDto input)
        {
            var post = await _blogPostRepository.GetAsync(input.BlogPostId, true);

            var newComment = new CommentWithLike(Guid.NewGuid(),
                input.Text,
                input.BlogPostId
                );

            post.AddComment(newComment);

            _ = await _blogPostRepository.UpdateAsync(post, true);

            var blogPostDto = ObjectMapper.Map<CommentWithLike, CommentWithLikeDto>(newComment);
            return blogPostDto;
        }

        public async Task<ICollection<CommentWithLikeDto>> GetCommentWihtLikesAsync(Guid blogPostId)
        {
            var post = await _blogPostRepository.GetAsync(blogPostId, true);

            var comments = post.Comments
                .Where(x => x.commentType == CommentType.CommentWithLike && (x as CommentWithLike).LikeCount > 0)
                .Select(o => o as CommentWithLike).ToList<CommentWithLike>();


            var commentDtos = ObjectMapper.Map<List<CommentWithLike>, List<CommentWithLikeDto>>(comments);

            return commentDtos;
        }

        public async Task<CommentWithLikeDto> UpdateAddALikeCommentWithLikeAsync(Guid commentId)
        {

            //QUESTION: why if I comment this line it doesn't pass the test, del pos is null?
            var commentXX = await _commentRepository.GetAsync(commentId) as CommentWithLike;

            var post = (await _blogPostRepository.GetListAsync())
                .Where(x => x.Comments.Any(y => y.Id == commentId)).FirstOrDefault();

            var comment = (post.Comments.Where(z => z.Id == commentId).FirstOrDefault() as CommentWithLike);

            comment.AddALike();

            //var commentUpdated = await _commentRepository.UpdateAsync(comment, true);

            _ = await _blogPostRepository.UpdateAsync(post, true);

            var blogPostDto = ObjectMapper.Map<CommentWithLike, CommentWithLikeDto>(comment);
            return blogPostDto;
        }
    }
}
