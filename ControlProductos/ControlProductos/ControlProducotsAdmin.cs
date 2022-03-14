using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlProductos
{
    internal class ControlProducotsAdmin
    {
        private List<Producto> _productos_belleza;
        private List<Producto> _productos_ropa;
        private List<Producto> _productos_hogar;
        private List<Producto> _productos_limpieza;

        public ControlProducotsAdmin()
        {
            _productos_belleza = new List<Producto>();
            _productos_ropa = new List<Producto>();
            _productos_hogar = new List<Producto>();
            _productos_limpieza = new List<Producto>();
        }

        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("1.- Listar productos");
                Console.WriteLine("2.- Agregar producto");
                Console.WriteLine("3.- Editar producto");
                Console.WriteLine("4.- Eliminar producto");
                Console.WriteLine("5.- Calcular tipo de producto más vendido");
                Console.WriteLine("6.- salir...");
            } while (!validaMenu(6, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    listarProductos();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuPrincipal();
                    break;
                case 2:
                    agregarProducto();
                    break;
                case 3:
                    editarProducto();
                    break;
                case 4:
                    eliminarProducto();
                    break;
                case 5:
                    calcularTipoProductoMasVendito();
                    break;
                case 6:
                    break;
            }
        }
        private void calcularTipoProductoMasVendito()
        {
            double sumatoria_belleza = 0.0;
            double sumatoria_ropa = 0.0;
            double sumatoria_hogar = 0.0;
            double sumatoria_limpieza = 0.0;
            foreach (Producto item in _productos_belleza)
            {
                sumatoria_belleza = sumatoria_belleza + (item.valor_producto * item.num_vendidos);
            }
            foreach (Producto item in _productos_ropa)
            {
                sumatoria_ropa = sumatoria_ropa + (item.valor_producto * item.num_vendidos);
            }
            foreach (Producto item in _productos_hogar)
            {
                sumatoria_hogar = sumatoria_hogar + (item.valor_producto * item.num_vendidos);
            }
            foreach (Producto item in _productos_limpieza)
            {
                sumatoria_limpieza = sumatoria_limpieza + (item.valor_producto * item.num_vendidos);
            }

            if (sumatoria_belleza >= sumatoria_ropa && sumatoria_belleza >= sumatoria_hogar && sumatoria_belleza >= sumatoria_limpieza)
            {
                Console.WriteLine($"Los producotos más vendidos fuenron los de blleza con {sumatoria_belleza}");
            }
            else if(sumatoria_ropa >= sumatoria_belleza && sumatoria_ropa >= sumatoria_hogar && sumatoria_ropa >= sumatoria_limpieza)
            {
                Console.WriteLine($"Los producotos más vendidos fuenron los de ropa con {sumatoria_ropa}");
            }
            else if (sumatoria_hogar >= sumatoria_ropa && sumatoria_hogar >= sumatoria_belleza && sumatoria_hogar >= sumatoria_limpieza)
            {
                Console.WriteLine($"Los producotos más vendidos fuenron los de blleza con {sumatoria_hogar}");
            }
            else if (sumatoria_limpieza >= sumatoria_ropa && sumatoria_limpieza >= sumatoria_hogar && sumatoria_limpieza >= sumatoria_belleza)
            {
                Console.WriteLine($"Los producotos más vendidos fuenron los de blleza con {sumatoria_limpieza}");
            }
            else
            {
                Console.WriteLine("Se encontraron más de un tipo de producots con la misma cantidad de ganancias");
            }
            Console.WriteLine("Presiona 'Enter' para continuar...");
            Console.ReadLine();
        }
        private void eliminarProducto()
        {
            int? id_producto;
            string tipo_producto;
            listarProductos();
            id_producto = pedirValorInt("Escribe el id del producto a eliminar");
            tipo_producto = pedirValorString("Escribe el tipo del producto a eliminar");
            Producto? productoEliminar = null;
            if (tipo_producto == "Belleza")
            {
                productoEliminar = _productos_belleza.FirstOrDefault(p => p.id_producto == id_producto);
            }
            else if (tipo_producto == "Ropa")
            {
                productoEliminar = _productos_ropa.FirstOrDefault(p => p.id_producto == id_producto);
            }
            else if (tipo_producto == "Hogar")
            {
                productoEliminar = _productos_hogar.FirstOrDefault(p => p.id_producto == id_producto);
            }
            else if (tipo_producto == "Limpieza")
            {
                productoEliminar = _productos_limpieza.FirstOrDefault(p => p.id_producto == id_producto);
            }

            if (productoEliminar == null)
            {
                Console.WriteLine("No se encontró el producto. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            else
            {
                if (tipo_producto == "Belleza")
                {
                    _productos_belleza.Remove(productoEliminar);
                }
                else if (tipo_producto == "Ropa")
                {
                    _productos_ropa.Remove(productoEliminar);
                }
                else if (tipo_producto == "Hogar")
                {
                    _productos_hogar.Remove(productoEliminar);
                }
                else if (tipo_producto == "Limpieza")
                {
                    _productos_limpieza.Remove(productoEliminar);
                }
                Console.WriteLine("El producto se eliminó correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            showMenuPrincipal();
        }

        private void editarProducto()
        {
            int? id_producto;
            string nombre_producto;
            string tipo_producto;
            double valor_producto;
            int cantidad_vendidos;
            listarProductos();
            id_producto = pedirValorInt("Escribe el id del producto a Editar");
            tipo_producto = pedirValorString("Escribe el tipo del producto a editar");
            Producto? productoEdicion = null;
            if (tipo_producto == "Belleza")
            {
                productoEdicion = _productos_belleza.FirstOrDefault(p => p.id_producto == id_producto);
            }
            else if (tipo_producto == "Ropa")
            {
                productoEdicion = _productos_ropa.FirstOrDefault(p => p.id_producto == id_producto);
            }
            else if (tipo_producto == "Hogar")
            {
                productoEdicion = _productos_hogar.FirstOrDefault(p => p.id_producto == id_producto);
            }
            else if (tipo_producto == "Limpieza")
            {
                productoEdicion = _productos_limpieza.FirstOrDefault(p => p.id_producto == id_producto);
            }

            if (productoEdicion == null)
            {
                Console.WriteLine("No se encontró el producto. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            else
            {
                nombre_producto = pedirValorString("Nombre");
                valor_producto = pedirValorDouble("Valor");
                cantidad_vendidos = pedirValorInt("Cantidad vendidos");
                productoEdicion.nombre = nombre_producto;
                productoEdicion.valor_producto = valor_producto;
                productoEdicion.num_vendidos = cantidad_vendidos;
                Console.WriteLine($"El producto con el nombre: {productoEdicion.nombre} se editó correctamente. Presiona 'Enter' para continuar...");
                Console.WriteLine("Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            showMenuPrincipal();
        }

        private void agregarProducto()
        {
            int id_producto;
            string? nombre;
            string tipo_producto;
            double valor_producto;
            int num_vendidos;
            
            Console.WriteLine("Alta de Producto");
            id_producto = pedirValorInt("Id del producto");
            nombre = pedirValorString("Nombre");
            tipo_producto = pedirValorString("Tipo del producto");
            valor_producto = pedirValorDouble("Valor del producto");
            num_vendidos = pedirValorInt("Numero de unidades vendidas");
            Producto nuevoProducto = new Producto(id_producto, nombre, tipo_producto, valor_producto, num_vendidos);
            
            if (tipo_producto == "Belleza")
            {
                _productos_belleza.Add(nuevoProducto);
                Console.WriteLine("Producto agregada correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            else if (tipo_producto == "Ropa")
            {
                _productos_ropa.Add(nuevoProducto);
                Console.WriteLine("Producto agregada correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            else if (tipo_producto == "Hogar")
            {
                _productos_hogar.Add(nuevoProducto);
                Console.WriteLine("Producto agregada correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            else if (tipo_producto == "Limpieza")
            {
                _productos_limpieza.Add(nuevoProducto);
                Console.WriteLine("Producto agregada correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Tipo de producto invalido, no se pudo agregar. Presiona 'Enter' para continuar...");
                Console.ReadLine();
            }
            showMenuPrincipal();
        }

        private void listarProductos()
        {
            Console.WriteLine("Lista de productos de Belleza");
            foreach (Producto item in _productos_belleza)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Lista de productos de Ropa");
            foreach (Producto item in _productos_ropa)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Lista de productos de Hogar");
            foreach (Producto item in _productos_hogar)
            {
                Console.WriteLine(item.ToString());

            }
            Console.WriteLine("Lista de productos de Limpieza");
            foreach (Producto item in _productos_limpieza)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private bool validaMenu(int opciones, ref int opcionSeleccionada)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones)
                {
                    opcionSeleccionada = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción Invalida.");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido, debes ingresar un número.");
                return false;
            }
        }
        private string pedirValorString(string texto)
        {
            string? valor;
            do
            {
                Console.Write($"{texto}: ");
                valor = Console.ReadLine();
                if (valor == null || valor == "")
                {
                    Console.WriteLine("Valor inválido.");
                }
            } while (valor == null || valor == "");
            return valor;
        }
        private int pedirValorInt(string texto)
        {
            int valor;
            Console.Write($"{texto}: ");
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Debes ingresar un número.");
                Console.Write($"{texto}: ");
            }
            return valor;
        }
        private double pedirValorDouble(string texto)
        {
            double valor;
            Console.Write($"{texto}: ");
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Debes ingresar un número.");
                Console.Write($"{texto}: ");
            }
            return valor;
        }
        public void inicializarDatos()
        {
            Producto producto1 = new Producto(0001, "Labial", "Belleza", 150, 10);
            _productos_belleza.Add(producto1);
            Producto producto2 = new Producto(0002, "Rimel", "Belleza", 160, 9);
            _productos_belleza.Add(producto2);
            Producto producto3 = new Producto(0001, "Pantalon Mezclilla", "Ropa", 600, 5);
            _productos_ropa.Add(producto3);
            Producto producto4 = new Producto(0002, "Falda larga", "Ropa", 450, 6);
            _productos_ropa.Add(producto4);
            Producto producto5 = new Producto(0001, "Sabanas blancas", "Hogar", 200, 7);
            _productos_hogar.Add(producto5);
            Producto producto6 = new Producto(0002, "Cobija de tigre", "Hogar", 300, 8);
            _productos_hogar.Add(producto6);
            Producto producto7 = new Producto(0001, "Jabon para ropa", "Limpieza", 90, 15);
            _productos_limpieza.Add(producto7);
            Producto producto8 = new Producto(0002, "Limpiador de ventanas", "Limpieza", 60, 10);
            _productos_limpieza.Add(producto8);
        }
    }
}
