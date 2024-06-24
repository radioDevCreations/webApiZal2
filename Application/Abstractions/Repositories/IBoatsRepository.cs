using Domain.Entities;

namespace Application.Abstractions.Repositories
{
    public interface IBoatsRepository
    {
        Task<IEnumerable<Boat>> GetAll(CancellationToken cancellationToken);
        Task AddBoat(Boat boat, CancellationToken cancellationToken);
        Task<Boat> GetById(Guid id, CancellationToken cancellationToken);
        Task UpdateBoat(Boat boat, CancellationToken cancellationToken);
        Task RemoveBoat(Boat boat, CancellationToken cancellationToken);
    }
}
