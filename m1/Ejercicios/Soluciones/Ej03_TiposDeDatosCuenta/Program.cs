namespace Ej03_TiposDeDatosCuenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string: texto. El CVU tiene 22 dígitos, pero se guarda como texto
            // porque no se opera con él (puede empezar con ceros).
            string titular = "Ana Gómez Rivera";
            string cvu = "0000003100012345678901";
            string aliasBilletera = "ana.gomez.billetera";

            // char: un solo símbolo. A = Caja de ahorro, C = Cuenta corriente.
            char tipoCuenta = 'A';

            // decimal: montos de dinero en pesos (exactitud decimal, sin errores de redondeo).
            decimal saldoDisponible = 1800.00m;
            decimal saldoMinimoMantenimiento = 50.00m;

            // int: contadores de tamaño moderado.
            int cantidadMovimientos = 12;

            // long: identificadores que superan el rango de int.
            long idUltimaOperacion = 202610030001L;

            // byte: contador pequeño (0 a 255). Aquí, intentos fallidos de clave.
            byte intentosClaveFallidos = 1;

            // bool: estados de sí / no.
            bool cuentaActiva = true;
            bool tieneTarjetaDebito = false;

            // DateTime: fecha de alta de la cuenta.
            DateTime fechaApertura = new DateTime(2023, 3, 15);

            // DateTime?: fecha que puede no existir todavía (sin movimientos).
            DateTime? fechaUltimoMovimiento = null;


            string nombreTipo = tipoCuenta == 'A' ? "Caja de ahorro en pesos" : "Cuenta corriente";
            string textoUltimoMovimiento = fechaUltimoMovimiento.HasValue ? 
                        fechaUltimoMovimiento.Value.ToString("dd/MM/yyyy")
                        : 
                        "Sin movimientos registrados";

            Console.WriteLine("=== FICHA DE LA BILLETERA ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("CVU: " + cvu);
            Console.WriteLine("Alias: " + aliasBilletera);
            Console.WriteLine("Tipo de cuenta: " + nombreTipo);
            Console.WriteLine("Saldo disponible: $ " + saldoDisponible.ToString("N2"));
            Console.WriteLine("Saldo mínimo de mantenimiento: $ " + saldoMinimoMantenimiento.ToString("N2"));
            Console.WriteLine("Cantidad de movimientos: " + cantidadMovimientos);
            Console.WriteLine("Último identificador de operación: " + idUltimaOperacion);
            Console.WriteLine("Intentos fallidos de clave: " + intentosClaveFallidos);
            Console.WriteLine("Cuenta activa: " + cuentaActiva);
            Console.WriteLine("Tarjeta de débito: " + tieneTarjetaDebito);
            Console.WriteLine("Fecha de alta: " + fechaApertura.ToString("dd/MM/yyyy"));
            Console.WriteLine("Último movimiento: " + textoUltimoMovimiento);
            Console.WriteLine();

            // Errores de tipo que el compilador detecta (descomentar para verlos):
            // int cuotas = 12.5;        // CS0266: no se puede convertir double a int.
            // byte intentos = 300;      // CS0031: 300 está fuera del rango de byte.
        }
    }
}
