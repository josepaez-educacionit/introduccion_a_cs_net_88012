namespace Ej04_CalculoTransferencia
{
    // Ejercicio 4: Cálculos de una transferencia con operadores aritméticos y de asignación.
    internal class Program
    {
        static void Main(string[] args)
        {
            const decimal porcentajeComision = 1.5m;        // 1,5 %
            const decimal tasaRendimientoMensual = 0.4m;    // 0,4 % mensual sobre el saldo de caja de ahorro

            decimal saldo = 1800.00m;
            decimal montoTransferencia = 500.00m;
            int cantidadTransferencias = 0;

            // Comisión = monto * porcentaje / 100. Se multiplica antes de dividir.
            decimal comision = montoTransferencia * porcentajeComision / 100m;
            decimal totalDescontado = montoTransferencia + comision;

            Console.WriteLine("=== TRANSFERENCIA A CVU ===");
            Console.WriteLine("Monto a transferir: $ " + montoTransferencia.ToString("N2"));
            Console.WriteLine("Comisión: $ " + comision.ToString("N2"));
            Console.WriteLine("Total descontado: $ " + totalDescontado.ToString("N2"));

            // Operador de incremento y operador de asignación compuesta.
            cantidadTransferencias++;
            saldo -= totalDescontado;

            Console.WriteLine("Transferencias realizadas: " + cantidadTransferencias);
            Console.WriteLine("Saldo después de la transferencia: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            // Rendimiento mensual sobre el saldo restante.
            decimal rendimientoMensual = saldo * tasaRendimientoMensual / 100m;
            saldo += rendimientoMensual;

            Console.WriteLine("=== RENDIMIENTO MENSUAL ===");
            Console.WriteLine("Rendimiento generado: $ " + rendimientoMensual.ToString("N2"));
            Console.WriteLine("Saldo con rendimiento: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            // Trampa común: la división entre dos enteros descarta la parte decimal.
            int repartoEntero = 1000 / 3;
            int restoEntero = 1000 % 3;
            decimal repartoDecimal = 1000m / 3m;

            Console.WriteLine("=== DIVISIÓN ===");
            Console.WriteLine("1000 / 3 con int: " + repartoEntero);
            Console.WriteLine("1000 % 3 con int (resto): " + restoEntero);
            Console.WriteLine("1000m / 3m con decimal: " + repartoDecimal);

        }
    }
}
