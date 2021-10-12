using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonaGuardarResponse
    {
        public Persona Persona { get; set; }
        public string Mensaje { get; set; }
        public bool IsError { get; set; }

        public PersonaGuardarResponse(Persona persona)
        {
            Persona = persona;
            IsError = false;
        }
        public PersonaGuardarResponse(string mensaje)
        {
            Mensaje = mensaje;
            IsError = true;
        }
    }
}
