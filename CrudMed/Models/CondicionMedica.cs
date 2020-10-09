using System;
using System.Collections.Generic;

namespace CrudMed.Models
{
    public partial class CondicionMedica
    {
   
        public int IdCondicionMed { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Registro IdCondicionMedNavigation { get; set; }
    }
}
