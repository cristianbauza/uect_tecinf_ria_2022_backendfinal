using Shared;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Documentos
    {
        PagedListResponse<Documento> GetPaged(int offset, int limit);
        List<Documento> GetActivos(string Tipo);
        Documento Get(long id);
        Documento Add(Documento x);
        Documento Update(Documento x);
    }
}
