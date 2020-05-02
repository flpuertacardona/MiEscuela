using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiEscuela.Web.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cargar escuela
            var escuela = new Escuela();
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Gimansio Los Alcazares";
            escuela.FechaCreacion = 1960;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Direccion = "Cra. 43a 66sur 30";
            escuela.Pais = Paises.Colombia;
            escuela.Ciudad = Ciudades.Sabaneta;
            escuela.TipoEscuela = TiposEscuela.Secundaria;
            escuela.Rector = "Mario Alberto Patiño Pardo";
            modelBuilder.Entity<Escuela>().HasData(escuela);

            // Cargar cursos
            List<Curso> listaCursos = CargarCursos(escuela);
            var cursos = listaCursos.ToArray();
            modelBuilder.Entity<Curso>().HasData(cursos);

            // x cada curso cargar asignaturas
            List<Asignatura> listaAsignaturas = CargarAsignaturas(listaCursos);
            var asignaturas = listaAsignaturas.ToArray();
            modelBuilder.Entity<Asignatura>().HasData(asignaturas);


            // x cada curso cargar alumnos
            List<Alumno> listaAlumnos = CargarCursoAlumnos(listaCursos);
            var alumnos = listaAlumnos.ToArray();
            modelBuilder.Entity<Alumno>().HasData(alumnos);

            // x cada curso y por cada alumno y por cada asignatura cargar evaluaciones
            List<Evaluacion> listaEvaluaciones = CargarEvaluaciones(listaAsignaturas, listaAlumnos);
            var evaluaciones = listaEvaluaciones.ToArray();
            modelBuilder.Entity<Evaluacion>().HasData(evaluaciones);
        }

        private List<Evaluacion> CargarEvaluaciones(List<Asignatura> listaAsignaturas, List<Alumno> listaAlumnos)
        {
            Random random = new Random();
            List<Evaluacion> listaEvaluaciones = new List<Evaluacion>() { };

            foreach (var alumno in listaAlumnos)
            {
                foreach (var asignatura in listaAsignaturas)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        listaEvaluaciones.Add(new Evaluacion { Id = Guid.NewGuid().ToString(), 
                            AlumnoId = alumno.Id, AsignaturaId = asignatura.Id, 
                            Nota = (random.Next(0, 5)), Cursoid = asignatura.CursoId, Curso = asignatura.Curso,
                        Nombre= " "});
                    }
                }
            }
            return listaEvaluaciones;
        }

        private List<Alumno> CargarCursoAlumnos(List<Curso> listaCursos)
        {
            List<Alumno> listaCurAlumnos = new List<Alumno>() { };
            foreach (var curso in listaCursos)
            {
                List<Alumno> listaAlumnos = CargarAlumnos(10);

                foreach (var alumno in listaAlumnos)
                {
                    listaCurAlumnos.Add(new Alumno { Nombre = alumno.Nombre, Id = Guid.NewGuid().ToString(), 
                        CursoId = curso.Id, Documento=" " });
                }
            }
            return listaCurAlumnos;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> listaCursos)
        {
            var listaAsignaturas = new List<Asignatura>() { };
            foreach (var curso in listaCursos)
            {
                listaAsignaturas.Add(new Asignatura { Nombre = "Matematicas", Id = Guid.NewGuid().ToString(), CursoId = curso.Id });
                listaAsignaturas.Add(new Asignatura { Nombre = "Español", Id = Guid.NewGuid().ToString(), CursoId = curso.Id });
                listaAsignaturas.Add(new Asignatura { Nombre = "Ingles", Id = Guid.NewGuid().ToString(), CursoId = curso.Id });
                listaAsignaturas.Add(new Asignatura { Nombre = "Educacion Fisica", Id = Guid.NewGuid().ToString(), CursoId = curso.Id });
                listaAsignaturas.Add(new Asignatura { Nombre = "Dibujo y Artistica", Id = Guid.NewGuid().ToString(), CursoId = curso.Id });
                listaAsignaturas.Add(new Asignatura { Nombre = "Programación", Id = Guid.NewGuid().ToString(), CursoId = curso.Id });
                listaAsignaturas.Add(new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString(), CursoId = curso.Id });
            }
            return listaAsignaturas;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>()
            {
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130" },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Mañana, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso() { Nombre = "301", Jornada = TiposJornada.Mañana, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso { Nombre = "102", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso { Nombre = "102", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso { Nombre = "102", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso { Nombre = "202", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso { Nombre = "302", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso() { Nombre = "402", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso() { Nombre = "502", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  },
                new Curso() { Nombre = "602", Jornada = TiposJornada.Nocturna, Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Direccion="Carrera 43A # 60sur 64 casa 130"  }
            };
        }

        private List<Alumno> CargarAlumnos(int cantidad)
        {
            string[] nombre1 = { "Pedro", "Juan", "Andres", "Santiago", "Felipe", "Matias", "Marcos", "Pablo", "Esteban" };
            string[] nombre2 = { "Juan", "Maria", "Davis", "Manue", "Esteban", "Tomas" };
            string[] apellido = { "Perez", "Puerta", "Rios", "Velez", "Marin", "Vallejo", "Cardona", "Osorio", "Bernal" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from ap in apellido
                               select new Alumno()
                               {
                                   Nombre = $"{n1} {n2} {ap}",
                                   Id = Guid.NewGuid().ToString()
                               };
            return listaAlumnos.OrderBy(a => a.Id).Take(cantidad).ToList();
        }
    }
}
