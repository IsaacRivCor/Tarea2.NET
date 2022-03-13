using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeccionPeliculas
{
    internal class ControlPeliculasAdmin
    {
        private List<Estante> _estantes;

        public ControlPeliculasAdmin()
        {
            _estantes = new List<Estante>();
        }

        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Control de Peliculas");
                Console.WriteLine("1.- Administrar Estantes");
                Console.WriteLine("2.- Administrar peliculas");
                Console.WriteLine("3.- Salir");
            } while (!validaMenu(3, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    showMenuAminEstantes();
                    break;
                case 2:
                    showMenuAdminPeliculas();
                    break;
                case 3:
                    break;
            }
        }

        private void showMenuAminEstantes()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Administración de Estantes");
                Console.WriteLine("1.- Listar");
                Console.WriteLine("2.- Crear");
                Console.WriteLine("3.- Eliminar");
                Console.WriteLine("4.- Regresar...");
            } while (!validaMenu(4, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    listarEstantes();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuAminEstantes();
                    break;
                case 2:
                    crearEstante();
                    break;
                case 3:
                    eliminarEstante();
                    break;
                case 4:
                    showMenuPrincipal();
                    break;
            }
        }

        private void eliminarEstante()
        {
            int numero;
            listarEstantes();
            numero = pedirValorInt("Escribe el numero del Estante a Eliminar");
            Estante? estanteEliminar = _estantes.FirstOrDefault(e => e.numeroEstante == numero);
            if (estanteEliminar == null)
            {
                Console.WriteLine("No se encontró el estante. Presiona 'Enter' para continuar...");
            }
            else
            {
                _estantes.Remove(estanteEliminar);
                Console.WriteLine($"El estante con numero: {estanteEliminar.numeroEstante} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            showMenuAminEstantes();
        }

        private void crearEstante()
        {
            int num_estante;
            string genero;
            string formato;
            Console.WriteLine("Añadiendo estante");
            num_estante = pedirValorInt("numero de estante");
            genero = pedirValorString("Genero");
            formato = pedirValorString("Formato de las peliculas");
            Estante nuevoEstante = new Estante(num_estante, genero, formato);
            _estantes.Add(nuevoEstante);
            Console.WriteLine("Estante añadido. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            showMenuAminEstantes();
        }

        private void listarEstantes()
        {
            Console.WriteLine("Lista de Estantes");
            foreach (Estante item in _estantes)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void showMenuAdminPeliculas()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Peliculas");
                Console.WriteLine("1.- Listar");
                Console.WriteLine("2.- Agregar");
                Console.WriteLine("3.- Editar");
                Console.WriteLine("4.- Eliminar");
                Console.WriteLine("5.- Regresar...");
            } while (!validaMenu(6, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    listarPeliculas();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuAdminPeliculas();
                    break;
                case 2:
                    agregarPelicula();
                    break;
                case 3:
                    editarPelicula();
                    break;
                case 4:
                    eliminarPelicula();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
            }
        }

        private void eliminarPelicula()
        {
            int? numeroEstante = -1;
            string? nombrePelicula;
            listarPeliculas();
            nombrePelicula = pedirValorString("Escribe el nombre de la pelicula a eliminar");
            Pelicula? peliculaEliminar = null;
            foreach (Estante item in _estantes)
            {
                //Console.WriteLine(item.ToString());
                peliculaEliminar = item.lista_peliculas.FirstOrDefault(p => p.nombre == nombrePelicula);
                numeroEstante = item.numeroEstante;
            }
            if (peliculaEliminar == null)
            {
                Console.WriteLine("No se encontró la pelicula. Presiona 'Enter' para continuar...");
            }
            else
            {
                Estante? estanteElminar = _estantes.FirstOrDefault(e => e.numeroEstante == numeroEstante);
                if (estanteElminar == null)
                {
                    Console.WriteLine("'Enter' para continuar...");
                }
                else
                {
                    estanteElminar.lista_peliculas.Remove(peliculaEliminar);
                    Console.WriteLine("se eliminó correctamente. Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                }
            }
            showMenuAdminPeliculas();
        }

        private void editarPelicula()
        {
            string? nombrePelicula;
            string productoraPelicula;
            string generoPelicula;
            int anioPelicula;
            string formatoPelicula;
            listarPeliculas();
            nombrePelicula = pedirValorString("Escribe el nombre de la pelicula a Editar");
            Pelicula? peliculaEdicion = null;
            foreach (Estante item in _estantes)
            {
                //Console.WriteLine(item.ToString());
                peliculaEdicion = item.lista_peliculas.FirstOrDefault(p => p.nombre == nombrePelicula);
            }

            if (peliculaEdicion == null)
            {
                Console.WriteLine("No se encontró la pelicula. Presiona 'Enter' para continuar...");
            }
            else
            {
                productoraPelicula = pedirValorString("Productora");
                generoPelicula = pedirValorString("genero");
                anioPelicula = pedirValorInt("año");
                formatoPelicula = pedirValorString("Formato de la pelicula");
                peliculaEdicion.productora = productoraPelicula;
                peliculaEdicion.genero = generoPelicula;
                peliculaEdicion.anio = anioPelicula;
                peliculaEdicion.formato = formatoPelicula;
                Console.WriteLine($"La pelicula con el nombre: {peliculaEdicion.nombre} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            showMenuAdminPeliculas();
        }

        private void agregarPelicula()
        {
            string? nombre;
            string productora;
            string genero;
            int anio;
            string formato;
            int num_estante;
            Console.WriteLine("Alta de Pelicula");
            nombre = pedirValorString("Nombre");
            productora = pedirValorString("Productora");
            genero = pedirValorString("Genero");
            anio = pedirValorInt("Año");
            formato = pedirValorString("Formato de la pelicula");
            num_estante = pedirValorInt("Numero del estante a guardar la pelicula");
            Pelicula nuevaPelicula = new Pelicula(nombre, productora, genero, anio, formato);
            Estante? estante = _estantes.FirstOrDefault(e => e.numeroEstante == num_estante);
            if (estante == null)
            {
                Console.WriteLine("Estante no encontrado");
            }
            else
            {
                if (estante.genero == genero && estante.formato == formato)
                {
                    estante.lista_peliculas.Add(nuevaPelicula);
                    List<Pelicula> sorted = estante.lista_peliculas.OrderBy(p => p.nombre).ToList();
                    estante.lista_peliculas = sorted;
                    //estante.lista_peliculas.Sort();
                }
                else
                {
                    Console.WriteLine("La pelicula no se puede agregar al estante seleccionado");
                }
            }
            Console.WriteLine("Pelicula agregada correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            showMenuAdminPeliculas();
        }

        private void listarPeliculas()
        {
            Console.WriteLine("Lista de Peliculas");
            foreach (Estante item in _estantes)
            {
                //Console.WriteLine(item.ToString());
                foreach (Pelicula itemPelicula in (List<Pelicula>)item.lista_peliculas)
                {
                    Console.WriteLine(itemPelicula.ToString());
                }
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
        public void inicializarDatos()
        {

            Estante estante1 = new Estante(1, "SyFy", "vhs");
            _estantes.Add(estante1);
            Estante estante2 = new Estante(2, "Drama", "DVD");
            _estantes.Add(estante2);
            Estante estante3 = new Estante(3, "Accion", "BlueRay");
            _estantes.Add(estante3);
            Estante estante4 = new Estante(4, "Fantasia", "vhs");
            _estantes.Add(estante4);
            Estante estante5 = new Estante(5, "Accion", "vhs");
            _estantes.Add(estante5);

            Pelicula pelicula6 = new Pelicula("Iron Man", "Marvel", "SyFy", 2008, "vhs");
            estante1.lista_peliculas.Add(pelicula6);
            Pelicula pelicula1 = new Pelicula("Vengadores", "Marvel", "SyFy", 2010, "vhs");
            estante1.lista_peliculas.Add(pelicula1);
            Pelicula pelicula2 = new Pelicula("Y donde estan las rubias", "Paramount", "Drama", 2004, "DVD");
            estante2.lista_peliculas.Add(pelicula2);
            Pelicula pelicula3 = new Pelicula("Jonh Wick", "MJW Films", "Accion", 2014, "BlueRay");
            estante3.lista_peliculas.Add(pelicula3);
            Pelicula pelicula4 = new Pelicula("El señor de los anillos", "New Line Cinema", "Fantasia", 2001, "vhs");
            estante4.lista_peliculas.Add(pelicula4);
            Pelicula pelicula5 = new Pelicula("Duro de matar", "Marvel", "20th Century fox", 1998, "vhs");
            estante5.lista_peliculas.Add(pelicula5);

        }

    }
}
