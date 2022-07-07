using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs.Interfaces
{
    public interface IDAL_Materias
    {
        List<Materia> Get();
        Materia Get(long id);
        Materia Add(Materia x);
        Materia Update(Materia x);
        void Delete(long id);
    }
}
