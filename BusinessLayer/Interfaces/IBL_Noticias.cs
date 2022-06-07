using Shared;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Noticias
    {
        List<Noticia> GetAll();
        PagedListResponse<Noticia> GetPaged(int offset, int limit);
        Noticia Get(long id);
        List<Noticia> GetActivas();
        Noticia Add(Noticia x);
        Noticia Update(Noticia x);
        void Delete(long id);
    }
}
