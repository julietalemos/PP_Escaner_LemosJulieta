using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Informes
    {
        
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            //Este metodo reutiliza el metodo MostrarDocumentosPorEstado y le pasa el estado "Distribuido"
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            /* Este metodo filtra los documentos por Estado y hace un resumen segun lo pedido*/

            extension = 0;
            cantidad = 0;
            StringBuilder resumenBuilder = new StringBuilder();
           
            foreach(Documento doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    // incrementa la cantidad y la extensión
                    cantidad++;
                    if(e.Tipo == Escaner.TipoDoc.libro)
                    {
                        extension += ((Libro)doc).NumPaginas;
                    }
                    else if (e.Tipo == Escaner.TipoDoc.mapa)
                    {
                        extension += ((Mapa)doc).Superficie;
                    }
                    
                    // añado los datos del documento al resumen.
                    resumenBuilder.AppendLine(doc.ToString());
                }
            }
            // Establece el resumen.            
            resumen = resumenBuilder.ToString();            
        }
        
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            //Este metodo reutiliza el metodo MostrarDocumentosPorEstado y le pasa el estado "EnEscaner"
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            //Este metodo reutiliza el metodo MostrarDocumentosPorEstado y le pasa el estado "EnRevision"
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            //Este metodo reutiliza el metodo MostrarDocumentosPorEstado y le pasa el estado "Terminado"
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }

    }
}
