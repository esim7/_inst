using _inst.Models.Like;
using _inst.Models.Post;
using AutoMapper;
using Domain.Model;

namespace _inst.MapperProfile
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<Like, LikeViewModel>();
            CreateMap<LikeViewModel, Like>();
        }
    }
}