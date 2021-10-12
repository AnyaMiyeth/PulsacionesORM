using Entidad;
using System.Collections.Generic;

namespace Logica
{
    public class PersonaBuscarResponse
    {
        public Persona Persona { get; set; }
        public string Mensaje { get; set; }
        public bool IsError { get; set; }

        public PersonaBuscarResponse(Persona persona)
        {
            Persona = persona;
            IsError = false;
        }
        public PersonaBuscarResponse(string mensaje)
        {
            Mensaje = mensaje;
            IsError = true;
        }
    }
}