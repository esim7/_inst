using _inst.Models.Comment;
using _inst.Models.Post;
using AutoMapper;
using Domain.Model;

namespace _inst.MapperProfile
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentCreateViewModel>();
            CreateMap<CommentCreateViewModel, Comment>();

            CreateMap<Comment, CommentIndexViewModel>();
            CreateMap<CommentIndexViewModel, Comment>();
        }
    }
}