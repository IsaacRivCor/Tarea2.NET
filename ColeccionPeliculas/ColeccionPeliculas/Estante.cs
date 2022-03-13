using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionPeliculas
{
    internal class Estante
    {
        private int _numeroEstante;
        private List<Pelicula> _lista_peliculas;
        private string _genero;
        private string _formato;

        public int numeroEstante
        {
            get { return _numeroEstante; }
            set { _numeroEstante = value; }
        }
        public string genero
        {
            get { return _genero; }
            set { _genero = value; }
        }
        public string formato
        {
            get { return _formato; }
            set { _formato = value; }
        }

        public List<Pelicula> lista_peliculas
        {
            get { return _lista_peliculas; }
            set { _lista_peliculas = value; }
        }

        public Estante (int numero_estante, string genero, string formato)
        {
            this._numeroEstante = numero_estante;
            this._genero = genero;
            this._formato = formato;
            this._lista_peliculas = new List<Pelicula>(30);
        }

        public override string ToString()
        {
            return $"Numero: {_numeroEstante},Genero: {_genero}, fomrato: {_formato}";
        }
    }
}
