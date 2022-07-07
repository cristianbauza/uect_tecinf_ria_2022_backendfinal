using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Previatura
    {
        public long Id { get; set; }
        public UnidadCurricular UnidadCurricular { get; set; }
        public UnidadCurricular Previa { get; set; }
        public string TipoPrevia { get; set; }
    }
}
