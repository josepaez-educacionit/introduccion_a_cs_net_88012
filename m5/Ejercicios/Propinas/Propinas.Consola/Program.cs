using Propinas.Core;

namespace Propinas.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Calculadora de propina ===");

            bool seguir = true;

            while (seguir)
            {
                decimal monto = PedirMonto();
                decimal porcentaje = PedirPorcentaje();

                // La calculadora está en el proyecto Propinas.Core y se comparte con las otras pantallas.
                CalculadoraPropina calculadora = new CalculadoraPropina(porcentaje);
                DetallePropina detalle = calculadora.Calcular(monto);
                MostrarDetalle(detalle);

                seguir = PreguntarSiContinua();
            }
            Console.WriteLine("Hasta luego.");
        }

        static bool PreguntarSiContinua()
        {
            while (true)
            {
                Console.Write("¿Calcular otra cuenta? (s/n): ");
                string? respuesta = Console.ReadLine();

                if (respuesta != null)
                {
                    respuesta = respuesta.Trim().ToLower();
                }

                if (respuesta == "s" || respuesta == "si" || respuesta == "sí")
                {
                    return true;
                }

                if (respuesta == "n" || respuesta == "no")
                {
                    return false;
                }

                Console.WriteLine("  Responda s o n.");
            }
        }

        // Pide el monto hasta que el usuario escriba un número mayor o igual a cero.
        static decimal PedirMonto()
        {
            while (true)
            {
                Console.Write("Monto de la cuenta: ");
                string? texto = Console.ReadLine();

                // TryParse intenta convertir el texto a número sin lanzar un error si no puede.
                // Usa la cultura del equipo: en Argentina, la coma separa los decimales (85,50).
                if (decimal.TryParse(texto, out decimal monto) && monto >= 0)
                {
                    return monto;
                }

                Console.WriteLine("  Ingrese un número mayor o igual a cero.");
            }
        }

        // Pide el porcentaje de propina. Si el usuario solo presiona Enter, se usa 10 %.
        static decimal PedirPorcentaje()
        {
            while (true)
            {
                Console.Write("Porcentaje de propina (Enter = 10): ");
                string? texto = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    return 0.10m;
                }

                // Se acepta que el usuario escriba "15" o "15%".
                texto = texto.Replace("%", "").Trim();

                if (decimal.TryParse(texto, out decimal porcentaje) && porcentaje >= 0 && porcentaje <= 100)
                {
                    // El usuario escribe de 0 a 100; la calculadora trabaja de 0 a 1.
                    return porcentaje / 100m;
                }

                Console.WriteLine("  Ingrese un porcentaje entre 0 y 100.");
            }
        }

        // Muestra el detalle de la cuenta, la propina y el total a pagar.
        static void MostrarDetalle(DetallePropina detalle)
        {
            // ",-16" deja la etiqueta alineada a la izquierda en 16 espacios.
            // ",14"  deja el importe alineado a la derecha en 14 espacios.
            // ":C"   da formato de moneda según la cultura del equipo.
            Console.WriteLine();
            Console.WriteLine($"  {"Cuenta",-16}{detalle.Monto,14:C}");
            Console.WriteLine($"  {"Propina",-16}{detalle.Propina,14:C}");
            Console.WriteLine($"  {"Total a pagar",-16}{detalle.Total,14:C}");
            Console.WriteLine();
        }
    }
}
