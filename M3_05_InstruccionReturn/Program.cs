namespace M3_05_InstruccionReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejecucion Ejemplo 1
            decimal precioConIva = CalcularPrecioConIva(100m, 21m);
            Console.WriteLine("Precio con IVA: $" + precioConIva);

            // Ejecucion Ejemplo 2
            int edad = 30;
            string clasificacionEdad = ClasificarEdad(edad);
            Console.WriteLine("Clasificación de edad: " + clasificacionEdad);

            // Ejecucion Ejemplo 3
            string[] productos = { }; // "Camiseta", "Pantalón", "Zapatos" };
            MostrarResumenCarrito(productos);

        }

        // Ejemplo 1: return con valor.
        // El método calcula un resultado y lo entrega a quien lo invocó; al ejecutar return termina.
        static decimal CalcularPrecioConIva(decimal precioNeto, decimal porcentajeIva)
        {
            decimal precioFinal = precioNeto + precioNeto * porcentajeIva / 100;
            return precioFinal;
        }

        // Ejemplo 2: return anticipado (cláusula de guarda) en un método con valor de retorno.
        // Apenas se conoce el resultado se sale del método, sin evaluar el resto de las condiciones.
        static string ClasificarEdad(int edad)
        {
            if (edad < 0)
            {
                return "Edad inválida";
            }

            if (edad < 18)
            {
                return "Menor de edad";
            }

            if (edad < 65)
            {
                return "Adulto";
            }

            return "Adulto mayor";
        }

        // Ejemplo 3: return sin valor en un método void.
        // Finaliza el método de forma anticipada cuando no hay nada que procesar.
        static void MostrarResumenCarrito(string[] productos)
        {
            if (productos.Length == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("Productos en el carrito: " + productos.Length);
            foreach (string producto in productos)
            {
                Console.WriteLine("- " + producto);
            }
        }
    }
}
