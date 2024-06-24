using Application.Models.Boat;
using Domain.Entities;

namespace Application.Abstractions.Services
{
    public interface IBoatService
    {
        Task<IEnumerable<Boat>> GetAll(CancellationToken cancellationToken);
        Task<Guid> AddBoat(CreateBoat boat, CancellationToken cancellationToken);
        Task<Guid> UpdateBoat(UpdateBoat boat, CancellationToken cancellationToken);
        Task<Boat> GetBoatById(Guid id, CancellationToken cancellationToken);
        Task<Guid> RemoveBoat(Guid id, CancellationToken cancellationToken);
    }
}
