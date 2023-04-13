using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Application.Applications;
using WebTemplate.Core.Repositories;
using WebTemplate.Domain;

namespace WebTemplate.Application.Cars
{
    public class CarAppService: ApplicationService, ICarAppService
    {
        private readonly ICarRepository _voitureRepository;

        public CarAppService(ICarRepository voitureRepository)
        {
            _voitureRepository = voitureRepository;
        }

        public async Task<Voiture> CreateCar(string name)
        {
            var car = new Voiture { Name = name };
            var carSave = _voitureRepository.InsertAsync(car);

            return car;
        }

        public async Task<IEnumerable<Voiture>> GetAllCar()
        {
            return await _voitureRepository.GetAllAsync(true);
        }

        public async Task<Voiture> UpdateCar(Guid id, string name)
        {
            var car = await _voitureRepository.GetAsync(id);
            car.Name = name;
            var carUpdate = await _voitureRepository.UpdateAsync(car);
            return carUpdate;
        }
    }
}
