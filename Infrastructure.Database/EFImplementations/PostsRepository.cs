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
    public class PostsRepository : IRepository<Post>
    {
        private readonly ApplicationContext _context;

        public PostsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Post> GetAsync(int? id)
        {
            return _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Post>> GetAllAsync()
        {
            return _context.Posts.Include(c => c.Comments).Include(u => u.User).ToListAsync();
        }

        public ValueTask<EntityEntry<Post>> CreateAsync(Post entity)
        {
            var createdPost = _context.Posts.AddAsync(entity);
            return createdPost;
        }

        public ValueTask<Post> EditAsync(Post entity)
        {
            var post = _context.Posts.FindAsync(entity.Id);
            if (post != null)
            {
                post.Result.CommentCount = entity.CommentCount;
                post.Result.LikeCount = entity.LikeCount;
                post.Result.PhotoPath = entity.PhotoPath;
            }
            return post;
        }

        public Task<List<Post>> GetAllByPostIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Post entity)
        {
            _context.Posts.Remove(entity);
        }

        public bool Exist(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}