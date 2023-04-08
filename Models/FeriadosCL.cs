namespace PRUEBA_TECNICA_UDD.Models
{
    public class FeriadosCL
    {
        public string? nombre { get; set; }
        public string? comentarios { get; set; }
        public DateTime fecha { get; set; }
        public string? irrenunciable { get; set; }
        public string? tipo { get; set; }
        public bool error { get; set; } = false;
        public string? message { get; set; }
    }
}
