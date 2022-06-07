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
    [Index(nameof(FechaCaducidad), Name = "Idx_Noticias_FechaCaducidad")]
    public class Noticias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id_Noticia { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Titulo { get; set; }

        [MaxLength(4096), MinLength(3), Required]
        public string Descripcion { get; set; }

        [Column(TypeName = "longtext")]
        public string Imagen { get; set; }

        [Required]
        public DateTime FechaCaducidad { get; set; }

        public Noticia GetEntity()
        {
            return new Noticia()
            {
                Descripcion = Descripcion,
                Id = Id_Noticia,
                Titulo = Titulo,
                FechaCaducidad = FechaCaducidad,
                Imagen = Imagen
            };
        }

        public static Noticias GetInstanciaParaGuardar(Noticia x)
        {
            return new Noticias()
            {
                Descripcion = x.Descripcion,
                Id_Noticia = x.Id,
                Titulo = x.Titulo,
                FechaCaducidad = x.FechaCaducidad,
                Imagen = x.Imagen
            };
        }
    }
}
