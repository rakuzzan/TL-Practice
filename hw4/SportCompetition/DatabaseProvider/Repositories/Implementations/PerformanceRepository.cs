using Core.Models;
using DatabaseProvider.Repositories.Abstractions;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Implementations
{
    public class PerformanceRepository : Repository<Performance>, IPerformance
    {
        public PerformanceRepository(ApplicationContext context)
            : base(context)
        {
        }

        public Performance GetById(int id)
        {
            return Entities.Where(a => a.PerformanceId == id).FirstOrDefault();
        }

        public List<Performance> GetAll()
        {
            return Entities.ToList();
        }

        public List<Performance> GetByValue(double value)
        {
            return Entities.Where(a => a.Value == value).ToList();
        }

        public List<Performance> GetBySportsmanId(int sportsmanId) 
        {
            return Entities.Where(a => a.SportsmanId == sportsmanId).ToList();
        }

        public List<Performance> GetByCompetitionId(int competitionId)
        {
            return Entities.Where(a => a.CompetitionId == competitionId).ToList();
        }

        public List<Performance> GetBySportTypeId(int sportTypeId)
        {
            return Entities.Where(a => a.SportTypeId == sportTypeId).ToList();
        }
    }
}