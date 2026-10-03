/*
6. Sentencias.

Un programa en C# está formado por una sucesión de instrucciones que se ejecutan una tras
otra, siguiendo un orden determinado. Cada una de estas instrucciones se conoce como sentencia,
y representa una acción concreta que el programa debe realizar.

Una sentencia puede consistir, por ejemplo, en declarar una variable, asignarle un valor,
invocar un método (es decir, ejecutar una porción de código ya definida en otra parte del
programa) o formar parte de estructuras que controlan el flujo de ejecución, como decisiones
condicionales o repeticiones.

En C#, cada sentencia debe finalizar con un punto y coma, símbolo que indica al compilador
dónde termina una instrucción y dónde comienza la siguiente. Esta marca es parte de las reglas
sintácticas del lenguaje y resulta indispensable para que el código pueda interpretarse
correctamente.

En resumen, las sentencias son las unidades básicas de acción dentro de un programa: al
combinarse en el orden adecuado, determinan el comportamiento completo de una aplicación
escrita en C#.
*/

namespace Sentencias
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== Declaración, asignación e invocación de método =====
            // Comentario: ejemplo de declaración, asignación e invocación de método WriteLine de la clase Console.
            Console.WriteLine("===== Declaración, asignación e invocación de método =====");
            int cantidadArticulos = 5; // Declaración y asignación
            cantidadArticulos = cantidadArticulos + 3; // Asignación con operación
            Console.WriteLine("El valor de la variable es: " + cantidadArticulos); // Invocación de método
            Console.WriteLine();

            // ===== Declaración de constante =====
            // Comentario: ejemplo de declaración e inicialización de una constante.
            Console.WriteLine("===== Declaración de constante =====");
            const int diasDevolucionPermitidos = 30; // Declaración e inicialización de constante
            Console.WriteLine("Plazo de devolución (días): " + diasDevolucionPermitidos);
            Console.WriteLine();

            // ===== Sentencia de decisión condicional (if / else) =====
            // Comentario: ejemplo de uso de if / else para tomar decisiones basadas en condiciones.
            Console.WriteLine("===== Sentencia if / else =====");
            if (cantidadArticulos > 5)
            {
                Console.WriteLine("La cantidad de artículos es mayor que 5.");
            }
            else
            {
                Console.WriteLine("La cantidad de artículos no es mayor que 5.");
            }
            Console.WriteLine();

            // ===== Sentencia de repetición (for) =====
            // Comentario: ejemplo de uso de for para repetir un bloque un número determinado de veces.
            Console.WriteLine("===== Sentencia for =====");
            for (int indiceFor = 0; indiceFor < cantidadArticulos; indiceFor++)
            {
                Console.WriteLine("Iteración número: " + indiceFor);
            }
            Console.WriteLine();

            // ===== Sentencia de repetición (while) =====
            // Comentario: ejemplo de uso de while para repetir un bloque mientras se cumpla una condición.
            Console.WriteLine("===== Sentencia while =====");
            int indiceWhile = 0;
            while (indiceWhile < cantidadArticulos)
            {
                Console.WriteLine("Iteración número: " + indiceWhile);
                indiceWhile++;
            }
            Console.WriteLine();

            // ===== Sentencia de repetición (do-while) =====
            // Comentario: ejemplo de uso de do-while para repetir un bloque al menos una vez.
            Console.WriteLine("===== Sentencia do-while =====");
            int indiceDoWhile = 0;
            do
            {
                Console.WriteLine("Iteración número: " + indiceDoWhile);
                indiceDoWhile++;
            } while (indiceDoWhile < cantidadArticulos);
            Console.WriteLine();

            // ===== Sentencia de selección múltiple (switch) =====
            // Comentario: ejemplo de uso de switch para selección múltiple.
            Console.WriteLine("===== Sentencia switch =====");
            switch (cantidadArticulos)
            {
                case 1:
                    Console.WriteLine("La cantidad de artículos es 1.");
                    break;
                case 2:
                    Console.WriteLine("La cantidad de artículos es 2.");
                    break;
                case 3:
                    Console.WriteLine("La cantidad de artículos es 3.");
                    break;
                default:
                    Console.WriteLine("La cantidad de artículos no es 1, 2 ni 3.");
                    break;
            }
        }
    }
}