using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiEscuela.Web.Models
{
    public class Escuela : ObjetoEscuelaBase
    {
        [Display(Name = "Año de creación")]
        [Required(ErrorMessage="El campo {0} es obligatorio")]
        public int FechaCreacion { get; set; }

        [Required(ErrorMessage = "El campo {0}, no debe estar en blanco")]
        public Paises Pais { get; set; }
        [Required(ErrorMessage = "El campo {0}, no debe estar en blanco")]
        public Ciudades Ciudad { get; set; }

        [Required(ErrorMessage = "El campo {0}, no debe estar en blanco")]
        [MinLength(10, ErrorMessage = "La longitud requerida del campo {0}, debe ser de {1} caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage="El campo {0} es obligatorio")]
        [Display(Name = "Tipo Escuela")]
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0}, no debe estar en blanco")]
        public string Rector { get; set; }

        public Escuela(string nombre, int año) => (Nombre, FechaCreacion) = (nombre, año);

        public Escuela(string nombre, int año,
                        TiposEscuela tipo,
                        string pais = "", string ciudad = "") : base()
        {
            (Nombre, FechaCreacion) = (nombre, año);
            Pais = Paises.Colombia;
            Ciudad = Ciudades.Medellín;
        }

        public Escuela()
        {

        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
    }
}
