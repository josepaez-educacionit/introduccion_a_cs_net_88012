namespace Ej01_CargasConfirmadas
{
    // Ejercicio 1: Cargas de dinero con validación y confirmación (do-while).
    class Program
    {
        static void Main()
        {
            // ===== Constantes =====
            const decimal limiteCargaOperacion = 5000.00m;
            const decimal montoCargaElevada = 1000.00m;

            // ===== Estado de la cuenta =====
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500.00m;
            int cantidadCargas = 0;
            decimal totalCargado = 0m;

            Console.WriteLine("=== CARGAS DE DINERO ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo inicial: $ " + saldo.ToString("N2"));

            // Ciclo externo: se repite mientras el usuario desee realizar otra carga.
            string? respuesta;
            do
            {
                Console.WriteLine();

                // Ciclo interno: se repite hasta que el monto ingresado sea válido.
                // Siempre se pide el dato al menos una vez, por eso corresponde do-while.
                decimal montoCarga;
                bool montoValido;
                do
                {
                    Console.Write("Monto a cargar: ");
                    // Si TryParse falla, montoCarga vale 0 y la condición montoCarga > 0 también falla.
                    montoValido = decimal.TryParse(Console.ReadLine(), out montoCarga)
                                  && montoCarga > 0
                                  && montoCarga <= limiteCargaOperacion;

                    if (!montoValido)
                    {
                        Console.WriteLine("Monto inválido. Ingrese un número mayor que cero y hasta $ " + limiteCargaOperacion.ToString("N2") + ".");
                    }
                } while (!montoValido);

                // Se acredita la carga y se actualizan los acumuladores.
                saldo += montoCarga;
                totalCargado += montoCarga;
                cantidadCargas++;
                Console.WriteLine("Carga acreditada: $ " + montoCarga.ToString("N2"));

                if (montoCarga >= montoCargaElevada)
                {
                    Console.WriteLine("Aviso: carga de monto elevado. Será informada al área de control.");
                }

                Console.WriteLine("Saldo actual: $ " + saldo.ToString("N2"));

                // Se consulta si se repite el ciclo externo.
                Console.Write("¿Desea realizar otra carga? (S/N): ");
                respuesta = Console.ReadLine();
            } while (respuesta == "S" || respuesta == "s");

            Console.WriteLine();
            Console.WriteLine("--- Resumen de la sesión ---");
            Console.WriteLine("Cargas realizadas: " + cantidadCargas);
            Console.WriteLine("Total cargado: $ " + totalCargado.ToString("N2"));
            Console.WriteLine("Saldo final: $ " + saldo.ToString("N2"));
        }
    }
}
