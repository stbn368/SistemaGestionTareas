using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTareas
{
    public class Tareas
    {
        public int tareaId { get; set; }
        public string descripcion { get; set; }
        public bool completada { get; set; }
    }

    public static class MetodosTareas
    {
        public static List<Tareas> listaTareas = new();

        public static int tareaIdAsignado = 0;
        public static int numeroOpcion;
        public static int tareaSeleccionarId;

        public static void VerTareas()
        {
            if(listaTareas.Count() != 0)
            {
                foreach (var tarea in listaTareas)
                {
                    Console.WriteLine($"ID: {tarea.tareaId} - Descripción: {tarea.descripcion} - ¿Completada? {tarea.completada}");
                }
            }
            else
            {
                Console.WriteLine("No hay tareas.");
            }
        }

        public static void AgregarTarea()
        {
            Tareas tarea = new Tareas();

            tareaIdAsignado = GenerarRamdonId();

            //Recorrer lista para comprobar si el ID existe y en ese caso generar un nuevo ID, es poco probable, pero así sería un ID único
            foreach (var t in listaTareas)
            {
                while (t.tareaId == tareaIdAsignado)
                {
                    tareaIdAsignado = GenerarRamdonId();
                }
            }
            
            tarea.tareaId = tareaIdAsignado;

            Console.WriteLine("Añade una descripción:");
            tarea.descripcion = Console.ReadLine();

            tarea.completada = false;

            listaTareas.Add(tarea);

            Console.WriteLine("Tarea creada!");
        }

        public static void EditarDescripcionTarea()
        {
            if (listaTareas.Count() != 0)
            {
                Console.WriteLine("Elige el ID de la tarea que quieres editar: ");
                VerTareas();

                int IDSeleccionado = SeleccionarIDTarea();
                bool existeID = false;

                try
                {
                    foreach(var t in listaTareas)
                    {
                        if (t.tareaId == IDSeleccionado)
                        {
                            //se usar para buscar el índice de la tarea a modificar en función del ID que se introduce
                            int buscarID = listaTareas.IndexOf(t);

                            Console.WriteLine("Añade la nueva descripción:");
                            string descripcionTarea = Console.ReadLine();

                            if (descripcionTarea == null || descripcionTarea.Trim() == "")
                            {
                                Console.WriteLine("Debes introducir una descripción...");
                                existeID = true;
                                break;
                            }
                            else
                            {
                                listaTareas[buscarID].descripcion = descripcionTarea;
                                Console.WriteLine("Tarea editada!");
                                existeID = true;
                                break;
                            }
                        }
                    }
                    if(existeID == false)
                    {
                        Console.WriteLine("Ese ID no existe...");
                    }
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            else
            {
                Console.WriteLine("No hay tareas creadas.");
            }
        }

        public static void EliminarTarea()
        {
            if (listaTareas.Count() != 0)
            {
                Console.WriteLine("Elige el ID de la tarea que quieres eliminar: ");
                VerTareas();

                int IDSeleccionado = SeleccionarIDTarea();
                bool existeID = false;

                try
                {
                    foreach (var t in listaTareas)
                    {
                        if (t.tareaId == IDSeleccionado)
                        {
                            int buscarID = listaTareas.IndexOf(t);

                            listaTareas.RemoveAt(buscarID);
                            Console.WriteLine("Tarea eliminada!");

                            existeID = true;
                        }
                    }
                    if (existeID == false)
                    {
                        Console.WriteLine("Ese ID no existe...");
                    }
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (System.InvalidOperationException ex)
                {
                    Console.WriteLine("Lista de tareas modificada.");
                }
            }
            else
            {
                Console.WriteLine("No hay tareas creadas.");
            }

        }

        public static void EditarEstadoTarea()
        {
            if (listaTareas.Count() != 0)
            {
                Console.WriteLine("Elige el ID de la tarea que quieres cambiar el estado: ");
                VerTareas();

                int IDSeleccionado = SeleccionarIDTarea();
                bool existeID = false;

                try
                {
                    foreach (var t in listaTareas)
                    {
                        if (t.tareaId == IDSeleccionado)
                        {
                            int buscarID = listaTareas.IndexOf(t);

                            if (listaTareas[buscarID].completada == false)
                            {
                                listaTareas[buscarID].completada = true;
                            }
                            else
                            {
                                listaTareas[buscarID].completada = false;
                            }
                            Console.WriteLine("Estado cambiado!");
                            existeID = true;
                        }
                    }
                    if (existeID == false)
                    {
                        Console.WriteLine("Ese ID no existe...");
                    }
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                }

            }
            else
            {
                Console.WriteLine("No hay tareas creadas.");
            }
        }

        /// <summary>
        /// Método no utilizado al modificar la forma de asignar un tareaID.
        /// </summary>
        public static void ResetearIdLista()
        {
            for (int i = tareaSeleccionarId; i <= listaTareas.Count(); i++)
            {
                listaTareas[i-1].tareaId = i;
            }
            tareaIdAsignado = listaTareas.Count();
        }

        public static int SeleccionarIDTarea()
        {
            try
            {
                tareaSeleccionarId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Introduce un ID válido...");
                tareaSeleccionarId = Convert.ToInt32(Console.ReadLine());
            }
            return tareaSeleccionarId;
        }

        public static int GenerarRamdonId()
        {
            Random r = new Random();
            var ramdonId = r.Next(0, 9999);

            return ramdonId;
        }

    }


}
