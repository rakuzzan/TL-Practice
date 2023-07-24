using Core.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface ISportsman : IRepository<Sportsman>
    {
        public List<Sportsman> GetAll();
        public Sportsman GetById(int id);
        public List<Sportsman> GetByFirstName(string firstName);
        public List<Sportsman> GetByLastName(string lastName);
        public List<Sportsman> GetByCoachId(int coachId);
    }
}