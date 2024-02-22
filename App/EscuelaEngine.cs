using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public sealed class EscuelaEngine
    {
        public Escuela escuela {  get; set; }

        public void Inicializar()
        {
            escuela = new Escuela
        (
              nombre: "Platzi Escuela",
              año: 2000,
              tipo: TiposEscuela.Secundaria,
              pais: "Perú",
              ciudad: "Lima"
        );

        CargarCursos();
        CargarAsignarutas();
        GenerarAlumnosAlAzar(10);
        CargarEvaluaciones();
    }

        private List<Alumno> GenerarAlumnosAlAzar(int CantidadPorSalon)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno {Nombre= $"{n1} {n2} {a1}"};

            return listaAlumnos.OrderBy( (alumndo) => alumndo.UniqueId).Take(CantidadPorSalon).ToList();
        }


        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true, 
            bool TraeAsignaturas = true, 
            bool TraeCursos = true
            )
        {

            conteoAlumnos = conteoAsignaturas = conteoEvaluaciones = conteoCursos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(escuela);

            if (TraeCursos)
            {
                listaObj.AddRange(escuela.Cursos);

                conteoCursos = escuela.Cursos.Count;

                foreach (var curso in escuela.Cursos)
                    {
                    conteoAsignaturas += curso.Asignaturas.Count;
                    conteoAlumnos += curso.Alumno.Count;

                    if (TraeAsignaturas)
                        {
                            listaObj.AddRange(curso.Asignaturas);
                        }       

                        if (traeAlumnos)
                        {
                            listaObj.AddRange(curso.Alumno);
                        }

                        if (traeEvaluaciones)
                        {
                            foreach (var alumno in curso.Alumno)
                            {
                                listaObj.AddRange(alumno.Evaluación);
                                conteoEvaluaciones += alumno.Evaluación.Count;
                            }
                        }
                    }
            
            }
            return listaObj;
        }

        private void CargarAsignarutas()
        {
            foreach (var curso in escuela.Cursos)
            {
                List<Asignatura> ListaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };

                curso.Asignaturas = ListaAsignaturas;
            }
        }

        private void CargarCursos()
        {
            escuela.Cursos = new List<Cursos>()
        {
            new Cursos(){Nombre = "101", TiposJornada=TiposJornada.Mañana},
            new Cursos(){Nombre = "201", TiposJornada=TiposJornada.Mañana},
            new Cursos(){Nombre = "301", TiposJornada=TiposJornada.Mañana},
            new Cursos(){Nombre = "401", TiposJornada=TiposJornada.Tarde},
            new Cursos(){Nombre = "501", TiposJornada=TiposJornada.Tarde}
        };

            foreach (var curso in escuela.Cursos)
            {
                Random rnd = new Random();
                curso.Alumno = GenerarAlumnosAlAzar(rnd.Next(5,20));
            }
        }

        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluación>();
            foreach (var curso in escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumno)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (var i = 0; i < 5; i++)
                        {
                            var evaluación = new Evaluación
                            {
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble())
                            };
                            alumno.Evaluación.Add(evaluación);
                        }
                    }
                }
            }
        }

    }
}
