using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        var engine = new EscuelaEngine();
        engine.Inicializar();
        ImprimirCursosEscuela(engine.escuela);

    }

    private static void ImprimirCursosEscuela(Escuela escuela)
    {
        Console.WriteLine("----------------Lista de cursos de la escuela---------------");
        if (escuela?.Cursos != null)
        {
            foreach (var curso in escuela.Cursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre}, Jornada: {curso.TiposJornada} y ID del curso: {curso.UniqueId}");
            }
        }
        else
        {
            Console.WriteLine("No se tiene cursos asignado a la escuela.");
        }
  
    }
}