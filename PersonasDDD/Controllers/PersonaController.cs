using Microsoft.AspNetCore.Mvc;
using PersonasDDD.ApplicationsServices;
using PersonasDDD.Commands;

namespace PersonasDDD.Controllers
{
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaServices personaServices;

        public PersonaController(PersonaServices personaServices)
        {
            this.personaServices = personaServices;
        }

        [HttpPost]
        public async Task<ActionResult> AddPerson(CreatePersonaCommand createPersonaCommand) 
        {
            await personaServices.HandleCommand(createPersonaCommand);
            return Ok(createPersonaCommand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(Guid id) { 
        var response = await personaServices.GetPerson(id);
            return Ok(response);
        }

        //creamos un API que implementa una DDD
        //el Dominio no tiene dependencias o referencias
        //Tiene sus interfaces de repositorio
        //tiene sus entidades de dominio
        //tiene sus valores objects de dominio
        //codificamos infraestructura al dominio con sus paquetes
        //infraestructura se instalan los paquetes necesarios
        //la api expone 
        //servicio tiene comandos y querys
        //tiene queryes para obtener la informacion
        //se pueden instalar dependencias sobre la api si se necesita
        //se deben registrar los servicios en la clase program

    }
}
