using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Implementations
{
    public class CoachRepository : Repository<Coach>, ICoach
    {
        public CoachRepository(ApplicationContext context) :
            base(context)
        {
        }

        public List<Coach> GetAll()
        {
            return Entities.ToList();
        }

        public Coach GetById(int id)
        {
            return Entities.Where(a => a.CoachId == id).FirstOrDefault();
        }

        public List<Coach> GetByFirstName(string firstName)
        {
            return Entities.Where(a => a.FirstName == firstName).ToList();
        }

        public List<Coach> GetByLastName(string lastName)
        {
            return Entities.Where(a => a.LastName == lastName).ToList();
        }
    }
}