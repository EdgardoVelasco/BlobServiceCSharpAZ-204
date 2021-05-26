using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs;

namespace BlobM3.Blob
{
    /*Es un clase que se conecta al Servicio Blob Storage
      Datos necesarios:
      1.- Cadena de conexión
     */
    class BlobAzure
    {
        private static readonly string CONNECTION_STRING = "DefaultEndpointsProtocol=https;AccountName=storagevefer;AccountKey=zFBrGFqJWFHXEBIDxQCypACzmKh1NEqXjPF8I9CYfRa7CB1EmKy1fLZVhP46swfXQYaYG6iRR0SbOdltkdZe4Q==;EndpointSuffix=core.windows.net";

        /*Variable para usar el servicio en cualquier parte de mi código*/
        /*Traducción: Podrás obtener y usar el servicio en cualquier parte,
         pero no lo podrás modificar fuera de la clase*/
        public static BlobServiceClient Servicio { get; private set; }

        /*Constructor: Nos ayuda a inicializar los atributos de una clase*/
        static BlobAzure() { InitBlob(); }

        /*Método usado para inicializar nuestro servicio*/
        private static void InitBlob() {
            if (Servicio == null) {
                Servicio = new BlobServiceClient(CONNECTION_STRING);
            }
        }

    }
}
