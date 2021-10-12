using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class PulsacionesContext: DbContext
    {
        public PulsacionesContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Pago> Pagos { get; set;}
    }
}