namespace Ej03_LoteDeTransferencias
{
    // Ejercicio 3: Lote de transferencias con corte anticipado (break).

    class Program
    {
        static void Main()
        {
            // ===== Constantes =====
            const int maximoTransferenciasLote = 10;
            const decimal limiteTransferenciaOperacion = 2000.00m;
            const decimal limiteTransferenciaDiario = 3000.00m;

            // ===== Estado =====
            decimal saldo = 2500.00m;
            decimal totalTransferido = 0m;
            decimal totalComisiones = 0m;
            int aprobadas = 0;
            int rechazadas = 0;
            string motivoCierre = "Se alcanzó el máximo de transferencias del lote.";

            Console.WriteLine("=== LOTE DE TRANSFERENCIAS ===");
            Console.WriteLine("Saldo inicial: $ " + saldo.ToString("N2"));
            Console.WriteLine("Ingrese cada monto. Ingrese 0 para finalizar el lote.");

            for (int numero = 1; numero <= maximoTransferenciasLote; numero++)
            {
                Console.WriteLine();
                Console.Write("Transferencia " + numero + " - Monto: ");
                // Si el texto no es un número se usa -1, valor que luego se rechaza como inválido.
                decimal monto = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : -1m;

                // Corte 1: el usuario indica que terminó.
                if (monto == 0)
                {
                    motivoCierre = "El usuario finalizó el lote.";
                    break;
                }

                // Datos inválidos: se rechaza, pero el lote continúa.
                if (monto < 0)
                {
                    Console.WriteLine("Estado: RECHAZADA. Monto inválido.");
                    rechazadas++;
                }
                else if (monto > limiteTransferenciaOperacion)
                {
                    Console.WriteLine("Estado: RECHAZADA. Supera el límite por operación de $ " + limiteTransferenciaOperacion.ToString("N2") + ".");
                    rechazadas++;
                }
                else
                {
                    // Comisión escalonada (igual que en M2).
                    decimal porcentaje;
                    if (monto <= 500m)
                    {
                        porcentaje = 1.5m;
                    }
                    else if (monto <= 1000m)
                    {
                        porcentaje = 1.2m;
                    }
                    else
                    {
                        porcentaje = 1.0m;
                    }

                    decimal comision = monto * porcentaje / 100m;
                    decimal total = monto + comision;

                    // Corte 2: límite diario acumulado. No tiene sentido seguir procesando el lote.
                    if (totalTransferido + monto > limiteTransferenciaDiario)
                    {
                        motivoCierre = "Se alcanzó el límite diario de transferencias.";
                        break;
                    }

                    // Corte 3: saldo insuficiente. El lote se detiene.
                    if (saldo < total)
                    {
                        motivoCierre = "Saldo insuficiente para la transferencia " + numero + ".";
                        break;
                    }

                    saldo -= total;
                    totalTransferido += monto;
                    totalComisiones += comision;
                    aprobadas++;
                    Console.WriteLine("Estado: APROBADA. Comisión (" + porcentaje.ToString("N1") + " %): $ " + comision.ToString("N2")
                                      + " | Saldo: $ " + saldo.ToString("N2"));
                }
            }

            Console.WriteLine();
            Console.WriteLine("--- Resumen del lote ---");
            Console.WriteLine("Motivo de cierre: " + motivoCierre);
            Console.WriteLine("Transferencias aprobadas: " + aprobadas);
            Console.WriteLine("Transferencias rechazadas: " + rechazadas);
            Console.WriteLine("Total transferido: $ " + totalTransferido.ToString("N2"));
            Console.WriteLine("Comisiones pagadas: $ " + totalComisiones.ToString("N2"));
            Console.WriteLine("Saldo final: $ " + saldo.ToString("N2"));
        }
    }
}
