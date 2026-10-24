/*
5. Pasar parámetros por valor.

Pasar un parámetro por valor es la forma habitual en que, por defecto, se envía información a
una función o un procedimiento en C#. En esta modalidad, lo que se envía es una copia del
valor original, y no el dato original en sí mismo.

Como consecuencia de esto, cualquier modificación que se realice sobre el parámetro dentro del
bloque de código de la función o el procedimiento afecta únicamente a esa copia, sin alterar
de ninguna manera el valor original que se encontraba en la parte del programa desde la cual se
realizó la invocación.

Una vez que la función o el procedimiento finalizan su ejecución, la copia utilizada como
parámetro deja de existir, y el valor original permanece exactamente igual a como estaba antes
de esa invocación, sin importar los cambios que se hayan realizado internamente.

Este comportamiento resulta útil porque brinda seguridad: permite tener la certeza de que
invocar una función o un procedimiento no modificará accidentalmente los datos originales que
se le proporcionaron como parámetros.

En resumen, pasar parámetros por valor significa trabajar sobre una copia del dato original,
de modo que los cambios realizados dentro de la función o el procedimiento no afectan al valor
original.
*/
namespace M4_05_ParametrosPorValor
{
    internal class Program
    {
        // El parámetro "saldo" recibe una COPIA del valor original.
        // Modificarlo dentro de la función no altera la variable que se usó al invocarla.
        static decimal CalcularSaldoConInteres(decimal saldo, decimal porcentajeInteres)
        {
            saldo += saldo * porcentajeInteres / 100; // Se modifica la copia local.
            System.Console.WriteLine("Dentro de la función, saldo con interés: " + saldo);

            return saldo; // Para obtener el resultado fuera, es necesario devolverlo.
        }

        // En un procedimiento ocurre lo mismo: los cambios sobre el parámetro
        // afectan solo a la copia y se pierden al finalizar la ejecución.
        static void AplicarDescuentoEnCaja(decimal precio, decimal porcentajeDescuento)
        {
            precio -= precio * porcentajeDescuento / 100; // Se modifica la copia local.
            System.Console.WriteLine("Dentro del procedimiento, precio con descuento: " + precio);
        }

        // Caso habitual: se modifica el parámetro para normalizar un dato antes de usarlo,
        // con la seguridad de que el texto original que proporcionó el usuario no cambia.
        static string FormatearNombreParaEtiqueta(string nombre)
        {
            nombre = nombre.Trim().ToUpper(); // Se reasigna la copia local.
            return "CLIENTE: " + nombre;
        }

        static void Main()
        {
            // Ejemplo 1: función que modifica su parámetro internamente.
            decimal saldoCuenta = 10000m;
            decimal saldoProyectado = CalcularSaldoConInteres(saldoCuenta, 5m);

            System.Console.WriteLine("Saldo original: " + saldoCuenta);         // Sigue siendo 10000
            System.Console.WriteLine("Saldo proyectado: " + saldoProyectado);   // Es 10500

            // Ejemplo 2: procedimiento que modifica su parámetro internamente.
            decimal precioProducto = 25000m;
            AplicarDescuentoEnCaja(precioProducto, 10m);

            System.Console.WriteLine("Precio del producto tras la invocación: " + precioProducto); // Sigue siendo 25000

            // Ejemplo 3: el dato original se conserva intacto aunque la función lo normalice.
            string nombreIngresado = "  ana gómez ";
            string etiqueta = FormatearNombreParaEtiqueta(nombreIngresado);

            System.Console.WriteLine("Nombre ingresado: [" + nombreIngresado + "]");
            System.Console.WriteLine("Etiqueta generada: [" + etiqueta + "]");
        }
    }
}
