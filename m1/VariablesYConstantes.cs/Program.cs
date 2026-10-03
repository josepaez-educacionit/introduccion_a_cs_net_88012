/*
4. Variables y constantes.

Para que un programa pueda trabajar con información, necesita un lugar donde guardarla
temporalmente mientras se ejecuta. Para esto se utilizan las variables, que son espacios de
memoria identificados con un nombre, en los que se almacena un dato que puede cambiar a lo
largo de la ejecución del programa.

Cada variable debe declararse indicando el tipo de dato que va a almacenar (por ejemplo, un
número entero o un texto) junto con el nombre que se le asignará. A partir de ese momento, el
programa puede leer el valor guardado en esa variable o modificarlo cuantas veces sea
necesario.

Existen situaciones en las que un valor no debe cambiar una vez definido, ya sea porque
representa una regla fija del programa o un dato que no tiene sentido modificar durante su
ejecución. Para estos casos se utilizan las constantes, que se declaran de forma similar a las
variables, pero indicando explícitamente que su valor quedará fijo desde el inicio y no podrá
alterarse posteriormente.

En resumen, las variables permiten almacenar y actualizar información a medida que el programa
se ejecuta, mientras que las constantes garantizan que ciertos valores permanezcan siempre
iguales, aportando mayor claridad y seguridad al código.
*/

namespace VariablesYConstantes.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ===== Declaración de variables y asignación posterior =====
            // Los datos del cliente llegan por separado.
            Console.WriteLine("===== Declaración de variables y asignación posterior =====");
            string nombreCliente;
            int cantidadProductos;

            nombreCliente = "Ana Gómez";
            cantidadProductos = 2;

            Console.WriteLine("Cliente: " + nombreCliente);
            Console.WriteLine("Productos solicitados: " + cantidadProductos);
            Console.WriteLine();

            // ===== Inicialización directa de variables =====
            // El precio se conoce al crear la línea del pedido.
            Console.WriteLine("===== Inicialización directa de variables =====");
            decimal precioPorUnidad = 12.50m;
            decimal totalPedido = precioPorUnidad * cantidadProductos;

            Console.WriteLine("Precio por unidad: " + precioPorUnidad);
            Console.WriteLine("Total del pedido: " + totalPedido);
            Console.WriteLine();

            // ===== Declaración de constantes =====
            // Una constante representa una regla fija del comercio durante la ejecución.
            Console.WriteLine("===== Declaración de constantes =====");
            const int diasDevolucionPermitidos = 30;

            Console.WriteLine("Plazo de devolución (días): " + diasDevolucionPermitidos);
            Console.WriteLine();


            // ===== Modificación del valor de una variable =====
            // Las variables pueden cambiar; si cambia la cantidad, se vuelve a calcular el total.
            Console.WriteLine("===== Modificación del valor de una variable =====");
            cantidadProductos = 3;
            totalPedido = precioPorUnidad * cantidadProductos;
            
            Console.WriteLine("Cantidad actualizada: " + cantidadProductos);
            Console.WriteLine("Total actualizado: " + totalPedido);
            Console.WriteLine();


            // ===== Las constantes no se pueden reasignar =====
            Console.WriteLine("===== Las constantes no se pueden reasignar =====");
            Console.WriteLine("Intentar reasignar diasDevolucionPermitidos generaría un error de compilación.");
            // Descomenta la línea para observar el error de compilación:
            //diasDevolucionPermitidos = 45;
            Console.WriteLine();


            // ===== Buenas prácticas de nombrado =====
            // Comparar un nombre que no comunica intención con uno que sí lo hace.
            Console.WriteLine("===== Buenas prácticas de nombrado =====");

            // Nombre pobre: no indica qué representa el valor ni para qué se usa.
            int x = 15;
            Console.WriteLine("Con un nombre pobre, no queda claro qué es \"x\": " + x);

            // Nombre descriptivo (camelCase): comunica claramente su propósito.
            int porcentajeDescuentoAplicado = 15;
            Console.WriteLine("Con un nombre descriptivo, el propósito es evidente: porcentajeDescuentoAplicado = " + porcentajeDescuentoAplicado);

            // Constante pública (PascalCase): convención habitual para constantes de clase.
            const int EdadMinimaParaCompra = 18;
            Console.WriteLine("Constante con convención PascalCase: EdadMinimaParaCompra = " + EdadMinimaParaCompra);
        }
    }
}
