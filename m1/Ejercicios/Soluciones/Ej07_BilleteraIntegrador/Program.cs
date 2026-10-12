namespace Ej07_BilleteraIntegrador
{
    // Ejercicio 7: Proyecto integrador. Sesión de la Billetera Virtual.
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== Constantes (reglas del banco) =====
            const decimal porcentajeComisionTransferencia = 1.5m;
            const decimal comisionFijaExtraccion = 50.00m;
            const decimal limiteExtraccionDiario = 1000.00m;
            const decimal limiteTransferenciaDiario = 2000.00m;

            // ===== Variables (estado de la cuenta) =====
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500.00m;
            int cantidadMovimientos = 0;
            DateTime? ultimoMovimiento = null;
            DateTime fechaSesion = new DateTime(2026, 10, 3);

            Console.WriteLine("=== BILLETERA VIRTUAL - Sesión de demostración ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine();

            // ===== Opción 1: Consultar saldo =====
            {
                Console.WriteLine("--- 1. Consultar saldo ---");
                Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));
                Console.WriteLine();
            }

            // ===== Opción 2: Cargar dinero =====
            {
                decimal montoCarga = 300.00m;
                saldo = saldo + montoCarga;
                cantidadMovimientos++;
                ultimoMovimiento = fechaSesion;

                Console.WriteLine("--- 2. Cargar dinero ---");
                Console.WriteLine("Carga: $ " + montoCarga.ToString("N2"));
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                Console.WriteLine();
            }

            // ===== Opción 3: Extraer efectivo (aprobado) =====
            {
                decimal montoExtraccion = 200.00m;
                decimal totalExtraccion = montoExtraccion + comisionFijaExtraccion;
                bool fondosSuficientes = saldo >= totalExtraccion;
                bool dentroDelLimite = montoExtraccion <= limiteExtraccionDiario;
                bool aprobado = fondosSuficientes && dentroDelLimite;

                saldo = aprobado ? saldo - totalExtraccion : saldo;
                cantidadMovimientos += aprobado ? 1 : 0;
                ultimoMovimiento = aprobado ? fechaSesion : ultimoMovimiento;

                Console.WriteLine("--- 3. Extraer efectivo ---");
                Console.WriteLine("Monto solicitado: $ " + montoExtraccion.ToString("N2") + " (comisión fija: $ " + comisionFijaExtraccion.ToString("N2") + ")");
                Console.WriteLine("Total a descontar: $ " + totalExtraccion.ToString("N2"));
                Console.WriteLine("Estado: " + (aprobado ? "APROBADO" : "RECHAZADO"));
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                Console.WriteLine();
            }

            // ===== Opción 4: Transferir a CVU (aprobado) =====
            {
                decimal montoTransferencia = 500.00m;
                decimal comision = montoTransferencia * porcentajeComisionTransferencia / 100m;
                decimal totalTransferencia = montoTransferencia + comision;
                bool fondosSuficientes = saldo >= totalTransferencia;
                bool dentroDelLimite = montoTransferencia <= limiteTransferenciaDiario;
                bool aprobado = fondosSuficientes && dentroDelLimite;

                saldo = aprobado ? saldo - totalTransferencia : saldo;
                cantidadMovimientos += aprobado ? 1 : 0;
                ultimoMovimiento = aprobado ? fechaSesion : ultimoMovimiento;

                Console.WriteLine("--- 4. Transferir a CVU ---");
                Console.WriteLine("Monto: $ " + montoTransferencia.ToString("N2") + " | Comisión: $ " + comision.ToString("N2"));
                Console.WriteLine("Total a descontar: $ " + totalTransferencia.ToString("N2"));
                Console.WriteLine("Estado: " + (aprobado ? "APROBADO" : "RECHAZADO"));
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                Console.WriteLine();
            }

            // ===== Opción 3 (segundo intento): extracción que supera el límite =====
            {
                decimal montoExtraccion = 2000.00m;
                decimal totalExtraccion = montoExtraccion + comisionFijaExtraccion;
                bool fondosSuficientes = saldo >= totalExtraccion;
                bool dentroDelLimite = montoExtraccion <= limiteExtraccionDiario;
                bool aprobado = fondosSuficientes && dentroDelLimite;

                saldo = aprobado ? saldo - totalExtraccion : saldo;
                cantidadMovimientos += aprobado ? 1 : 0;
                ultimoMovimiento = aprobado ? fechaSesion : ultimoMovimiento;

                Console.WriteLine("--- 3. Extraer efectivo (segundo intento) ---");
                Console.WriteLine("Monto solicitado: $ " + montoExtraccion.ToString("N2"));
                Console.WriteLine("Estado: " + (aprobado ? "APROBADO" : "RECHAZADO"));
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                Console.WriteLine();
            }

            // ===== Opción 5: Ver resumen de movimientos =====
            {
                string textoUltimoMovimiento = ultimoMovimiento.HasValue
                    ? ultimoMovimiento.Value.ToString("dd/MM/yyyy")
                    : "Sin movimientos";

                Console.WriteLine("--- 5. Ver resumen de movimientos ---");
                Console.WriteLine("Titular: " + titular);
                Console.WriteLine("Saldo: $ " + saldo.ToString("N2"));
                Console.WriteLine("Movimientos realizados: " + cantidadMovimientos);
                Console.WriteLine("Último movimiento: " + textoUltimoMovimiento);
                Console.WriteLine();
            }

            Console.WriteLine("Fin de la sesión. Saldo final: $ " + saldo.ToString("N2"));
        }
    }
}
