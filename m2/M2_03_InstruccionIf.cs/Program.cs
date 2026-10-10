/*
3. Instrucción if.

La instrucción if es la forma más básica de aplicar una condicional simple en C#. Permite
indicarle al programa que ejecute un bloque de código únicamente cuando una determinada
condición se evalúa como verdadera.

Para utilizarla, se escribe la palabra clave if seguida de una condición encerrada entre
paréntesis. A continuación se ubica el bloque de código, delimitado por llaves, que el
programa ejecutará solo si esa condición resulta verdadera.

Si la condición evaluada es falsa, el bloque asociado al if se omite por completo y la
ejecución continúa directamente con la siguiente instrucción del programa, sin generar ningún
error ni interrupción.

La instrucción if es una de las herramientas más utilizadas en la programación, ya que permite
que un programa adapte su comportamiento según los datos que recibe o el estado en el que se
encuentra en un momento determinado.

En resumen, la instrucción if permite ejecutar un bloque de código de manera condicional,
únicamente cuando la condición indicada se cumple.
*/

namespace M2_03_InstruccionIf.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalCompra = 125.50m;
            decimal montoMinimoEnvioGratis = 100m;
            int stockDisponible = 3;
            int cantidadSolicitada = 2;
            bool usuarioAutenticado = false;

            // Caso 1: if con una comparación numérica.
            // El mensaje solo se muestra si el total alcanza el monto mínimo.
            if (totalCompra >= montoMinimoEnvioGratis)
            {
                Console.WriteLine("Su compra califica para envío gratis.");
            }

            // Caso 2: if que valida una regla de negocio antes de continuar.
            // Se confirma que hay existencias suficientes para atender el pedido.
            if (cantidadSolicitada <= stockDisponible)
            {
                stockDisponible -= cantidadSolicitada; // stockDisponible = stockDisponible - cantidadSolicitada;
                Console.WriteLine($"Pedido confirmado. Unidades restantes en stock: {stockDisponible}.");
            }

            // Caso 3: if sobre un valor booleano.
            // No hace falta compararlo con true: la variable ya es la condición.
            if (usuarioAutenticado)
            {
                Console.WriteLine("Sesión activa: puede continuar con el pago.");
            }

            // Si una condición es falsa, su bloque se omite y la ejecución continúa aquí.
            Console.WriteLine("Fin del proceso de validación.");
        }
    }
}
