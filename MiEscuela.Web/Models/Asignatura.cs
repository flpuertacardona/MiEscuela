using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiEscuela.Web.Models
{
    public class Asignatura : ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}
