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

        //CreateMap<Comment, CommentDto>();
        CreateMap<CreateUpdateCommentDto, Comment>();
     
    }
}
