using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Infrastructure.Database.EFImplementations
{
    public class CommentsRepository : IRepository<Comment>
    {
        private readonly ApplicationContext _context;

        public CommentsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Comment> GetAsync(int? id)
        {
            return _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Comment>> GetAllByPostIdAsync(int id)
        {
            return _context.Comments.Where(c => c.PostId == id).ToListAsync();
        }

        public Task<List<Comment>> GetAllAsync()
        {
            return _context.Comments.ToListAsync();
        }

        public ValueTask<EntityEntry<Comment>> CreateAsync(Comment entity)
        {
            var createdComment = _context.Comments.AddAsync(entity);
            return createdComment;
        }

        public ValueTask<Comment> EditAsync(Comment entity)
        {
            var comment = _context.Comments.FindAsync(entity.Id);
            if (comment != null)
            {
                comment.Result.Text = entity.Text;
            }
            return comment;
        }

        public void Remove(Comment entity)
        {
            _context.Comments.Remove(entity);
        }

        public bool Exist(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}