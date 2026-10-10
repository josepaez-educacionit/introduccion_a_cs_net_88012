/*
6. Instrucciones condicionales múltiples.

Las instrucciones condicionales múltiples permiten evaluar más de dos alternativas posibles
frente a una misma situación, a diferencia de las condicionales simples, que solo contemplan
una única condición, o del if...else, que contempla exactamente dos caminos.

En C#, esta posibilidad se logra combinando varias condiciones mediante las palabras clave if,
else if y else. Cada bloque else if agrega una condición adicional que se evalúa únicamente
si las condiciones anteriores no se cumplieron, permitiendo encadenar distintas alternativas de
forma ordenada.

El programa evalúa las condiciones en el orden en que fueron escritas y ejecuta el primer
bloque cuya condición resulte verdadera. Si ninguna de las condiciones se cumple, se ejecuta
el bloque else final, en caso de que este haya sido incluido.

Este tipo de estructura resulta especialmente útil cuando una decisión depende de varios
valores o rangos posibles, permitiendo representar de manera clara distintas respuestas del
programa según la situación que se presente.

En resumen, las condicionales múltiples permiten evaluar y responder a varias alternativas
posibles, ejecutando únicamente el bloque correspondiente a la primera condición que se
cumpla.
*/

namespace M2_06_CondicionalesMultiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalCompra = 85.50m;
            decimal montoMinimoEnvioGratis = 100m;
            int stockDisponible = 3;
            int cantidadSolicitada = 2;
            bool usuarioAutenticado = true;


            // Caso 1: condicional múltiple para determinar el estado del pedido.
            // Las condiciones se evalúan en orden y se ejecuta solo el primer bloque
            // verdadero. Por eso las validaciones que impiden continuar (sesión y
            // stock) van antes que los casos en los que el pedido se confirma.
            if (!usuarioAutenticado)
            {
                Console.WriteLine("Inicie sesión para realizar su pedido.");
            }
            else if (cantidadSolicitada > stockDisponible)
            {
                Console.WriteLine($"Stock insuficiente. Unidades disponibles: {stockDisponible}.");
            }
            else if (totalCompra >= montoMinimoEnvioGratis)
            {
                Console.WriteLine("Su compra califica para envío gratis. Pedido confirmado.");
            }
            else
            {
                decimal montoFaltante = montoMinimoEnvioGratis - totalCompra;
                Console.WriteLine($"Agregue {montoFaltante:C} más para obtener envío gratis. Pedido confirmado.");
            }

            // Caso 2: condicional múltiple sobre rangos de valores.
            // Se asigna el porcentaje de descuento según el total de la compra.
            // Las condiciones van de mayor a menor: si se evaluara primero
            // totalCompra >= 100, un total de 300 nunca llegaría a la condición del 15 %.
            decimal porcentajeDescuento;

            if (totalCompra >= 300m)
            {
                porcentajeDescuento = 0.15m;
            }
            else if (totalCompra >= 200m)
            {
                porcentajeDescuento = 0.10m;
            }
            else if (totalCompra >= 100m)
            {
                porcentajeDescuento = 0.05m;
            }
            else
            {
                porcentajeDescuento = 0m;
            }

            decimal totalConDescuento = totalCompra * (1 - porcentajeDescuento);
            Console.WriteLine($"Descuento aplicado: {porcentajeDescuento:P0}. Total a pagar: {totalConDescuento:C}.");

            // Caso 3: condicional múltiple para clasificar el nivel de stock.
            // El bloque else cubre el caso restante: no quedan unidades.
            if (stockDisponible > 10)
            {
                Console.WriteLine("Producto disponible.");
            }
            else if (stockDisponible > 0)
            {
                Console.WriteLine($"¡Últimas {stockDisponible} unidades disponibles!");
            }
            else
            {
                Console.WriteLine("Producto agotado.");
            }
        }
    }
}
