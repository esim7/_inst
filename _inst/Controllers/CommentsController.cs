using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _inst.Models.Comment;
using _inst.Models.Post;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _inst.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _map;
        private readonly UserManager<User> _userManager;

        public CommentsController(IUnitOfWork uow, IMapper map, UserManager<User> userManager)
        {
            _uow = uow;
            _map = map;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            var comments = await _uow.CommentRepository.GetAllByPostIdAsync(id);
            var viewModel = _map.Map<IList<CommentIndexViewModel>>(comments);
            return View(viewModel);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(int id, CommentCreateViewModel commentCreateViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = _userManager.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
        //        commentCreateViewModel.PostId = id;
        //        commentCreateViewModel.CommentAuthor = user?.Name;

        //        var comment = _map.Map<Comment>(commentCreateViewModel);
        //        await _uow.CommentRepository.CreateAsync(comment);
        //        await _uow.Save();
        //        return RedirectToAction("Index", "Posts");
        //    }
        //    return View(commentCreateViewModel);
        //}
     
        [HttpPost]
        public async Task<Comment> CreateComment(CommentCreateViewModel comment)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
            comment.CommentAuthor = user?.Name;

            var newComment = _map.Map<Comment>(comment);
            await _uow.CommentRepository.CreateAsync(newComment);
            await _uow.Save();
            return newComment;
        }
    }
}
