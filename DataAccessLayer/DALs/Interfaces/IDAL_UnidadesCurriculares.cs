using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs.Interfaces
{
    public interface IDAL_UnidadesCurriculares
    {
        List<UnidadCurricular> Get();
        UnidadCurricular Get(long id);
        UnidadCurricular Add(UnidadCurricular x);
        UnidadCurricular Update(UnidadCurricular x);
        void Delete(long id);
    }
}
