using BusinessLayer.Interfaces;
using DataAccessLayer.DALs.Interfaces;
using Shared;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class BL_Documentos : IBL_Documentos
    {
        private IDAL_Documentos _dal;

        public BL_Documentos(IDAL_Documentos dal)
        {
            _dal = dal;
        }

        public PagedListResponse<Documento> GetPaged(int offset, int limit)
        {
            return _dal.GetPaged(offset, limit);
        }

        public List<Documento> GetActivos(string Tipo)
        {
            return _dal.GetActivos(Tipo);
        }

        public Documento Get(long id)
        {
            return _dal.Get(id);
        }
        public Documento Add(Documento x)
        {
            return _dal.Add(x);
        }

        public Documento Update(Documento x)
        {
            return _dal.Update(x);
        }
    }
}
