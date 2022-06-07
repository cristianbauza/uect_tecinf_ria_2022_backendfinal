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
    public class DAL_Documentos_EF : IDAL_Documentos
    {
        private readonly DataContext _db;

        public DAL_Documentos_EF(DataContext db)
        {
            _db = db;
        }

        public PagedListResponse<Documento> GetPaged(int offset, int limit)
        {
            List<Documento> result = new List<Documento>();
            _db.Documentos
               .Skip(offset)
               .Take(limit)
               .ToList()
               .ForEach(x => result.Add(x.GetEntity()));

            long size = _db.Noticias.Count();

            return new PagedListResponse<Documento>(result, size);
        }
        public List<Documento> GetActivos(string Tipo)
        {
            List<Documento> result = new List<Documento>();
            _db.Documentos
               .Where(x => x.Activo && x.Tipo == Tipo)
               .ToList()
               .ForEach(x => result.Add(x.GetEntity()));
            return result;
        }

        public Documento Get(long id)
        {
            return _db.Documentos
                      .Where(x => x.Id_Documento == id)
                      .FirstOrDefault()
                      ?.GetEntity();
        }

        public Documento Add(Documento x)
        {
            Documentos aux = Documentos.GetInstanciaParaGuardar(x);
            _db.Documentos.Add(aux);
            _db.SaveChanges();
            return Get(aux.Id_Documento);
        }
        public Documento Update(Documento x)
        {
            Documentos aux = Documentos.GetInstanciaParaGuardar(x);
            _db.Update(aux);
            _db.SaveChanges();
            return Get(x.Id);
        }
    }
}
