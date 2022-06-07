namespace Shared
{
    public class Noticia
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCaducidad { get; set; }
    }
}