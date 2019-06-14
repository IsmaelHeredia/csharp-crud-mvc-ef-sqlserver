// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class CambiarUsuario
    {
        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Required]
        [Display(Name = "Nuevo nombre de usuario")]
        public string nuevo_usuario { get; set; }
    }
}
