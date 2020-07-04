using System.Threading.Tasks;
using Domain.Model;

namespace Infrastructure.Database.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Post> PostRepository { get; set; }
        IRepository<Comment> CommentRepository { get; set; }


        Task Save();
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}