namespace Ej05_MenuYDestinatarios
{
    internal class Program
    {
        static void Main()
        {
            const decimal comisionFijaExtraccion = 50.00m;

            // ===== Parte 1: menú de opciones (switch sobre un entero) =====
            Console.WriteLine("=== MENÚ DE LA BILLETERA ===");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Cargar dinero");
            Console.WriteLine("3. Extraer efectivo");
            Console.WriteLine("4. Transferir (CBU / CVU / alias)");
            Console.WriteLine("5. Ver resumen de movimientos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.TryParse(Console.ReadLine(), out int opcionLeida) ? opcionLeida : 0;

            string nombreOperacion;
            string costoOperacion;

            // Cada case termina con break. default cubre las opciones no contempladas.
            switch (opcion)
            {
                case 1:
                    nombreOperacion = "Consultar saldo";
                    costoOperacion = "Sin costo";
                    break;
                case 2:
                    nombreOperacion = "Cargar dinero";
                    costoOperacion = "Sin costo";
                    break;
                case 3:
                    nombreOperacion = "Extraer efectivo";
                    costoOperacion = "Comisión fija de $ " + comisionFijaExtraccion.ToString("N2");
                    break;
                case 4:
                    nombreOperacion = "Transferir";
                    costoOperacion = "Comisión escalonada del 1,0 % al 1,5 %";
                    break;
                case 5:
                    nombreOperacion = "Ver resumen de movimientos";
                    costoOperacion = "Sin costo";
                    break;
                case 6:
                    nombreOperacion = "Salir";
                    costoOperacion = "Sin costo";
                    break;
                default:
                    nombreOperacion = "Opción no válida";
                    costoOperacion = "No corresponde";
                    break;
            }

            Console.WriteLine("Operación seleccionada: " + nombreOperacion);
            Console.WriteLine("Costo: " + costoOperacion);
            Console.WriteLine();

            // ===== Parte 2: tipo de destinatario (switch sobre un string) =====
            Console.WriteLine("=== TIPO DE DESTINATARIO ===");
            Console.Write("Tipo de identificador (CBU / CVU / ALIAS): ");
            string? tipoDestino = Console.ReadLine();

            string descripcionDestino;
            string plazoAcreditacion;

            // Varias etiquetas case consecutivas comparten el mismo bloque.
            switch (tipoDestino)
            {
                case "CBU":
                case "cbu":
                    descripcionDestino = "Cuenta bancaria";
                    plazoAcreditacion = "Hasta 24 horas hábiles";
                    break;
                case "CVU":
                case "cvu":
                    descripcionDestino = "Billetera virtual";
                    plazoAcreditacion = "Inmediata";
                    break;
                case "ALIAS":
                case "alias":
                    descripcionDestino = "Alias asociado a un CBU o CVU";
                    plazoAcreditacion = "Según la cuenta asociada";
                    break;
                default:
                    descripcionDestino = "Tipo de identificador no reconocido";
                    plazoAcreditacion = "No corresponde";
                    break;
            }

            Console.WriteLine("Destino: " + descripcionDestino);
            Console.WriteLine("Acreditación: " + plazoAcreditacion);
            Console.WriteLine();

            // ===== Parte 3: tipo de cuenta (switch sobre un char) =====
            Console.WriteLine("=== TIPO DE CUENTA ===");
            Console.Write("Tipo de cuenta (A = caja de ahorro, C = cuenta corriente): ");
            char tipoCuenta = char.TryParse(Console.ReadLine(), out char tipoLeido) ? tipoLeido : '?';

            string nombreCuenta;
            decimal descubiertoAutorizado;

            switch (tipoCuenta)
            {
                case 'A':
                case 'a':
                    nombreCuenta = "Caja de ahorro en pesos";
                    descubiertoAutorizado = 0m;
                    break;
                case 'C':
                case 'c':
                    nombreCuenta = "Cuenta corriente";
                    descubiertoAutorizado = 500.00m;
                    break;
                default:
                    nombreCuenta = "Tipo de cuenta no reconocido";
                    descubiertoAutorizado = 0m;
                    break;
            }

            Console.WriteLine("Cuenta: " + nombreCuenta);
            Console.WriteLine("Descubierto autorizado: $ " + descubiertoAutorizado.ToString("N2"));
            Console.WriteLine();

            // ===== Desafío: expresión switch =====
            // Cada brazo devuelve un valor; el descarte (_) cumple la función de default.
            string categoriaOperacion = opcion switch
            {
                1 or 5 => "Consulta",
                2 or 3 => "Movimiento de efectivo",
                4 => "Transferencia",
                6 => "Salida",
                _ => "Desconocida"
            };
            Console.WriteLine("Categoría de la operación: " + categoriaOperacion);
        }

    }
}
