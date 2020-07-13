using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _inst.Models.Like;
using AutoMapper;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _inst.Controllers
{
    public class LikesController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _environment;

        public LikesController(IUnitOfWork uow, IMapper map, UserManager<User> userManager, IWebHostEnvironment environment)
        {
            _uow = uow;
            _map = map;
            _userManager = userManager;
            _environment = environment;
        }

        [HttpPost]
        public async Task<Like> AddLike(LikeViewModel like)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            like.UserId = user.Id;

            var createdLike = _map.Map<Like>(like);

            if (_uow.LikeRepository.isExist(createdLike.PostId, createdLike.UserId))
            {
                _uow.LikeRepository.Remove(createdLike);
            }
            else
            {
                await _uow.LikeRepository.CreateAsync(createdLike);
            }
            await _uow.Save();
            return createdLike;
        }
    }
}
