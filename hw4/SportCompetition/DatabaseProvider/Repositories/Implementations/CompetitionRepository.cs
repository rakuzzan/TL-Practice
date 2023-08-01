using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Implementations
{
    public class CompetitionRepository : Repository<Competition>, ICompetition
    {
        public CompetitionRepository(ApplicationContext context)
            : base(context)
        {
        }

        public Competition GetById(int id)
        {
            return Entities.Where(a => a.CompetitionId == id).FirstOrDefault();
        }

        public List<Competition> GetAll()
        {
            return Entities.ToList();
        }

        public List<Competition> GetByVenue(string venue)
        {
            return Entities.Where(a => a.Venue == venue).ToList();
        }

        public List<Competition> GetByTitle(string title)
        {
            return Entities.Where(a => a.Title == title).ToList();
        }
    }
}