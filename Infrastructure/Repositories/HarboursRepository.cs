using Application.Abstractions.Repositories;
using Application.Models.Harbour;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HarboursRepository(AppDbContext context, IMapper mapper) : IHarboursRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Harbour>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Harbours
                .ToListAsync(cancellationToken);
        }

        public async Task<Harbour> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Harbours
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task AddHarbour(Harbour Harbour, CancellationToken cancellationToken) 
        {
            await _context.Harbours.AddAsync(Harbour, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateHarbour(Harbour Harbour, CancellationToken cancellationToken)
        {
            _context.Harbours.Update(Harbour);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveHarbour(Harbour Harbour, CancellationToken cancellationToken)
        {
            _context.Harbours.Remove(Harbour);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
