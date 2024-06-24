using Application.Models.Harbour;
using Domain.Entities;

namespace Application.Abstractions.Services
{
    public interface IHarbourService
    {
        Task<IEnumerable<Harbour>> GetAll(CancellationToken cancellationToken);
        Task<Guid> AddHarbour(CreateHarbour harbour, CancellationToken cancellationToken);
        Task<Guid> UpdateHarbour(UpdateHarbour harbour, CancellationToken cancellationToken);
        Task<Harbour> GetHarbourById(Guid id, CancellationToken cancellationToken);
        Task<Guid> RemoveHarbour(Guid id, CancellationToken cancellationToken);
    }
}
