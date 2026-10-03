/*
3. Sintaxis y semántica de C#.

Para comenzar a programar en C# es necesario comprender dos conceptos que suelen presentarse
juntos, pero que tienen significados distintos: la sintaxis y la semántica del lenguaje.

La sintaxis es el conjunto de reglas que indican cómo debe escribirse el código para que sea
válido, de manera similar a las reglas gramaticales de un idioma. Estas reglas determinan, por
ejemplo, cómo se declara una variable, cómo se indica el tipo de dato que almacenará, cómo se
escriben los operadores, cómo se estructuran las decisiones y repeticiones dentro de un
programa, y cómo se organizan los métodos y las clases. Si la sintaxis no se respeta, el
compilador (la herramienta que traduce el código a un formato ejecutable) no podrá procesar el
programa.

La semántica, en cambio, se refiere al significado del código: qué hace realmente cada
instrucción cuando el programa se ejecuta. Es posible escribir código sintácticamente correcto
pero que no realice la tarea deseada, porque su comportamiento no coincide con la intención del
programador. Por eso, comprender la semántica implica entender cómo el entorno de ejecución de
.NET interpreta y procesa cada instrucción del programa.

En definitiva, la sintaxis define cómo se escribe el código, mientras que la semántica define
cómo se comporta ese código al ejecutarse. Dominar ambos aspectos es indispensable para escribir
programas correctos, claros y fáciles de mantener a lo largo del tiempo.
*/

// Ejemplos:

using System;

class Program
{
    static void Main()
    {
        // ===== Error de sintaxis (comentado): el compilador no puede procesar el código =====
        // La sintaxis exige que cada sentencia termine en punto y coma y que las llaves cierren
        // correctamente cada bloque. Si se omite alguno de estos elementos, el compilador detiene
        // el proceso antes de poder ejecutar el programa, sin importar qué se quiso lograr.
        Console.WriteLine("===== Error de sintaxis =====");
        Console.WriteLine("El siguiente código no compila porque falta el punto y coma:");
        Console.WriteLine("    int edadCliente = 25");
        Console.WriteLine("El compilador reporta un error de sintaxis antes de ejecutar nada.");
        // int edadCliente = 25   <-- descomentar esta línea provoca un error de compilación
        Console.WriteLine();

        // ===== Sintaxis válida, semántica correcta =====
        // El código respeta las reglas del lenguaje y, además, produce el resultado esperado:
        // determinar si un estudiante aprueba según su calificación.
        Console.WriteLine("===== Sintaxis válida, semántica correcta =====");
        int calificacionEstudiante = 7;
        const int calificacionMinimaParaAprobar = 6;

        if (calificacionEstudiante >= calificacionMinimaParaAprobar)
        {
            Console.WriteLine("El estudiante aprobó la materia.");
        }
        else
        {
            Console.WriteLine("El estudiante no aprobó la materia.");
        }
        Console.WriteLine();

        // ===== Sintaxis válida, semántica incorrecta =====
        // El código compila sin problemas, pero el operador utilizado no refleja la regla real:
        // se quiso calcular el promedio de dos notas y, por error, se usó + en lugar de la
        // fórmula completa (sumar y dividir entre la cantidad de notas).
        Console.WriteLine("===== Sintaxis válida, semántica incorrecta =====");
        double primeraNota = 8.0;
        double segundaNota = 6.0;
        double promedioIncorrecto = primeraNota + segundaNota; // Falta dividir entre 2
        Console.WriteLine("Promedio calculado (incorrecto): " + promedioIncorrecto);
        Console.WriteLine("El resultado no es un promedio válido: faltó dividir la suma entre 2.");
        Console.WriteLine();

        // ===== Corrección semántica =====
        // La sintaxis no cambia; se corrige la fórmula para que el significado del cálculo
        // coincida con la intención original: obtener el promedio real de las dos notas.
        Console.WriteLine("===== Corrección semántica =====");
        double promedioCorrecto = (primeraNota + segundaNota) / 2;
        Console.WriteLine("Promedio calculado (correcto): " + promedioCorrecto);
    }
}
