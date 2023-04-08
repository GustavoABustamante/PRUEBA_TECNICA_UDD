using MediatR;
using PRUEBA_TECNICA_UDD.Models;
using PRUEBA_TECNICA_UDD.Queries;
using PRUEBA_TECNICA_UDD.Repositories;

namespace PRUEBA_TECNICA_UDD.Handlers
{
    public class GetPersonaByIdHandler : IRequestHandler<GetPersonaByIdQuery, Persona>
    {
        private readonly IPersonaRepository _personaRepository;

        public GetPersonaByIdHandler(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<Persona> Handle(GetPersonaByIdQuery query, CancellationToken cancellationToken)
        {
            return await _personaRepository.GetPersonaByIdAsync(query.Id);
        }
    }
}
