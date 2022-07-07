using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class UnidadCurricular
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Creditos { get; set; }
        public string Documento { get; set; }
        public int Semestre { get; set; }
        public Materia Materia { get; set; }
        public List<Previatura> Previas { get; set; }

        public UnidadCurricular() {
            Previas = new List<Previatura>();
        }
    }
}
