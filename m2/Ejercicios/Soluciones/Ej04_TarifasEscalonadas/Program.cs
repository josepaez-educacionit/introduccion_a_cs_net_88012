namespace Ej04_TarifasEscalonadas
{
    internal class Program
    {
        static void Main()
        {
            const decimal limiteTransferenciaOperacion = 2000.00m;

            // ===== Parte A: comisión de la transferencia según el monto =====
            Console.WriteLine("=== COMISIÓN POR TRANSFERENCIA ===");
            Console.Write("Monto a transferir: ");
            decimal monto = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : 0m;

            // Las variables se asignan en todas las ramas, para que el compilador
            // pueda garantizar que tienen valor antes de usarse.
            decimal porcentajeComision;
            string tramo;
            bool operacionPermitida;

            // Se evalúa de arriba hacia abajo y se ejecuta solo la primera rama verdadera.
            if (monto <= 0)
            {
                porcentajeComision = 0m;
                tramo = "Monto no válido";
                operacionPermitida = false;
            }
            else if (monto <= 500m)
            {
                porcentajeComision = 1.5m;
                tramo = "Tramo 1 (hasta $ 500,00)";
                operacionPermitida = true;
            }
            else if (monto <= 1000m)
            {
                porcentajeComision = 1.2m;
                tramo = "Tramo 2 (hasta $ 1.000,00)";
                operacionPermitida = true;
            }
            else if (monto <= limiteTransferenciaOperacion)
            {
                porcentajeComision = 1.0m;
                tramo = "Tramo 3 (hasta $ 2.000,00)";
                operacionPermitida = true;
            }
            else
            {
                porcentajeComision = 0m;
                tramo = "Supera el límite por operación";
                operacionPermitida = false;
            }

            Console.WriteLine("Clasificación: " + tramo);
            if (operacionPermitida)
            {
                decimal comision = monto * porcentajeComision / 100m;
                Console.WriteLine("Porcentaje de comisión: " + porcentajeComision.ToString("N1") + " %");
                Console.WriteLine("Comisión: $ " + comision.ToString("N2"));
                Console.WriteLine("Total a descontar: $ " + (monto + comision).ToString("N2"));
            }
            else
            {
                Console.WriteLine("La transferencia no puede calcularse.");
            }
            Console.WriteLine();

            // ===== Parte B: rendimiento mensual según el saldo =====
            Console.WriteLine("=== RENDIMIENTO MENSUAL ===");
            Console.Write("Saldo de la caja de ahorro: ");
            decimal saldo = decimal.TryParse(Console.ReadLine(), out decimal saldoLeido) ? saldoLeido : 0m;

            decimal tasaRendimiento;
            string categoria;

            if (saldo <= 0)
            {
                tasaRendimiento = 0m;
                categoria = "Sin saldo para rendimiento";
            }
            else if (saldo < 1000m)
            {
                tasaRendimiento = 0.2m;
                categoria = "Saldo inicial";
            }
            else if (saldo < 5000m)
            {
                tasaRendimiento = 0.4m;
                categoria = "Saldo intermedio";
            }
            else
            {
                tasaRendimiento = 0.6m;
                categoria = "Saldo alto";
            }

            decimal rendimiento = saldo > 0 ? saldo * tasaRendimiento / 100m : 0m;
            Console.WriteLine("Categoría: " + categoria);
            Console.WriteLine("Tasa mensual: " + tasaRendimiento.ToString("N1") + " %");
            Console.WriteLine("Rendimiento del mes: $ " + rendimiento.ToString("N2"));
            Console.WriteLine("Saldo con rendimiento: $ " + (saldo > 0 ? saldo + rendimiento : saldo).ToString("N2"));
        }

    }
}
