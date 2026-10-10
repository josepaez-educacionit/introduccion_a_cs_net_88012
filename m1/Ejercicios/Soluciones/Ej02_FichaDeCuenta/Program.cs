namespace Ej02_FichaDeCuenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Constantes: reglas fijas de la billetera.No cambian durante la ejecución.
            const string nombreBanco = "Banco NetSur";
            const decimal porcentajeComisionTransferencia = 1.5m;
            const decimal limiteDiarioTransferencias = 2000.00m;

            // Variables: datos de la cuenta que pueden cambiar.
            string titular = "Ana Gómez Rivera";
            string cvu = "0000003100012345678901";
            string aliasBilletera = "ana.gomez.billetera";
            decimal saldo = 1500.00m;
            int cantidadMovimientos = 0;

            Console.WriteLine("=== FICHA DE LA BILLETERA ===");
            Console.WriteLine("Entidad: " + nombreBanco);
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("CVU: " + cvu);
            Console.WriteLine("Alias: " + aliasBilletera);
            Console.WriteLine("Saldo inicial: $ " + saldo.ToString("N2"));
            Console.WriteLine("Comisión por transferencia (%): " + porcentajeComisionTransferencia);
            Console.WriteLine("Límite diario de transferencias: $ " + limiteDiarioTransferencias.ToString("N2"));
            Console.WriteLine();

            // Una carga de dinero modifica el saldo y el contador de movimientos.
            decimal montoCarga = 300.00m;
            saldo = saldo + montoCarga;
            cantidadMovimientos = cantidadMovimientos + 1;

            Console.WriteLine("=== DESPUÉS DE LA CARGA DE DINERO ===");
            Console.WriteLine("Carga realizada: $ " + montoCarga.ToString("N2"));
            Console.WriteLine("Saldo actual: $ " + saldo.ToString("N2"));
            Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);

            // Descomentar la siguiente línea produce un error de compilación (CS0131):
            //limiteDiarioTransferencias = 3000.00m;
        }
    }
}
