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
