using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
    public class OpiniaRepository : IOpiniaRepository
    {
        private readonly AppDBContext _appDBContext;

        public OpiniaRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void DodajOpinie(Opinia opinia)
        {
            _appDBContext.Opinie.Add(opinia);
            _appDBContext.SaveChanges();
        }
    }
}
