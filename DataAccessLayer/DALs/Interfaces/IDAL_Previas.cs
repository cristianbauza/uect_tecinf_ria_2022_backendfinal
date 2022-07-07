using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs.Interfaces
{
    public interface IDAL_Previas
    {
        Previatura Add(Previatura x);
        void Delete(long id);
    }
}
