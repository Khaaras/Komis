using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class SamochodRepository : ISamochodRepository
    {
        private readonly AppDBContext _appDBContext;

        public SamochodRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public Samochod PobierzSamochodOId(int samochodId)
        {
            return _appDBContext.Samochody.FirstOrDefault(s => s.Id == samochodId);
        }

        public IEnumerable<Samochod> PobierzWszystkieSamochody()
        {
            return _appDBContext.Samochody;
        }
    }
}
