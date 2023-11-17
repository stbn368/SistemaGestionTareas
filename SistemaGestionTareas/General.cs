using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTareas
{
    public static class General
    {
        public static void ListaOpciones()
        {
            Console.WriteLine("...Sistema de gestión de tareas...");
            Console.WriteLine("1. Ver tareas");
            Console.WriteLine("2. Agregar tarea");
            Console.WriteLine("3. Editar descripción tarea");
            Console.WriteLine("4. Editar estado tarea");
            Console.WriteLine("5. Eliminar tarea");
            Console.WriteLine("6. Ver opciones");
            Console.WriteLine("7. Salir");
            Console.WriteLine("--------------------------------------------");
        }

        public static int PedirOpcion()
        {
            try
            {
                Console.Write("Selecciona una opción: ");
                MetodosTareas.numeroOpcion = Convert.ToInt32(Console.ReadLine());
                return MetodosTareas.numeroOpcion;

            }catch(Exception ex)
            {
                Console.Write("Vuelve a introducir una opción: ");
                MetodosTareas.numeroOpcion = Convert.ToInt32(Console.ReadLine());
                return MetodosTareas.numeroOpcion;
            }
        }

        public static void Menu()
        {
            int opcion = PedirOpcion();

            while (opcion == 6)
            {
                ListaOpciones();
                opcion = PedirOpcion();
            }

            switch (opcion)
            {
                case 1:
                    MetodosTareas.VerTareas();
                    Menu();
                    break;

                case 2:
                    MetodosTareas.AgregarTarea();
                    Menu();
                    break;

                case 3:
                    MetodosTareas.EditarDescripcionTarea();
                    Menu();
                    break;

                case 4:
                    MetodosTareas.EditarEstadoTarea();
                    Menu();
                    break;

                case 5:
                    MetodosTareas.EliminarTarea();
                    Menu();
                    break;

                case 6:
                    ListaOpciones();
                    Menu();
                    break;

                case 7:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no encontrada...");
                    Menu();
                    break;
            }
        }
    }
}
