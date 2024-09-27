using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tienda_2._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Llenar el catálogo con productos
            Catalogo.LlenarCatalogo();

            Carrito carrito = new Carrito();
            Ticket ticket = new Ticket();

            while (true)
            {
                Console.WriteLine("\nSelecciona el artículo (ingresa '0' para finalizar):");
                Catalogo.MostrarCatalogo();

                if (!int.TryParse(Console.ReadLine(), out int artID))
                {
                    Console.WriteLine("Por favor ingresa un número válido.");
                    continue;
                }

                if (artID == 0) break;

                Articulo articuloSeleccionado = Catalogo.BuscarArticuloPorID(artID);

                if (articuloSeleccionado != null)
                {
                    carrito.AgregarArticulo(articuloSeleccionado);
                    Console.WriteLine($"Artículo '{articuloSeleccionado.Nombre}' agregado al carrito.");
                }
                else
                {
                    Console.WriteLine("Artículo no encontrado.");
                }
            }

            // Mostrar los artículos en el carrito
            carrito.MostrarArticulosEnCarrito();

            // Calcular total y generar ticket
            decimal totalSinIVA = carrito.CalcularTotal();
            decimal iva = totalSinIVA * 0.16m; // 16% de IVA

            Console.WriteLine($"\nTotal a pagar (sin IVA): {totalSinIVA:C}");
            Console.WriteLine($"IVA (16%): {iva:C}");
            decimal totalConIVA = totalSinIVA + iva;
            Console.WriteLine($"Total a pagar (con IVA): {totalConIVA:C}");

            // Solicitar el monto pagado
            Console.WriteLine("Ingrese el monto con el que va a pagar:");
            decimal montoPagado;
            while (!decimal.TryParse(Console.ReadLine(), out montoPagado) || montoPagado < totalConIVA)
            {
                Console.WriteLine("El monto pagado es insuficiente. Ingrese un monto mayor o igual al total.");
            }

            decimal cambio = montoPagado - totalConIVA;

            // Llenar detalles del ticket
            ticket.Lista = carrito.ObtenerArticulos();
            ticket.Total = totalSinIVA;
            ticket.IVA = iva;
            ticket.Pagado = montoPagado;
            ticket.Cambio = cambio;
            ticket.Fecha = DateTime.Now;
            ticket.NumCompra = new Random().Next(1000, 9999); // Generar un número de compra aleatorio

            // Mostrar el ticket completo
            ticket.MostrarTicket();

            Console.WriteLine("Gracias por su compra.");

            // Pausar la ejecución para evitar que el programa se cierre inmediatamente
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();  // Pausa hasta que el usuario presione una tecla
        }
    }
}

