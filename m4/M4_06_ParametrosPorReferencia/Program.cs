/*
6. Pasar parámetros por referencia.

Pasar un parámetro por referencia es una alternativa a la forma habitual de pasar parámetros
por valor, que permite que una función o un procedimiento trabajen directamente sobre el valor
original, en lugar de hacerlo sobre una copia de él.

Cuando un parámetro se pasa por referencia, cualquier modificación que se realice sobre él
dentro del bloque de código de la función o el procedimiento se refleja también en el valor
original, incluso después de que esa función o procedimiento hayan finalizado su ejecución.

En C#, esta forma de paso de parámetros debe indicarse explícitamente, tanto en la definición
de la función o el procedimiento como en el momento de invocarlos, para dejar en claro que se
está trabajando sobre el dato original y no sobre una copia.

Pasar parámetros por referencia resulta útil cuando se necesita que una función o un
procedimiento modifiquen directamente uno o varios valores originales, en lugar de limitarse a
entregar un único resultado mediante la instrucción return.

En resumen, pasar parámetros por referencia permite que una función o un procedimiento
modifiquen directamente el valor original recibido, a diferencia del paso por valor, en el que
solo se trabaja sobre una copia.
*/
namespace M4_06_ParametrosPorReferencia
{
    internal class Program
    {
        // La palabra clave "ref" en la definición indica que el parámetro trabaja sobre
        // el valor original y no sobre una copia. Es obligatoria también al invocar.
        static void AplicarInteres(ref decimal saldo, decimal porcentajeInteres)
        {
            saldo += saldo * porcentajeInteres / 100; // Modifica directamente la variable original.
        }

        // Caso habitual: modificar varios valores originales, algo que return no permite
        // porque solo puede entregar un único resultado.
        static void RealizarTransferencia(ref decimal saldoOrigen, ref decimal saldoDestino, decimal monto)
        {
            if (monto > saldoOrigen)
            {
                System.Console.WriteLine("Transferencia rechazada: saldo insuficiente.");
                return;
            }

            saldoOrigen -= monto;
            saldoDestino += monto;
        }

        // Caso clásico: intercambiar el contenido de dos variables.
        static void IntercambiarValores(ref int primerValor, ref int segundoValor)
        {
            int valorTemporal = primerValor;
            primerValor = segundoValor;
            segundoValor = valorTemporal;
        }

        static void Main()
        {
            // Ejemplo 1: la variable original se modifica tras la invocación.
            // Se indica "ref" también al pasar el argumento.
            decimal saldoCuenta = 10000m;
            AplicarInteres(ref saldoCuenta, 5m);
            System.Console.WriteLine("Saldo con interés: " + saldoCuenta); // 10500

            // Ejemplo 2: un único procedimiento actualiza dos variables originales.
            decimal saldoCuentaCorriente = 50000m;
            decimal saldoCajaAhorro = 20000m;

            RealizarTransferencia(ref saldoCuentaCorriente, ref saldoCajaAhorro, 15000m);
            System.Console.WriteLine("Cuenta corriente: " + saldoCuentaCorriente); // 35000
            System.Console.WriteLine("Caja de ahorro: " + saldoCajaAhorro);        // 35000

            // Si la transferencia es rechazada, los saldos originales no cambian.
            RealizarTransferencia(ref saldoCuentaCorriente, ref saldoCajaAhorro, 90000m);

            // Ejemplo 3: intercambio de valores entre dos variables.
            int turnoActual = 3;
            int turnoSiguiente = 8;

            IntercambiarValores(ref turnoActual, ref turnoSiguiente);
            System.Console.WriteLine("Turno actual: " + turnoActual + " | Turno siguiente: " + turnoSiguiente); // 8 y 3
        }
    }
}
