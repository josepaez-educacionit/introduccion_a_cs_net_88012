/*
9. Uso de consola.

La consola es el medio de comunicación básico entre el programa y el usuario, a través de la
ventana de texto de la terminal. A través de la clase Console, el programa puede escribir
información en pantalla (salida) y leer lo que el usuario escribe con el teclado (entrada).

Los datos que llegan desde la consola siempre son texto. Para operar con ellos como números hay
que convertirlos a su tipo correspondiente. Esta conversión puede ser implícita, cuando C# la
realiza automáticamente porque no hay pérdida de información, o explícita, cuando el programador
la solicita de forma expresa, porque puede perder información o fallar.

Por último, para que los resultados sean fáciles de leer, es posible dar formato a las salidas:
indicar el número de decimales, el porcentaje, la moneda, la fecha o la alineación de las columnas.

En resumen, la consola permite leer y mostrar datos, las conversiones de tipos permiten trabajar
con esos datos como números, y el formato permite presentar los resultados de manera clara.
*/


using System.Globalization;

namespace UsoDeConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                // ============================================================
                // 1. Escritura en consola: Write y WriteLine
                // ============================================================
                // Write escribe el texto y deja el cursor en la misma línea.
                // WriteLine escribe el texto y después avanza a la línea siguiente.
                Console.WriteLine("===== 1. Escritura en consola =====");
                Console.Write("Esta frase se escribe con Write, ");
                Console.Write("y continúa en la misma línea.");
                Console.WriteLine(); // Sin texto: solo avanza el cursor a la línea siguiente.
                Console.WriteLine("Esta frase se escribe con WriteLine y termina la línea.");
                Console.WriteLine();

                // ============================================================
                // 2. Conversiones de tipos: implícitas
                // ============================================================
                // Una conversión implícita la realiza C# automáticamente cuando no se pierde información.
                // Un int siempre cabe en un double, así que no hace falta indicar nada.
                Console.WriteLine("===== 2. Conversiones implícitas =====");
                int entero = 25;
                double real = entero; // int -> double: conversión implícita
                Console.WriteLine($"int {entero} convertido a double: {real}");
                Console.WriteLine();

                // ============================================================
                // 3. Conversiones de tipos: explícitas (casting)
                // ============================================================
                // Una conversión explícita se escribe entre paréntesis delante del valor: (tipo)valor.
                // Se usa cuando puede haber pérdida de información. Aquí la parte decimal se descarta (truncado).
                Console.WriteLine("===== 3. Conversiones explícitas =====");
                double precio = 9.7;
                int parteEntera = (int)precio; // double -> int: se pierde la parte decimal
                Console.WriteLine($"double {precio} convertido a int (casting): {parteEntera}");
                Console.WriteLine();

                // ============================================================
                // 4. Conversiones de tipos: número a texto y texto a número
                // ============================================================
                // ToString() convierte un número en texto.
                // Convert.ToInt32 y Convert.ToDouble convierten texto en número.
                // Si el texto no es un número válido, Convert lanza una excepción (error en tiempo de ejecución).
                Console.WriteLine("===== 4. Número a texto y texto a número =====");
                string numeroComoTexto = entero.ToString();
                Console.WriteLine("Número convertido a texto: \"" + numeroComoTexto + "\"");

                int textoComoEntero = Convert.ToInt32("42");
                double textoComoReal = Convert.ToDouble("3.5", CultureInfo.InvariantCulture);
                Console.WriteLine($"Texto \"42\" convertido a int: {textoComoEntero + 1}");
                Console.WriteLine($"Texto \"3.5\" convertido a double: {textoComoReal * 2}");
                Console.WriteLine();

                // ============================================================
                // 5. Escritura con interpolación de cadenas
                // ============================================================
                // Con el prefijo $ se pueden insertar variables dentro de la cadena usando llaves { }.
                Console.WriteLine("===== 5. Interpolación de cadenas =====");
                string nombreAlumno = "Lucía";
                int notaFinal = 9;
                Console.WriteLine($"El alumno {nombreAlumno} obtuvo una nota de {notaFinal}.");
                Console.WriteLine();

                // ============================================================
                // 6. Formato de salida: decimales, porcentajes y fechas
                // ============================================================
                // Dentro de las llaves se puede indicar un formato después de dos puntos: {valor:formato}.
                //   F2  -> número con 2 decimales
                //   N0  -> número con separador de miles y sin decimales
                //   P1  -> porcentaje con 1 decimal (0.256 se muestra como 25,6 %)
                //   C2  -> moneda con 2 decimales
                //   dd/MM/yyyy -> formato personalizado de fecha
                // Nota: N, P y C usan la configuración regional del equipo (en español, la coma separa decimales).
                Console.WriteLine("===== 6. Formato de salida =====");
                double pi = Math.PI;
                double ventas = 1234567.891;
                double tasa = 0.256;
                DateTime fechaCurso = new DateTime(2026, 10, 3);

                Console.WriteLine($"Pi con dos decimales (F2): {pi:F2}");
                Console.WriteLine($"Ventas con separador de miles (N0): {ventas:N0}");
                Console.WriteLine($"Tasa como porcentaje (P1): {tasa:P1}");
                Console.WriteLine($"Precio como moneda (C2): {precio:C2}");
                Console.WriteLine($"Fecha personalizada (dd/MM/yyyy): {fechaCurso:dd/MM/yyyy}");
                Console.WriteLine();

                // ============================================================
                // 7. Formato de salida: alineación de columnas
                // ============================================================
                // Después de la expresión se puede indicar un ancho: {valor,ancho}.
                // Un ancho positivo alinea a la derecha y uno negativo alinea a la izquierda.
                Console.WriteLine("===== 7. Alineación de columnas =====");
                Console.WriteLine($"{"Producto",-12}{"Cantidad",10}{"Precio",12}");
                Console.WriteLine(new string('-', 34));
                Console.WriteLine($"{"Lápiz",-12}{3,10}{0.5,12:F2}");
                Console.WriteLine($"{"Cuaderno",-12}{2,10}{3.25,12:F2}");
                Console.WriteLine($"{"Mochila",-12}{1,10}{18.9,12:F2}");
                Console.WriteLine();

                // ============================================================
                // 8. Lectura en consola: ReadLine
                // ============================================================
                // ReadLine espera a que el usuario escriba una línea y pulse Enter.
                // Siempre devuelve texto (string), por lo que los números deben convertirse.
                Console.WriteLine("===== 8. Lectura de texto =====");
                Console.Write("Escribe tu nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Has escrito: " + nombre);
                Console.WriteLine();

                // ============================================================
                // 9. Lectura de números: TryParse para validar la entrada
                // ============================================================
                // int.Parse convierte el texto en número, pero lanza una excepción si el texto no es válido.
                // int.TryParse es más seguro: devuelve true si la conversión funciona y false si no.
                Console.WriteLine("===== 9. Lectura de números =====");
                Console.Write("Escribe un número entero: ");
                string entradaTexto = Console.ReadLine();

                if (int.TryParse(entradaTexto, out int numeroLeido))
                {
                    Console.WriteLine($"El doble de {numeroLeido} es {numeroLeido * 2}.");
                }
                else
                {
                    Console.WriteLine("Lo que escribiste no es un número entero válido.");
                }
                Console.WriteLine();

                // Lectura de un decimal con punto, usando la cultura invariante para aceptar el punto como separador.
                Console.Write("Escribe un número decimal (usa punto, por ejemplo 3.5): ");
                string decimalTexto = Console.ReadLine();

                if (double.TryParse(decimalTexto, NumberStyles.Float, CultureInfo.InvariantCulture, out double decimalLeido))
                {
                    Console.WriteLine($"Has escrito el decimal {decimalLeido:F2}.");
                }
                else
                {
                    Console.WriteLine("Lo que escribiste no es un número decimal válido.");
                }
                Console.WriteLine();

                // ============================================================
                // 10. Lectura de una tecla: ReadKey
                // ============================================================
                // ReadKey espera una tecla y devuelve información de ella sin necesidad de pulsar Enter.
                // Se usa true en el parámetro para que la tecla no se muestre en pantalla.
                Console.WriteLine("===== 10. Lectura de una tecla =====");
                Console.Write("Pulsa cualquier tecla para continuar...");
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                Console.WriteLine();
                Console.WriteLine("Has pulsado: " + tecla.Key);
                Console.WriteLine();

                // ============================================================
                // 12. Ejemplo práctico: leer datos, convertirlos y mostrar un resumen
                // ============================================================
                // Combina lectura, conversión de tipos y formato de salida.
                Console.WriteLine("===== 12. Ejemplo práctico =====");
                Console.Write("Nombre del producto: ");
                string producto = Console.ReadLine();

                Console.Write("Cantidad de unidades: ");
                int cantidad = int.TryParse(Console.ReadLine(), out int cantidadLeida) ? cantidadLeida : 0;

                Console.Write("Precio por unidad: ");
                double precioUnitario = double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double precioLeido) ? precioLeido : 0;

                double total = cantidad * precioUnitario;
                Console.WriteLine();
                Console.WriteLine("----- Resumen -----");
                Console.WriteLine($"{"Producto:",-12}{producto}");
                Console.WriteLine($"{"Cantidad:",-12}{cantidad}");
                Console.WriteLine($"{"Total:",-12}{total:F2}");
                Console.WriteLine("-------------------");
            }
        }
    }
}