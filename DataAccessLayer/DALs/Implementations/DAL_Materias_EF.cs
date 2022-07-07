using DataAccessLayer.DALs.Interfaces;
using DataAccessLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs.Implementations
{
    public class DAL_Materias_EF : IDAL_Materias
    {
        private readonly DataContext _db;

        public DAL_Materias_EF(DataContext db)
        {
            _db = db;
        }

        public Materia Add(Materia x)
        {
            Materias aux = Materias.GetInstanciaParaGuardar(x);
            _db.Materias.Add(aux);
            _db.SaveChanges();
            return Get(aux.Id_Materia);
        }

        public void Delete(long id)
        {
            Materias x = _db.Materias.Find(id);
            _db.Materias.Remove(x);
            _db.SaveChanges();
        }

        public List<Materia> Get()
        {
            return _db.Materias
                      .Select(x => x.GetEntity())
                      .ToList();
        }

        public Materia Get(long id)
        {
            return _db.Materias
                      .Find(id)?
                      .GetEntity();
        }

        public Materia Update(Materia x)
        {
            Materias aux = Materias.GetInstanciaParaGuardar(x);
            _db.Update(aux);
            _db.SaveChanges();
            return Get(x.Id);
        }
    }
}
