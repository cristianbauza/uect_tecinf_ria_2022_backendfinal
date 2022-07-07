using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Materias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Materia { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Nombre { get; set; }

        [MaxLength(4096), MinLength(3), Required]
        public string Descripcion { get; set; }

        [Required]
        public int CreditosMinimos { get; set; }

        public Materia GetEntity()
        {
            return new Materia()
            {
                Id = Id_Materia,
                Nombre = Nombre,
                Descripcion = Descripcion,
                CreditosMinimos = CreditosMinimos
            };
        }

        public static Materias GetInstanciaParaGuardar(Materia x)
        {
            return new Materias()
            {
                Id_Materia = x.Id,
                CreditosMinimos = x.CreditosMinimos,
                Descripcion = x.Descripcion,
                Nombre = x.Nombre
            };
        }
    }
}
