using Interviewbot_API.BuildingBlocks.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Interviewbot_API.BuildingBlocks.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}