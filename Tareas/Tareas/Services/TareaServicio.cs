using Tareas.Models;

namespace Tareas.Services
    {

    public interface ITareaServicio
        {

        public List<Tarea> ObtenerTodas();
        public void Agregar(Tarea tarea);
        public Tarea? ObtenerPorId(int id);
        public bool AlternarCompletada(int id);

        }

    public class TareaServicio : ITareaServicio
        {

        private static readonly List<Tarea> _tareas = new()
        {
            new Tarea { Id = 1, Titulo = "Repasar routing", Prioridad = 2, Completada = false },
            new Tarea { Id = 2, Titulo = "Armar resumen SQL", Prioridad = 3, Completada = true }
        };





        public void Agregar(Tarea tarea)
            {

            tarea.Id = _tareas.Count > 0 ? _tareas.Max(t => t.Id) + 1 : 1;
            tarea.Completada = false;
            _tareas.Add(tarea);

            }





        public Tarea? ObtenerPorId(int id) => _tareas.FirstOrDefault(t => t.Id == id);





        public bool AlternarCompletada(int id)
            {

            var tarea = ObtenerPorId(id);
            if (tarea == null)
                return false;

            tarea.Completada = !tarea.Completada;
            return true;
            }





        public List<Tarea> ObtenerTodas()
            {
            return _tareas;
            }
        }
    }
