namespace Ej05_ControlDeAcceso
{
    // Ejercicio 5: Control de acceso con salidas anticipadas (return en Main).

    class Program
    {
        static void Main()
        {
            // ===== Constantes =====
            const string claveCorrecta = "2468";
            const int maximoIntentosClave = 3;
            const int horaApertura = 6;
            const int horaCierre = 22;
            const decimal limiteExtraccionOperacion = 1000.00m;
            const decimal limiteExtraccionDiario = 1500.00m;
            const decimal comisionFija = 50.00m;

            // ===== Estado =====
            decimal saldo = 400.00m;
            decimal totalExtraidoHoy = 900.00m;

            Console.WriteLine("=== ACCESO A LA BILLETERA VIRTUAL ===");

            // ===== Control 1: horario de atención =====
            Console.Write("Hora actual (0 a 23): ");
            if (!int.TryParse(Console.ReadLine(), out int hora) || hora < 0 || hora > 23)
            {
                Console.WriteLine("Hora inválida. Fin del programa.");
                return;
            }

            if (hora < horaApertura || hora >= horaCierre)
            {
                Console.WriteLine("Servicio disponible de " + horaApertura + ":00 a " + horaCierre + ":00. Fin del programa.");
                return;
            }

            // ===== Control 2: clave con intentos limitados =====
            bool accesoOtorgado = false;
            for (int intento = 1; intento <= maximoIntentosClave; intento++)
            {
                Console.Write("Ingrese su clave (intento " + intento + " de " + maximoIntentosClave + "): ");
                if (Console.ReadLine() == claveCorrecta)
                {
                    accesoOtorgado = true;
                    break;
                }
                Console.WriteLine("Clave incorrecta.");
            }

            if (!accesoOtorgado)
            {
                Console.WriteLine("Cuenta bloqueada por intentos fallidos. Fin del programa.");
                return;
            }

            Console.WriteLine("Acceso concedido.");
            Console.WriteLine();

            // ===== Extracción con validaciones: cada falla termina el programa =====
            Console.WriteLine("--- Extraer efectivo ---");
            Console.WriteLine("Saldo: $ " + saldo.ToString("N2") + " | Extraído hoy: $ " + totalExtraidoHoy.ToString("N2"));
            Console.Write("Monto a extraer: ");
            decimal monto = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : 0m;

            if (monto <= 0)
            {
                Console.WriteLine("Estado: RECHAZADO. El monto debe ser un número mayor que cero.");
                return;
            }

            if (monto > limiteExtraccionOperacion)
            {
                Console.WriteLine("Estado: RECHAZADO. Supera el límite por operación de $ " + limiteExtraccionOperacion.ToString("N2") + ".");
                return;
            }

            if (totalExtraidoHoy + monto > limiteExtraccionDiario)
            {
                Console.WriteLine("Estado: RECHAZADO. Supera el límite diario. Disponible hoy: $ " + (limiteExtraccionDiario - totalExtraidoHoy).ToString("N2") + ".");
                return;
            }

            if (saldo < monto + comisionFija)
            {
                Console.WriteLine("Estado: RECHAZADO. Saldo insuficiente.");
                return;
            }

            saldo -= monto + comisionFija;
            totalExtraidoHoy += monto;
            Console.WriteLine("Estado: APROBADO");
            Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));

            // Este mensaje solo se muestra si la extracción fue aprobada: los return anteriores lo evitan.
            Console.WriteLine("Fin de la sesión. Extraído hoy: $ " + totalExtraidoHoy.ToString("N2"));
        }
    }
}
