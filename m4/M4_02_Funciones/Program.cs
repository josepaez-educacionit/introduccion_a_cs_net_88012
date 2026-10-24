/*
2. Funciones.

Una función es un bloque de código identificado con un nombre, que agrupa un conjunto de
instrucciones destinadas a resolver una tarea específica y que, al finalizar su ejecución,
entrega un valor de resultado a la parte del programa desde la cual fue invocada.

Utilizar funciones permite dividir un programa en partes más pequeñas y manejables, cada una
encargada de una responsabilidad concreta, en lugar de escribir todas las instrucciones de
forma continua dentro de un único bloque de código extenso.

Una función puede recibir información necesaria para realizar su tarea a través de parámetros,
que actúan como datos de entrada, y siempre finaliza devolviendo un valor mediante la
instrucción return, valor que puede ser utilizado posteriormente por quien la invocó.

Además de organizar mejor el código, las funciones permiten reutilizar una misma solución las
veces que sea necesario, evitando escribir varias veces las mismas instrucciones a lo largo de
un programa.

En resumen, una función es un bloque de código reutilizable, identificado con un nombre, que
realiza una tarea determinada y que siempre entrega un valor de resultado al finalizar su
ejecución.
*/
namespace M4_02_Funciones
{
    internal class Program
    {
        // Estructura de una función:
        // <tipo de retorno> <Nombre>(<tipo> <parámetro>, ...) { ... return <valor>; }

        // Función con dos parámetros de entrada que devuelve un valor decimal.
        // Calcula el precio final de un producto aplicando un porcentaje de descuento.
        static decimal CalcularPrecioConDescuento(decimal precioLista, decimal porcentajeDescuento)
        {
            decimal montoDescuento = precioLista * porcentajeDescuento / 100;
            return precioLista - montoDescuento;
        }

        // Función con un parámetro de entrada que devuelve un valor booleano.
        // Indica si una edad corresponde a una persona mayor de edad.
        static bool EsMayorDeEdad(int edad)
        {
            return edad >= 18;
        }

        // Función que recibe un arreglo como parámetro y devuelve un valor calculado a partir de él.
        // Calcula el promedio de una lista de notas.
        static double CalcularPromedio(int[] notas)
        {
            int sumaNotas = 0;

            for (int i = 0; i < notas.Length; i++)
            {
                sumaNotas += notas[i];
            }

            return (double)sumaNotas / notas.Length;
        }

        // Función que devuelve texto.
        // Construye un saludo personalizado a partir del nombre recibido.
        static string ConstruirSaludo(string nombre)
        {
            return "Hola, " + nombre + "! Bienvenido al sistema.";
        }

        static void Main()
        {
            // Invocación de una función: se escribe su nombre y se entregan los argumentos
            // en el mismo orden que los parámetros. El valor devuelto se guarda en una variable.
            decimal precioFinal = CalcularPrecioConDescuento(15000m, 20m);
            System.Console.WriteLine("Precio final con descuento: " + precioFinal);

            // El valor devuelto también puede usarse directamente en una condición.
            int edadCliente = 17;

            if (EsMayorDeEdad(edadCliente))
            {
                System.Console.WriteLine("El cliente puede registrarse.");
            }
            else
            {
                System.Console.WriteLine("El cliente debe contar con autorización de un tutor.");
            }

            // Reutilización: la misma función se invoca con distintos datos sin repetir su lógica.
            int[] notasEstudianteA = { 7, 8, 9 };
            int[] notasEstudianteB = { 4, 6, 5, 7 };

            System.Console.WriteLine("Promedio del estudiante A: " + CalcularPromedio(notasEstudianteA));
            System.Console.WriteLine("Promedio del estudiante B: " + CalcularPromedio(notasEstudianteB));

            // El resultado de una función puede pasarse como argumento de otra.
            System.Console.WriteLine(ConstruirSaludo("Lucía"));
        }
    }
}