using DataAccessLayer.DALs.Interfaces;
using DataAccessLayer.Models;
using Shared;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DALs.Implementations
{
    public class DAL_Previas_EF : IDAL_Previas
    {
        private readonly DataContext _db;

        public DAL_Previas_EF(DataContext db)
        {
            _db = db;
        }

        public Previatura Add(Previatura x)
        {
            Previaturas aux = Previaturas.GetInstanciaParaGuardar(x);
            _db.Previaturas.Add(aux);
            _db.SaveChanges();
            Previatura result = Get(aux.Id_Previatura);

            result.UnidadCurricular = _db.UnidadesCurriculares.Include(uc => uc.Materias)
                                             .Where(x => x.Id_UnidadCurricular == result.UnidadCurricular.Id)
                                             .FirstOrDefault()?.GetEntity(false);
            result.Previa = _db.UnidadesCurriculares.Include(uc => uc.Materias)
                                               .Where(x => x.Id_UnidadCurricular == result.Previa.Id)
                                               .FirstOrDefault()?.GetEntity(false);

            return result;
        }

        public void Delete(long id)
        {
            Previaturas x = _db.Previaturas.Find(id);
            _db.Previaturas.Remove(x);
            _db.SaveChanges();
        }

        public Previatura Get(long id)
        {
            return _db.Previaturas
                      .Find(id)?
                      .GetEntity();
        }
    }
}
