using DataAccessLayer.DALs.Interfaces;
using DataAccessLayer.Models;
using Shared;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DALs.Implementations
{
    public class DAL_UnidadesCurriculares_EF : IDAL_UnidadesCurriculares
    {
        private readonly DataContext _db;

        public DAL_UnidadesCurriculares_EF(DataContext db)
        {
            _db = db;
        }

        public UnidadCurricular Add(UnidadCurricular x)
        {
            UnidadesCurriculares aux = UnidadesCurriculares.GetInstanciaParaGuardar(x);

            _db.UnidadesCurriculares.Add(aux);
            _db.SaveChanges();
            return Get(aux.Id_UnidadCurricular);
        }

        public void Delete(long id)
        {
            UnidadesCurriculares x = _db.UnidadesCurriculares.Find(id);
            _db.UnidadesCurriculares.Remove(x);
            _db.SaveChanges();
        }

        public List<UnidadCurricular> Get()
        {
            List<UnidadCurricular> result = 
                   _db.UnidadesCurriculares
                      .Include(x => x.Materias)
                      .Include(x => x.Previaturas)
                      .Include(x => x.Unidades)
                      .Select(x => x.GetEntity(true))
                      .ToList();

            result.ForEach(x =>
            {
                x.Previas.ForEach(p => 
                {
                    p.UnidadCurricular = _db.UnidadesCurriculares.Include(uc => uc.Materias)
                                                                 .Where(x => x.Id_UnidadCurricular == p.UnidadCurricular.Id)
                                                                 .FirstOrDefault()?.GetEntity(false);
                    p.Previa = _db.UnidadesCurriculares.Include(uc => uc.Materias)
                                                       .Where(x => x.Id_UnidadCurricular == p.Previa.Id)
                                                       .FirstOrDefault()?.GetEntity(false);
                });
            });

            return result;
        }

        public UnidadCurricular Get(long id)
        {
            UnidadCurricular result = _db.UnidadesCurriculares
                      .Include(x => x.Materias)
                      .Include(x => x.Previaturas)
                      .Include(x => x.Unidades)
                      .Where(x => x.Id_UnidadCurricular == id)
                      .FirstOrDefault()?
                      .GetEntity(true);

            result.Previas.ForEach(p =>
            {
                p.UnidadCurricular = _db.UnidadesCurriculares.Include(uc => uc.Materias)
                                                             .Where(x => x.Id_UnidadCurricular == p.UnidadCurricular.Id)
                                                             .FirstOrDefault()?.GetEntity(false);
                p.Previa = _db.UnidadesCurriculares.Include(uc => uc.Materias)
                                                   .Where(x => x.Id_UnidadCurricular == p.Previa.Id)
                                                   .FirstOrDefault()?.GetEntity(false);
            });

            return result;
        }

        public UnidadCurricular Update(UnidadCurricular x)
        {
            UnidadesCurriculares aux = UnidadesCurriculares.GetInstanciaParaGuardar(x);
            _db.Update(aux);
            _db.SaveChanges();
            return Get(x.Id);
        }
    }
}
