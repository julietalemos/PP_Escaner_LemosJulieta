using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        //ATRIBUTOS
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;


        // ENUMERADORES
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }


        // PROPIEDADES
        public List<Documento> ListaDocumentos { get => listaDocumentos; }
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca; }
        public TipoDoc Tipo { get => tipo; }    


        //CONSTRUCTOR
        public Escaner(string marca, TipoDoc tipo)
        {
            this.listaDocumentos = new List<Documento>();
            this.marca = marca;
            this.tipo = tipo;

            if(tipo == TipoDoc.mapa) 
            {
                this.locacion = Departamento.mapoteca;
            }
            else
            {
                this.locacion = Departamento.procesosTecnicos;
            }
        }


        // OPERADORES 
        public static bool operator ==(Escaner e, Documento d) 
        {
            /* Comprueba que el documento recibido por parámetro pertenezca a la lista del escáner recibido por parámetro y utiliza
             los operadores == de Libro y Mapa segun el caso.*/

            foreach (Documento doc in e.ListaDocumentos)
            {
                if (doc is Libro && d is Libro)
                {
                    if((Libro)doc == (Libro)d)
                    {
                        return true;

                    }
                }
                else if (doc is Mapa && d is Mapa)
                {
                    if ((Mapa)doc == (Mapa)d)
                    {
                        return true;
                    }
                }
            }
            return false;            
        }

        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);            
        }

        public static bool operator +(Escaner e, Documento d)
        {
            /* Si el documento recibido por parámetro no se encuentra en la lista de Documentos del escáner y
             su estado es "Inicio", se agrega a la lista y se avanza su estado a "Distribuido" */
            
            if((e.Tipo == Escaner.TipoDoc.mapa && d.GetType() == typeof(Mapa)) || (e.Tipo == Escaner.TipoDoc.libro && d.GetType() == typeof(Libro)))
            {                
                if(e != d && d.Estado == Documento.Paso.Inicio)
                {              
                    d.AvanzarEstado();
                    e.ListaDocumentos.Add(d);                    
                    return true;                
                }                
            }
            return false;
        }

        // MÉTODOS
        public bool CambiarEstadoDocumento(Documento d)
        {
            /* Este método cambia el estado del documento recibido por parámetro si se encuentra en la Lista 
               de documentos y utiliza el método "AvanzarEstado" de la clase Documento.*/

            foreach (Documento doc in ListaDocumentos)
            {
                if (doc == d)
                {                    
                    return d.AvanzarEstado();
                }
            }
            return false;
            
        }

    }
}
