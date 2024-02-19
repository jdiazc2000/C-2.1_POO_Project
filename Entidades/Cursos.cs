namespace CoreEscuela.Entidades
{
    public class Cursos
    {
        public string UniqueId { get; private set; }
        public Cursos() => UniqueId = Guid.NewGuid().ToString();
        public string Nombre {  get; set; }
        public TiposJornada TiposJornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumno { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, ID: {UniqueId}, Tipo de jornada: {TiposJornada}";
        }
    }
}
