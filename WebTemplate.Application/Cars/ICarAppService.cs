using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Application.Applications;
using WebTemplate.Domain;

namespace WebTemplate.Application.Cars
{
    public interface ICarAppService: IApplicationService
    {
        public Task<Voiture> CreateCar(string name);
        public Task<IEnumerable<Voiture>> GetAllCar();

        public Task<Voiture> UpdateCar(Guid id, string name);
        public Task DeleteCar(Guid id);
        public Task HardDeleteAsync(Guid id);
    }
}
