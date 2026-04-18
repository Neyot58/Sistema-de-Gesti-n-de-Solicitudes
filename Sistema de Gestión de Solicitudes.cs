using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Solicitud> lista = new List<Solicitud>();
        int opcion;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Registrar solicitud");
            Console.WriteLine("2. Mostrar solicitudes");
            Console.WriteLine("3. Cambiar estado");
            Console.WriteLine("4. Buscar por ID");
            Console.WriteLine("0. Salir");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Registrar(lista);
                    break;

                case 2:
                    Mostrar(lista);
                    break;

                case 3:
                    CambiarEstado(lista);
                    break;

                case 4:
                    Buscar(lista);
                    break;
            }

        } while (opcion != 0);
    }

    static void Registrar(List<Solicitud> lista)
    {
        Solicitud s = new Solicitud();

        Console.Write("ID: ");
        s.Id = int.Parse(Console.ReadLine());

        Console.Write("Nombre del cliente: ");
        s.NombreCliente = Console.ReadLine();

        Console.Write("Descripción: ");
        s.Descripcion = Console.ReadLine();

        s.Estado = EstadoSolicitud.Pendiente;

        lista.Add(s);

        Console.WriteLine("Solicitud registrada.");
    }

    static void Mostrar(List<Solicitud> lista)
    {
        foreach (var s in lista)
        {
            s.Mostrar();
        }
    }

    static void CambiarEstado(List<Solicitud> lista)
    {
        Console.Write("Ingrese ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (var s in lista)
        {
            if (s.Id == id)
            {
                Console.WriteLine("Seleccione estado:");
                Console.WriteLine("0. Pendiente");
                Console.WriteLine("1. EnProceso");
                Console.WriteLine("2. Completada");
                Console.WriteLine("3. Cancelada");

                int opcion = int.Parse(Console.ReadLine());

                if (Enum.IsDefined(typeof(EstadoSolicitud), opcion))
                {
                    s.Estado = (EstadoSolicitud)opcion;
                    Console.WriteLine("Estado actualizado.");
                }
                else
                {
                    Console.WriteLine("Estado inválido.");
                }
                return;
            }
        }

        Console.WriteLine("Solicitud no encontrada.");
    }

    static void Buscar(List<Solicitud> lista)
    {
        Console.Write("Ingrese ID: ");
        int id = int.Parse(Console.ReadLine());

        foreach (var s in lista)
        {
            if (s.Id == id)
            {
                s.Mostrar();
                return;
            }
        }

        Console.WriteLine("Solicitud no encontrada.");
    }
}
