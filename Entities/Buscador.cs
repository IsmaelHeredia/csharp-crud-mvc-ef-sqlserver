// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Buscador
    {
        [Display(Name = "nombre_buscar")]
        public string nombre_buscar { get; set; }
    }
}
