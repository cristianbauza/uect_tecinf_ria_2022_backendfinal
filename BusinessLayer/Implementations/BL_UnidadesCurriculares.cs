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
    public class BL_UnidadesCurriculares : IBL_UnidadesCurriculares
    {
        private IDAL_UnidadesCurriculares _dal;

        public BL_UnidadesCurriculares(IDAL_UnidadesCurriculares dal)
        {
            _dal = dal;
        }

        public UnidadCurricular Add(UnidadCurricular x)
        {
            return _dal.Add(x);
        }

        public void Delete(long id)
        {
            _dal.Delete(id);
        }

        public List<UnidadCurricular> Get()
        {
            return _dal.Get();
        }

        public UnidadCurricular Get(long id)
        {
            return _dal.Get(id);
        }

        public UnidadCurricular Update(UnidadCurricular x)
        {
            return _dal.Update(x);
        }
    }
}
