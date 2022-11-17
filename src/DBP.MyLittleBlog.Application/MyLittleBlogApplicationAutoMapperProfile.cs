using AutoMapper;
using DBP.MyLittleBlog.BlogPosts;

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

        CreateMap<CommentBase, CommentDto>().IncludeAllDerived();
        CreateMap<Comment, CommentDto>().IncludeBase<CommentBase, CommentDto>();
        CreateMap<CommentWithLike, CommentWithLikeDto>().IncludeBase<CommentBase, CommentDto>();


        CreateMap<CreateCommentDto, CommentBase>();
        CreateMap<UpdateCommentDto, CommentBase>();
    }
}
