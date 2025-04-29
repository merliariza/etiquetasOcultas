using System;
using System.Collections.Generic;
using System.Linq;

namespace demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Laptop HP", Categoria = "Electrónica", Precio = 3500, Stock = 10, ProveedorId = 1 },
                new Producto { Id = 2, Nombre = "Mouse Logitech", Categoria = "Electrónica", Precio = 150, Stock = 50, ProveedorId = 2 },
                new Producto { Id = 3, Nombre = "Silla de Oficina", Categoria = "Muebles", Precio = 800, Stock = 5, ProveedorId = 3 },
                new Producto { Id = 4, Nombre = "Cafetera Oster", Categoria = "Electrodomésticos", Precio = 600, Stock = 0, ProveedorId = 4 },
                new Producto { Id = 5, Nombre = "Escritorio Moderno", Categoria = "Muebles", Precio = 1200, Stock = 7, ProveedorId = 3 },
                new Producto { Id = 6, Nombre = "Monitor Samsung", Categoria = "Electrónica", Precio = 2500, Stock = 8, ProveedorId = 1 },
                new Producto { Id = 7, Nombre = "Teclado Mecánico", Categoria = "Electrónica", Precio = 400, Stock = 15, ProveedorId = 2 },
                new Producto { Id = 8, Nombre = "Aspiradora LG", Categoria = "Electrodomésticos", Precio = 1100, Stock = 2, ProveedorId = 4 }
            };

            List<Proveedor> proveedores = new List<Proveedor>
            {
                new Proveedor { Id = 1, Nombre = "TechSupply" },
                new Proveedor { Id = 2, Nombre = "Accesorios PC" },
                new Proveedor { Id = 3, Nombre = "Muebles XYZ" },
                new Proveedor { Id = 4, Nombre = "ElectroHome" }
            };

            var productosConEtiquetas = new List<(string Producto, List<string> Etiquetas)>
            {
                ("Laptop HP", new List<string> { "Electrónica", "Computadores", "Trabajo" }),
                ("Silla de Oficina", new List<string> { "Muebles", "Confort", "Oficina" }),
                ("Laptop HP", new List<string> { "Cocina", "Electrodomésticos", "Café" })
            };

            var etiquetas = (from p in productosConEtiquetas
                             from e in p.Etiquetas
                             select e).Distinct().ToList();

            Random rnd = new Random();
            string etiquetaOculta = etiquetas[rnd.Next(etiquetas.Count)];

            List<string> opciones = etiquetas.OrderBy(e => rnd.Next()).Take(4).ToList();

            if (!opciones.Contains(etiquetaOculta))
            {
                opciones[rnd.Next(opciones.Count)] = etiquetaOculta;
            }

            Console.WriteLine("Adivina la etiqueta oculta:");
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i]}");
            }

            Console.Write("Ingresa el número de la etiqueta: ");
            int seleccion;

            if (int.TryParse(Console.ReadLine(), out seleccion) &&
                seleccion >= 1 && seleccion <= opciones.Count)
            {
                if (opciones[seleccion - 1] == etiquetaOculta)
                {
                    Console.WriteLine("¡Correcto! Adivinaste la etiqueta.");
                }
                else
                {
                    Console.WriteLine($"Incorrecto. La etiqueta correcta era: {etiquetaOculta}");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
        }
    }

}
