using MediatR;
using PRUEBA_TECNICA_UDD.Models;

namespace PRUEBA_TECNICA_UDD.Commands
{
    public class CreatePersonaCommand : IRequest<Persona>
    {
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool EsFeriadoLegal { get; set; }

        public CreatePersonaCommand(string nombre, DateTime fechaIngreso, bool esFeriadoLegal)
        {
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
            EsFeriadoLegal = esFeriadoLegal;
        }
    }
}
