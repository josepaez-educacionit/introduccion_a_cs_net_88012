namespace Ej03_TransferenciaValidada
{
    internal class Program
    {
        static void Main()
        {
            // Reglas del banco.
            const decimal porcentajeComision = 1.5m;
            const decimal limiteTransferenciaOperacion = 2000.00m;
            const decimal umbralValidacionSms = 1000.00m;
            const string codigoSmsCorrecto = "482915";

            // Estado de la cuenta. Para probar una cuenta bloqueada, cambie true por false.
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1800.00m;
            int cantidadMovimientos = 0;
            bool cuentaActiva = true;

            Console.WriteLine("=== TRANSFERENCIA A CVU ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            Console.Write("Monto a transferir: ");
            decimal monto = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : 0m;

            // Resultado de las validaciones: se completa dentro de los if anidados.
            bool aprobada = false;
            string motivoRechazo = "";
            decimal comision = monto * porcentajeComision / 100m;
            decimal total = monto + comision;

            // Cada if es un "nivel": solo se llega al siguiente si el anterior se cumple.
            if (cuentaActiva)
            {
                if (monto > 0)
                {
                    if (monto <= limiteTransferenciaOperacion)
                    {
                        if (saldo >= total)
                        {
                            if (monto > umbralValidacionSms)
                            {
                                Console.WriteLine("Esta operación requiere validación por SMS.");
                                Console.Write("Código recibido: ");
                                string? codigoIngresado = Console.ReadLine();

                                if (codigoIngresado == codigoSmsCorrecto)
                                {
                                    aprobada = true;
                                }
                                else
                                {
                                    motivoRechazo = "El código SMS es incorrecto.";
                                }
                            }
                            else
                            {
                                aprobada = true;
                            }
                        }
                        else
                        {
                            motivoRechazo = "Saldo insuficiente para cubrir el monto y la comisión.";
                        }
                    }
                    else
                    {
                        motivoRechazo = "El monto supera el límite por operación de $ " + limiteTransferenciaOperacion.ToString("N2") + ".";
                    }
                }
                else
                {
                    motivoRechazo = "El monto debe ser un número mayor que cero.";
                }
            }
            else
            {
                motivoRechazo = "La cuenta está bloqueada.";
            }

            // Resultado final: se informa en un único lugar.
            Console.WriteLine();
            if (aprobada)
            {
                saldo -= total;
                cantidadMovimientos++;
                Console.WriteLine("Monto: $ " + monto.ToString("N2") + " | Comisión: $ " + comision.ToString("N2"));
                Console.WriteLine("Total descontado: $ " + total.ToString("N2"));
                Console.WriteLine("Estado: APROBADA");
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
            }
            else
            {
                Console.WriteLine("Estado: RECHAZADA");
                Console.WriteLine("Motivo: " + motivoRechazo);
                Console.WriteLine("Saldo sin cambios: $ " + saldo.ToString("N2"));
            }

            Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);
        }

    }
}
