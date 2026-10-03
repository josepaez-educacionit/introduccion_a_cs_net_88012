/*
5. Tipos de datos.

En C#, cada variable debe tener asociado un tipo de dato, que indica qué clase de información
puede almacenar y qué operaciones son válidas sobre ella. Definir el tipo de dato correcto es
esencial, ya que permite que el compilador verifique que el programa utiliza la información de
manera coherente antes de ejecutarla.

Existen tipos de datos simples, también llamados primitivos, que representan valores básicos
como números enteros, números con decimales, caracteres individuales o valores que solo pueden
ser verdadero o falso. Junto a estos, existen tipos más elaborados, capaces de representar
información más compleja, como cadenas de texto, colecciones de varios elementos u objetos que
agrupan distintos datos relacionados entre sí.

Además, los tipos de datos se clasifican según la forma en que almacenan la información: los
tipos por valor guardan el dato directamente en el espacio de memoria de la variable, mientras
que los tipos por referencia almacenan una dirección que indica dónde se encuentra realmente el
dato dentro de la memoria. Esta diferencia influye en cómo se comportan las variables al
copiarse o al utilizarse en distintas partes de un programa.

En síntesis, comprender los tipos de datos permite al programador elegir la representación
adecuada para cada valor y anticipar cómo será tratado por el compilador y por el entorno de
ejecución de .NET.
*/

namespace TiposDeDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== Enteros con signo =====
            Console.WriteLine("===== Enteros con signo =====");

            int unidadesEnInventario = 120; // Entero de 32 bits, habitual para contar elementos.
            long bytesProcesados = 5_000_000_000L; // Entero de 64 bits para cantidades que superan el rango de int.
            short temperaturaExterior = -8; // Entero de 16 bits para un rango más reducido que int.
            sbyte ajusteTemperatura = -5; // Entero de 8 bits con signo.

            Console.WriteLine("unidadesEnInventario (int): " + unidadesEnInventario);
            Console.WriteLine("bytesProcesados (long): " + bytesProcesados);
            Console.WriteLine("temperaturaExterior (short): " + temperaturaExterior);
            Console.WriteLine("ajusteTemperatura (sbyte): " + ajusteTemperatura);
            Console.WriteLine();

            // ===== Enteros sin signo =====
            // Representan valores desde cero en adelante.
            Console.WriteLine("===== Enteros sin signo =====");

            byte porcentajeBateria = 85; // Entero de 8 bits (0 a 255); el dominio de porcentaje limita el valor a 100.
            ushort numeroHabitacion = 305; // Entero de 16 bits sin signo.
            uint registrosImportados = 250U; // Entero de 32 bits sin signo; U identifica el literal.
            ulong espacioDisponibleBytes = 10_000_000_000UL; // Entero de 64 bits sin signo; UL identifica el literal.

            Console.WriteLine("porcentajeBateria (byte): " + porcentajeBateria);
            Console.WriteLine("numeroHabitacion (ushort): " + numeroHabitacion);
            Console.WriteLine("registrosImportados (uint): " + registrosImportados);
            Console.WriteLine("espacioDisponibleBytes (ulong): " + espacioDisponibleBytes);
            Console.WriteLine();


            // ===== Números con punto decimal =====
            // Float y double representan valores aproximados; decimal representa valores exactos con base decimal.
            Console.WriteLine("===== Números con punto decimal =====");

            // Decimal: útil para importes monetarios por su representación decimal.
            decimal precioProducto = 1299.99m; // El sufijo m identifica el literal; decimal también tiene límites de rango y precisión.
            Console.WriteLine("precioProducto (decimal): " + precioProducto);

            // Punto flotante: apropiado para mediciones; algunos valores se representan de forma aproximada.
            float proporcionDescargada = 0.75f; // Punto flotante de 32 bits; el sufijo f identifica el literal.
            double distanciaRecorridaKm = 12.75; // Punto flotante de 64 bits, común para mediciones.
            Console.WriteLine("proporcionDescargada (float): " + proporcionDescargada);
            Console.WriteLine("distanciaRecorridaKm (double): " + distanciaRecorridaKm);
            Console.WriteLine();

            // ===== Caracteres y texto =====
            Console.WriteLine("===== Caracteres y texto =====");

            char categoriaProducto = 'A'; // Una unidad de código UTF-16 de 16 bits.
            string nombreCliente = "Ana García"; // Texto Unicode representado internamente con unidades UTF-16.

            Console.WriteLine("categoriaProducto (char): " + categoriaProducto);
            Console.WriteLine("nombreCliente (string): " + nombreCliente);
            Console.WriteLine();


            // ===== Valores lógicos =====
            // Expresan si una condición se cumple o no.
            Console.WriteLine("===== Valores lógicos =====");

            bool productoDisponible = true;
            bool pedidoDespachado = false;

            Console.WriteLine("productoDisponible (bool): " + productoDisponible);
            Console.WriteLine("pedidoDespachado (bool): " + pedidoDespachado);
            Console.WriteLine();


            // ===== Tipos nullable =====
            // Permiten representar un valor conocido o su ausencia (null).
            Console.WriteLine("===== Tipos nullable =====");

            int? calificacionEntrega = null; // La entrega todavía no ha recibido una calificación.
            bool? pagoConfirmado = null; // Aún no se conoce si el pago fue confirmado.

            Console.WriteLine("calificacionEntrega (int?): " + calificacionEntrega);
            Console.WriteLine("pagoConfirmado (bool?): " + pagoConfirmado);
            Console.WriteLine();


            // ===== Fecha, hora e intervalos de tiempo =====
            Console.WriteLine("===== Fecha, hora e intervalos de tiempo =====");

            // DateTime representa una fecha y hora; Now obtiene la hora local del equipo.
            DateTime fechaRegistro = DateTime.Now;
            TimeSpan duracionEntrega = new TimeSpan(1, 30, 0); // Intervalo de una hora y treinta minutos.

            Console.WriteLine("fechaRegistro (DateTime): " + fechaRegistro);
            Console.WriteLine("duracionEntrega (TimeSpan): " + duracionEntrega);
            Console.WriteLine();

            // ===== Tipos object y dynamic =====
            Console.WriteLine("===== Tipos object y dynamic =====");

            // object puede referirse a valores de distintos tipos; asignar un tipo por valor implica boxing.
            object datoImportado = 42;
            Console.WriteLine("datoImportado (object) antes: " + datoImportado);
            datoImportado = "Pendiente";
            Console.WriteLine("datoImportado (object) después: " + datoImportado);

            // dynamic aplaza la comprobación de ciertas operaciones hasta la ejecución.
            dynamic resultadoImportacion = "Pendiente";
            Console.WriteLine("resultadoImportacion (dynamic) antes: " + resultadoImportacion);

            resultadoImportacion = 42; // Puede recibir valores de tipos distintos, con menos comprobaciones estáticas.
            Console.WriteLine("resultadoImportacion (dynamic) después: " + resultadoImportacion);
            Console.WriteLine();

        }
    }
}