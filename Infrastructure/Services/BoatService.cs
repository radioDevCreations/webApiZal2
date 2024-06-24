using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Models.Boat;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class BoatService : IBoatService
    {
        private readonly IBoatsRepository _BoatRepository;
        private readonly IMapper _mapper;

        public BoatService(IBoatsRepository BoatRepository, IMapper mapper)
        {
            _BoatRepository = BoatRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Boat>> GetAll(CancellationToken cancellationToken)
        {
            return await _BoatRepository.GetAll(cancellationToken);
        }

        public async Task<Boat> GetBoatById(Guid id, CancellationToken cancellationToken)
        {
            return await _BoatRepository.GetById(id, cancellationToken);
        }

        public async Task<Guid> AddBoat(CreateBoat Boat, CancellationToken cancellationToken)
        {
            var newBoat = _mapper.Map<CreateBoat, Boat>(Boat);
            newBoat.Id = Guid.NewGuid();

            await _BoatRepository.AddBoat(newBoat, cancellationToken);

            return newBoat.Id;
        }

        public async Task<Guid> UpdateBoat(UpdateBoat Boat, CancellationToken cancellationToken)
        {
            var BoatToUpdate = await _BoatRepository.GetById(Boat.Id, cancellationToken);

            BoatToUpdate.Brand = Boat.Brand;
            BoatToUpdate.Type = Boat.Type;
            BoatToUpdate.Model = Boat.Model;
            BoatToUpdate.Year = Boat.Year;

            await _BoatRepository.UpdateBoat(BoatToUpdate, cancellationToken);

            return BoatToUpdate.Id;
        }

        public async Task<Guid> RemoveBoat(Guid id, CancellationToken cancellationToken)
        {
            var BoatToRemove = await _BoatRepository.GetById(id, cancellationToken);

            await _BoatRepository.RemoveBoat(BoatToRemove, cancellationToken);

            return id;
        }

    }
}