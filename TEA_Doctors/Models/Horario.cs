using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEA_Doctors.Models
{
    public class Horario
    {
        //Nombres de las variables como en la tabla de la base de datos
        [Key]
        public int ID_horario { get; set; }
        public string Dias_semana { get; set; }
        public string Hora_tiempo { get; set; }

    }
}
