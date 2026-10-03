/*
8. Operadores.

Los operadores son símbolos especiales del lenguaje C# que permiten realizar operaciones sobre
uno o más valores, denominados operandos. Gracias a ellos, un programa puede calcular
resultados, comparar información y tomar decisiones en función de esas comparaciones.

Existen distintos grupos de operadores según la tarea que realizan. Los operadores aritméticos
permiten efectuar cálculos matemáticos básicos, como sumas, restas, multiplicaciones,
divisiones y el cálculo del resto de una división. Los operadores de comparación permiten
evaluar la relación entre dos valores, determinando si son iguales, distintos, mayores o
menores entre sí. Los operadores lógicos permiten combinar condiciones, evaluando si una o
varias de ellas se cumplen. Por último, los operadores de asignación permiten asignar valores a
una variable, incluyendo formas abreviadas que combinan una operación con la asignación.

En resumen, los operadores son herramientas fundamentales del lenguaje, ya que permiten
manipular datos, realizar cálculos y construir las condiciones que guían el comportamiento de
un programa escrito en C#.
*/

namespace Operadores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== Operadores aritméticos =====
            // Realizan operaciones matemáticas básicas como suma, resta, multiplicación, división y módulo.
            Console.WriteLine("===== Operadores aritméticos =====");

            int primerNumero = 10;
            int segundoNumero = 3;

            Console.WriteLine("Suma: " + (primerNumero + segundoNumero));
            Console.WriteLine("Resta: " + (primerNumero - segundoNumero));
            Console.WriteLine("Multiplicación: " + (primerNumero * segundoNumero));
            Console.WriteLine("División: " + (primerNumero / segundoNumero));
            Console.WriteLine("Resto: " + (primerNumero % segundoNumero));
            Console.WriteLine();


            // ===== Operadores de comparación / relacionales =====
            // Comparan dos valores y devuelven un valor booleano (true o false) según la relación entre ellos.
            Console.WriteLine("===== Operadores de comparación =====");
            Console.WriteLine("primerNumero == segundoNumero: " + (primerNumero == segundoNumero));
            Console.WriteLine("primerNumero != segundoNumero: " + (primerNumero != segundoNumero));
            Console.WriteLine("primerNumero > segundoNumero: " + (primerNumero > segundoNumero));
            Console.WriteLine("primerNumero < segundoNumero: " + (primerNumero < segundoNumero));
            Console.WriteLine("primerNumero >= segundoNumero: " + (primerNumero >= segundoNumero));
            Console.WriteLine("primerNumero <= segundoNumero: " + (primerNumero <= segundoNumero));
            Console.WriteLine();

            // ===== Operadores lógicos =====
            // Permiten combinar condiciones, evaluando si una o varias de ellas se cumplen.
            Console.WriteLine("===== Operadores lógicos =====");

            bool esMayorDeEdad = true;
            bool tienePermiso = false;

            Console.WriteLine("esMayorDeEdad && tienePermiso: " + (esMayorDeEdad && tienePermiso));   // AND lógico: true si ambos son true
            Console.WriteLine("esMayorDeEdad || tienePermiso: " + (esMayorDeEdad || tienePermiso));   // OR lógico: true si al menos uno es true
            Console.WriteLine("!esMayorDeEdad: " + (!esMayorDeEdad));                                  // NOT lógico: invierte el valor booleano
            Console.WriteLine();


            // Tabla de verdad del operador AND (&&)
            Console.WriteLine("-- AND (&&) --");
            Console.WriteLine("true && true: " + (true && true));
            Console.WriteLine("true && false: " + (true && false));
            Console.WriteLine("false && true: " + (false && true));
            Console.WriteLine("false && false: " + (false && false));
            Console.WriteLine();

            // Tabla de verdad del operador OR (||)
            Console.WriteLine("-- OR (||) --");
            Console.WriteLine("true || true: " + (true || true));
            Console.WriteLine("true || false: " + (true || false));
            Console.WriteLine("false || true: " + (false || true));
            Console.WriteLine("false || false: " + (false || false));
            Console.WriteLine();

            // Tabla de verdad del operador NOT (!)
            Console.WriteLine("-- NOT (!) --");
            Console.WriteLine("!true: " + (!true));
            Console.WriteLine("!false: " + (!false));
            Console.WriteLine();


            // ===== Operadores de asignación =====
            // Permiten asignar valores a una variable, incluyendo formas abreviadas que combinan una operación con la asignación.
            Console.WriteLine("===== Operadores de asignación =====");
            int contador = 5;
            contador += 3; // Equivalente a contador = contador + 3
            Console.WriteLine("contador después de contador += 3: " + contador);
            Console.WriteLine();

            // ===== Operadores de incremento y decremento =====
            // Permiten aumentar o disminuir el valor de una variable en una unidad, utilizando los operadores ++ y -- respectivamente.
            Console.WriteLine("===== Operadores de incremento y decremento =====");
            int acumulador = 5;
            acumulador++; // Equivalente a acumulador = acumulador + 1
            Console.WriteLine("acumulador después de acumulador++: " + acumulador);
            acumulador--; // Equivalente a acumulador = acumulador - 1
            Console.WriteLine("acumulador después de acumulador--: " + acumulador);
            Console.WriteLine();


            // ===== Operadores de multiplicación y división combinados con asignación =====
            // Permiten realizar operaciones aritméticas de multiplicación y división combinadas con la asignación.
            Console.WriteLine("===== Operadores *= y /= =====");
            int multiplicando = 6;
            int factor = 3;

            Console.WriteLine("multiplicando * factor: " + (multiplicando * factor));
            multiplicando *= factor; // Equivalente a multiplicando = multiplicando * factor


            Console.WriteLine("multiplicando después de multiplicando *= factor: " + multiplicando);
            Console.WriteLine("multiplicando / factor: " + (multiplicando / factor));

            multiplicando /= factor; // Equivalente a multiplicando = multiplicando / factor
            Console.WriteLine("multiplicando después de multiplicando /= factor: " + multiplicando);
            Console.WriteLine();

            // ===== Operador ternario =====
            // Permite evaluar una condición y devolver un valor u otro según si la condición es verdadera o falsa.
            Console.WriteLine("===== Operador ternario =====");

            int numeroAEvaluar = 10;
            string paridad = (numeroAEvaluar % 2 == 0) ? "Par" : "Impar";

            Console.WriteLine("numeroAEvaluar es: " + paridad);
            Console.WriteLine();

            // ===== Operador de concatenación de cadenas =====
            // Permite unir varias cadenas de texto en una sola utilizando el operador +.
            Console.WriteLine("===== Operador de concatenación de cadenas =====");

            string saludo = "Hola";
            string destinatario = "Mundo";
            string mensaje = saludo + " " + destinatario;

            Console.WriteLine("Mensaje concatenado: " + mensaje);
            Console.WriteLine();

            // ===== Operador de acceso a miembros =====
            // Permite acceder a las propiedades y métodos de un objeto o estructura utilizando el operador . (punto).
            Console.WriteLine("===== Operador de acceso a miembros =====");

            DateTime fechaActual = DateTime.Now;

            Console.WriteLine("Año actual: " + fechaActual.Year);
            Console.WriteLine();
        }
    }
}
