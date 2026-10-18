/*
3. Instrucción break.

La instrucción break permite interrumpir de manera inmediata la ejecución de una estructura
repetitiva, como un while, un do...while o un for, o bien la de una instrucción switch, sin
esperar a que se cumpla la condición de finalización habitual de esa estructura.

Cuando el programa encuentra un break dentro de un bucle, abandona ese bucle de inmediato y
continúa la ejecución con la instrucción que se encuentra justo después de él, sin evaluar
nuevamente la condición del ciclo ni completar las repeticiones restantes.

Este comportamiento resulta útil cuando, durante la ejecución de un ciclo, se detecta una
situación que hace innecesario continuar repitiendo el bloque de código, permitiendo salir de
la estructura de forma anticipada y controlada.

En el caso de la instrucción switch, el break cumple una función similar: indica que, una vez
ejecutado el bloque correspondiente a un caso, el programa debe abandonar el switch en lugar de
continuar evaluando los casos siguientes.

Sintaxis:

    break;

Uso habitual dentro de un ciclo, normalmente condicionado por un if:

    while (condición)
    {
        if (condiciónDeCorte)
        {
            break;
        }
        // instrucciones que se ejecutan mientras no se haya interrumpido el ciclo
    }
    // la ejecución continúa aquí después del break

Explicación de cada parte:
- break: palabra reservada que interrumpe de inmediato la estructura que la contiene.
- ; (punto y coma): obligatorio al final de la instrucción.
- if (condiciónDeCorte): break casi siempre se ubica dentro de un if. Sin condición, el ciclo se
  interrumpiría siempre en la primera repetición.
- Alcance: break solo abandona la estructura más interna que lo contiene. En ciclos anidados,
  el ciclo exterior continúa su ejecución.
- Dentro de un switch, break se coloca al final de cada case para salir del switch.
- Fuera de un ciclo o de un switch, break produce un error de compilación.

En resumen, la instrucción break permite finalizar de forma anticipada un bucle o un switch,
interrumpiendo su ejecución antes de que se complete de la manera habitual.
*/

namespace M3_03_InstruccionBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: búsqueda de un elemento en una lista.
            // Una vez encontrado el producto no tiene sentido seguir recorriendo el resto,
            // por lo que break abandona el for de inmediato.
            string[] inventario = { "Teclado", "Mouse", "Monitor", "Auriculares", "Webcam" };
            string productoBuscado = "Celular";
            int posicionEncontrada = -1;

            for (int indice = 0; indice < inventario.Length; indice++)
            {
                if (inventario[indice] == productoBuscado)
                {
                    posicionEncontrada = indice;
                    break;
                }
            }

            if (posicionEncontrada >= 0)
            {
                Console.WriteLine(productoBuscado + " encontrado en la posición " + posicionEncontrada);
            }
            else
            {
                Console.WriteLine(productoBuscado + " no se encuentra en el inventario.");
            }


            // Ejemplo 2: interrupción del ciclo cuando se detecta una condición de corte.
            // Se procesan pagos hasta que el saldo disponible no alcanza para el siguiente.
            decimal saldoDisponible = 500m;
            decimal[] pagosPendientes = { 120m, 200m, 150m, 90m, 60m };

            for (int numeroPago = 0; numeroPago < pagosPendientes.Length; numeroPago++)
            {
                if (pagosPendientes[numeroPago] > saldoDisponible)
                {
                    Console.WriteLine("Saldo insuficiente para el pago de $" + pagosPendientes[numeroPago] + ". Proceso detenido.");
                    break;
                }

                saldoDisponible -= pagosPendientes[numeroPago];
                Console.WriteLine("Pago de $" + pagosPendientes[numeroPago] + " realizado. Saldo restante: $" + saldoDisponible);
            }

            // Ejemplo 3: break en un ciclo while(true) que se repite hasta que el usuario decide salir.
            // La condición de salida se evalúa dentro del cuerpo, no en el encabezado del while.
            while (true)
            {
                Console.Write("Ingrese un comando (ayuda / salir): ");
                string comando = Console.ReadLine();

                if (comando == "salir")
                {
                    Console.WriteLine("Programa finalizado.");
                    break;
                }

                if (comando == "ayuda")
                {
                    Console.WriteLine("Comandos disponibles: ayuda, salir.");
                }
                else
                {
                    Console.WriteLine("Comando no reconocido.");
                }
            }
        }
    }
}
