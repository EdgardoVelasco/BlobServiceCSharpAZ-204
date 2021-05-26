using System;
using Azure.Storage.Blobs;
using BlobM3.Blob;
using System.Linq;
using System.IO;

namespace BlobM3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Inicializamos el servicio de blob storage*/
            var cliente = BlobAzure.Servicio;

            Menu();
            Console.WriteLine("Selecciona opción: ");
            var opc = int.Parse(Console.ReadLine());
            while (opc!=7) {
                switch (opc) {
                    case 1:
                        Console.WriteLine("-.-.-.Contenedores-.-.-.");
                        GetContainers(cliente);
                        Menu();
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine());
                        break;

                    case 2:
                        Console.WriteLine("-.-.-Cargando Archivo-.-.-.");
                        CargarArchivo(cliente);
                        Menu();
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine());
                        break;
                
                }
             
            }

        }

        private static void Menu() {
            Console.WriteLine("-.-.-.Menú Opciones-.-.-.");
            Console.WriteLine("-.- 1.Ver Contenedores");
            Console.WriteLine("-.-.2.Cargar archivo");
            Console.WriteLine("-.-.-.-.Fin Menú-.-.-.-.");
        }

        private static void CargarArchivo(BlobServiceClient cliente) {
            Console.WriteLine("Url archivo: ");
            var url = Console.ReadLine();
            Console.WriteLine("Nombre Contenedor: ");
            var nombreC = Console.ReadLine();

            /*validamos que el contenedor exista*/
            var contenedor = cliente.GetBlobContainerClient(nombreC.ToLower());
            if (contenedor.Exists()) {
                var nombreArchivo = Path.GetFileName(url); //C:/archivo1.txt
                try {
                    var respuesta = contenedor.UploadBlob(nombreArchivo, File.OpenRead(url));
                    Console.WriteLine(respuesta.GetRawResponse().Status);
                    Console.WriteLine("cargado correctamente");
                }
                catch (Azure.RequestFailedException ex) {
                    Console.WriteLine($"error al cargar archivo {ex}");
                    return;
                }

            }
        
        }


       
        private static void GetContainers(BlobServiceClient cliente) {
            /*obtenemos todos los contenedores de nuestro Blob Storage*/
            var contenedores = cliente.GetBlobContainers();
            contenedores.ToList()
                        .ForEach(t=>Console.WriteLine($"nombre:{t.Name}"));
        
        }

    }
}
