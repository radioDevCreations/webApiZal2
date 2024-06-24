using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BoatsRepository(AppDbContext context, IMapper mapper) : IBoatsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Boat>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Boats
                .ToListAsync(cancellationToken);
        }

        public async Task<Boat> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Boats
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task AddBoat(Boat Boat, CancellationToken cancellationToken)
        {
            await _context.Boats.AddAsync(Boat, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateBoat(Boat Boat, CancellationToken cancellationToken)
        {
            _context.Boats.Update(Boat);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveBoat(Boat Boat, CancellationToken cancellationToken)
        {
            _context.Boats.Remove(Boat);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
