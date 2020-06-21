using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicApp.Infrastructure
{
    public interface IContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}