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

            bool continuarComprando = true;

            while (continuarComprando)
            {
                Carrito carrito = new Carrito();
                Ticket ticket = new Ticket();

                Console.WriteLine("\n--- Nueva Compra ---");

                while (true)
                {
                    Console.WriteLine("\nSelecciona el artículo (ingresa '0' para finalizar la selección):");
                    Catalogo.MostrarCatalogo();

                    string entrada = Console.ReadLine();

                    if (!int.TryParse(entrada, out int artID))
                    {
                        Console.WriteLine("Por favor, ingresa un número válido.");
                        continue;
                    }

                    if (artID == 0)
                        break;

                    Articulo articuloSeleccionado = Catalogo.BuscarArticuloPorID(artID);

                    if (articuloSeleccionado != null)
                    {
                        carrito.AgregarArticulo(articuloSeleccionado);
                        Console.WriteLine($"Artículo '{articuloSeleccionado.Nombre}' agregado al carrito.");
                    }
                    else
                    {
                        Console.WriteLine("Artículo no encontrado. Por favor, intenta nuevamente.");
                    }
                }

                // Mostrar los artículos en el carrito
                carrito.MostrarArticulosEnCarrito();

                if (carrito.ObtenerArticulos().Count == 0)
                {
                    Console.WriteLine("No se ha seleccionado ningún artículo. La compra se cancelará.");
                }
                else
                {
                    // Calcular total y generar ticket
                    decimal totalSinIVA = carrito.CalcularTotal();
                    decimal iva = Math.Round(totalSinIVA * 0.16m, 2); // 16% de IVA redondeado a 2 decimales

                    decimal totalConIVA = totalSinIVA + iva;

                    // Solicitar el monto pagado
                    decimal montoPagado;
                    while (true)
                    {
                        Console.WriteLine($"\nTotal a pagar (sin IVA): {totalSinIVA:F2} MXN");
                        Console.WriteLine($"IVA (16%): {iva:F2} MXN");
                        Console.WriteLine($"Total a pagar (con IVA): {totalConIVA:F2} MXN");
                        Console.WriteLine("Ingrese el monto con el que va a pagar:");

                        string pagoEntrada = Console.ReadLine();

                        if (!decimal.TryParse(pagoEntrada, out montoPagado))
                        {
                            Console.WriteLine("Por favor, ingresa un monto válido.");
                            continue;
                        }

                        if (montoPagado < totalConIVA)
                        {
                            Console.WriteLine("El monto pagado es insuficiente. Ingrese un monto mayor o igual al total.");
                            continue;
                        }

                        break;
                    }

                    decimal cambio = Math.Round(montoPagado - totalConIVA, 2);

                    // Llenar detalles del ticket
                    ticket.Lista = carrito.ObtenerArticulos();
                    ticket.Total = Math.Round(totalSinIVA, 2);
                    ticket.IVA = iva;
                    ticket.Pagado = Math.Round(montoPagado, 2);
                    ticket.Cambio = cambio;
                    ticket.Fecha = DateTime.Now;

                    // Mostrar el ticket completo
                    ticket.MostrarTicket();

                    Console.WriteLine("Gracias por su compra.");
                }

                // Preguntar si desea realizar otra compra
                Console.WriteLine("\n¿Desea realizar otra compra? (S/N):");
                string respuesta = Console.ReadLine().Trim().ToUpper();

                if (respuesta != "S")
                {
                    continuarComprando = false;
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();  // Pausa hasta que el usuario presione una tecla
        }
    }
}
