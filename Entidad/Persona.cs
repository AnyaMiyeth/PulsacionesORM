using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Persona
    {
        public Persona()
        {

        }
        public Persona(string identificacion, string nombre, int edad, string sexo)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
        }

        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Pulsacion { get; set; }

        public void CalcularPulsacion()
        {
            if (Sexo.ToUpper().Equals("M"))
            {
                Pulsacion = (210 - Edad) / 10;
            }
            else if (Sexo.ToUpper().Equals("F"))
            {
                Pulsacion = (220 - Edad) / 10;
            }
            else
            {
                Pulsacion = 0;
            }
        }

        public override string ToString()
        {
            return $"Identificación:{Identificacion} \nNombre:{Nombre} \nEdad:{Edad} \nSexo:{Sexo} \nPulsacion:{Pulsacion}";
        }
    }
}
