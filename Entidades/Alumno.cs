namespace CoreEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        //Inicializamos la lista de notas de evaluaciones por alumno
        public List<Evaluación> Evaluación { get; set; } = new List<Evaluación>();
    }
}
