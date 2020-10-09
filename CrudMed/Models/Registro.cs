using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMed.Models
{
    [Table("Registro")]
    public partial class Registro
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int Contacto { get; set; }
        [ForeignKey("CondicionMedica")]
        public int IdCondicionMed { get; set; }
        [NotMapped]
        public virtual List<CondicionMedica> condicionMedica { get; set; }
    }
}
