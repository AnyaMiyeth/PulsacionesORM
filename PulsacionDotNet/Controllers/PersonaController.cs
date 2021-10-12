using Entidad;
using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using PulsacionDotNet.Models;
using System.Collections.Generic;
using System.Linq;
using Datos;

namespace PulsacionDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;
        public IConfiguration Configuration { get; }
        public PersonaController(PulsacionesContext context)
        {
            
            _personaService = new PersonaService(context);
        }

        [HttpPost]
        public ActionResult<PersonaViewModel> Guardar(PersonaInputModel personaInputModel)
        {
            var persona = MapearaPersona(personaInputModel);
            var respuesta = _personaService.Guardar(persona);
            if (respuesta.IsError == true)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.Persona);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonaViewModel>> Gets()
        {
            var respuesta = _personaService.Consultar();
            if (respuesta.Error == true)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.Personas.Select(p => new PersonaViewModel(p)));
        }

        [HttpGet("byId")]
        public ActionResult<PersonaViewModel> Gets(string id)
        {
            var respuesta = _personaService.Buscar(id);
            if (respuesta.IsError == true)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.Persona);
        }
        private Persona MapearaPersona(PersonaInputModel personaInputModel)
        {
            var persona = new Persona();
            persona.Identificacion = personaInputModel.Identificacion;
            persona.Nombre = personaInputModel.Nombre;
            persona.Edad = personaInputModel.Edad;
            persona.Sexo = personaInputModel.Sexo;
            persona.CalcularPulsacion();
            return persona;
        }
    }
}
