/*
8. Instrucción cíclica while.

La instrucción while es una estructura de control de flujo que permite repetir la ejecución de
un bloque de código mientras se siga cumpliendo una determinada condición. A este tipo de
estructuras se les conoce como bucles o estructuras cíclicas.

Antes de cada repetición, el programa evalú la condición indicada junto a la palabra clave
while. Si el resultado es verdadero, se ejecuta el bloque de código asociado y, al finalizar,
se vuelve a evaluar la misma condición para decidir si corresponde repetirlo nuevamente.

Este ciclo continúa hasta que la condición evalúe como falsa, momento en el cual el programa
deja de repetir el bloque y continúa con las instrucciones siguientes. Si la condición nunca
llega a ser falsa, el bucle se repetirá de forma indefinida, situación que debe evitarse al
diseñar un programa.

La instrucción while resulta especialmente útil cuando no se conoce de antemano la cantidad
exacta de repeticiones necesarias, sino que esta depende de una condición que puede cambiar
durante la ejecución del programa.

En resumen, la instrucción while permite repetir un bloque de código mientras una condición
se mantenga verdadera, deteniendo la repetición en cuanto esta deja de cumplirse.
*/

namespace M2_08_InstruccionWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Caso 1: while controlado por un contador.
            // La variable se inicializa antes del ciclo, se evalúa en la condición y se
            // modifica dentro del bloque. Si se omitiera el incremento, la condición
            // nunca sería falsa y el ciclo se repetiría indefinidamente.
            int numeroIntento = 1;
            int maximoIntentos = 3;

            while (numeroIntento <= maximoIntentos)
            {
                Console.WriteLine($"Intento de conexión {numeroIntento} de {maximoIntentos}...");
                numeroIntento++;
            }

            // Caso 2: while controlado por un acumulador.
            // No se sabe de antemano cuántas repeticiones harán falta: el ciclo termina
            // cuando el saldo cubre el costo de la compra.
            decimal saldoDisponible = 0m;
            decimal costoCompra = 120m;
            decimal montoRecarga = 50m;
            int cantidadRecargas = 0;

            while (saldoDisponible < costoCompra)
            {
                saldoDisponible += montoRecarga;
                cantidadRecargas++;
                Console.WriteLine($"Recarga {cantidadRecargas}: saldo actual {saldoDisponible:C}.");
            }

            Console.WriteLine("Saldo suficiente para realizar la compra.");

            // Caso 3: while que procesa elementos mientras queden pendientes.
            // La condición se evalúa antes de cada repetición, por lo que si la
            // cantidad inicial fuera cero, el bloque no se ejecutaría ni una vez.
            int pedidosPendientes = 4;

            while (pedidosPendientes > 0)
            {
                Console.WriteLine($"Procesando pedido. Pendientes: {pedidosPendientes}.");
                pedidosPendientes--;
            }

            Console.WriteLine("Todos los pedidos fueron procesados.");
        }

    }
}
