using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Esta clase permite clasififcar con un rol a cada usuario que se registre en el sistema para identificarlos
    public class Rol
    {
        [Key]
        public int PkRol { get; set; }

        public string Nombre { get; set; }
    }
}
