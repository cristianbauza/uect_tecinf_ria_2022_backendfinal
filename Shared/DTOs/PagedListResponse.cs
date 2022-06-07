using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class PagedListResponse<T>
    {
        public List<T> List { get; set; }
        public long Size { get; set; }

        public PagedListResponse(List<T> _List, long _Size)
        {
            List = _List;
            Size = _Size;
        }
    }
}
