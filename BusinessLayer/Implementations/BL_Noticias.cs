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
    public class BL_Noticias : IBL_Noticias
    {
        private IDAL_Noticias _dal;

        public BL_Noticias(IDAL_Noticias dal)
        {
            _dal = dal;
        }

        public List<Noticia> GetAll()
        {
            return _dal.GetAll();
        }

        public PagedListResponse<Noticia> GetPaged(int offset, int limit)
        {
            return _dal.GetPaged(offset, limit);
        }

        public Noticia Get(long id)
        {
            return _dal.Get(id);
        }

        public List<Noticia> GetActivas()
        {
            return _dal.GetActivas();
        }

        public Noticia Add(Noticia x)
        {
            return _dal.Add(x);
        }

        public Noticia Update(Noticia x)
        {
            return _dal.Update(x);
        }

        public void Delete(long id)
        {
            _dal.Delete(id);
        }
    }
}
