using Core.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IPerformance : IRepository<Performance>
    {
        public List<Performance> GetAll();
        public Performance GetById(int id);
        public List<Performance> GetByValue(double value);
        public List<Performance> GetBySportsmanId(int sportsmanId);
        public List<Performance> GetBySportTypeId(int sportTypeId);
        public List<Performance> GetByCompetitionId(int competitionId);
    }
}