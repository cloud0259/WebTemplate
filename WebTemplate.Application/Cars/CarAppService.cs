using WebTemplate.Application.Applications;
using WebTemplate.Core.Entities;
using WebTemplate.Domain;

namespace WebTemplate.Application.Cars
{
    public class CarAppService : ApplicationService, ICarAppService
    {
        private readonly ICarRepository _voitureRepository;

        public CarAppService(ICarRepository voitureRepository)
        {
            _voitureRepository = voitureRepository;
        }

        public async Task<Voiture> CreateCar(string name)
        {
            var car = new Voiture { Name = name };
            var carSave = await _voitureRepository.InsertAsync(car);

            return car;
        }

        public async Task<IEnumerable<Voiture>> GetAllCar()
        {
            using (var t = DataFilter.Disable<ISoftDelete>())
            {
                return await _voitureRepository.GetAllAsync(true);
            }
        }

        public async Task<Voiture> UpdateCar(Guid id, string name)
        {
            var car = await _voitureRepository.GetAsync(id);
            car.Name = name;
            var carUpdate = await _voitureRepository.UpdateAsync(car);
            return carUpdate;
        }

        public async Task DeleteCar(Guid id)
        {
            var car = await _voitureRepository.GetAsync(id);
            if (car != null)
            {
                await _voitureRepository.DeleteAsync(car);
            }
        }

        public async Task HardDeleteAsync(Guid id)
        {
            using (var filter = DataFilter.Disable<ISoftDelete>())
            {
                var car = await _voitureRepository.GetAsync(id);
                if (car != null)
                {
                    await _voitureRepository.HardDeleteAsync(car);
                }
            }
        }
    }
}
