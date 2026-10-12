namespace Ej06_DepuracionBilletera
{
    // Ejercicio 6 (solución): Depuración de un programa con errores.
    internal class Program
    {
        static void Main(string[] args)
        {
            // Corrección 1: cadena cerrada con comillas.
            string titular = "Luis Morales";
            Console.WriteLine("Titular: " + titular);

            // Corrección 2: se agrega el punto y coma final.
            decimal saldo = 900.00m;
            decimal montoExtraccion = 250.00m;

            // Corrección 3: 12.5 es decimal; una variable int solo acepta enteros.
            int cuotas = 12;

            // Corrección 4: la constante no puede reasignarse; se usa una variable.
            decimal tasaComision = 1.5m;
            tasaComision = 2.0m;

            // Corrección 5: la variable recibe un valor antes de usarse.
            decimal comision = montoExtraccion * tasaComision / 100m;
            Console.WriteLine("Comisión: $ " + comision.ToString("N2"));

            // Corrección 6: nombre corregido (saldoFinal en lugar de saldoFianl).
            decimal saldoFinal = saldo - montoExtraccion - comision;
            Console.WriteLine("Saldo final: $ " + saldoFinal.ToString("N2"));

            // Corrección 7 (lógica): la división entre enteros descarta decimales.
            // Se usan literales decimal para obtener el resultado esperado.
            decimal tercio = 1m / 3m;
            Console.WriteLine("Tercio de la cuota: " + tercio);
            Console.WriteLine("Cuotas: " + cuotas);
        }
    }
}
