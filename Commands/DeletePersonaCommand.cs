using MediatR;

namespace PRUEBA_TECNICA_UDD.Commands
{
    public class DeletePersonaCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
