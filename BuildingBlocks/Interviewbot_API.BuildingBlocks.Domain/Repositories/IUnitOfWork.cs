namespace Interviewbot_API.BuildingBlocks.Domain.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}