namespace Ej09_BilleteraConHistorial
{
    // Ejercicio 9: Proyecto integrador. Billetera Virtual con historial de movimientos.

    class Program
    {
        static void Main()
        {
            // ===== Constantes (reglas del banco) =====
            const string claveCorrecta = "2468";
            const string codigoSmsCorrecto = "482915";
            const int maximoIntentosClave = 3;
            const int capacidadHistorial = 10;
            const decimal comisionFijaExtraccion = 50.00m;
            const decimal limiteExtraccionOperacion = 1000.00m;
            const decimal limiteExtraccionDiario = 1500.00m;
            const decimal limiteTransferenciaOperacion = 2000.00m;
            const decimal limiteCargaOperacion = 5000.00m;
            const decimal umbralValidacionSms = 1000.00m;

            // ===== Variables (estado de la sesión) =====
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500.00m;
            int cantidadRechazos = 0;
            decimal totalExtraidoHoy = 0m;
            decimal totalComisiones = 0m;
            DateTime fechaSesion = new DateTime(2026, 10, 3);

            // ===== Historial: arreglos paralelos de tamaño fijo =====
            // cantidadMovimientos indica cuántas posiciones están ocupadas.
            string[] historialTipos = new string[capacidadHistorial];
            decimal[] historialMontos = new decimal[capacidadHistorial];
            int cantidadMovimientos = 0;
            int movimientosNoRegistrados = 0;

            Console.WriteLine("=== BILLETERA VIRTUAL - Banco NetSur ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine();

            // ===== Acceso: clave con intentos limitados =====
            bool accesoOtorgado = false;
            for (int intento = 1; intento <= maximoIntentosClave; intento++)
            {
                Console.Write("Ingrese su clave: ");
                if (Console.ReadLine() == claveCorrecta)
                {
                    accesoOtorgado = true;
                    break;
                }
                Console.WriteLine("Clave incorrecta. Intentos restantes: " + (maximoIntentosClave - intento));
            }

            if (!accesoOtorgado)
            {
                Console.WriteLine("Cuenta bloqueada por intentos fallidos. Fin del programa.");
                return;
            }

            Console.WriteLine("Acceso concedido.");

            // ===== Menú principal: do-while, se ejecuta al menos una vez =====
            int opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("=== MENÚ ===");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Cargar dinero");
                Console.WriteLine("3. Extraer efectivo");
                Console.WriteLine("4. Transferir (CBU / CVU / alias)");
                Console.WriteLine("5. Ver historial de movimientos");
                Console.WriteLine("6. Ver resumen");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.TryParse(Console.ReadLine(), out int opcionLeida) ? opcionLeida : 0;
                Console.WriteLine();

                // Variables que cada operación completa para registrar el movimiento.
                bool operacionAprobada = false;
                string tipoMovimiento = "";
                decimal montoMovimiento = 0m;

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
                            // Validación del dato con do-while: se repite hasta recibir un monto aceptable.
                            decimal montoCarga;
                            bool montoValido;
                            do
                            {
                                Console.Write("Monto a cargar: ");
                                montoValido = decimal.TryParse(Console.ReadLine(), out montoCarga)
                                              && montoCarga > 0
                                              && montoCarga <= limiteCargaOperacion;
                                if (!montoValido)
                                {
                                    Console.WriteLine("Monto inválido. Debe ser mayor que cero y hasta $ " + limiteCargaOperacion.ToString("N2") + ".");
                                }
                            } while (!montoValido);

                            saldo += montoCarga;
                            operacionAprobada = true;
                            tipoMovimiento = "Carga";
                            montoMovimiento = montoCarga;
                            Console.WriteLine("Estado: APROBADO");
                            Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
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
                            else if (totalExtraidoHoy + montoExtraccion > limiteExtraccionDiario)
                            {
                                Console.WriteLine("Estado: RECHAZADO. Supera el límite diario. Disponible para extraer hoy: $ " + (limiteExtraccionDiario - totalExtraidoHoy).ToString("N2") + ".");
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
                                operacionAprobada = true;
                                tipoMovimiento = "Extracción";
                                montoMovimiento = -totalExtraccion;
                                Console.WriteLine("Total descontado: $ " + totalExtraccion.ToString("N2") + " (comisión: $ " + comisionFijaExtraccion.ToString("N2") + ")");
                                Console.WriteLine("Estado: APROBADO");
                                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("--- 4. Transferir ---");
                            Console.Write("Tipo de destino (CBU / CVU / ALIAS): ");
                            string? tipoDestino = Console.ReadLine();
                            string tipoNormalizado = tipoDestino == null ? "" : tipoDestino.ToUpper();

                            if (tipoNormalizado != "CBU" && tipoNormalizado != "CVU" && tipoNormalizado != "ALIAS")
                            {
                                Console.WriteLine("Estado: RECHAZADO. Tipo de destino no reconocido.");
                                cantidadRechazos++;
                                break;
                            }

                            Console.Write("Monto a transferir: ");
                            decimal montoTransferencia = decimal.TryParse(Console.ReadLine(), out decimal transferenciaLeida) ? transferenciaLeida : 0m;

                            if (montoTransferencia <= 0)
                            {
                                Console.WriteLine("Estado: RECHAZADO. El monto debe ser un número mayor que cero.");
                                cantidadRechazos++;
                                break;
                            }

                            if (montoTransferencia > limiteTransferenciaOperacion)
                            {
                                Console.WriteLine("Estado: RECHAZADO. El monto supera el límite por operación de $ " + limiteTransferenciaOperacion.ToString("N2") + ".");
                                cantidadRechazos++;
                                break;
                            }

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
                                break;
                            }

                            // Validación por SMS solo para montos altos.
                            if (montoTransferencia > umbralValidacionSms)
                            {
                                Console.Write("Código SMS: ");
                                if (Console.ReadLine() != codigoSmsCorrecto)
                                {
                                    Console.WriteLine("Estado: RECHAZADO. El código SMS es incorrecto.");
                                    cantidadRechazos++;
                                    break;
                                }
                            }

                            saldo -= totalTransferencia;
                            totalComisiones += comision;
                            operacionAprobada = true;
                            tipoMovimiento = "Transferencia " + tipoNormalizado;
                            montoMovimiento = -totalTransferencia;
                            Console.WriteLine("Estado: APROBADO");
                            Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("--- 5. Historial de movimientos ---");
                            if (cantidadMovimientos == 0)
                            {
                                Console.WriteLine("Todavía no hay movimientos registrados.");
                                break;
                            }

                            Console.Write("Filtrar: 1. Todos  2. Solo ingresos  3. Solo egresos: ");
                            int filtro = int.TryParse(Console.ReadLine(), out int filtroLeido) ? filtroLeido : 1;
                            int mostrados = 0;

                            // Se recorren solo las posiciones ocupadas del arreglo.
                            for (int i = 0; i < cantidadMovimientos; i++)
                            {
                                // continue: se salta el movimiento que no cumple el filtro.
                                if (filtro == 2 && historialMontos[i] < 0)
                                {
                                    continue;
                                }
                                if (filtro == 3 && historialMontos[i] > 0)
                                {
                                    continue;
                                }

                                Console.WriteLine((i + 1).ToString().PadLeft(2) + ". " + historialTipos[i].PadRight(22) + "$ " + historialMontos[i].ToString("N2").PadLeft(10));
                                mostrados++;
                            }
                            Console.WriteLine("Movimientos mostrados: " + mostrados);
                            break;
                        }

                    case 6:
                        {
                            Console.WriteLine("--- 6. Resumen ---");

                            // Totales calculados recorriendo las posiciones ocupadas del historial.
                            decimal totalIngresos = 0m;
                            decimal totalEgresos = 0m;
                            for (int i = 0; i < cantidadMovimientos; i++)
                            {
                                if (historialMontos[i] > 0)
                                {
                                    totalIngresos += historialMontos[i];
                                }
                                else
                                {
                                    totalEgresos += historialMontos[i];
                                }
                            }

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
                            Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);
                            Console.WriteLine("Total ingresos: $ " + totalIngresos.ToString("N2"));
                            Console.WriteLine("Total egresos: $ " + totalEgresos.ToString("N2"));
                            Console.WriteLine("Operaciones rechazadas: " + cantidadRechazos);
                            Console.WriteLine("Comisiones pagadas: $ " + totalComisiones.ToString("N2"));
                            Console.WriteLine("Extraído hoy: $ " + totalExtraidoHoy.ToString("N2"));
                            if (movimientosNoRegistrados > 0)
                            {
                                Console.WriteLine("Movimientos sin registrar en el historial (capacidad agotada): " + movimientosNoRegistrados);
                            }
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine("Gracias por utilizar la Billetera Virtual.");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opción no válida. Ingrese un número del 1 al 7.");
                            break;
                        }
                }

                // Registro común: si la operación fue aprobada se guarda en el historial.
                if (operacionAprobada)
                {
                    if (cantidadMovimientos < capacidadHistorial)
                    {
                        historialTipos[cantidadMovimientos] = tipoMovimiento;
                        historialMontos[cantidadMovimientos] = montoMovimiento;
                        cantidadMovimientos++;
                    }
                    else
                    {
                        movimientosNoRegistrados++;
                        Console.WriteLine("Aviso: el historial está completo. El movimiento no se registró en el historial.");
                    }
                }
            } while (opcion != 7);

            Console.WriteLine();
            Console.WriteLine("Fin de la sesión " + fechaSesion.ToString("dd/MM/yyyy") + ". Saldo final: $ " + saldo.ToString("N2"));
        }
    }
}
