using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda_2._1._1
{

    internal class Ticket
    {
        private static int numeroCompra = 1000; // Inicialización del número de compra

        public List<Articulo> Lista { get; set; } = new List<Articulo>();
        public decimal Total { get; set; }
        public decimal Pagado { get; set; }
        public decimal Cambio { get; set; }
        public DateTime Fecha { get; set; }
        public int NumCompra { get; set; }
        public decimal IVA { get; set; }

        public Ticket()
        {
            NumCompra = numeroCompra++;
        }

        public void MostrarTicket()
        {
            Console.WriteLine("\n----- TICKET DE COMPRA -----");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Número de Compra: {NumCompra}");
            Console.WriteLine("\n--- Detalle de los Artículos Comprados ---");

            foreach (var articulo in Lista)
            {
                Console.WriteLine($"- {articulo.Nombre}: Cantidad: {articulo.Cantidad}, Precio Unitario: {articulo.Precio:F2} MXN, Subtotal: {articulo.CalcularSubtotal():F2} MXN");
            }

            Console.WriteLine("\n--- Resumen de la Compra ---");
            Console.WriteLine($"Total (sin IVA): {Total:F2} MXN");
            Console.WriteLine($"IVA (16%): {IVA:F2} MXN");
            Console.WriteLine($"Total (con IVA): {(Total + IVA):F2} MXN");
            Console.WriteLine($"Pagado: {Pagado:F2} MXN");
            Console.WriteLine($"Cambio: {Cambio:F2} MXN");
            Console.WriteLine("-----------------------------");
        }
    }
}
