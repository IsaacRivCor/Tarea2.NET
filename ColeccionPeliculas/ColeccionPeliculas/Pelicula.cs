using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionPeliculas
{
    internal class Pelicula
    {
        private string _nombre;
        private string _productora;
        private string _genero;
        private int _anio;
        private string _formato;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string productora
        {
            get { return _productora; }
            set { _productora = value; }
        }
        public string genero
        {
            get { return _genero; }
            set { _genero = value; }
        }
        public int anio
        {
            get { return _anio; }
            set { _anio = value; }
        }
        public string formato
        {
            get { return _formato; }
            set { _formato = value; }
        }
        
        public Pelicula(string nombre, string productora, string genero, int anio, string formato)
        {
            this._nombre = nombre;
            this._productora = productora;
            this._genero = genero;
            this._anio = anio;
            this._formato = formato;
        }

        public override string ToString()
        {
            return _nombre;
        }
    }
}
