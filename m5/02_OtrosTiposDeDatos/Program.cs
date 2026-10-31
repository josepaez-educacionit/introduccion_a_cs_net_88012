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
        }
    }
}
