using CoreEscuela.Interfaces;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        public int AñoDeCreacion {get;set;}
        public string Pais {get;set;}
        public string Ciudad {get;set;}
        public string Dirección { get;set;}
        public TiposEscuela Tipo { get;set;}
        public List<Cursos> Cursos { get;set;}

        //Constructor que requiere el nombre y el año de la escuela.
        //public Escuela(string nombre, int año) => (this.Nombre, this.AñoDeCreacion) = (nombre, año);

        //Constructor que requiere el nombre , año de la escuela , tipo, opcionalmente puedes llenar el país y la ciudad.
        public Escuela(string nombre, int año, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            (this.Nombre, this.AñoDeCreacion, this.Tipo, this.Pais, this.Ciudad) = (nombre, año, tipo ,pais, ciudad);
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {Tipo}, Pais: {Pais}, Ciudad: {Ciudad}, Año de creación: {AñoDeCreacion}";
        }

        public void LimpiarLugar()
        {
            Console.WriteLine("Limpiando escuela...");
  
            foreach (var curso in Cursos)
            {
                Console.WriteLine("Limpiando curso...");
                Console.WriteLine($"El curso {curso.Nombre} fué limpiado.");
                Console.Beep(1000, 500);
            }
            Console.WriteLine($"La escuela {Nombre} fué limpiado.");
       
        }
    }
}