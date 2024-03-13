using Personas.DDD.Domain.Entities;
using Personas.DDD.Domain.Repositories;
using Personas.DDD.Domain.ValueObjects;
using PersonasDDD.Commands;
using PersonasDDD.Queries;



namespace PersonasDDD.ApplicationsServices
{
    public class PersonaServices
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonaQueries personaQueries;

        public PersonaServices(IPersonRepository _personRepository,
            PersonaQueries personaQueries
            
            )  //no es necesario hacer referencia esta implicito por que ifraestrucutra hace referencia directa a dominio
        {
            this._personRepository = _personRepository;
            this.personaQueries = personaQueries;
        }

        public async Task HandleCommand(CreatePersonaCommand createPersona)
        {
            var person = new Persona(
                PersonId.Create(createPersona.personId));// PaSWA POR UN VALUE OBJ Y SI TIENE VALIDACIONES PASA POR ESAS Y SE CREA COMO S ENECESITA 

            person.SetName(PersonName.Create(createPersona.Nombre));

            await _personRepository.AddPerson(person);
        }

        //estuctura para crear entitys u objetos
        public async Task<Persona> GetPerson(Guid id) { 
            return await personaQueries.GetPersonaIdAsync(id);   
        }
    }
}
