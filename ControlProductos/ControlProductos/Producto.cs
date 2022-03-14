using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlProductos
{
    internal class Producto
    {
        private int _id_producto;
        private string _nombre;
        private string _tipo_producto;
        private double _valor_producto;
        private int _num_vendidos;

        public int id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string tipo_producto
        {
            get { return _tipo_producto; }
            set { _tipo_producto = value; }
        }
        public double valor_producto
        {
            get { return _valor_producto; }
            set { _valor_producto = value; }
        }
        public int num_vendidos
        {
            get { return _num_vendidos; }
            set { _num_vendidos = value; }
        }

        public Producto(int id_producto, string nombre, string tipo_producto, double valor_producto, int num_vendidos)
        {
            this._id_producto=id_producto;
            this._nombre = nombre;
            this._tipo_producto=tipo_producto;
            this._valor_producto=valor_producto;
            this._num_vendidos=num_vendidos;
        }
        public override string ToString()
        {
            return $"id del producto {_id_producto} ,Nombre producto {_nombre}, Cantidad vendidos {_num_vendidos}";
        }
    }
}
