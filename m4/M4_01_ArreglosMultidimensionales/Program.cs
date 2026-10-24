/*
1. Arreglos multidimensionales.

Un arreglo multidimensional es una variante de los arreglos que permite organizar sus
elementos en más de una dimensión, en lugar de disponerlos en una única fila de valores como
ocurre con los arreglos vistos anteriormente.

El caso más común de arreglo multidimensional es el de dos dimensiones, que puede
representarse como una tabla organizada en filas y columnas. Para acceder a un elemento
específico dentro de un arreglo de este tipo, es necesario indicar dos índices: uno que
identifica la fila y otro que identifica la columna en la que se encuentra ese valor.

De la misma manera en que existen arreglos de dos dimensiones, es posible definir arreglos con
tres o más dimensiones, aunque su uso resulta menos frecuente y suele reservarse para
situaciones en las que los datos se organizan naturalmente de esa forma, como en aplicaciones
que trabajan con información espacial o matricial.

Al igual que los arreglos de una sola dimensión, los arreglos multidimensionales tienen un
tamaño fijo en cada una de sus dimensiones, definido en el momento en que se crean, y todos
sus elementos deben ser del mismo tipo de dato.

En resumen, un arreglo multidimensional permite organizar un conjunto de valores relacionados
en varias dimensiones, accediendo a cada elemento mediante la combinación de los índices
correspondientes a cada una de ellas.
*/
namespace M4_01_ArreglosMultidimensionales
{
    internal class Program
    {
        static void Main()
        {
            // Ejemplo 1: arreglo de dos dimensiones que representa las notas de tres estudiantes
            // en cuatro evaluaciones. Cada fila corresponde a un estudiante y cada columna a una evaluación.
            int[,] notas = new int[3, 4]
            {
            {7, 8, 6, 9},   // Estudiante 0
            {5, 6, 7, 8},   // Estudiante 1
            {9, 10, 8, 9}   // Estudiante 2
            };

            // Los índices comienzan en 0: [fila, columna]
            // Nota del estudiante 1 (segunda fila) en la evaluación 2 (tercera columna)
            int notaEstudiante1 = notas[1, 2];
            System.Console.WriteLine("Nota del estudiante 1 en la evaluación 2: " + notaEstudiante1);

            // Modificación de un elemento: se corrige la primera nota del estudiante 0
            notas[0, 0] = 10;

            // GetLength(dimensión) devuelve el tamaño de cada dimensión:
            // 0 = cantidad de filas, 1 = cantidad de columnas
            int cantidadEstudiantes = notas.GetLength(0);
            int cantidadEvaluaciones = notas.GetLength(1);

            // Recorrido completo con bucles anidados: el externo recorre las filas y el interno las columnas
            for (int estudiante = 0; estudiante < cantidadEstudiantes; estudiante++)
            {
                int sumaNotas = 0;

                for (int evaluacion = 0; evaluacion < cantidadEvaluaciones; evaluacion++)
                {
                    sumaNotas += notas[estudiante, evaluacion];
                }

                double promedio = (double)sumaNotas / cantidadEvaluaciones;
                System.Console.WriteLine("Promedio del estudiante " + estudiante + ": " + promedio);
            }

            // Ejemplo 2: arreglo de dos dimensiones de texto que representa el estado de los asientos
            // de una sala de cine (3 filas x 4 asientos). "L" = libre, "O" = ocupado.
            string[,] asientos = new string[3, 4]
            {
            {"L", "O", "L", "L"},
            {"O", "O", "L", "O"},
            {"L", "L", "L", "O"}
            };

            // Se reserva el asiento de la fila 0, columna 0
            asientos[0, 0] = "O";

            // Se cuentan los asientos libres recorriendo toda la sala
            int asientosLibres = 0;

            for (int fila = 0; fila < asientos.GetLength(0); fila++)
            {
                for (int columna = 0; columna < asientos.GetLength(1); columna++)
                {
                    if (asientos[fila, columna] == "L")
                    {
                        asientosLibres++;
                    }
                }
            }

            System.Console.WriteLine("Asientos libres: " + asientosLibres + " de " + asientos.Length);
        }
    }
}
