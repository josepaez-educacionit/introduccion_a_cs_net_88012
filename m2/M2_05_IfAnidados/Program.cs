/*
5. Instrucciones if anidadas.

Se dice que hay instrucciones if anidadas cuando una instrucción if, o su correspondiente
else, contiene dentro de su propio bloque de código otra instrucción if. Es decir, una
condicional se encuentra ubicada dentro de otra.

Este mecanismo permite evaluar condiciones adicionales, pero únicamente después de que se haya
cumplido una condición anterior. De esta forma, es posible representar situaciones en las que
una decisión depende de varios criterios relacionados entre sí, evaluados de manera
progresiva.

Cada instrucción if anidada mantiene su propio bloque de código, delimitado por llaves, y
puede a su vez incluir nuevas condicionales dentro de ella. Sin embargo, anidar demasiados
niveles de condicionales puede dificultar la lectura y el mantenimiento del programa.

Por esta razón, aunque los if anidados son válidos y útiles, conviene utilizarlos con
moderación y, cuando la lógica se vuelve muy compleja, considerar estructuras alternativas que
organicen mejor las distintas condiciones.

En resumen, los if anidados permiten evaluar condiciones dependientes entre sí, ubicando una
instrucción condicional dentro de otra para representar decisiones de mayor complejidad.
*/

namespace M2_05_IfAnidados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal totalCompra = 185.50m;
            decimal montoMinimoEnvioGratis = 100m;
            int stockDisponible = 3;
            int cantidadSolicitada = 2;
            bool usuarioAutenticado = false;

            // Caso 1: if anidado para validar el pedido paso a paso.
            // La existencia de stock solo se verifica si el usuario ya inició sesión,
            // porque la segunda condición depende de que la primera se cumpla.
            if (usuarioAutenticado)
            {
                if (cantidadSolicitada <= stockDisponible)
                {
                    stockDisponible -= cantidadSolicitada;
                    Console.WriteLine("Pedido confirmado.");
                }
                else
                {
                    Console.WriteLine($"Stock insuficiente. Unidades disponibles: {stockDisponible}.");
                }
            }
            else
            {
                Console.WriteLine("Inicie sesión para realizar su pedido.");
            }


            // Caso 2: if anidado en ambas ramas (if y else).
            // El mensaje sobre el envío se adapta al monto de la compra, y cada rama
            // agrega además lo que corresponde según el estado de la sesión.
            if (totalCompra >= montoMinimoEnvioGratis)
            {
                if (usuarioAutenticado)
                {
                    Console.WriteLine("Su compra califica para envío gratis. Puede continuar con el pago.");
                }
                else
                {
                    Console.WriteLine("Su compra califica para envío gratis. Inicie sesión para continuar con el pago.");
                }
            }
            else
            {
                decimal montoFaltante = montoMinimoEnvioGratis - totalCompra;

                if (usuarioAutenticado)
                {
                    Console.WriteLine($"Agregue {montoFaltante:C} más para obtener envío gratis.");
                }
                else
                {
                    Console.WriteLine($"Agregue {montoFaltante:C} más para obtener envío gratis e inicie sesión para continuar con el pago.");
                }
            }

        }
    }
}
