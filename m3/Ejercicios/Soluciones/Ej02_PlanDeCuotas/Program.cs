namespace Ej02_PlanDeCuotas
{
    // Ejercicio 2: Plan de cuotas de un préstamo personal (for).
    class Program
    {
        static void Main()
        {
            // ===== Constantes (reglas del banco) =====
            const decimal montoMinimo = 1000.00m;
            const decimal montoMaximo = 50000.00m;
            const int cuotasMinimas = 3;
            const int cuotasMaximas = 24;
            const decimal tasaMensual = 4.0m;   // porcentaje de interés simple por mes

            DateTime fechaSesion = new DateTime(2026, 10, 3);

            Console.WriteLine("=== PRÉSTAMO PERSONAL - Banco NetSur ===");
            Console.WriteLine("Titular: Ana Gómez Rivera");
            Console.WriteLine();

            // ===== Lectura validada del monto (do-while) =====
            decimal montoPrestamo;
            bool montoValido;
            do
            {
                Console.Write("Monto del préstamo: ");
                montoValido = decimal.TryParse(Console.ReadLine(), out montoPrestamo)
                              && montoPrestamo >= montoMinimo
                              && montoPrestamo <= montoMaximo;
                if (!montoValido)
                {
                    Console.WriteLine("Monto inválido. Debe estar entre $ " + montoMinimo.ToString("N2") + " y $ " + montoMaximo.ToString("N2") + ".");
                }
            } while (!montoValido);

            // ===== Lectura validada de la cantidad de cuotas (do-while) =====
            int cantidadCuotas;
            bool cuotasValidas;
            do
            {
                Console.Write("Cantidad de cuotas (" + cuotasMinimas + " a " + cuotasMaximas + "): ");
                cuotasValidas = int.TryParse(Console.ReadLine(), out cantidadCuotas)
                                && cantidadCuotas >= cuotasMinimas
                                && cantidadCuotas <= cuotasMaximas;
                if (!cuotasValidas)
                {
                    Console.WriteLine("Cantidad inválida. Ingrese un entero entre " + cuotasMinimas + " y " + cuotasMaximas + ".");
                }
            } while (!cuotasValidas);

            // ===== Cálculo del préstamo =====
            decimal interesTotal = montoPrestamo * tasaMensual / 100m * cantidadCuotas;
            decimal totalAPagar = montoPrestamo + interesTotal;
            decimal valorCuota = totalAPagar / cantidadCuotas;

            Console.WriteLine();
            Console.WriteLine("--- Condiciones del préstamo ---");
            Console.WriteLine("Capital: $ " + montoPrestamo.ToString("N2"));
            Console.WriteLine("Tasa mensual: " + tasaMensual.ToString("N1") + " %");
            Console.WriteLine("Interés total: $ " + interesTotal.ToString("N2"));
            Console.WriteLine("Total a pagar: $ " + totalAPagar.ToString("N2"));
            Console.WriteLine("Valor de cada cuota: $ " + valorCuota.ToString("N2"));

            // ===== Parte 1: cronograma de vencimientos (for ascendente) =====
            Console.WriteLine();
            Console.WriteLine("--- Cronograma de cuotas ---");
            Console.WriteLine("Cuota | Vencimiento | Valor           | Saldo pendiente");
            for (int numeroCuota = 1; numeroCuota <= cantidadCuotas; numeroCuota++)
            {
                DateTime vencimiento = fechaSesion.AddMonths(numeroCuota);
                // Saldo pendiente = cuotas que faltan pagar x valor de la cuota.
                decimal saldoPendiente = (cantidadCuotas - numeroCuota) * valorCuota;
                Console.WriteLine(numeroCuota.ToString().PadLeft(5) + " | "
                                  + vencimiento.ToString("dd/MM/yyyy") + "  | $ "
                                  + valorCuota.ToString("N2").PadLeft(12) + " | $ "
                                  + saldoPendiente.ToString("N2").PadLeft(12));
            }

            // ===== Parte 2: cuenta regresiva de cuotas pendientes (for descendente) =====
            Console.WriteLine();
            Console.WriteLine("--- Cuotas pendientes después de cada pago ---");
            for (int pendientes = cantidadCuotas - 1; pendientes >= 0; pendientes--)
            {
                Console.WriteLine("Quedan " + pendientes + " cuota(s) por pagar.");
            }

            // ===== Parte 3: simulador de plazos (for con paso de 6 meses) =====
            Console.WriteLine();
            Console.WriteLine("--- Simulador: cuota del mismo capital en otros plazos ---");
            for (int plazo = 6; plazo <= 24; plazo += 6)
            {
                decimal cuotaSimulada = (montoPrestamo + montoPrestamo * tasaMensual / 100m * plazo) / plazo;
                Console.WriteLine(plazo.ToString().PadLeft(2) + " cuotas de $ " + cuotaSimulada.ToString("N2"));
            }
        }
    }
}
