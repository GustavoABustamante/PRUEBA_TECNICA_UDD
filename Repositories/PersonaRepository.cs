using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PRUEBA_TECNICA_UDD.Data;
using PRUEBA_TECNICA_UDD.DTOs;
using PRUEBA_TECNICA_UDD.Models;
using System.Numerics;
using System.Text.Json;

namespace PRUEBA_TECNICA_UDD.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DbContextClass _dbContext;
        private readonly IMapper _mapper;

        public PersonaRepository(DbContextClass dbContext, IMapper autoMapper)
        {
            _dbContext = dbContext;
            _mapper = autoMapper;
        }
        public async Task<Persona> AddPersonaAsync(CreatePersonaDTO newPersona)
        {
            var persona = _mapper.Map<Persona>(newPersona);

            // Aquí realice la call al endpoint del gobierno para obtener respuesta feriado o no feriado enviando una fecha en formato 0001/01/01
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://apis.digital.gob.cl/fl/feriados/");

                var response = await client.GetAsync(persona.FechaIngreso.ToString("yyyy/MM/dd"));
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var responseToken = JToken.Parse(responseContent);

                    if (responseToken != null)
                    {
                        if (responseToken is JArray)
                        {
                            IEnumerable<FeriadosCL> feriados = responseToken.ToObject<List<FeriadosCL>>();
                            persona.EsFeriadoLegal = feriados.FirstOrDefault().error ? false : true;
                        }
                        else if (responseToken is JObject)
                        {
                            FeriadosCL feriado = responseToken.ToObject<FeriadosCL>();
                            persona.EsFeriadoLegal = feriado.error ? false : true;
                        }
                    }
                }
            }

            var result = _dbContext.Personas.Add(persona);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeletePersonaAsync(int Id)
        {
            var filteredData = _dbContext.Personas.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Personas.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Persona> GetPersonaByIdAsync(int Id)
        {
            return await _dbContext.Personas.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
