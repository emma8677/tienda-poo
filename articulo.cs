using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda_2._1._1
{
    internal class Articulo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; } = 1;  // Se añade una propiedad de cantidad, con valor inicial de 1

        // Método para calcular el subtotal según la cantidad
        public decimal CalcularSubtotal()
        {
            return Precio * Cantidad;
        }

        // Método para clonar el artículo (para evitar modificar el inventario original)
        public Articulo Clonar()
        {
            return new Articulo
            {
                ID = this.ID,
                Nombre = this.Nombre,
                Precio = this.Precio,
                Cantidad = this.Cantidad
            };
        }
    }
}
