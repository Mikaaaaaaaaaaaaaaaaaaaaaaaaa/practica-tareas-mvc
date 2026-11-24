namespace Tareas.Models
    {

    public class Tarea
        {

        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public int Prioridad { get; set; } // 1 = Baja, 2 = Media, 3 = Alta
        public bool Completada { get; set; }

        }
    }