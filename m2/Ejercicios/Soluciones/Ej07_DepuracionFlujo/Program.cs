namespace Ej07_DepuracionFlujo
{
    internal class Program
    {
        static void Main()
        {
            string titular = "Luis Morales";
            decimal saldo = 1200.00m;
            decimal montoExtraccion = 1000.00m;
            decimal montoTransferencia = 300.00m;
            const decimal comisionFija = 50.00m;
            const decimal limiteExtraccion = 1000.00m;
            int opcion = 3;
            int intentosClave = 0;

            Console.WriteLine("Titular: " + titular);

            // Bloque 1: aprobación de la extracción.
            // Corrección 1 (sintaxis): se agrega el paréntesis que cierra la condición del if.
            // Corrección 7 (lógica): el límite es inclusivo, por lo que corresponde <= y no <.
            if (montoExtraccion <= limiteExtraccion && saldo >= montoExtraccion + comisionFija)
            {
                saldo = saldo - montoExtraccion - comisionFija;
                Console.WriteLine("Extracción aprobada. Saldo: $ " + saldo.ToString("N2"));
            }
            else
            {
                Console.WriteLine("Extracción rechazada.");
            }

            // Bloque 2: nombre de la operación elegida.
            // Corrección 2 (sintaxis): se agrega el punto y coma después del primer break.
            // Corrección 4 (semántica): el case 2 termina con break; no puede continuar en el case 3.
            // Corrección 5 (semántica): se agrega default para que la variable siempre tenga valor.
            string nombreOperacion;
            switch (opcion)
            {
                case 1:
                    nombreOperacion = "Consultar saldo";
                    break;
                case 2:
                    nombreOperacion = "Cargar dinero";
                    break;
                case 3:
                    nombreOperacion = "Extraer efectivo";
                    break;
                default:
                    nombreOperacion = "Opción no válida";
                    break;
            }
            Console.WriteLine("Operación: " + nombreOperacion);

            // Bloque 3: validación de la opción elegida.
            // Corrección 3 (sintaxis): se elimina el punto y coma que cerraba el if antes de su bloque.
            // Corrección 6 (semántica): para comparar se usa == (el operador = asigna).
            if (opcion == 3)
            {
                Console.WriteLine("La opción 3 requiere validar el límite diario.");
            }
            else
            {
                Console.WriteLine("La opción elegida no requiere validación.");
            }

            // Bloque 4: comisión de la transferencia según el monto.
            // Corrección 8 (lógica): las condiciones se evalúan en orden, de la más restrictiva
            // a la más amplia. Con "<= 1000" primero, un monto de 300 nunca llega al tramo del 1,5 %.
            decimal porcentajeComision;
            if (montoTransferencia <= 500m)
            {
                porcentajeComision = 1.5m;
            }
            else if (montoTransferencia <= 1000m)
            {
                porcentajeComision = 1.2m;
            }
            else
            {
                porcentajeComision = 1.0m;
            }
            decimal comision = montoTransferencia * porcentajeComision / 100m;
            Console.WriteLine("Comisión de transferencia: " + porcentajeComision.ToString("N1") + " % ($ " + comision.ToString("N2") + ")");

            // Bloque 5: reintentos de clave.
            // Corrección 9 (lógica): la variable de la condición se modifica dentro del ciclo.
            while (intentosClave < 3)
            {
                intentosClave++;
                Console.WriteLine("Reintento " + intentosClave + " de 3");
            }
            Console.WriteLine("Se agotaron los reintentos.");
        }

    }
}
