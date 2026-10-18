namespace Ej01_CargaDeDinero
{
    // Ejercicio 1: Carga de dinero con condicionales simples (if).
    internal class Program
    {
        static void Main()
        {
            // Constante: a partir de este monto la carga se informa al área de control.
            const decimal montoCargaElevada = 1000.00m;

            // Estado de la cuenta.
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500.00m;
            int cantidadMovimientos = 0;

            Console.WriteLine("=== CARGA DE DINERO ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo actual: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            // Lectura del monto. ReadLine devuelve texto (puede ser null), por eso string?.
            // TryParse devuelve true si el texto es un número válido y deja el valor en montoCarga.
            Console.Write("Monto a cargar: ");
            string? textoMonto = Console.ReadLine();
            bool montoEsNumero = decimal.TryParse(textoMonto, out decimal montoCarga);
            Console.WriteLine();

            // Condicional simple 1: el texto ingresado no es un número.
            if (!montoEsNumero)
            {
                Console.WriteLine("El monto ingresado no es un número válido. No se realizó la carga.");
            }

            // Condicional simple 2: es un número, pero no es positivo.
            if (montoEsNumero && montoCarga <= 0)
            {
                Console.WriteLine("El monto debe ser mayor que cero. No se realizó la carga.");
            }

            // Condicional simple 3: carga válida. Se actualiza el estado de la cuenta.
            if (montoEsNumero && montoCarga > 0)
            {
                saldo += montoCarga;
                cantidadMovimientos++;
                Console.WriteLine("Carga acreditada: $ " + montoCarga.ToString("N2"));
                Console.WriteLine("Saldo actual: $ " + saldo.ToString("N2"));
            }

            // Condicional simple 4: aviso independiente de las decisiones anteriores.
            if (montoEsNumero && montoCarga >= montoCargaElevada)
            {
                Console.WriteLine("Aviso: carga de monto elevado. Será informada al área de control.");
            }

            Console.WriteLine();
            Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);
            Console.WriteLine("Fin de la operación.");
        }

    }
}
