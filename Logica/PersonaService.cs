using Datos;
using Entidad;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class PersonaService
    {
        private readonly PulsacionesContext _context;

        public PersonaService(PulsacionesContext context)
        {
            _context = context;
        }

        public PersonaGuardarResponse Guardar(Persona persona)
        {
            try
            {

                if (_context.Personas.Find(persona.Identificacion)== null)
                {
                    _context.Personas.Add(persona);
                    _context.SaveChanges();
                    return new PersonaGuardarResponse(persona);
                }
                return new PersonaGuardarResponse($"No fue posible Guardar la información, porque ya existe un registro con la identificaion {persona.Identificacion}");
            }
            catch (Exception e)
            {
                return new PersonaGuardarResponse($"Error inesperado al Guardar: { e.Message}");
            }

        }
        public string Eliminar(string identificacion)
        {
            try
            {
                var persona = _context.Personas.Find(identificacion);
                if (persona != null)
                {
                    _context.Remove(persona);
                    _context.SaveChanges();
                    return $"Se Eliminó el registro de la persona con identificacion{identificacion}";
                }
                return $"No fue posible eliminar el registro, porque no existe la persona con la identificacion {identificacion}";
            }
            catch (Exception e)
            {
                return $"Error inesperado al Eliminar: {e.Message}";
            }
            
        }
        public PersonasConsultaResponse Consultar()
        {
            try
            {

                return new PersonasConsultaResponse(_context.Personas.ToList());

            }
            catch (Exception e)
            {
                return new PersonasConsultaResponse($"Error inesperado al Consultar: {e.Message}");
            }
            
        }
        public PersonaBuscarResponse Buscar(string identificacion)
        {
            try
            {
        
                var persona = _context.Personas.Find(identificacion);
                if (persona == null)
                {
                    
                    throw new PeronaNoEncontradaException("No se encontraró un registro con la identificacion Solicitada");
                }
                return new PersonaBuscarResponse(persona);
            }
            catch (PeronaNoEncontradaException e)
            {
                return new PersonaBuscarResponse("Error al Buscar:" + e.Message);
            }
            catch (Exception e)
            {
                return new PersonaBuscarResponse("Error inesperado al Buscar:" + e.Message);
            }
            
        }
        // public string Modificiar(string identificacion, Persona personaNew)
        // {
        //     try
        //     {
        //         conexion.Open();
        //         if (personaRepository.BuscarPorIdentificacion(identificacion)==null)
        //         {
        //             return $"No es posible realizar la Modificación, la persona con Identificacion {identificacion} no existe";
        //         }
        //         if (personaRepository.BuscarPorIdentificacion(personaNew.Identificacion)!=null)
        //         {
        //             return $"No es posible realizar la Modificación, La Nueva Identificación {personaNew.Identificacion} ya se encuentra asignada a otra persona";
        //         }
        //         personaRepository.Modificar(personaNew);
        //         return "Se realizó la Modificación Satisfactoriamente";
        //     }
        //     catch (Exception e)
        //     {

        //         return $"Error inesperado al Modificar: {e.Message}";
        //     }
          
        // }
    }
}
