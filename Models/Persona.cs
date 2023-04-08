namespace PRUEBA_TECNICA_UDD.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool EsFeriadoLegal { get; set; } = false;
    }
}
