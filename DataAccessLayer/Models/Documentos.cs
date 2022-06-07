using Microsoft.EntityFrameworkCore;
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
    [Index(nameof(Tipo), nameof(Activo), Name = "Idx_Documentos_TipoActivo")]
    public class Documentos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Documento { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Titulo { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Tipo { get; set; }

        [Column(TypeName = "longtext")]
        public string DocumentoPDF { get; set; }

        [Required]
        public bool Activo { get; set; }

        public Documento GetEntity()
        {
            return new Documento()
            {
                Activo = Activo,
                Tipo = Tipo,
                DocumentoPDF = DocumentoPDF,
                Id = Id_Documento,
                Titulo = Titulo                
            };
        }

        public static Documentos GetInstanciaParaGuardar(Documento x)
        {
            return new Documentos()
            {
                Activo = x.Activo,
                Titulo = x.Titulo,
                DocumentoPDF = x.DocumentoPDF,
                Id_Documento = x.Id,
                Tipo = x.Tipo
            };
        }
    }
}
