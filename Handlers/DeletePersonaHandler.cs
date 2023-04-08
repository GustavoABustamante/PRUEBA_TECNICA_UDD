using MediatR;
using PRUEBA_TECNICA_UDD.Commands;
using PRUEBA_TECNICA_UDD.Repositories;

namespace PRUEBA_TECNICA_UDD.Handlers
{
    public class DeletePersonaHandler : IRequestHandler<DeletePersonaCommand, int>
    {
        private readonly IPersonaRepository _personaRepository;

        public DeletePersonaHandler(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<int> Handle(DeletePersonaCommand command, CancellationToken cancellationToken)
        {
            var persona = await _personaRepository.GetPersonaByIdAsync(command.Id);
            if (persona == null)
                return default;
            return await _personaRepository.DeletePersonaAsync(persona.Id);
        }
    }
}
