using System.Threading.Tasks;
using Domain.Model;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.Database.EFImplementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IRepository<Post> PostRepository { get; set; }
        public IRepository<Comment> CommentRepository { get; set; }

        public EFUnitOfWork(IRepository<Post> postRepository, IRepository<Comment> commentRepository, ApplicationContext context)
        {
            PostRepository = postRepository;
            CommentRepository = commentRepository;
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }

        public async Task Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }
    }
}