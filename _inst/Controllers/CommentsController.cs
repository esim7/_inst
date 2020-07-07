using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _inst.Models.Comment;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Microsoft.AspNetCore.Identity;

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

        // GET: Comments
        //public async Task<IActionResult> Index(int id)
        //{
        //    var applicationContext = _uow.CommentRepository.GetAsync(id);
        //    return View(await applicationContext.ToListAsync());
        //}

        //// GET: Comments/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments
        //        .Include(c => c.Post)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(comment);
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, CommentCreateViewModel commentCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
                commentCreateViewModel.PostId = id;
                commentCreateViewModel.CommentAuthor = user?.Name;

                var comment = _map.Map<Comment>(commentCreateViewModel);
                await _uow.CommentRepository.CreateAsync(comment);
                await _uow.Save();
                return RedirectToAction("Index", "Posts");
            }
            return View(commentCreateViewModel);
        }

        //// GET: Comments/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments.FindAsync(id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", comment.PostId);
        //    return View(comment);
        //}

        //// POST: Comments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Text,CommentAuthor,PostId,Id,CreationDate")] Comment comment)
        //{
        //    if (id != comment.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(comment);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CommentExists(comment.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", comment.PostId);
        //    return View(comment);
        //}

        //// GET: Comments/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await _context.Comments
        //        .Include(c => c.Post)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(comment);
        //}

        //// POST: Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var comment = await _context.Comments.FindAsync(id);
        //    _context.Comments.Remove(comment);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CommentExists(int id)
        //{
        //    return _context.Comments.Any(e => e.Id == id);
        //}
    }
}
