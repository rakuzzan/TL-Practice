using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Implementations
{
    public class SportTypeRepository : Repository<SportType>, ISportType
    {
        public SportTypeRepository(ApplicationContext context)
            : base(context)
        {
        }

        public SportType GetById(int id)
        {
            return Entities.Where(a => a.SportTypeId == id).FirstOrDefault();
        }

        public List<SportType> GetAll()
        {
            return Entities.ToList();
        }

        public List<SportType> GetByUnitOfMeasurment(string unitOfMeasurment)
        {
            return Entities.Where(a => a.UnitOfMeasurment == unitOfMeasurment).ToList();
        }

        public List<SportType> GetByTitle(string title)
        {
            return Entities.Where(a => a.Title == title).ToList();
        }
    }
}