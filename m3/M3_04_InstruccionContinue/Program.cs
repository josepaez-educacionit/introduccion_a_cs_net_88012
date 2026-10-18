/*
4. Instrucción continue.

La instrucción continue se utiliza dentro de estructuras repetitivas, como el while, el
do...while o el for, para omitir el resto de las instrucciones que quedan en la repetición
actual del bucle y pasar directamente a la siguiente repetición.

A diferencia del break, que finaliza por completo el bucle, el continue no interrumpe la
estructura repetitiva en su totalidad, sino únicamente la vuelta en curso. Una vez ejecutado
el continue, el programa vuelve a evaluar la condición del bucle para determinar si
corresponde iniciar una nueva repetición.

Esta instrucción resulta útil cuando, durante una repetición, se detecta que no tiene sentido
continuar ejecutando el resto de las instrucciones de ese bloque para el caso actual, pero se
desea que el ciclo continúe normalmente con las repeticiones siguientes.

Utilizar continue permite evitar estructuras condicionales anidadas dentro de un bucle,
haciendo que el código resulte, en muchos casos, más simple y fácil de seguir.

Sintaxis:

    continue;

Uso habitual dentro de un ciclo, normalmente condicionado por un if:

    for (inicialización; condición; actualización)
    {
        if (condiciónDeOmisión)
        {
            continue;
        }
        // instrucciones que se omiten cuando se ejecuta el continue
    }

Explicación de cada parte:
- continue: palabra reservada que finaliza la repetición en curso y pasa a la siguiente.
- ; (punto y coma): obligatorio al final de la instrucción.
- if (condiciónDeOmisión): continue casi siempre se ubica dentro de un if. Sin condición, las
  instrucciones posteriores nunca se ejecutarían.
- Comportamiento según el ciclo:
  - En un for, el programa ejecuta la actualización y luego evalúa la condición.
  - En un while o do...while, el programa evalúa directamente la condición. Por eso la variable
    de control debe actualizarse antes del continue; de lo contrario, el ciclo podría repetirse
    indefinidamente.
- Alcance: continue afecta únicamente al ciclo más interno que lo contiene.
- Fuera de un ciclo, continue produce un error de compilación.

En resumen, la instrucción continue omite las instrucciones restantes de la repetición
actual de un bucle, permitiendo que la estructura continúe con la siguiente repetición.
*/

namespace M3_04_InstruccionContinue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: omitir los elementos que no cumplen un criterio.
            // Si el pedido está cancelado se salta el resto del cuerpo (no se suma ni se muestra)
            // y el for continúa con el pedido siguiente.
            string[] estadosPedidos = { "Entregado", "Cancelado", "Entregado", "Pendiente", "Cancelado", "Entregado" };
            decimal[] montosPedidos = { 150m, 80m, 200m, 120m, 60m, 95m };
            decimal totalFacturado = 0;

            for (int numeroPedido = 0; numeroPedido < estadosPedidos.Length; numeroPedido++)
            {
                if (estadosPedidos[numeroPedido] == "Cancelado")
                {
                    continue;
                }

                totalFacturado += montosPedidos[numeroPedido];
                Console.WriteLine("Pedido " + numeroPedido + " (" + estadosPedidos[numeroPedido] + "): $" + montosPedidos[numeroPedido]);
            }

            Console.WriteLine("Total facturado (sin cancelados): $" + totalFacturado);


            // Ejemplo 2: ignorar entradas inválidas y seguir procesando el resto.
            // Las lecturas fuera de rango se descartan y no afectan el promedio.
            int[] temperaturasRegistradas = { 22, 24, -999, 21, 25, -999, 23 };
            int sumaTemperaturas = 0;
            int lecturasValidas = 0;

            foreach (int temperatura in temperaturasRegistradas)
            {
                // -999 es el valor que emite el sensor cuando falla la lectura.
                if (temperatura == -999)
                {
                    continue;
                }

                sumaTemperaturas += temperatura;
                lecturasValidas++;
            }

            Console.WriteLine("Temperatura promedio: " + (double)sumaTemperaturas / lecturasValidas + " °C");


            // Ejemplo 3: continue en un while.
            // Es imprescindible actualizar la variable de control ANTES de continue;
            // de lo contrario el ciclo repetiría siempre la misma iteración sin terminar.
            int numeroLinea = 0;
            string[] lineasArchivo = { "# Configuración", "usuario=admin", "", "# Comentario", "puerto=8080" };

            while (numeroLinea < lineasArchivo.Length)
            {
                string lineaActual = lineasArchivo[numeroLinea];
                numeroLinea++;

                // Se omiten las líneas vacías y los comentarios.
                if (lineaActual == "" || lineaActual.StartsWith("#"))
                {
                    continue;
                }

                Console.WriteLine("Parámetro leído: " + lineaActual);
            }
        }
    }
}
