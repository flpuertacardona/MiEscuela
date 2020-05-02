using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiEscuela.Web.Models
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public string Cursoid { get; set; }
        public Curso Curso { get; set; }
        public string AlumnoId { get; set; }
        public string AsignaturaId { get; set; }
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }

        [Range(0, 5, ErrorMessage = "El valor de {0} debe estar entre {1} y {2}.")]
        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}
