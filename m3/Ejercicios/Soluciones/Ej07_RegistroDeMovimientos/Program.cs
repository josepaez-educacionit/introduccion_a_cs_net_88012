namespace Ej07_RegistroDeMovimientos
{
    // Ejercicio 7: Registro de movimientos con arreglos (arreglos, for y foreach).

    class Program
    {
        static void Main()
        {
            // ===== Arreglos paralelos: el índice i relaciona concepto y monto =====
            // Montos positivos = ingresos; montos negativos = egresos.
            string[] conceptos = { "Carga inicial", "Extracción cajero", "Transferencia a Luis", "Carga desde banco",
                               "Extracción cajero", "Transferencia a María", "Carga desde banco", "Comisión mensual" };
            decimal[] montos = { 2000.00m, -500.00m, -800.00m, 1200.00m, -300.00m, -450.00m, 600.00m, -50.00m };
            const decimal saldoInicial = 1500.00m;
            const decimal montoRelevante = 1000.00m;

            Console.WriteLine("=== REGISTRO DE MOVIMIENTOS ===");
            Console.WriteLine("Cantidad de movimientos: " + montos.Length);

            // ===== Parte 1: listado con for y saldo acumulado =====
            Console.WriteLine();
            Console.WriteLine("--- Detalle de movimientos ---");
            decimal saldoActual = saldoInicial;
            Console.WriteLine("Saldo inicial: $ " + saldoInicial.ToString("N2"));
            for (int i = 0; i < montos.Length; i++)
            {
                saldoActual += montos[i];
                Console.WriteLine((i + 1).ToString().PadLeft(2) + ". " + conceptos[i].PadRight(22)
                                  + "$ " + montos[i].ToString("N2").PadLeft(10)
                                  + "  | Saldo: $ " + saldoActual.ToString("N2"));
            }

            // ===== Parte 2: totales con foreach =====
            decimal totalIngresos = 0m;
            decimal totalEgresos = 0m;
            foreach (decimal monto in montos)
            {
                if (monto > 0)
                {
                    totalIngresos += monto;
                }
                else
                {
                    totalEgresos += monto;
                }
            }

            Console.WriteLine();
            Console.WriteLine("--- Totales ---");
            Console.WriteLine("Ingresos: $ " + totalIngresos.ToString("N2"));
            Console.WriteLine("Egresos: $ " + totalEgresos.ToString("N2"));
            Console.WriteLine("Saldo final: $ " + (saldoInicial + totalIngresos + totalEgresos).ToString("N2"));

            // ===== Parte 3: mayor ingreso y mayor egreso (con su posición) =====
            int posicionMayorIngreso = 0;
            int posicionMayorEgreso = 0;
            for (int i = 1; i < montos.Length; i++)
            {
                if (montos[i] > montos[posicionMayorIngreso])
                {
                    posicionMayorIngreso = i;
                }
                if (montos[i] < montos[posicionMayorEgreso])
                {
                    posicionMayorEgreso = i;
                }
            }

            Console.WriteLine();
            Console.WriteLine("--- Extremos ---");
            Console.WriteLine("Mayor ingreso: $ " + montos[posicionMayorIngreso].ToString("N2") + " (" + conceptos[posicionMayorIngreso] + ")");
            Console.WriteLine("Mayor egreso: $ " + montos[posicionMayorEgreso].ToString("N2") + " (" + conceptos[posicionMayorEgreso] + ")");

            // ===== Parte 4: movimientos relevantes (valor absoluto >= $ 1.000,00) =====
            Console.WriteLine();
            Console.WriteLine("--- Movimientos relevantes (>= $ " + montoRelevante.ToString("N2") + ") ---");
            int cantidadRelevantes = 0;
            for (int i = 0; i < montos.Length; i++)
            {
                decimal absoluto = montos[i] < 0 ? -montos[i] : montos[i];
                if (absoluto >= montoRelevante)
                {
                    Console.WriteLine("- " + conceptos[i] + ": $ " + montos[i].ToString("N2"));
                    cantidadRelevantes++;
                }
            }
            Console.WriteLine("Total de movimientos relevantes: " + cantidadRelevantes);

            // ===== Parte 5: búsqueda de un concepto ingresado por el usuario =====
            Console.WriteLine();
            Console.Write("Concepto a buscar: ");
            string? buscado = Console.ReadLine();
            int posicionEncontrada = -1;
            for (int i = 0; i < conceptos.Length; i++)
            {
                if (conceptos[i] == buscado)
                {
                    posicionEncontrada = i;
                    break;
                }
            }

            if (posicionEncontrada == -1)
            {
                Console.WriteLine("No se encontró ningún movimiento con ese concepto.");
            }
            else
            {
                Console.WriteLine("Primera aparición en la posición " + (posicionEncontrada + 1) + ": $ " + montos[posicionEncontrada].ToString("N2"));
            }

            // ===== Parte 6: corrección de un movimiento por posición =====
            Console.WriteLine();
            Console.Write("Número de movimiento a corregir (1 a " + montos.Length + "): ");
            if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 1 && numero <= montos.Length)
            {
                Console.Write("Nuevo monto: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal nuevoMonto))
                {
                    int indice = numero - 1;
                    Console.WriteLine("Movimiento corregido: de $ " + montos[indice].ToString("N2") + " a $ " + nuevoMonto.ToString("N2"));
                    montos[indice] = nuevoMonto;

                    decimal saldoCorregido = saldoInicial;
                    foreach (decimal monto in montos)
                    {
                        saldoCorregido += monto;
                    }
                    Console.WriteLine("Nuevo saldo final: $ " + saldoCorregido.ToString("N2"));
                }
                else
                {
                    Console.WriteLine("El monto ingresado no es válido. No se modificó el movimiento.");
                }
            }
            else
            {
                Console.WriteLine("Número de movimiento fuera de rango. No se modificó nada.");
            }
        }
    }
}
