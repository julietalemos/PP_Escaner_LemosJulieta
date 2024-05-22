using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Mapa : Documento
    {
        private int alto;
        private int ancho;

        //PROPIEDADES

        public int Alto
        { get => alto; }

        public int Ancho
        { get => ancho; }

        public int Superficie
        { get => ancho * alto; }

        // CONSTRUCTOR

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto)
            : base(anio, autor, codebar, "", titulo)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        //OPERADORES
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            /* Considera que dos mapas son iguales si tienen el mismo código de barras o el mismo título, autor, año y superficie.  */
            
            return m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Anio == m2.Anio && m1.Autor == m2.Autor && m1.Superficie == m2.Superficie);
            
        }

        public static bool operator !=(Mapa m1, Mapa m2)
        {
            // Utiliza el operador == definido para implementar el operador !=

            return !(m1 == m2);
        }

        // MÉTODO TOSTRING
        public override string ToString() 
        {
            // Este método arma el mensaje con la información. Reutiliza código de la clase Padre

            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString()).AppendLine()
            .Append("Cód. de barras: " + this.Barcode).AppendLine()
            .Append("Superficie: " + this.ancho + " * " + this.alto + " = " + this.Superficie + " cm2.").AppendLine();

            return sb.ToString();
        }
    }
}
