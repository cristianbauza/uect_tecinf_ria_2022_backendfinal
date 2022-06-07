using DataAccessLayer.DALs.Interfaces;
using DataAccessLayer.Models;
using Shared;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs.Implementations
{
    public class DAL_Noticias_EF : IDAL_Noticias
    {
        private readonly DataContext _db;

        public DAL_Noticias_EF(DataContext db)
        {
            _db = db;
        }

        public List<Noticia> GetAll()
        {
            List<Noticia> result = new List<Noticia>();
            _db.Noticias
               .ToList()
               .ForEach(x => result.Add(x.GetEntity()));
            return result;
        }

        public PagedListResponse<Noticia> GetPaged(int offset, int limit)
        {
            List<Noticia> result = new List<Noticia>();
            _db.Noticias
               .Skip(offset)
               .Take(limit)
               .ToList()
               .ForEach(x => result.Add(x.GetEntity()));

            long size = _db.Noticias.Count();

            return new PagedListResponse<Noticia>(result, size);
        }

        public Noticia Get(long id)
        {
            return _db.Noticias
                      .Where(x => x.Id_Noticia == id)
                      .FirstOrDefault()
                      ?.GetEntity();
        }

        public List<Noticia> GetActivas()
        {
            DateTime fechaHora = DateTime.Now;
            List<Noticia> result = new List<Noticia>();
            _db.Noticias
               .Where(x => x.FechaCaducidad > fechaHora)
               .ToList()
               .ForEach(x => result.Add(x.GetEntity()));
            return result;
        }

        public Noticia Add(Noticia x)
        {
            Noticias aux = Noticias.GetInstanciaParaGuardar(x);
            _db.Noticias.Add(aux);
            _db.SaveChanges();
            return Get(aux.Id_Noticia);
        }

        public Noticia Update(Noticia x)
        {
            Noticias aux = Noticias.GetInstanciaParaGuardar(x);
            _db.Update(aux);
            _db.SaveChanges();
            return Get(x.Id);
        }

        public void Delete(long id)
        {
            Noticias c = _db.Noticias.Find(id);
            _db.Noticias.Remove(c);
            _db.SaveChanges();
        }
    }
}
