using AutoMapper;
using DBP.MyLittleBlog.BlogPosts;
using DBP.MyLittleBlog.BlogPosts.Dtos;

namespace DBP.MyLittleBlog;

public class MyLittleBlogApplicationAutoMapperProfile : Profile
{
    public MyLittleBlogApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<BlogPost, BlogPostDto>();
        CreateMap<CreateUpdateBlogPostDto, BlogPost>();

        CreateMap<CommentBase, CommentBaseDto>().IncludeAllDerived();
        CreateMap<Comment, CommentDto>().IncludeBase<CommentBase, CommentBaseDto>();
        CreateMap<CommentWithLike, CommentWithLikeDto>().IncludeBase<CommentBase, CommentBaseDto>();


        CreateMap<CreateCommentDto, CommentBase>();
        CreateMap<UpdateCommentDto, CommentBase>();
    }
}
