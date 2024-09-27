using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda_2._1._1
{
    internal class Catalogo
    {
        private static List<Articulo> Inventario { get; set; }

        public static void LlenarCatalogo()
        {
            Inventario = new List<Articulo>
            {
                new Articulo {Nombre = "Jabón", Precio = 18.9m, ID = 1},
                new Articulo {Nombre = "Mayonesa", Precio = 20.6m, ID = 2},
                new Articulo {Nombre = "Tomate", Precio = 10.9m, ID = 3},
                new Articulo {Nombre = "Carne", Precio = 19.8m, ID = 4},
                new Articulo {Nombre = "Huevos", Precio = 30m, ID = 5},
            };
        }

        public static void MostrarCatalogo()
        {
            Console.WriteLine("\n--- Catálogo de Productos ---");
            foreach (Articulo art in Inventario)
            {
                Console.WriteLine($"{art.ID} - {art.Nombre} - Precio: {art.Precio:C}");
            }
        }

        public static Articulo BuscarArticuloPorID(int artID)
        {
            return Inventario.Find(articulo => articulo.ID == artID);
        }
    }
}
