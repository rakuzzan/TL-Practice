using Core.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface ICompetition : IRepository<Competition>
    {
        public List<Competition> GetAll();
        public Competition GetById(int id);
        public List<Competition> GetByTitle(string title);
        public List<Competition> GetByVenue(string venue);
    }
}