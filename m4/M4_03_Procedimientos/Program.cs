/*
3. Procedimientos.

Un procedimiento es, al igual que una función, un bloque de código identificado con un
nombre, que agrupa un conjunto de instrucciones destinadas a resolver una tarea específica
dentro de un programa.

La diferencia principal entre un procedimiento y una función radica en que el procedimiento no
entrega ningún valor de resultado al finalizar su ejecución, ya que su propósito es realizar
una acción determinada, y no producir un dato que deba ser utilizado posteriormente por quien
lo invocó.

Al igual que las funciones, los procedimientos pueden recibir parámetros como datos de
entrada, necesarios para llevar a cabo la tarea que tienen asignada, y su ejecución puede
finalizar de forma anticipada mediante la instrucción return, aunque en este caso sin
acompañarla de ningún valor.

Utilizar procedimientos ayuda a organizar el código en tareas concretas y reutilizables,
resultando especialmente adecuados para aquellas acciones que no necesitan producir un
resultado, como mostrar información o modificar el estado de un programa.

En resumen, un procedimiento es un bloque de código reutilizable que realiza una tarea
determinada sin entregar ningún valor de resultado al finalizar su ejecución.
*/
namespace M4_03_Procedimientos
{
    internal class Program
    {
        // Estructura de un procedimiento:
        // void <Nombre>(<tipo> <parámetro>, ...) { ... }
        // El tipo de retorno void indica que no se devuelve ningún valor.

        // Procedimiento sin parámetros: ejecuta siempre la misma acción.
        // Muestra el menú principal de una aplicación de consola.
        static void MostrarMenuPrincipal()
        {
            System.Console.WriteLine("=== Menú principal ===");
            System.Console.WriteLine("1. Registrar venta");
            System.Console.WriteLine("2. Consultar stock");
            System.Console.WriteLine("3. Salir");
        }

        // Procedimiento con parámetros: la acción depende de los datos recibidos.
        // Muestra por consola el detalle de un producto.
        static void MostrarDetalleProducto(string nombre, decimal precio, int stock)
        {
            System.Console.WriteLine("Producto: " + nombre + " | Precio: " + precio + " | Stock: " + stock);
        }

        // Procedimiento con retorno anticipado: return sin valor finaliza la ejecución
        // cuando no tiene sentido continuar.
        static void MostrarAlertaStock(string nombre, int stock, int stockMinimo)
        {
            if (stock > stockMinimo)
            {
                return; // El stock es suficiente: no hay nada que informar.
            }

            System.Console.WriteLine("Alerta: el producto " + nombre + " tiene stock bajo (" + stock + " unidades).");
        }

        // Procedimiento que modifica el estado del programa: altera el contenido del arreglo recibido.
        // Los arreglos se pasan por referencia, por lo que los cambios son visibles fuera del procedimiento.
        static void AplicarAumentoDePrecios(decimal[] precios, decimal porcentajeAumento)
        {
            for (int i = 0; i < precios.Length; i++)
            {
                precios[i] += precios[i] * porcentajeAumento / 100;
            }
        }

        static void Main()
        {
            // Invocación de un procedimiento: se escribe su nombre como una instrucción independiente.
            // No se guarda ningún resultado, porque no devuelve ninguno.
            MostrarMenuPrincipal();

            // Reutilización con distintos datos.
            MostrarDetalleProducto("Teclado", 25000m, 12);
            MostrarDetalleProducto("Mouse", 12000m, 3);

            // El retorno anticipado evita mostrar la alerta cuando el stock es suficiente.
            MostrarAlertaStock("Teclado", 12, 5); // No muestra nada.
            MostrarAlertaStock("Mouse", 3, 5);    // Muestra la alerta.

            // Modificación del estado: tras la invocación, el arreglo original contiene los nuevos precios.
            decimal[] preciosProductos = { 25000m, 12000m, 8000m };
            AplicarAumentoDePrecios(preciosProductos, 10m);

            for (int i = 0; i < preciosProductos.Length; i++)
            {
                System.Console.WriteLine("Precio actualizado " + (i + 1) + ": " + preciosProductos[i]);
            }
        }
    }
}