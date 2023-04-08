using MediatR;
using PRUEBA_TECNICA_UDD.DTOs;
using PRUEBA_TECNICA_UDD.Models;

namespace PRUEBA_TECNICA_UDD.Commands
{
    public class CreatePersonaCommand : IRequest<Persona>
    {
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }

        public CreatePersonaCommand(string nombre, DateTime fechaIngreso)
        {
            Nombre = nombre;
            FechaIngreso = fechaIngreso;
        }
    }
}
