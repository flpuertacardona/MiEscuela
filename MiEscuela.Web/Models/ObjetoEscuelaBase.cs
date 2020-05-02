using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiEscuela.Web.Models
{
    public abstract class ObjetoEscuelaBase
    {
        private string nombre;
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MinLength(10, ErrorMessage = "El campo {0}, debe tener una longitud minima de {1}")]
        public string Nombre { get => nombre.ToUpper(); set => nombre = value; }
        public ObjetoEscuelaBase() => Id = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}
