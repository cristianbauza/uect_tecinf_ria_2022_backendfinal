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
    public class UnidadesCurriculares
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_UnidadCurricular { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Nombre { get; set; }

        [MaxLength(4096), MinLength(3), Required]
        public string Descripcion { get; set; }

        [Required]
        public int Creditos { get; set; }

        [Column(TypeName = "longtext")]
        public string Documento { get; set; }

        [Required]
        public int Semestre { get; set; }

        [Required]
        [ForeignKey("Materias")]
        public long MateriasId_Materia { get; set; }
        public Materias Materias { get; set; }


        [InverseProperty("UnidadCurricular")]
        public ICollection<Previaturas> Unidades { get; set; }

        [InverseProperty("Previa")]
        public ICollection<Previaturas> Previaturas { get; set; }

        public UnidadCurricular GetEntity(bool addPrevias)
        {
            UnidadCurricular result = new UnidadCurricular()
            {
                Id = Id_UnidadCurricular,
                Creditos = Creditos,
                Descripcion = Descripcion,
                Documento = Documento,
                Materia = Materias.GetEntity(),
                Nombre = Nombre,
                Semestre = Semestre
            };

            if (addPrevias)
                Unidades.ToList().ForEach(x => { result.Previas.Add(x.GetEntity()); });

            return result;
        }

        public static UnidadesCurriculares GetInstanciaParaGuardar(UnidadCurricular x)
        {
            return new UnidadesCurriculares()
            {
                Id_UnidadCurricular = x.Id,
                Creditos = x.Creditos,
                Descripcion = x.Descripcion,
                Documento = x.Documento, 
                Nombre = x.Nombre,
                MateriasId_Materia = x.Materia.Id,
                Semestre = x.Semestre,                
            };
        }
    }
}
