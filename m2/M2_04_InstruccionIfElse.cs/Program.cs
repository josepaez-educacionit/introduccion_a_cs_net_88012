/*
4. Instrucción if...else.

La instrucción if...else es una extensión de la instrucción if que permite definir dos
caminos posibles de ejecución: uno para cuando la condición evaluada es verdadera, y otro
para cuando esa misma condición es falsa.

El bloque asociado al if se ejecuta cuando la condición se cumple, mientras que el bloque
asociado a la palabra clave else se ejecuta únicamente cuando la condición no se cumple. De
esta manera, el programa siempre ejecuta uno de los dos bloques, nunca ambos ni ninguno.

Esta estructura resulta útil cuando existen exactamente dos alternativas posibles frente a una
misma situación, y se necesita que el programa responda de manera distinta según cuál de
ellas se presente.

A diferencia de la instrucción if simple, que solo contempla una acción opcional, el
if...else garantiza que siempre se ejecute alguna acción, ofreciendo una respuesta definida
para ambos posibles resultados de la condición.

En resumen, la instrucción if...else permite que un programa elija entre dos caminos de
ejecución excluyentes, según el resultado de evaluar una condición.
*/

namespace M2_04_InstruccionIfElse.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalCompra = 85.50m;
            decimal montoMinimoEnvioGratis = 100m;
            int stockDisponible = 3;
            int cantidadSolicitada = 5;
            bool usuarioAutenticado = false;


            // Caso 1: if...else con una comparación numérica.
            // Solo uno de los dos bloques se ejecuta: el primero si el total alcanza
            // el monto mínimo y el segundo en caso contrario. Con estos valores se
            // ejecuta el bloque else.
            if (totalCompra >= montoMinimoEnvioGratis)
            {
                Console.WriteLine("Su compra califica para envío gratis.");
            }
            else
            {
                decimal montoFaltante = montoMinimoEnvioGratis - totalCompra;
                Console.WriteLine($"Agregue {montoFaltante:C} más a su compra para obtener envío gratis.");
            }


            // Caso 2: if...else que valida una regla de negocio.
            // Si no hay existencias suficientes, se informa al cliente en lugar de
            // confirmar el pedido.
            if (cantidadSolicitada <= stockDisponible)
            {
                stockDisponible -= cantidadSolicitada;
                Console.WriteLine("Pedido confirmado.");
            }
            else
            {
                Console.WriteLine($"Stock insuficiente. Unidades disponibles: {stockDisponible}.");
            }

            // Caso 3: if...else sobre un valor booleano.
            // La variable ya es la condición, por lo que no se compara con true o false.
            if (usuarioAutenticado)
            {
                Console.WriteLine("Sesión activa: puede continuar con el pago.");
            }
            else
            {
                Console.WriteLine("Inicie sesión para continuar con el pago.");
            }
        }
    }
}
