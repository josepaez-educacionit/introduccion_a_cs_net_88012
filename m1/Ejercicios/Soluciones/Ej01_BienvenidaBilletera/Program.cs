namespace Ej01_BienvenidaBilletera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombreBanco = "Banco NetSur";
            string nombreAplicacion = "BILLETERA VIRTUAL";

            Console.WriteLine("==============================================");
            Console.WriteLine("        " + nombreAplicacion);
            Console.WriteLine("        " + nombreBanco);
            Console.WriteLine("==============================================");
            Console.WriteLine();

            Console.WriteLine("Bienvenido/a. Seleccione una opción:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Cargar dinero");
            Console.WriteLine("3. Extraer efectivo");
            Console.WriteLine("4. Transferir (CBU / CVU / alias)");
            Console.WriteLine("5. Ver resumen de movimientos");
            Console.WriteLine("6. Salir");
            Console.WriteLine();

            Console.WriteLine("Fin de la presentación.");
        }
    }
}
