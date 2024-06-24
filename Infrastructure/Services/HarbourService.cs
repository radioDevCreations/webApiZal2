using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Models.Harbour;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class HarbourService : IHarbourService
    {
        private readonly IHarboursRepository _HarbourRepository;
        private readonly IMapper _mapper;

        public HarbourService(IHarboursRepository HarbourRepository, IMapper mapper)
        {
            _HarbourRepository = HarbourRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Harbour>> GetAll(CancellationToken cancellationToken)
        {
            return await _HarbourRepository.GetAll(cancellationToken);
        }

        public async Task<Harbour> GetHarbourById(Guid id, CancellationToken cancellationToken)
        {
            return await _HarbourRepository.GetById(id, cancellationToken);
        }

        public async Task<Guid> AddHarbour(CreateHarbour harbour, CancellationToken cancellationToken)
        {
            var newHarbour = _mapper.Map<CreateHarbour, Harbour>(harbour);
            newHarbour.Id = Guid.NewGuid();

            await _HarbourRepository.AddHarbour(newHarbour, cancellationToken);

            return newHarbour.Id;
        }
        
        public async Task<Guid> UpdateHarbour(UpdateHarbour Harbour, CancellationToken cancellationToken)
        {
            var HarbourToUpdate = await _HarbourRepository.GetById(Harbour.Id, cancellationToken);

            HarbourToUpdate.Name = Harbour.Name;
            HarbourToUpdate.Type = Harbour.Type;
            HarbourToUpdate.Street = Harbour.Street;
            HarbourToUpdate.StreetNumber = Harbour.StreetNumber;
            HarbourToUpdate.City = Harbour.City;
            HarbourToUpdate.Country = Harbour.Country;
            HarbourToUpdate.ZipCode = Harbour.ZipCode;

            await _HarbourRepository.UpdateHarbour(HarbourToUpdate, cancellationToken);

            return HarbourToUpdate.Id;
        }

        public async Task<Guid> RemoveHarbour(Guid id, CancellationToken cancellationToken)
        {
            var HarbourToRemove = await _HarbourRepository.GetById(id, cancellationToken);

            await _HarbourRepository.RemoveHarbour(HarbourToRemove, cancellationToken);

            return id;
        }

    }
}
