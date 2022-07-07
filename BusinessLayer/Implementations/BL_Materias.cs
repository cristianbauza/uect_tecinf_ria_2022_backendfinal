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
    public class BL_Materias : IBL_Materias
    {
        private IDAL_Materias _dal;

        public BL_Materias(IDAL_Materias dal)
        {
            _dal = dal;
        }

        public Materia Add(Materia x)
        {
            return _dal.Add(x);
        }

        public void Delete(long id)
        {
            _dal.Delete(id);
        }

        public List<Materia> Get()
        {
            return _dal.Get();
        }

        public Materia Get(long id)
        {
            return _dal.Get(id);
        }

        public Materia Update(Materia x)
        {
            return _dal.Update(x);
        }
    }
}
