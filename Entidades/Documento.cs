using System.Text;

namespace Entidades
{

    public abstract class Documento
    {
        //ENUMERADOR
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        //ATRIBUTOS
        private int anio;
        private string autor;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;

        //CONSTRUCTOR
        protected Documento(int anio, string autor, string barcode, string numNormalizado, string titulo)
        {
            this.anio = anio;
            this.autor = autor;
            this.barcode = barcode;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
            this.estado = Paso.Inicio;
        }

        //PROPIEDADES
        public int Anio { get => anio; }
        public string Autor { get => autor; }
        public string Barcode { get => barcode; }
        public Paso Estado { get => estado; }
        protected string NumNormalizado { get => numNormalizado; } //lo quiero solo disponible desde las clases derivadas
        public string Titulo { get => titulo; }


        //METODOS
        public bool AvanzarEstado()          
        {
            // Este método avanza el estado al siguiente paso, solo si el siguiente paso no es Terminado.

            if (this.Estado == Paso.Terminado)
            {
                return false;
            }
            this.estado++;
            return true;
        }

        public override string ToString() 
        {
            // Este metodo sobrecarga el metodo ToString() retornando una cadena que incluye el título, autor y año

            StringBuilder sb = new StringBuilder();
            sb.Append("Titulo: " + this.Titulo).AppendLine()
            .Append("Autor: " + this.Autor).AppendLine()
            .Append("Año: " + this.Anio);
            
            return sb.ToString();
        }
    }
}
