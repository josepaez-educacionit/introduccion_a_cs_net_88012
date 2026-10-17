namespace M3_03_InstruccionBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: búsqueda de un elemento en una lista.
            // Una vez encontrado el producto no tiene sentido seguir recorriendo el resto,
            // por lo que break abandona el for de inmediato.
            string[] inventario = { "Teclado", "Mouse", "Monitor", "Auriculares", "Webcam" };
            string productoBuscado = "Celular";
            int posicionEncontrada = -1;

            for (int indice = 0; indice < inventario.Length; indice++)
            {
                if (inventario[indice] == productoBuscado)
                {
                    posicionEncontrada = indice;
                    break;
                }
            }

            if (posicionEncontrada >= 0)
            {
                Console.WriteLine(productoBuscado + " encontrado en la posición " + posicionEncontrada);
            }
            else
            {
                Console.WriteLine(productoBuscado + " no se encuentra en el inventario.");
            }


            // Ejemplo 2: interrupción del ciclo cuando se detecta una condición de corte.
            // Se procesan pagos hasta que el saldo disponible no alcanza para el siguiente.
            decimal saldoDisponible = 500m;
            decimal[] pagosPendientes = { 120m, 200m, 150m, 90m, 60m };

            for (int numeroPago = 0; numeroPago < pagosPendientes.Length; numeroPago++)
            {
                if (pagosPendientes[numeroPago] > saldoDisponible)
                {
                    Console.WriteLine("Saldo insuficiente para el pago de $" + pagosPendientes[numeroPago] + ". Proceso detenido.");
                    break;
                }

                saldoDisponible -= pagosPendientes[numeroPago];
                Console.WriteLine("Pago de $" + pagosPendientes[numeroPago] + " realizado. Saldo restante: $" + saldoDisponible);
            }

            // Ejemplo 3: break en un ciclo while(true) que se repite hasta que el usuario decide salir.
            // La condición de salida se evalúa dentro del cuerpo, no en el encabezado del while.
            while (true)
            {
                Console.Write("Ingrese un comando (ayuda / salir): ");
                string comando = Console.ReadLine();

                if (comando == "salir")
                {
                    Console.WriteLine("Programa finalizado.");
                    break;
                }

                if (comando == "ayuda")
                {
                    Console.WriteLine("Comandos disponibles: ayuda, salir.");
                }
                else
                {
                    Console.WriteLine("Comando no reconocido.");
                }
            }
        }
    }
}
