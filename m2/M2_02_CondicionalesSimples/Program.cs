/*
2. Instrucciones condicionales simples.

Las instrucciones condicionales simples son las estructuras de control de flujo que permiten
que un programa ejecute o no un determinado bloque de instrucciones, dependiendo de si se
cumple una condición específica.

Una condición es una expresión que el programa evalúa y que solo puede dar como resultado uno
de dos valores posibles: verdadero o falso. Según ese resultado, el programa decide si debe
ejecutar o saltar el bloque de instrucciones asociado a esa condición.

Este tipo de instrucciones se consideran simples porque plantean una única alternativa: si la
condición se cumple, se realiza una acción determinada; si no se cumple, el programa
simplemente continúa con las instrucciones siguientes, sin ejecutar ese bloque.

Las condicionales simples son la base sobre la que se construyen estructuras de decisión más
complejas, como aquellas que contemplan alternativas adicionales o múltiples caminos posibles,
que se estudiarán en los siguientes temas de este módulo.

En resumen, las instrucciones condicionales simples permiten que un programa tome una decisión
básica: ejecutar o no un bloque de código, según si se cumple una única condición evaluada.
*/

namespace M2_02_CondicionalesSimples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero = 0;

            // Condicional simple
            if (numero > 0)
            {
                Console.WriteLine("El número es positivo.");
            }
        }
    }
}
