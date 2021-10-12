using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidad
{
    public class Pago
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}