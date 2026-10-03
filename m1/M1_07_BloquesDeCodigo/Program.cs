/*
7. Bloques de código.

A medida que un programa crece, resulta necesario agrupar varias sentencias relacionadas para
que se ejecuten en conjunto, como si formaran una sola unidad. En C#, esta agrupación se logra
mediante los bloques de código, que se delimitan utilizando llaves de apertura y cierre.

Todo lo que se encuentra dentro de un bloque se considera parte de una misma sección lógica del
programa. Los bloques se utilizan, por ejemplo, para definir el contenido de un método, el
cuerpo de una repetición o las acciones que deben realizarse cuando se cumple una determinada
condición.

Además de agrupar instrucciones, los bloques de código determinan el alcance de las variables
que se declaran dentro de ellos, es decir, la región del programa en la que esa variable existe
y puede utilizarse. Una vez que la ejecución sale del bloque, las variables declaradas en su
interior dejan de estar disponibles.

En conclusión, los bloques de código son una herramienta clave para organizar un programa de
forma clara y ordenada, facilitando tanto su lectura como su mantenimiento posterior.
*/

// Ejemplos:

using System;

class Program
{
    static void Main()
    {
        // ===== Bloque de código independiente dentro de un método =====
        Console.WriteLine("===== Bloque de código independiente =====");
        {
            int valorEnBloque = 10;
            Console.WriteLine("Valor de valorEnBloque dentro del bloque: " + valorEnBloque);
        }
        // El siguiente código generaría un error porque valorEnBloque no está disponible fuera del bloque
        // Console.WriteLine("Valor de valorEnBloque fuera del bloque: " + valorEnBloque);
        Console.WriteLine();

        // ===== Bloque de código dentro de un if =====
        Console.WriteLine("===== Bloque dentro de un if =====");
        if (true)
        {
            Console.WriteLine("Este es un bloque dentro de un if");
        }
        Console.WriteLine();

        // ===== Bloque de código dentro de un for =====
        Console.WriteLine("===== Bloque dentro de un for =====");
        for (int indiceFor = 0; indiceFor < 3; indiceFor++)
        {
            Console.WriteLine("Este es un bloque dentro de un for, iteración: " + indiceFor);
        }
        Console.WriteLine();

        // ===== Bloque de código dentro de un while =====
        Console.WriteLine("===== Bloque dentro de un while =====");
        int contadorWhile = 0;
        while (contadorWhile < 3)
        {
            Console.WriteLine("Este es un bloque dentro de un while, iteración: " + contadorWhile);
            contadorWhile++;
        }
    }
}
