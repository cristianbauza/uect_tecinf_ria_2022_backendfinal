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
    public class Previaturas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Previatura { get; set; }

        [Required]
        [ForeignKey("UnidadesCurriculares")]
        public long UnidadCurricularId_UnidadCurricular { get; set; }
        public UnidadesCurriculares UnidadCurricular { get; set; }

        [Required]
        [ForeignKey("UnidadesCurriculares")]
        public long PreviaId_UnidadCurricular { get; set; }
        public UnidadesCurriculares Previa { get; set; }


        [MaxLength(128), MinLength(3), Required]
        public string TipoPrevia { get; set; }

        public Previatura GetEntity()
        {
            return new Previatura()
            {
                Id = Id_Previatura,
                TipoPrevia = TipoPrevia,
                UnidadCurricular = new UnidadCurricular() { Id = UnidadCurricularId_UnidadCurricular},
                Previa = new UnidadCurricular() { Id = PreviaId_UnidadCurricular }
            };
        }

        public static Previaturas GetInstanciaParaGuardar(Previatura x)
        {
            return new Previaturas()
            {
                Id_Previatura = x.Id,
                TipoPrevia = x.TipoPrevia,
                PreviaId_UnidadCurricular = x.Previa.Id,
                UnidadCurricularId_UnidadCurricular = x.UnidadCurricular.Id
            };
        }
    }
}
