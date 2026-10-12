namespace Ej05_ValidacionTransferencia
{
    // Ejercicio 5: Validación de transferencias con operadores relacionales, lógicos y ternario.
    internal class Program
    {
        static void Main(string[] args)
        {
            const decimal limiteDiario = 2000.00m;
            const decimal porcentajeComision = 1.5m;

            // Escenario 1: operación válida.
            {
                decimal saldo = 1500.00m;
                decimal monto = 500.00m;
                bool cuentaBloqueada = false;

                decimal total = monto + monto * porcentajeComision / 100m;
                bool fondosSuficientes = saldo >= total;
                bool dentroDelLimite = monto <= limiteDiario;
                bool aprobada = fondosSuficientes && dentroDelLimite && !cuentaBloqueada;
                string resultado = aprobada ? "APROBADA" : "RECHAZADA";

                Console.WriteLine("Escenario 1 (saldo 1500, monto 500): " + resultado);
            }

            // Escenario 2: saldo insuficiente.
            {
                decimal saldo = 300.00m;
                decimal monto = 500.00m;
                bool cuentaBloqueada = false;

                decimal total = monto + monto * porcentajeComision / 100m;
                bool fondosSuficientes = saldo >= total;
                bool dentroDelLimite = monto <= limiteDiario;
                bool aprobada = fondosSuficientes && dentroDelLimite && !cuentaBloqueada;
                string resultado = aprobada ? "APROBADA" : "RECHAZADA";

                Console.WriteLine("Escenario 2 (saldo 300, monto 500): " + resultado);
            }

            // Escenario 3: supera el límite diario aunque hay fondos.
            {
                decimal saldo = 5000.00m;
                decimal monto = 2500.00m;
                bool cuentaBloqueada = false;

                decimal total = monto + monto * porcentajeComision / 100m;
                bool fondosSuficientes = saldo >= total;
                bool dentroDelLimite = monto <= limiteDiario;
                bool aprobada = fondosSuficientes && dentroDelLimite && !cuentaBloqueada;
                string resultado = aprobada ? "APROBADA" : "RECHAZADA";

                Console.WriteLine("Escenario 3 (saldo 5000, monto 2500): " + resultado);
            }

            // Escenario 4: cuenta bloqueada.
            {
                decimal saldo = 1500.00m;
                decimal monto = 500.00m;
                bool cuentaBloqueada = true;

                decimal total = monto + monto * porcentajeComision / 100m;
                bool fondosSuficientes = saldo >= total;
                bool dentroDelLimite = monto <= limiteDiario;
                bool aprobada = fondosSuficientes && dentroDelLimite && !cuentaBloqueada;
                string resultado = aprobada ? "APROBADA" : "RECHAZADA";

                Console.WriteLine("Escenario 4 (cuenta bloqueada): " + resultado);
            }

            // Escenario 5: caso límite. El saldo es exactamente igual al total.
            {
                decimal saldo = 507.50m;
                decimal monto = 500.00m;
                bool cuentaBloqueada = false;

                decimal total = monto + monto * porcentajeComision / 100m;
                bool fondosSuficientes = saldo >= total;
                bool dentroDelLimite = monto <= limiteDiario;
                bool aprobada = fondosSuficientes && dentroDelLimite && !cuentaBloqueada;
                string resultado = aprobada ? "APROBADA" : "RECHAZADA";

                Console.WriteLine("Escenario 5 (saldo igual al total): " + resultado);
            }

            Console.WriteLine();

            // Operador lógico O: la transferencia requiere validación adicional (código por SMS)
            // si el monto supera $ 1.000,00 o si la cuenta es nueva.
            decimal montoRevision = 1200.00m;
            bool cuentaNueva = false;
            bool requiereValidacionAdicional = montoRevision > 1000m || cuentaNueva;
            Console.WriteLine("¿Requiere validación adicional por SMS? " + requiereValidacionAdicional);
        }
    }
}
