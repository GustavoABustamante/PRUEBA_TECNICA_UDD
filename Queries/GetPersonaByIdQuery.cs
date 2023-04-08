using MediatR;
using PRUEBA_TECNICA_UDD.Models;

namespace PRUEBA_TECNICA_UDD.Queries
{
    public class GetPersonaByIdQuery : IRequest<Persona>
    {
        public int Id { get; set; }
    }
}
