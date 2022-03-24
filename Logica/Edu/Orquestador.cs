using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Edu.Interfaces;
using Api.Edu.Modelo;
using Api.Edu.Utilidades;

namespace IRentBook.Logica.Edu
{
    public class Orquestador : IModerador
    {
        private static string rBack= @"C:\Users\Portatil\source\repos\IRentBook\Logica\Back";
        private static string rFront= @"C:\Users\Portatil\source\repos\IRentBook\Logica\Front";
        private Cargador carBack;
        private Cargador carFront;
        private Type type=null;
        public Orquestador()
        {
            carBack = new Cargador(rBack);
            carFront = new Cargador(rFront);
        }
        /*
        public void moderar()
        {
            
            //string ruta = Directory.GetCurrentDirectory();
            string ruta = @"C:\Users\Portatil\source\repos\ComponentesIRB\Componentes\Front";
            //ruta = Path.Combine(ruta, "Front");
            Console.WriteLine("Front");
            Cargador car = new Cargador(ruta);
            Type tipo = null;
            try
            {
                tipo = car.getClase("Api.Edu.Interfaces.IComunidad");
                dynamic ent = Activator.CreateInstance(tipo);
                Console.WriteLine(ent.registrarUsuario(new Usuario()));
                Console.WriteLine(ent.modificarUsuario(0, new Usuario()));
                Console.WriteLine(ent.eliminarUsuario(0));
            }
            catch (Exception exc)
            {
                Console.WriteLine("No hay proveedor de interfaz comunidad");
            }

            try
            {
                tipo = car.getClase("Api.Edu.Interfaces.IDomicilio");
                dynamic ent = Activator.CreateInstance(tipo);
                Console.WriteLine(ent.generarDomicilio(0, new Domicilio()));
                Console.WriteLine(ent.cancelarDomicilio(0, new Domicilio()));
            }
            catch (Exception exc)
            {
                Console.WriteLine("No hay proveedor de interfaz domicilio");
            }

            try
            {
                tipo = car.getClase("Api.Edu.Interfaces.IAccecibilidad");
                dynamic ent = Activator.CreateInstance(tipo);
                Console.WriteLine(ent.loggearUsuario(new Usuario()));
            }
            catch (Exception exc)
            {
                Console.WriteLine("No hay proveedor de interfaz accecibilidad");
            }

            //ruta = Directory.GetCurrentDirectory();
            //ruta = Path.Combine(ruta, "Back");
            ruta = @"C:\Users\Portatil\source\repos\ComponentesIRB\Componentes\Back";
            Console.WriteLine("");
            Console.WriteLine("Back");
            car = new Cargador(ruta);
            try
            {
                tipo = car.getClase("Api.Edu.Interfaces.IInventario");
                dynamic core = Activator.CreateInstance(tipo);
                Console.WriteLine(core.agregarLibro(new Libro()));
                Console.WriteLine(core.eliminarLibro(0));
            }
            catch (Exception exc)
            {
                Console.WriteLine("No hay proveedor de inventario");
            }

            try
            {
                tipo = car.getClase("Api.Edu.Interfaces.ISolicitudes");
                dynamic core = Activator.CreateInstance(tipo);
                Console.WriteLine(core.generarPrestamo(0, new Usuario()));
                Console.WriteLine(core.devolverPrestamo(0, new Usuario()));
            }
            catch (Exception exc)
            {
                Console.WriteLine("No hay proveedor de solicitudes");
                Console.WriteLine(exc);
            }
        }
        */       
        public void ModerarCrear(Usuario U)
        {
            type = carFront.getClase("Api.Edu.Interfaces.IUsuario");
            dynamic ent = Activator.CreateInstance(type);
            ent.agregarUsuario(U);
            //Añadir un catch en el controlador
        }

        public void ModerarEditar(Usuario U)
        {
            type = carFront.getClase("Api.Edu.Interfaces.IUsuario");
            dynamic ent = Activator.CreateInstance(type);
            ent.editarUsuario(U);
            //Añadir un catch en el controlador
        }

        public void ModerarEliminar(Usuario U)
        {
            type = carFront.getClase("Api.Edu.Interfaces.IUsuario");
            dynamic ent = Activator.CreateInstance(type);
            ent.eliminarUsuario(U);
            //Añadir un catch en el controlador
        }

        public List<Usuario> ModerarLeerU()
        {
            type = carFront.getClase("Api.Edu.Interfaces.IUsuario");
            dynamic ent = Activator.CreateInstance(type);
            return ent.getUsuarios();
            //Añadir un catch en el controlador
        }

        public List<Persona> ModerarLeerE()
        {
            type = carBack.getClase("Api.Edu.Interfaces.IEmpleado");
            dynamic ent = Activator.CreateInstance(type);
            return ent.GetEmpleados();
        }

        public Persona ModerarLoggearU(int codigo, string password)
        {
            type = carFront.getClase("Api.Edu.Interfaces.ILogger");
            dynamic ent = Activator.CreateInstance(type);
            return ent.loggear(codigo, password);
        }

        public void ModerarCrear(Libro U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.ILibro");
            dynamic ent = Activator.CreateInstance(type,U);
            ent.agregarLibro();
        }

        public void ModerarEditar(Libro U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.ILibro");
            dynamic ent = Activator.CreateInstance(type, U);
            ent.editarLibro();
        }

        public void ModerarEliminar(Libro U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.ILibro");
            dynamic ent = Activator.CreateInstance(type, U);
            ent.eliminarLibro();
        }

        public List<Libro> ModerarLeerL(Libro U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.ILibro");
            dynamic ent = Activator.CreateInstance(type, U);
            return ent.getLibros();
        }

        public void ModerarCrear(Pelicula U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.IPelicula");
            dynamic ent = Activator.CreateInstance(type, U);
            ent.agregarPelicula();
        }

        public void ModerarEditar(Pelicula U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.IPelicula");
            dynamic ent = Activator.CreateInstance(type, U);
            ent.editarPelicula();
        }

        public void ModerarEliminar(Pelicula U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.IPelicula");
            dynamic ent = Activator.CreateInstance(type, U);
            ent.eliminarPelicula();
        }

        public List<Pelicula> ModerarLeerP(Pelicula U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.IPelicula");
            dynamic ent = Activator.CreateInstance(type);
            return ent.getPeliculas();
        }

        public void ModerarCrear(Genero U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.IGenero");
            dynamic ent = Activator.CreateInstance(type);
            ent.agregarGenero(U);
        }

        public void ModerarEditar(Genero U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.IGenero");
            dynamic ent = Activator.CreateInstance(type);
            ent.editarGenero(U);
        }

        public void ModerarEliminar(Genero U)
        {
            type = carBack.getClase("Api.Edu.Interfaces.IGenero");
            dynamic ent = Activator.CreateInstance(type);
            ent.eliminarGenero(U);
        }

        public List<Genero> ModerarLeerG()
        {
            type = carBack.getClase("Api.Edu.Interfaces.IGenero");
            dynamic ent = Activator.CreateInstance(type);
           return ent.getGeneros();
        }

        public List<Prestamo> ModerarLeerPres()
        {
            type = carFront.getClase("Api.Edu.Interfaces.IPrestamo");
            dynamic ent = Activator.CreateInstance(type);
            return ent.prestamos();
        }
    }
}
