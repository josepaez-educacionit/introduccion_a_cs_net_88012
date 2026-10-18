namespace Ej02_ExtraccionDeEfectivo
{
    internal class Program
    {
        static void Main()
        {
            // Reglas del banco.
            const decimal comisionFijaExtraccion = 50.00m;
            const decimal limiteExtraccionOperacion = 1000.00m;
            const decimal saldoMinimoAviso = 1000.00m;

            // Estado de la cuenta.
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1800.00m;
            int cantidadMovimientos = 0;

            Console.WriteLine("=== EXTRACCIÓN DE EFECTIVO ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            // Si el texto no es un número, montoExtraccion queda en 0 y la operación se rechaza.
            Console.Write("Monto a extraer: ");
            decimal montoExtraccion = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : 0m;
            Console.WriteLine();

            // Cálculo de la operación y de las condiciones de aprobación.
            decimal totalExtraccion = montoExtraccion + comisionFijaExtraccion;
            bool montoValido = montoExtraccion > 0;
            bool fondosSuficientes = saldo >= totalExtraccion;
            bool dentroDelLimite = montoExtraccion <= limiteExtraccionOperacion;
            bool aprobada = montoValido && fondosSuficientes && dentroDelLimite;

            Console.WriteLine("Monto solicitado: $ " + montoExtraccion.ToString("N2"));
            Console.WriteLine("Comisión fija: $ " + comisionFijaExtraccion.ToString("N2"));
            Console.WriteLine("Total a descontar: $ " + totalExtraccion.ToString("N2"));
            Console.WriteLine("Monto válido: " + (montoValido ? "Sí" : "No"));
            Console.WriteLine("Fondos suficientes: " + (fondosSuficientes ? "Sí" : "No"));
            Console.WriteLine("Dentro del límite: " + (dentroDelLimite ? "Sí" : "No"));

            // Decisión if-else: exactamente dos caminos posibles.
            if (aprobada)
            {
                saldo -= totalExtraccion;
                cantidadMovimientos++;
                Console.WriteLine("Estado: APROBADA");
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));

                // Condicional simple dentro de la rama aprobada.
                if (saldo < saldoMinimoAviso)
                {
                    Console.WriteLine("Aviso: su saldo quedó por debajo de $ " + saldoMinimoAviso.ToString("N2") + ".");
                }
            }
            else
            {
                Console.WriteLine("Estado: RECHAZADA");
                Console.WriteLine("El saldo no se modificó: $ " + saldo.ToString("N2"));
            }

            Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);
        }

    }
}
