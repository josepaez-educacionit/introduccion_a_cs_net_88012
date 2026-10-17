namespace M3_02_InstruccionFor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: recorrido de un rango conocido de valores.
            // Inicialización: numeroCuota = 1 | Condición: numeroCuota <= totalCuotas | Actualización: numeroCuota++
            int totalCuotas = 6;
            decimal montoPrestamo = 12000m;
            decimal valorCuota = montoPrestamo / totalCuotas;

            for (int numeroCuota = 1; numeroCuota <= totalCuotas; numeroCuota++)
            {
                Console.WriteLine("Cuota " + numeroCuota + " de " + totalCuotas + ": $" + valorCuota);
            }


            // Ejemplo 2: recorrido de un arreglo usando su longitud como límite.
            // El índice comienza en 0 y la condición usa < Length para no salirse del arreglo.
            string[] productos = { "Teclado", "Mouse", "Monitor", "Auriculares" };
            decimal[] precios = { 45.50m, 20.00m, 210.99m, 35.75m };
            decimal totalCompra = 0;

            for (int indice = 0; indice < productos.Length; indice++)
            {
                Console.WriteLine(productos[indice] + ": $" + precios[indice]);
                totalCompra += precios[indice];
            }

            //Console.WriteLine("Total de la compra: $" + totalCompra);

            // Ejemplo 3: cuenta regresiva con actualización decreciente.
            // La actualización no tiene por qué ser un incremento de uno en uno.
            for (int segundosRestantes = 10; segundosRestantes > 0; segundosRestantes -= 2)
            {
                Console.WriteLine("Tiempo restante: " + segundosRestantes + " segundos");
            }

            Console.WriteLine("Tiempo agotado.");
        }
    }
}
