using PRUEBA_TECNICA_UDD.DTOs;
using PRUEBA_TECNICA_UDD.Models;
using AutoMapper;

namespace PRUEBA_TECNICA_UDD
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region PersonaClass
            CreateMap<CreatePersonaDTO, Persona>();
            #endregion
        }
    }
}
