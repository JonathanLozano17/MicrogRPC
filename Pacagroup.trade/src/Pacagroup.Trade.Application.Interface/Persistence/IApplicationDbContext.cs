using Microsoft.EntityFrameworkCore;
using Pacagroup.Trade.Domain.Entities;

namespace Pacagroup.Trade.Application.Interface.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
