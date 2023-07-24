using Core.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface ISportType : IRepository<SportType>
    {
        public List<SportType> GetAll();
        public SportType GetById(int id);
        public List<SportType> GetByTitle(string title);
        public List<SportType> GetByUnitOfMeasurment(string title);
    }
}