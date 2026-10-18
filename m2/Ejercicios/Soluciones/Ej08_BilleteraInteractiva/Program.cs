namespace Ej08_BilleteraInteractiva
{
    internal class Program
    {
        static void Main()
        {
            // ===== Constantes (reglas del banco) =====
            const string claveCorrecta = "2468";
            const string codigoSmsCorrecto = "482915";
            const int maximoIntentosClave = 3;
            const decimal comisionFijaExtraccion = 50.00m;
            const decimal limiteExtraccionOperacion = 1000.00m;
            const decimal limiteExtraccionDiario = 1500.00m;
            const decimal limiteTransferenciaOperacion = 2000.00m;
            const decimal limiteCargaOperacion = 5000.00m;
            const decimal umbralValidacionSms = 1000.00m;

            // ===== Variables (estado de la sesión) =====
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500.00m;
            int cantidadMovimientos = 0;
            int cantidadRechazos = 0;
            decimal totalExtraidoHoy = 0m;
            decimal totalComisiones = 0m;
            DateTime fechaSesion = new DateTime(2026, 10, 3);
            DateTime? ultimoMovimiento = null;

            Console.WriteLine("=== BILLETERA VIRTUAL - Banco NetSur ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine();

            // ===== Acceso: clave con intentos limitados =====
            int intentos = 0;
            bool accesoOtorgado = false;

            while (intentos < maximoIntentosClave && !accesoOtorgado)
            {
                Console.Write("Ingrese su clave: ");
                string? claveIngresada = Console.ReadLine();
                intentos++;

                if (claveIngresada == claveCorrecta)
                {
                    accesoOtorgado = true;
                }
                else
                {
                    Console.WriteLine("Clave incorrecta. Intentos restantes: " + (maximoIntentosClave - intentos));
                }
            }

            if (!accesoOtorgado)
            {
                Console.WriteLine("Cuenta bloqueada por intentos fallidos. Fin del programa.");
            }
            else
            {
                Console.WriteLine("Acceso concedido.");

                // ===== Menú principal: se repite hasta que el usuario elige salir =====
                bool salir = false;

                while (!salir)
                {
                    Console.WriteLine();
                    Console.WriteLine("=== MENÚ ===");
                    Console.WriteLine("1. Consultar saldo");
                    Console.WriteLine("2. Cargar dinero");
                    Console.WriteLine("3. Extraer efectivo");
                    Console.WriteLine("4. Transferir (CBU / CVU / alias)");
                    Console.WriteLine("5. Ver resumen de movimientos");
                    Console.WriteLine("6. Salir");
                    Console.Write("Seleccione una opción: ");
                    int opcion = int.TryParse(Console.ReadLine(), out int opcionLeida) ? opcionLeida : 0;
                    Console.WriteLine();

                    switch (opcion)
                    {
                        case 1:
                            {
                                Console.WriteLine("--- 1. Consultar saldo ---");
                                Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));
                                break;
                            }

                        case 2:
                            {
                                Console.WriteLine("--- 2. Cargar dinero ---");
                                Console.Write("Monto a cargar: ");
                                decimal montoCarga = decimal.TryParse(Console.ReadLine(), out decimal cargaLeida) ? cargaLeida : 0m;

                                if (montoCarga <= 0)
                                {
                                    Console.WriteLine("Estado: RECHAZADO. El monto debe ser un número mayor que cero.");
                                    cantidadRechazos++;
                                }
                                else if (montoCarga > limiteCargaOperacion)
                                {
                                    Console.WriteLine("Estado: RECHAZADO. El monto supera el límite de carga de $ " + limiteCargaOperacion.ToString("N2") + ".");
                                    cantidadRechazos++;
                                }
                                else
                                {
                                    saldo += montoCarga;
                                    cantidadMovimientos++;
                                    ultimoMovimiento = fechaSesion;
                                    Console.WriteLine("Estado: APROBADO");
                                    Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                                }
                                break;
                            }

                        case 3:
                            {
                                Console.WriteLine("--- 3. Extraer efectivo ---");
                                Console.Write("Monto a extraer: ");
                                decimal montoExtraccion = decimal.TryParse(Console.ReadLine(), out decimal extraccionLeida) ? extraccionLeida : 0m;
                                decimal totalExtraccion = montoExtraccion + comisionFijaExtraccion;

                                if (montoExtraccion <= 0)
                                {
                                    Console.WriteLine("Estado: RECHAZADO. El monto debe ser un número mayor que cero.");
                                    cantidadRechazos++;
                                }
                                else if (montoExtraccion > limiteExtraccionOperacion)
                                {
                                    Console.WriteLine("Estado: RECHAZADO. El monto supera el límite por operación de $ " + limiteExtraccionOperacion.ToString("N2") + ".");
                                    cantidadRechazos++;
                                }
                                else
                                {
                                    // Validaciones en cascada: límite diario acumulado y fondos.
                                    if (totalExtraidoHoy + montoExtraccion > limiteExtraccionDiario)
                                    {
                                        decimal disponibleHoy = limiteExtraccionDiario - totalExtraidoHoy;
                                        Console.WriteLine("Estado: RECHAZADO. Supera el límite diario. Disponible para extraer hoy: $ " + disponibleHoy.ToString("N2") + ".");
                                        cantidadRechazos++;
                                    }
                                    else if (saldo < totalExtraccion)
                                    {
                                        Console.WriteLine("Estado: RECHAZADO. Saldo insuficiente (se requieren $ " + totalExtraccion.ToString("N2") + ").");
                                        cantidadRechazos++;
                                    }
                                    else
                                    {
                                        saldo -= totalExtraccion;
                                        totalExtraidoHoy += montoExtraccion;
                                        totalComisiones += comisionFijaExtraccion;
                                        cantidadMovimientos++;
                                        ultimoMovimiento = fechaSesion;
                                        Console.WriteLine("Total descontado: $ " + totalExtraccion.ToString("N2") + " (comisión: $ " + comisionFijaExtraccion.ToString("N2") + ")");
                                        Console.WriteLine("Estado: APROBADO");
                                        Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                                    }
                                }
                                break;
                            }

                        case 4:
                            {
                                Console.WriteLine("--- 4. Transferir ---");
                                Console.Write("Tipo de destino (CBU / CVU / ALIAS): ");
                                string? tipoDestino = Console.ReadLine();

                                string descripcionDestino;
                                bool destinoValido;

                                switch (tipoDestino)
                                {
                                    case "CBU":
                                    case "cbu":
                                        descripcionDestino = "Cuenta bancaria";
                                        destinoValido = true;
                                        break;
                                    case "CVU":
                                    case "cvu":
                                        descripcionDestino = "Billetera virtual";
                                        destinoValido = true;
                                        break;
                                    case "ALIAS":
                                    case "alias":
                                        descripcionDestino = "Alias";
                                        destinoValido = true;
                                        break;
                                    default:
                                        descripcionDestino = "No reconocido";
                                        destinoValido = false;
                                        break;
                                }

                                if (!destinoValido)
                                {
                                    Console.WriteLine("Estado: RECHAZADO. Tipo de destino no reconocido.");
                                    cantidadRechazos++;
                                }
                                else
                                {
                                    Console.WriteLine("Destino: " + descripcionDestino);
                                    Console.Write("Monto a transferir: ");
                                    decimal montoTransferencia = decimal.TryParse(Console.ReadLine(), out decimal transferenciaLeida) ? transferenciaLeida : 0m;

                                    if (montoTransferencia <= 0)
                                    {
                                        Console.WriteLine("Estado: RECHAZADO. El monto debe ser un número mayor que cero.");
                                        cantidadRechazos++;
                                    }
                                    else if (montoTransferencia > limiteTransferenciaOperacion)
                                    {
                                        Console.WriteLine("Estado: RECHAZADO. El monto supera el límite por operación de $ " + limiteTransferenciaOperacion.ToString("N2") + ".");
                                        cantidadRechazos++;
                                    }
                                    else
                                    {
                                        // Comisión escalonada según el monto.
                                        decimal porcentajeComision;
                                        if (montoTransferencia <= 500m)
                                        {
                                            porcentajeComision = 1.5m;
                                        }
                                        else if (montoTransferencia <= 1000m)
                                        {
                                            porcentajeComision = 1.2m;
                                        }
                                        else
                                        {
                                            porcentajeComision = 1.0m;
                                        }

                                        decimal comision = montoTransferencia * porcentajeComision / 100m;
                                        decimal totalTransferencia = montoTransferencia + comision;
                                        Console.WriteLine("Comisión (" + porcentajeComision.ToString("N1") + " %): $ " + comision.ToString("N2") + " | Total: $ " + totalTransferencia.ToString("N2"));

                                        if (saldo < totalTransferencia)
                                        {
                                            Console.WriteLine("Estado: RECHAZADO. Saldo insuficiente.");
                                            cantidadRechazos++;
                                        }
                                        else
                                        {
                                            // Validación por SMS solo para montos altos.
                                            bool smsValidado = true;

                                            if (montoTransferencia > umbralValidacionSms)
                                            {
                                                Console.Write("Código SMS: ");
                                                smsValidado = Console.ReadLine() == codigoSmsCorrecto;
                                            }

                                            if (smsValidado)
                                            {
                                                saldo -= totalTransferencia;
                                                totalComisiones += comision;
                                                cantidadMovimientos++;
                                                ultimoMovimiento = fechaSesion;
                                                Console.WriteLine("Estado: APROBADO");
                                                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                                            }
                                            else
                                            {
                                                Console.WriteLine("Estado: RECHAZADO. El código SMS es incorrecto.");
                                                cantidadRechazos++;
                                            }
                                        }
                                    }
                                }
                                break;
                            }

                        case 5:
                            {
                                Console.WriteLine("--- 5. Resumen de movimientos ---");

                                string nivelCliente;
                                if (saldo >= 5000m)
                                {
                                    nivelCliente = "Premium";
                                }
                                else if (saldo >= 1000m)
                                {
                                    nivelCliente = "Plus";
                                }
                                else
                                {
                                    nivelCliente = "Clásico";
                                }

                                Console.WriteLine("Titular: " + titular);
                                Console.WriteLine("Nivel de cliente: " + nivelCliente);
                                Console.WriteLine("Saldo: $ " + saldo.ToString("N2"));
                                Console.WriteLine("Movimientos aprobados: " + cantidadMovimientos);
                                Console.WriteLine("Operaciones rechazadas: " + cantidadRechazos);
                                Console.WriteLine("Comisiones pagadas: $ " + totalComisiones.ToString("N2"));
                                Console.WriteLine("Extraído hoy: $ " + totalExtraidoHoy.ToString("N2"));

                                if (ultimoMovimiento.HasValue)
                                {
                                    Console.WriteLine("Último movimiento: " + ultimoMovimiento.Value.ToString("dd/MM/yyyy"));
                                }
                                else
                                {
                                    Console.WriteLine("Último movimiento: Sin movimientos");
                                }
                                break;
                            }

                        case 6:
                            {
                                Console.WriteLine("Gracias por utilizar la Billetera Virtual.");
                                salir = true;
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("Opción no válida. Ingrese un número del 1 al 6.");
                                break;
                            }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Fin de la sesión. Saldo final: $ " + saldo.ToString("N2"));
            }
        }

    }
}
