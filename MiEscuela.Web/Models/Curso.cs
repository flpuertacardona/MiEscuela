using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiEscuela.Web.Models
{
    public class Curso : ObjetoEscuelaBase
    {
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
        public TiposJornada Jornada { get; set; }

        [Display(Prompt = "Direccion correspondencia", Name = "Address")]
        [Required(ErrorMessage = "El campo {0}, es obligatrio")]
        [MinLength(10, ErrorMessage = "La longitud requerida del campo {0}, debe ser de {1} caracteres")]
        public string Direccion { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
    }
}
