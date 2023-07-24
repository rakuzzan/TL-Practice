using Core.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface ICoach : IRepository<Coach>
    {
        public List<Coach> GetAll();
        public Coach GetById(int id);
        public List<Coach> GetByFirstName(string firstName);
        public List<Coach> GetByLastName(string lastName);
    }
}