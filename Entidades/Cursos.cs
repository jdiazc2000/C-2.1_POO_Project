using CoreEscuela.Interfaces;

namespace CoreEscuela.Entidades
{
    public class Cursos : ObjetoEscuelaBase, ILugar
    {
        public TiposJornada TiposJornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumno { get; set; }
        public string Dirección { get; set; }

        /*
        public override string ToString()
        {
            return $"Nombre: {Nombre}, ID: {UniqueId}, Tipo de jornada: {TiposJornada}";
        }
        */

        public void LimpiarLugar()
        {
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Nombre} fué limpiado.");
        }
    }
}
