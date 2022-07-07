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
    public class BL_Previas : IBL_Previas
    {
        private IDAL_Previas _dal;
        private IDAL_UnidadesCurriculares _dalUC;

        public BL_Previas(IDAL_Previas dal, IDAL_UnidadesCurriculares dalUC)
        {
            _dal = dal;
            _dalUC = dalUC;
        }

        public Previatura Add(PreviaCreateDTO x)
        {
            UnidadCurricular uc = _dalUC.Get(x.UnidadCurricular);
            UnidadCurricular pr = _dalUC.Get(x.Previa);
            Previatura previa = new Previatura
            {
                Previa = pr,
                UnidadCurricular = uc,
                TipoPrevia = x.Tipo
            };

            return _dal.Add(previa);
        }

        public void Delete(long id)
        {
            _dal.Delete(id);
        }
    }
}
