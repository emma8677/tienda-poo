using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda_2._1._1
{
    internal class Carrito
    {
        private List<Articulo> articulosEnCarrito = new List<Articulo>();

        public void AgregarArticulo(Articulo articulo)
        {
            // Verificar si el artículo ya existe en el carrito para aumentar la cantidad
            var articuloExistente = articulosEnCarrito.Find(a => a.ID == articulo.ID);
            if (articuloExistente != null)
            {
                articuloExistente.Cantidad++;  // Aumentar la cantidad si el artículo ya estaba en el carrito
            }
            else
            {
                articulosEnCarrito.Add(articulo);
            }
        }

        public List<Articulo> ObtenerArticulos()
        {
            return articulosEnCarrito;
        }

        public void MostrarArticulosEnCarrito()
        {
            Console.WriteLine("\n--- Artículos en el Carrito ---");
            if (articulosEnCarrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                foreach (var articulo in articulosEnCarrito)
                {
                    Console.WriteLine($"ID: {articulo.ID}, Nombre: {articulo.Nombre}, Cantidad: {articulo.Cantidad}, Precio Unitario: {articulo.Precio:C}, Subtotal: {articulo.CalcularSubtotal():C}");
                }
            }
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var articulo in articulosEnCarrito)
            {
                total += articulo.CalcularSubtotal();  // Calcular el total basado en el subtotal de cada artículo
            }
            return total;
        }
    }

}
