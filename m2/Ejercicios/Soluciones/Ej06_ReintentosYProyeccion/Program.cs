namespace Ej06_ReintentosYProyeccion
{
    internal class Program
    {
        static void Main()
        {
            // Reglas del banco.
            const string claveCorrecta = "2468";
            const int maximoIntentosClave = 3;
            const decimal limiteCargaOperacion = 5000.00m;
            const decimal tasaRendimientoMensual = 0.4m;
            const decimal metaAhorro = 5000.00m;

            // Estado de la cuenta.
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1800.00m;

            // ===== Parte 1: ingreso de clave con intentos limitados =====
            Console.WriteLine("=== ACCESO A LA BILLETERA ===");
            Console.WriteLine("Titular: " + titular);

            int intentos = 0;
            bool accesoOtorgado = false;

            // El ciclo se repite mientras queden intentos y no se haya ingresado la clave correcta.
            // Dentro del bloque se modifican las variables de la condición, para que el ciclo termine.
            while (intentos < maximoIntentosClave && !accesoOtorgado)
            {
                Console.Write("Ingrese su clave: ");
                string? claveIngresada = Console.ReadLine();
                intentos++;

                if (claveIngresada == claveCorrecta)
                {
                    accesoOtorgado = true;
                    Console.WriteLine("Acceso concedido.");
                }
                else
                {
                    int intentosRestantes = maximoIntentosClave - intentos;
                    Console.WriteLine("Clave incorrecta. Intentos restantes: " + intentosRestantes);
                }
            }

            if (!accesoOtorgado)
            {
                Console.WriteLine("Cuenta bloqueada por intentos fallidos. Comuníquese con el banco.");
            }
            else
            {
                // ===== Parte 2: carga de dinero con validación del monto =====
                Console.WriteLine();
                Console.WriteLine("=== CARGA DE DINERO ===");

                decimal montoCarga = 0m;
                bool cargaValida = false;

                // Se repite la solicitud hasta que el monto sea válido.
                while (!cargaValida)
                {
                    Console.Write("Monto a cargar (mayor que 0 y hasta $ " + limiteCargaOperacion.ToString("N2") + "): ");

                    if (decimal.TryParse(Console.ReadLine(), out decimal montoLeido) && montoLeido > 0 && montoLeido <= limiteCargaOperacion)
                    {
                        montoCarga = montoLeido;
                        cargaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Monto no válido. Intente nuevamente.");
                    }
                }

                saldo += montoCarga;
                Console.WriteLine("Carga acreditada: $ " + montoCarga.ToString("N2"));
                Console.WriteLine("Saldo actual: $ " + saldo.ToString("N2"));

                // ===== Parte 3: proyección de ahorro mes a mes =====
                Console.WriteLine();
                Console.WriteLine("=== PROYECCIÓN DE AHORRO ===");

                decimal aporteMensual = 300.00m;
                decimal saldoProyectado = saldo;
                int meses = 0;

                Console.WriteLine("Meta: $ " + metaAhorro.ToString("N2") + " | Aporte mensual: $ " + aporteMensual.ToString("N2"));

                // No se sabe de antemano cuántos meses harán falta: el ciclo termina al alcanzar la meta.
                // Si la meta ya está alcanzada, el bloque no se ejecuta ni una vez.
                while (saldoProyectado < metaAhorro)
                {
                    decimal rendimiento = saldoProyectado * tasaRendimientoMensual / 100m;
                    saldoProyectado = saldoProyectado + rendimiento + aporteMensual;
                    meses++;
                    Console.WriteLine("Mes " + meses + ": saldo $ " + saldoProyectado.ToString("N2"));
                }

                Console.WriteLine("La meta se alcanza en " + meses + " meses.");
            }
        }

    }
}
