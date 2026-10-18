/*
1. Instrucción do...while.

La instrucción do...while es otra estructura cíclica de C#, similar al while, que permite
repetir un bloque de código mientras se cumpla una determinada condición. Su principal
diferencia radica en el momento en que esa condición se evalúa.

En el while, la condición se comprueba antes de ejecutar el bloque de código, por lo que si
la condición es falsa desde el inicio, el bloque puede no llegar a ejecutarse nunca. En
cambio, en el do...while el bloque de código se ejecuta primero, y recién después se evalúa
la condición para decidir si corresponde repetirlo.

Esto significa que, en una instrucción do...while, el bloque de código se ejecuta siempre al
menos una vez, sin importar si la condición resulta verdadera o falsa en esa primera
evaluación.

Este comportamiento resulta útil en situaciones donde se necesita garantizar que una acción
se realice al menos una vez antes de comprobar si debe repetirse, por ejemplo, cuando se
solicita información al usuario y se desea validarla después de haberla pedido.

Sintaxis:

    do
    {
        // instrucciones que se ejecutan en cada repetición
    } while (condición);

Explicación de cada parte:
- do: palabra reservada que marca el comienzo del bloque que se va a repetir.
- { ... }: bloque de instrucciones. Se ejecuta primero, antes de evaluar cualquier condición.
- while: palabra reservada que da inicio a la evaluación de la condición, una vez finalizado el
  bloque.
- (condición): expresión que debe resultar en un valor booleano (true o false). Si es true, el
  bloque se ejecuta nuevamente; si es false, el ciclo termina y el programa continúa con la
  instrucción siguiente.
- ; (punto y coma): es obligatorio al final de la instrucción, a diferencia del while, y su
  omisión produce un error de compilación.

Para evitar un ciclo infinito, alguna instrucción dentro del bloque debe modificar el valor
que interviene en la condición, de manera que en algún momento esta deje de cumplirse.

En resumen, la instrucción do...while repite un bloque de código mientras se cumpla una
condición, con la particularidad de que ese bloque siempre se ejecuta al menos una vez.
*/

namespace M3_01_InstruccionDoWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: el bloque se ejecuta siempre al menos una vez.
            // Aunque la condición sea falsa desde el inicio (0 < 0), el mensaje se muestra una vez.
            int intentosRealizados = 0;
            int maximoIntentos = 0;
            do
            {
                Console.WriteLine("Intento de conexión número: " + (intentosRealizados + 1));
                intentosRealizados++;
            } while (intentosRealizados < maximoIntentos);

            // Ejemplo 2: validación de datos ingresados por el usuario.
            // Primero se solicita la edad y recién después se comprueba si es válida,
            // por eso el bloque debe ejecutarse al menos una vez.

            int edad;
            bool edadValida;
            do
            {
                Console.Write("Ingrese su edad (entre 18 y 99): ");
                string entrada = Console.ReadLine();

                // TryParse evita una excepción si el texto ingresado no es un número.
                edadValida = int.TryParse(entrada, out edad) && edad >= 18 && edad <= 99;

                if (!edadValida)
                {
                    Console.WriteLine("Edad inválida. Intente nuevamente.");
                }
            } while (!edadValida);

            // Ejemplo 3: menú que se repite hasta que el usuario elige salir.
            // El menú debe mostrarse al menos una vez antes de conocer la opción elegida.
            string opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Realizar depósito");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Saldo disponible: $1500.00");
                        break;
                    case "2":
                        Console.WriteLine("Depósito registrado correctamente.");
                        break;
                    case "0":
                        Console.WriteLine("Sesión finalizada.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != "0");
        }
    }
}
