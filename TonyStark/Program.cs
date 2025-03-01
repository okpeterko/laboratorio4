using System;
using System.IO;

class Program
{
    static string rutaBase = @"C:\Users\marro\Desktop\UMG\3er semestre\Programacion 1\laboratorio4\";
    static string archivoInventos = rutaBase + "inventos.txt";

    static void Main()
    {
        Directory.CreateDirectory(rutaBase);
        Console.WriteLine("Bienvenido al sistema de gestión de archivos de Tony Stark.");

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Crear archivo inventos.txt");
            Console.WriteLine("2. Agregar un invento");
            Console.WriteLine("3. Leer archivo línea por línea");
            Console.WriteLine("4. Leer todo el archivo");
            Console.WriteLine("5. Copiar archivo a Backup");
            Console.WriteLine("6. Mover archivo a ArchivosClasificados");
            Console.WriteLine("7. Crear carpeta ProyectosSecretos");
            Console.WriteLine("8. Eliminar archivo inventos.txt");
            Console.WriteLine("9. Listar archivos en laboratorio4");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearArchivo();
                    break;
                case "2":
                    Console.Write("Ingrese el nombre del invento: ");
                    string invento = Console.ReadLine();
                    AgregarInvento(invento);
                    break;
                case "3":
                    LeerLineaPorLinea();
                    break;
                case "4":
                    LeerTodoElTexto();
                    break;
                case "5":
                    CopiarArchivo();
                    break;
                case "6":
                    MoverArchivo();
                    break;
                case "7":
                    CrearCarpeta("ProyectosSecretos");
                    break;
                case "8":
                    EliminarArchivo();
                    break;
                case "9":
                    ListarArchivos();
                    break;
                case "0":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void CrearArchivo()
    {
        try
        {
            if (!File.Exists(archivoInventos))
            {
                File.WriteAllText(archivoInventos, "1. Traje Mark I\n2. Reactor Arc\n3. Inteligencia Artificial JARVIS\n");
                Console.WriteLine("Archivo creado exitosamente.");
            }
            else
            {
                Console.WriteLine("El archivo ya existe.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al crear el archivo: " + e.Message);
        }
    }

    static void AgregarInvento(string invento)
    {
        try
        {
            File.AppendAllText(archivoInventos, invento + "\n");
            Console.WriteLine("Invento agregado correctamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al agregar invento: " + e.Message);
        }
    }

    static void LeerLineaPorLinea()
    {
        try
        {
            foreach (string linea in File.ReadLines(archivoInventos))
            {
                Console.WriteLine(linea);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer el archivo: " + e.Message);
        }
    }

    static void LeerTodoElTexto()
    {
        try
        {
            Console.WriteLine(File.ReadAllText(archivoInventos));
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer el archivo: " + e.Message);
        }
    }

    static void CopiarArchivo()
    {
        try
        {
            string rutaCopia = rutaBase + @"Backup\inventos_backup.txt";
            Directory.CreateDirectory(rutaBase + "Backup");
            File.Copy(archivoInventos, rutaCopia, true);
            Console.WriteLine("Archivo copiado a Backup.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al copiar archivo: " + e.Message);
        }
    }

    static void MoverArchivo()
    {
        try
        {
            string rutaDestino = rutaBase + @"ArchivosClasificados\inventos.txt";
            Directory.CreateDirectory(rutaBase + "ArchivosClasificados");
            File.Move(archivoInventos, rutaDestino, true);
            Console.WriteLine("Archivo movido a ArchivosClasificados.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al mover archivo: " + e.Message);
        }
    }

    static void CrearCarpeta(string nombreCarpeta)
    {
        try
        {
            string rutaCarpeta = rutaBase + nombreCarpeta;
            Directory.CreateDirectory(rutaCarpeta);
            Console.WriteLine("Carpeta creada: " + nombreCarpeta);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al crear carpeta: " + e.Message);
        }
    }

    static void EliminarArchivo()
    {
        try
        {
            if (File.Exists(archivoInventos))
            {
                File.Delete(archivoInventos);
                Console.WriteLine("Archivo inventos.txt eliminado.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al eliminar archivo: " + e.Message);
        }
    }

    static void ListarArchivos()
    {
        try
        {
            string[] archivos = Directory.GetFiles(rutaBase);
            Console.WriteLine("Archivos en laboratorio4:");
            foreach (string archivo in archivos)
            {
                Console.WriteLine(Path.GetFileName(archivo));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al listar archivos: " + e.Message);
        }
    }
}
