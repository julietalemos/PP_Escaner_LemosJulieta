using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Libro : Documento
    {
        private int numPaginas;

        //CONSTRUCTOR
        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(anio, autor, barcode, numNormalizado, titulo)
        {
            this.numPaginas = numPaginas;
        }

        //PROPIEDADES 
        public string ISBN
        { get => NumNormalizado; }

        public int NumPaginas
        { get => numPaginas; }

        //OPERADORES
        public static bool operator ==(Libro l1, Libro l2)
        {
            /*Considera que dos libros son iguales si tienen el mismo código de barras, el mismo ISBN, o el mismo título y autor. */

            return (l1.ISBN == l2.ISBN) || (l1.Barcode == l2.Barcode) || (l1.Autor == l2.Autor && l1.Titulo == l2.Titulo);
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            // Utiliza el operador == definido para implementar el operador !=

            return !(l1 == l2);
        }

        //METODO 

        public override string ToString()
        {
            // Este método arma el mensaje con la información. Reutiliza código de la clase Padre

            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).AppendLine()
            .Append("ISBN: " + this.ISBN).AppendLine()
            .Append("Cód. de barras: " + this.Barcode).AppendLine()
            .Append("Número de páginas: " + this.NumPaginas).AppendLine();

            return sb.ToString();
        }
    }
}
