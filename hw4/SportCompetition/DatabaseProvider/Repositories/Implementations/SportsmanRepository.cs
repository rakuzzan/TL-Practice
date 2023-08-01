using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Implementations
{
    public class SportsmanRepository : Repository<Sportsman>, ISportsman
    {
        public SportsmanRepository(ApplicationContext context)
            : base(context)
        {
        }

        public Sportsman GetById(int id)
        {
            return Entities.Where(a => a.SportsmanId == id).FirstOrDefault();
        }

        public List<Sportsman> GetAll()
        {
            return Entities.ToList();
        }

        public List<Sportsman> GetByFirstName(string firstName)
        {
            return Entities.Where(a => a.FirstName == firstName).ToList();
        }

        public List<Sportsman> GetByLastName(string lastName)
        {
            return Entities.Where(a => a.LastName == lastName).ToList();
        }

    public List<Sportsman> GetByCoachId(int coachId)
        {
            return Entities.Where(a => a.CoachId == coachId).ToList();
        }
    }
}