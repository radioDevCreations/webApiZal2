using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface IHarboursRepository
    {
        Task<IEnumerable<Harbour>> GetAll(CancellationToken cancellationToken);
        Task AddHarbour(Harbour harbour, CancellationToken cancellationToken);
        Task<Harbour> GetById(Guid id, CancellationToken cancellationToken);
        Task UpdateHarbour(Harbour harbour, CancellationToken cancellationToken);
        Task RemoveHarbour(Harbour harbour, CancellationToken cancellationToken);
    }
}
