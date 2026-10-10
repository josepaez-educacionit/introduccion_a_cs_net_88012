/*
1. Control de flujo de programa.

Cuando un programa se ejecuta, sus instrucciones se procesan normalmente una detrás de otra,
en el mismo orden en que fueron escritas. A esta ejecución ordenada y secuencial se le llama
flujo del programa.

Sin embargo, la mayoría de los programas necesitan tomar decisiones o repetir acciones según
ciertas condiciones, en lugar de limitarse a ejecutar todas sus instrucciones en línea recta.
El control de flujo es el conjunto de mecanismos del lenguaje que permiten alterar ese orden
básico de ejecución de forma controlada.

En C# existen principalmente dos tipos de estructuras de control de flujo: las estructuras
condicionales, que permiten ejecutar distintas instrucciones según si se cumple o no una
determinada condición, y las estructuras repetitivas, también llamadas bucles, que permiten
ejecutar un mismo bloque de instrucciones varias veces mientras se cumpla una condición.

Comprender el control de flujo es fundamental porque es lo que permite que un programa
reaccione de manera distinta ante diferentes situaciones, en lugar de comportarse siempre de la
misma forma sin importar los datos con los que trabaja.

En resumen, el control de flujo determina el camino que sigue la ejecución de un programa,
permitiendo tomar decisiones y repetir acciones de forma organizada y predecible.
*/


namespace M2_01_ControlDeFlujo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero = 10;

            // Estructura condicional
            if (numero > 0)
            {
                Console.WriteLine("El número es positivo.");
            }
            else
            {
                Console.WriteLine("El número no es positivo.");
            }

            // Estructura repetitiva
            for (int i = 0; i < numero; i++)
            {
                Console.WriteLine("Iteración: " + i);
            }
        }
    }
}
