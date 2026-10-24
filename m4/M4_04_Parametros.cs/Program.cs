/*
4. Parámetros.

Los parámetros son los datos de entrada que una función o un procedimiento pueden recibir para
llevar a cabo la tarea que tienen asignada. Gracias a ellos, un mismo bloque de código puede
comportarse de manera distinta según la información que se le proporcione en cada ocasión en
que es invocado.

Cada parámetro se define indicando el tipo de dato que debe recibir y el nombre con el que se
hará referencia a ese valor dentro del bloque de código correspondiente. Una función o un
procedimiento pueden definir uno, varios o ningún parámetro, según la información que
necesiten para cumplir su tarea.

Cuando se invoca una función o un procedimiento, se deben proporcionar los valores concretos
que corresponden a cada uno de los parámetros definidos. A esos valores concretos se les
conoce como argumentos, y son los que efectivamente se utilizan durante esa ejecución en
particular.

Gracias a los parámetros, es posible escribir un único bloque de código capaz de resolver una
misma tarea para distintos datos de entrada, evitando tener que crear una versión diferente de
esa solución para cada caso particular.

En resumen, los parámetros permiten que una función o un procedimiento reciban la información
necesaria para realizar su tarea, adaptándose a los distintos valores que se les proporcionen
en cada invocación.
*/
namespace M4_04_Parametros.cs
{
    internal class Program
    {
        // Sin parámetros: no necesita información externa para realizar su tarea.
        static string ObtenerTituloAplicacion()
        {
            return "Sistema de facturación";
        }

        // Un parámetro: "monto" es el parámetro, es decir, el dato de entrada que la función espera recibir.
        static decimal CalcularIva(decimal monto)
        {
            const decimal tasaIva = 0.21m;
            return monto * tasaIva;
        }

        // Varios parámetros: cada uno define un tipo y un nombre.
        // Los argumentos deben entregarse en el mismo orden y con tipos compatibles.
        static decimal CalcularTotalFactura(decimal subtotal, decimal porcentajeDescuento, bool incluyeIva)
        {
            decimal totalConDescuento = subtotal - (subtotal * porcentajeDescuento / 100);

            if (incluyeIva)
            {
                totalConDescuento += CalcularIva(totalConDescuento);
            }

            return totalConDescuento;
        }

        // Parámetros en un procedimiento: la acción se adapta a los datos recibidos.
        static void MostrarResumenFactura(string cliente, int numeroFactura, decimal total)
        {
            System.Console.WriteLine("Factura N° " + numeroFactura + " | Cliente: " + cliente + " | Total: " + total);
        }

        static void Main()
        {
            // Invocación sin argumentos, porque la función no define parámetros.
            System.Console.WriteLine(ObtenerTituloAplicacion());

            // Los valores entre paréntesis son los argumentos: los datos concretos
            // que se utilizan durante esta ejecución en particular.
            decimal iva = CalcularIva(10000m);
            System.Console.WriteLine("IVA: " + iva);

            // El mismo código resuelve distintos casos según los argumentos entregados.
            decimal totalSinDescuento = CalcularTotalFactura(20000m, 0m, true);
            decimal totalConDescuento = CalcularTotalFactura(20000m, 15m, true);
            decimal totalExento = CalcularTotalFactura(20000m, 15m, false);

            // Los argumentos pueden ser valores literales, variables o resultados de otras funciones.
            string nombreCliente = "Ana Gómez";
            MostrarResumenFactura(nombreCliente, 1001, totalSinDescuento);
            MostrarResumenFactura("Carlos Ruiz", 1002, totalConDescuento);
            MostrarResumenFactura("Laura Díaz", 1003, totalExento);

            // Los argumentos con nombre permiten indicar a qué parámetro corresponde cada valor,
            // lo que mejora la legibilidad cuando hay varios parámetros del mismo tipo o de significado poco evidente.
            decimal totalFinal = CalcularTotalFactura(subtotal: 8500m, porcentajeDescuento: 5m, incluyeIva: true);
            System.Console.WriteLine("Total final: " + totalFinal);
        }
    }
}
