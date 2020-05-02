using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiEscuela.Web.Models
{
    public class Alumno:ObjetoEscuelaBase
    {
        [Required(ErrorMessage="El campo {0}, es requerido")]
        public string Documento { get; set; }
        public TiposDocumento TipoDocumento { get; set; }
        public TiposGenero Genero { get; set; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}
