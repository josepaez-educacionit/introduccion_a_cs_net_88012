/*
2. Otros tipos de datos.

Además de los tipos de datos básicos vistos anteriormente, como los números enteros, los
números con decimales, los valores lógicos y los caracteres, C# ofrece otros tipos de datos
que permiten representar información adicional de manera más precisa según la necesidad de
cada programa.

Existen tipos de datos especiales pensados para representar fechas y horas:
DateTime almacena una fecha y hora concretas, y TimeSpan representa una duración. Permiten
manipular momentos específicos en el tiempo y calcular diferencias entre ellos (restar dos
fechas produce un TimeSpan), algo que resultaría mucho más complejo utilizando únicamente
números o texto. Cuando solo interesa una de las dos partes, DateOnly almacena únicamente la
fecha (por ejemplo, una fecha de nacimiento) y TimeOnly únicamente la hora (por ejemplo, un
horario de atención).

Otros tipos resuelven necesidades puntuales: Guid genera identificadores únicos globales sin
necesidad de coordinar un contador, y BigInteger representa enteros de tamaño ilimitado, como
el resultado de un factorial que no cabe en un long.

Finalmente, las tuplas agrupan varios valores con nombre sin necesidad de definir una clase o
estructura, y las colecciones genéricas amplían lo que se puede hacer con los arreglos:
List<T> es una lista que crece dinámicamente y Dictionary<TKey, TValue> almacena pares
clave-valor con búsqueda directa por clave.

Conocer estos otros tipos de datos permite elegir, en cada situación, la representación más
adecuada para la información que se necesita manejar, evitando forzar el uso de un tipo básico
para un propósito para el cual no fue pensado.

En resumen, C# ofrece, además de los tipos de datos fundamentales, otros tipos especializados que permiten representar con mayor precisión y comodidad la información de un programa.
*/

using System.Numerics;

namespace _02_OtrosTiposDeDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DateTime: representa una fecha y hora concretas.
            DateTime fechaPedido = DateTime.Now;
            DateTime fechaEntrega = fechaPedido.AddDays(5);
            TimeSpan tiempoDeEspera = fechaEntrega - fechaPedido; // restar fechas produce un TimeSpan

            // TimeSpan: representa una duración (días, horas, minutos...).
            TimeSpan duracionGarantia = TimeSpan.FromDays(365);
            DateTime vencimientoGarantia = fechaEntrega + duracionGarantia;

            // DateOnly y TimeOnly: almacenan solo la fecha o solo la hora, sin la otra parte.
            DateOnly fechaNacimiento = new DateOnly(1990, 5, 17);
            TimeOnly horaApertura = new TimeOnly(9, 30);
            TimeOnly horaCierre = horaApertura.AddHours(8.5);

            // Guid: identificador único global de 128 bits; no requiere coordinar un contador
            Guid idPedido = Guid.NewGuid();

            // BigInteger: entero sin límite de tamaño (long se desborda en 20!).
            BigInteger factorial25 = 1;
            for (int i = 2; i <= 25; i++)
            {
                factorial25 *= i;
            }

            // Tupla: agrupa varios valores con nombre sin definir una clase o estructura.
            (string nombre, decimal precio) producto = ("Teclado", 45.50m);

            // List<T>: lista que crece dinámicamente (a diferencia de un arreglo de tamaño fijo).
            List<decimal> montos = new List<decimal> { 10.5m, 20m };
            montos.Add(35.25m);
            montos.Remove(20m);

            // Dictionary<TKey, TValue>: pares clave-valor con búsqueda directa por clave.
            Dictionary<string, int> stock = new Dictionary<string, int>
            {
                ["Teclado"] = 12,
                ["Mouse"] = 30
            };

            stock["Mouse"] -= 5;

            // Salida por consola: todos los resultados se muestran al final.
            Console.WriteLine("--- Fechas ---");
            Console.WriteLine($"Fecha del pedido: {fechaPedido:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Entrega estimada: {fechaEntrega:dd/MM/yyyy}");
            Console.WriteLine($"Días de espera: {tiempoDeEspera.Days}");
            Console.WriteLine($"Garantía hasta: {vencimientoGarantia:dd/MM/yyyy}");

            Console.WriteLine("--- Solo fecha / solo hora ---");
            Console.WriteLine($"Nacimiento: {fechaNacimiento:dd/MM/yyyy} (día {fechaNacimiento.DayOfWeek})");
            Console.WriteLine($"Atención: {horaApertura:HH:mm} a {horaCierre:HH:mm}");

            Console.WriteLine("--- Colecciones ---");
            Console.WriteLine($"Montos ({montos.Count}): {string.Join(", ", montos)}");
            Console.WriteLine($"Stock de Mouse: {stock["Mouse"]}");
            Console.WriteLine($"¿Hay Monitor?: {stock.ContainsKey("Monitor")}");

            Console.WriteLine("--- Identificador, enteros enormes y tuplas ---");
            Console.WriteLine($"Id del pedido: {idPedido}");
            Console.WriteLine($"25! = {factorial25}");
            Console.WriteLine($"Producto: {producto.nombre} a {producto.precio:C}");
        }
    }
}
