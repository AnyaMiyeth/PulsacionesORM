using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonasConsultaResponse
    {
        public List<Persona> Personas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public PersonasConsultaResponse(List<Persona> personas)
        {
            Personas = personas;
            Error = false;
        }
        public PersonasConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
