using Shared;
using Shared.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface IBL_Previas
    {
        Previatura Add(PreviaCreateDTO x);
        void Delete(long id);
    }
}
