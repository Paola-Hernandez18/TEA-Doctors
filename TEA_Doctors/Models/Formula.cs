using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEA_Doctors.Models
{
    public class Formula
    {
        [Key]
        public int ID_formula { get; set; }
        public int ID_medicamento { get; set; }
        public int ID_horario { get; set; }
        public string Recomendaciones { get; set; }
        public string Terapia { get; set; }
    }
}
