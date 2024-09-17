using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POO_5TO_LUCIO.Program;

namespace POO_5TO_LUCIO
{
    internal class Program
    {
        public class Persona
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Edad { get; set; }

            public const int MAYORIA_DE_EDAD = 18;

            public Persona(string nombre, string apellido, int edad)
            {
                Nombre = nombre;
                Apellido = apellido;
                Edad = edad;
            }

            public void Presentarse()
            {
                Console.WriteLine($"Hola, soy {Nombre} {Apellido}");
            }

            public bool EsMayorDeEdad()
            {
                return Edad >= MAYORIA_DE_EDAD;
            }
        }
        public class Direccion
        {
            public string Calle { get; set; }
            public int Altura { get; set; }
            public string Ciudad { get; set; }
            public string Barrio { get; set; }

            public Direccion(string calle, int altura, string ciudad, string barrio)
            {
                Calle = calle;
                Altura = altura;
                Ciudad = ciudad;
                Barrio = barrio;
            }

            public int ObtenerCodigoPostal()
            {
                return Altura * Calle.Length;
            }
        }
        public class Casa
        {
            public int Capacidad { get; set; }
            public string ColorExterior { get; set; }
            public Direccion Direccion { get; set; }
            public List<Persona> Habitantes { get; set; }

            public Casa(int capacidad, string colorExterior, Direccion direccion)
            {
                Capacidad = capacidad;
                ColorExterior = colorExterior;
                Direccion = direccion;
                Habitantes = new List<Persona>();
            }

            public string DescribirCasa()
            {
                return $"La casa tiene una capacidad de {Capacidad} personas y su color exterior es {ColorExterior}.";
            }

            public void PresentarHabitantes()
            {
                foreach (var persona in Habitantes)
                {
                    persona.Presentarse();
                }
            }

            public void PresentarMayoresDeEdad()
            {
                foreach (var persona in Habitantes)
                {
                    if (persona.EsMayorDeEdad())
                    {
                        persona.Presentarse();
                    }
                }
            }
        }

        public class CuentaBancaria
        {
            public Persona Titular { get; set; }
            public decimal Saldo { get; private set; }

            public CuentaBancaria(Persona titular, decimal saldoInicial)
            {
                Titular = titular;
                Saldo = saldoInicial;
            }

            public void Depositar(decimal monto)
            {
                if (monto > 0)
                {
                    Saldo += monto;
                }
                else
                {
                    Console.WriteLine("El monto a depositar debe ser positivo.");
                }
            }

            public void Retirar(decimal monto)
            {
                if (monto > 0 && monto <= Saldo)
                {
                    Saldo -= monto;
                }
                else
                {
                    Console.WriteLine("El monto a retirar debe ser positivo y menor o igual al saldo disponible.");
                }
            }

            public decimal ObtenerSaldo()
            {
                return Saldo;
            }
        }
        public class Producto
        {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int CantidadDisponible { get; set; }

            public Producto(string nombre, decimal precio, int cantidadDisponible)
            {
                Nombre = nombre;
                Precio = precio;
                CantidadDisponible = cantidadDisponible;
            }

            public void AjustarPrecio(decimal nuevoPrecio)
            {
                Precio = nuevoPrecio;
            }

            public void AjustarCantidadDisponible(int nuevaCantidad)
            {
                CantidadDisponible = nuevaCantidad;
            }

            public void MostrarInformacion()
            {
                Console.WriteLine($"Nombre: {Nombre}, Precio: {Precio}, Cantidad Disponible: {CantidadDisponible}");
            }
        }

        public class CarritoDeCompras
        {
            private List<Producto> productos;

            public CarritoDeCompras()
            {
                productos = new List<Producto>();
            }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void EliminarProducto(Producto producto)
        {
            productos.Remove(producto);
        }

        public void VaciarCarrito()
        {
            productos.Clear();
        }

        public decimal CalcularTotal()
        {
            return productos.Sum(p => p.Precio);
        }
    }
        public class Empleado : Persona
        {
            public string Puesto { get; set; }
            public decimal Salario { get; set; }

            public Empleado(string nombre, string apellido, int edad, string puesto, decimal salario)
                : base(nombre, apellido, edad)
            {
                Puesto = puesto;
                Salario = salario;
            }

            public void AumentarSalario(decimal porcentaje)
            {
                if (porcentaje > 0)
                {
                    Salario += Salario * porcentaje / 100;
                }
                else
                {
                    Console.WriteLine("El porcentaje debe ser positivo.");
                }
            }
        }
        public class Estudiante : Persona
        {
            public string Carrera { get; set; }
            public decimal Promedio { get; set; }

            public Estudiante(string nombre, string apellido, int edad, string carrera, decimal promedio)
                : base(nombre, apellido, edad)
            {
                Carrera = carrera;
                Promedio = promedio;
            }

            public void ActualizarPromedio(decimal nuevoPromedio)
            {
                if (nuevoPromedio >= 0 && nuevoPromedio <= 10)
                {
                    Promedio = nuevoPromedio;
                }
                else
                {
                    Console.WriteLine("El promedio debe estar entre 0 y 10.");
                }
            }
        }
        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }

            public Libro(string titulo, string autor)
            {
                Titulo = titulo;
                Autor = autor;
            }
        }
        public class Socio : Persona
        {
            public Socio(string nombre, string apellido, int edad) : base(nombre, apellido, edad)
            {
            }
        }

        public class Biblioteca
        {
            private List<Libro> libros;
            private List<Socio> socios;

            public Biblioteca()
            {
            libros = new List<Libro>();
            socios = new List<Socio>();
            }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void PrestarLibro(Libro libro, Socio socio)
        {
            if (libros.Contains(libro) && socios.Contains(socio))
            {
                libros.Remove(libro);
                Console.WriteLine($"{libro.Titulo} ha sido prestado a {socio.Nombre} {socio.Apellido}.");
            }
            else
            {
                Console.WriteLine("No se puede prestar el libro.");
            }
        }

        public void DevolverLibro(Libro libro, Socio socio)
        {
            if (socios.Contains(socio))
            {
                libros.Add(libro);
                Console.WriteLine($"{libro.Titulo} ha sido devuelto por {socio.Nombre} {socio.Apellido}.");
            }
            else
            {
                Console.WriteLine("El socio no está registrado.");
            }
        }
    }

    static void Main(string[] args)
        {
            {
                // Crear personas
                Persona persona1 = new Persona("Juan", "Pérez", 25);

                // Mostrar presentación de personas
                persona1.Presentarse();

                // Verificar mayoría de edad
                Console.WriteLine($"¿{persona1.Nombre} es mayor de edad? {persona1.EsMayorDeEdad()}");

                // Crear dirección
                Direccion direccion = new Direccion("Calle Falsa", 123, "Ciudad Ficticia", "Barrio Imaginario");

                // Crear casa
                Casa casa = new Casa(4, "Rojo", direccion);
                casa.Habitantes.Add(persona1);

                // Describir casa
                Console.WriteLine(casa.DescribirCasa());

                // Presentar habitantes
                casa.PresentarHabitantes();

                // Presentar mayores de edad
                casa.PresentarMayoresDeEdad();

                // Crear cuenta bancaria
                CuentaBancaria cuenta = new CuentaBancaria(persona1, 1000m);
                cuenta.Depositar(500m);
                cuenta.Retirar(200m);
                Console.WriteLine($"Saldo de la cuenta de {cuenta.Titular.Nombre}: {cuenta.ObtenerSaldo()}");

                // Crear productos
                Producto producto1 = new Producto("Laptop", 1200m, 5);
                Producto producto2 = new Producto("Mouse", 25m, 20);

                // Mostrar información de productos
                producto1.MostrarInformacion();
                producto2.MostrarInformacion();

                // Ajustar precio y cantidad
                producto1.AjustarPrecio(1100m);
                producto2.AjustarCantidadDisponible(15);
                producto1.MostrarInformacion();
                producto2.MostrarInformacion();

                // Crear carrito de compras
                CarritoDeCompras carrito = new CarritoDeCompras();
                carrito.AgregarProducto(producto1);
                carrito.AgregarProducto(producto2);

                // Calcular total del carrito
                Console.WriteLine($"Total del carrito: {carrito.CalcularTotal()}");

                // Crear empleado
                Empleado empleado = new Empleado("Carlos", "López", 30, "Desarrollador", 2000m);
                empleado.AumentarSalario(10); // Aumentar salario en un 10%
                Console.WriteLine($"Salario del empleado después del aumento: {empleado.Salario}");

                // Crear estudiante
                Estudiante estudiante = new Estudiante("Laura", "Martínez", 22, "Ingeniería", 8.5m);
                estudiante.ActualizarPromedio(9.0m);
                Console.WriteLine($"Nuevo promedio del estudiante: {estudiante.Promedio}");

                // Crear libros
                Libro libro1 = new Libro("El Gran Gatsby", "F. Scott Fitzgerald");
                Libro libro2 = new Libro("1984", "George Orwell");

                // Crear socios
                Socio socio1 = new Socio("Luis", "Fernández", 28);
                Socio socio2 = new Socio("Marta", "Paz", 35);

                // Crear biblioteca
                Biblioteca biblioteca = new Biblioteca();
                biblioteca.AgregarLibro(libro1);
                biblioteca.AgregarLibro(libro2);

                // Prestar y devolver libros
                biblioteca.PrestarLibro(libro1, socio1);
                biblioteca.DevolverLibro(libro1, socio1);

                Console.ReadKey();
            }
        }


    }
}

