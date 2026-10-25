namespace Ej06_AsistenteDeTransferencia
{
    // Ejercicio 6: Asistente de transferencia con reintentos (for, while, break y continue).
    class Program
    {
        static void Main()
        {
            // ===== Constantes =====
            const int maximoReintentos = 3;
            const decimal limiteTransferenciaOperacion = 2000.00m;
            const decimal comisionPorcentaje = 1.2m;

            // ===== Estado =====
            decimal saldo = 3000.00m;
            string descripcionDestino = "";
            bool destinoValido = false;
            bool operacionAprobada = false;

            Console.WriteLine("=== ASISTENTE DE TRANSFERENCIA ===");
            Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));

            // ===== Paso 1: destino. for con reintentos limitados; break al elegir un destino válido =====
            for (int intento = 1; intento <= maximoReintentos; intento++)
            {
                Console.Write("Tipo de destino (CBU / CVU / ALIAS): ");
                string? tipoLeido = Console.ReadLine();
                string tipoDestino = tipoLeido == null ? "" : tipoLeido.ToUpper();

                switch (tipoDestino)
                {
                    case "CBU":
                        descripcionDestino = "Cuenta bancaria";
                        destinoValido = true;
                        break;
                    case "CVU":
                        descripcionDestino = "Billetera virtual";
                        destinoValido = true;
                        break;
                    case "ALIAS":
                        descripcionDestino = "Alias";
                        destinoValido = true;
                        break;
                    default:
                        Console.WriteLine("Tipo no reconocido (" + intento + " de " + maximoReintentos + ").");
                        break;
                }

                // Este break pertenece al for (el del switch ya terminó).
                if (destinoValido)
                {
                    break;
                }
            }

            // ===== Pasos 2 y 3: monto y confirmación. Cada vuelta del while es un intento =====
            if (destinoValido)
            {
                Console.WriteLine("Destino: " + descripcionDestino);

                int reintentosMonto = 0;
                bool operacionFinalizada = false;

                while (!operacionFinalizada)
                {
                    Console.Write("Monto a transferir: ");
                    bool montoEsNumero = decimal.TryParse(Console.ReadLine(), out decimal monto);

                    // Monto inválido: se cuenta el reintento y se vuelve a pedir (continue).
                    if (!montoEsNumero || monto <= 0 || monto > limiteTransferenciaOperacion)
                    {
                        reintentosMonto++;
                        Console.WriteLine("Monto inválido. Debe estar entre $ 0,01 y $ " + limiteTransferenciaOperacion.ToString("N2")
                                          + " (" + reintentosMonto + " de " + maximoReintentos + ").");
                        if (reintentosMonto >= maximoReintentos)
                        {
                            operacionFinalizada = true;
                        }
                        continue;
                    }

                    decimal comision = monto * comisionPorcentaje / 100m;
                    decimal total = monto + comision;

                    // Saldo insuficiente: no tiene sentido pedir confirmación.
                    if (saldo < total)
                    {
                        Console.WriteLine("Saldo insuficiente. Se requieren $ " + total.ToString("N2") + ".");
                        operacionFinalizada = true;
                        continue;
                    }

                    // Confirmación.
                    Console.WriteLine();
                    Console.WriteLine("--- Confirmación ---");
                    Console.WriteLine("Destino: " + descripcionDestino);
                    Console.WriteLine("Monto: $ " + monto.ToString("N2"));
                    Console.WriteLine("Comisión (" + comisionPorcentaje.ToString("N1") + " %): $ " + comision.ToString("N2"));
                    Console.WriteLine("Total a debitar: $ " + total.ToString("N2"));
                    Console.Write("1. Confirmar  2. Cambiar monto  3. Cancelar: ");
                    int opcionConfirmada = int.TryParse(Console.ReadLine(), out int opcionLeida) ? opcionLeida : 0;

                    switch (opcionConfirmada)
                    {
                        case 1:
                            saldo -= total;
                            operacionAprobada = true;
                            operacionFinalizada = true;
                            Console.WriteLine("Estado: APROBADA. Saldo actualizado: $ " + saldo.ToString("N2"));
                            break;
                        case 2:
                            // Se vuelve a pedir el monto y los reintentos comienzan de nuevo.
                            reintentosMonto = 0;
                            break;
                        default:
                            operacionFinalizada = true;
                            break;
                    }
                }
            }

            // ===== Cierre =====
            if (!operacionAprobada)
            {
                Console.WriteLine("Operación cancelada. No se modificó el saldo.");
            }

            Console.WriteLine("Fin del asistente.");
        }
    }
}
