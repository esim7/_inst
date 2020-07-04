using _inst.Models.Post;
using AutoMapper;
using Domain.Model;

namespace _inst.MapperProfile
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostIndexViewModel>();
            CreateMap<PostIndexViewModel, Post>();

            CreateMap<Post, PostDetailViewModel>();
            CreateMap<PostDetailViewModel, Post>();

            CreateMap<Post, PostCreateViewModel>();
            CreateMap<PostCreateViewModel, Post>();

            CreateMap<Post, PostEditViewModel>();
            CreateMap<PostEditViewModel, Post>();

            CreateMap<Post, PostDeleteViewModel>();
            CreateMap<PostDeleteViewModel, Post>();
        }
    }
}