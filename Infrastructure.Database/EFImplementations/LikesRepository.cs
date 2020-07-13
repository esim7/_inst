using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Database.EFImplementations
{
    public class LikesRepository : IRepository<Like>
    {
        private readonly ApplicationContext _context;

        public LikesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Like> GetAsync(int? id)
        {
            return _context.Likes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Like>> GetAllAsync()
        {
            return _context.Likes.ToListAsync();
        }

        public ValueTask<EntityEntry<Like>> CreateAsync(Like entity)
        {
            var createdLike = _context.Likes.AddAsync(entity);
            return createdLike;
        }

        public ValueTask<Like> EditAsync(Like entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Like>> GetAllByPostIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Like entity)
        {
            var deletedLike = _context.Likes.FirstOrDefault(l => l.UserId == entity.UserId && l.PostId == entity.PostId);
            _context.Likes.Remove(deletedLike);
        }

        public bool Exist(int id)
        {
            return _context.Likes.Any(e => e.Id == id);
        }

        public bool isExist(int postId, string userId)
        {
            return _context.Likes.Any(e => e.PostId == postId && e.UserId == userId);
        }
    }
}