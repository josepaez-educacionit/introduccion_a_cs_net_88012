namespace Ej04_AuditoriaDeMovimientos
{
    // Ejercicio 4: Auditoría de movimientos del día (continue).
    class Program
    {
        static void Main()
        {
            // ===== Constantes =====
            const int cantidadRevisiones = 8;
            const decimal montoMinimoAuditable = 100.00m;
            const decimal montoSospechoso = 5000.00m;

            // ===== Acumuladores =====
            decimal totalCargas = 0m;
            decimal totalExtracciones = 0m;
            decimal totalTransferencias = 0m;
            int cantidadAuditados = 0;
            int cantidadDescartadosInvalidos = 0;
            int cantidadOmitidosPorMonto = 0;
            int cantidadSospechosos = 0;

            Console.WriteLine("=== AUDITORÍA DE MOVIMIENTOS ===");
            Console.WriteLine("Se revisarán " + cantidadRevisiones + " movimientos.");
            Console.WriteLine("Tipos válidos: C (carga), E (extracción), T (transferencia).");

            for (int numero = 1; numero <= cantidadRevisiones; numero++)
            {
                Console.WriteLine();
                Console.WriteLine("Movimiento " + numero + " de " + cantidadRevisiones);
                Console.Write("Tipo (C/E/T): ");
                string? tipoLeido = Console.ReadLine();
                string tipo = tipoLeido == null ? "" : tipoLeido.ToUpper();
                Console.Write("Monto: ");
                bool montoEsNumero = decimal.TryParse(Console.ReadLine(), out decimal monto);

                // Descarte 1: el tipo no es válido. Se pasa directamente al próximo movimiento.
                if (tipo != "C" && tipo != "E" && tipo != "T")
                {
                    Console.WriteLine("-> Descartado: tipo de movimiento inválido.");
                    cantidadDescartadosInvalidos++;
                    continue;
                }

                // Descarte 2: el monto no es un número positivo.
                if (!montoEsNumero || monto <= 0)
                {
                    Console.WriteLine("-> Descartado: monto inválido.");
                    cantidadDescartadosInvalidos++;
                    continue;
                }

                // Omisión: los montos menores al mínimo auditable no se procesan.
                if (monto < montoMinimoAuditable)
                {
                    Console.WriteLine("-> Omitido: monto menor al mínimo auditable de $ " + montoMinimoAuditable.ToString("N2") + ".");
                    cantidadOmitidosPorMonto++;
                    continue;
                }

                // Si llegó hasta aquí, el movimiento es auditable.
                cantidadAuditados++;

                if (tipo == "C")
                {
                    totalCargas += monto;
                }
                else if (tipo == "E")
                {
                    totalExtracciones += monto;
                }
                else
                {
                    totalTransferencias += monto;
                }

                if (monto >= montoSospechoso)
                {
                    cantidadSospechosos++;
                    Console.WriteLine("-> Auditado. ALERTA: monto sospechoso, derivar a revisión manual.");
                }
                else
                {
                    Console.WriteLine("-> Auditado correctamente.");
                }
            }

            decimal flujoNeto = totalCargas - totalExtracciones - totalTransferencias;

            Console.WriteLine();
            Console.WriteLine("--- Resultado de la auditoría ---");
            Console.WriteLine("Movimientos auditados: " + cantidadAuditados);
            Console.WriteLine("Descartados por datos inválidos: " + cantidadDescartadosInvalidos);
            Console.WriteLine("Omitidos por monto bajo: " + cantidadOmitidosPorMonto);
            Console.WriteLine("Movimientos sospechosos: " + cantidadSospechosos);
            Console.WriteLine("Total cargas: $ " + totalCargas.ToString("N2"));
            Console.WriteLine("Total extracciones: $ " + totalExtracciones.ToString("N2"));
            Console.WriteLine("Total transferencias: $ " + totalTransferencias.ToString("N2"));
            Console.WriteLine("Flujo neto: $ " + flujoNeto.ToString("N2"));
        }
    }
}
