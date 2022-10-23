using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEA_Doctors.Models
{
    public class Medicamento
    {
        [Key]
        public int ID_medicamento { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }
}
