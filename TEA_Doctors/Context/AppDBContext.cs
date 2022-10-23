using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEA_Doctors.Models;

namespace TEA_Doctors.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        //----------------------------  Representacion de las tablas ----------------------------

        //Este nombre debe coincidir con el nombre de la tabla
        // ------------------------vvvvvvvvv------------------
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Formula> Formula { get; set; }

    }
}
