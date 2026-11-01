/*
4. Enumeraciones.

Una enumeración es un tipo de dato que permite definir un conjunto de valores con nombre,
limitado y conocido de antemano, que representan las distintas opciones posibles para una
determinada situación dentro de un programa.

En lugar de utilizar números o textos sueltos para representar esas opciones, una enumeración
asigna un nombre descriptivo a cada uno de los valores posibles, haciendo que el código
resulte más claro y fácil de entender, ya que se hace referencia a las opciones por su
significado y no por un valor numérico sin contexto.

Internamente, cada uno de los valores definidos en una enumeración está asociado a un número
entero, aunque en la mayoría de los casos el programador trabaja directamente con los nombres
definidos, sin necesidad de preocuparse por esos valores numéricos subyacentes.

Utilizar enumeraciones resulta especialmente útil cuando una variable solo puede tomar un
número limitado de valores predefinidos, como los días de la semana, los estados posibles de
un pedido o las categorías disponibles para un determinado elemento.

En resumen, una enumeración permite definir un conjunto cerrado de valores con nombre,
facilitando que el código represente de forma clara las distintas opciones válidas para una
situación determinada.
*/

namespace _04_Enumeraciones
{
    internal class Program
    {

        // Conjunto cerrado de estados posibles de un pedido.
        // Por defecto, cada nombre recibe un entero consecutivo desde 0.
        enum EstadoPedido
        {
            Pendiente,
            Pagado,
            Enviado,
            Entregado,
            Cancelado
        }

        enum NivelPrioridad
        {
            Baja = 1,
            Media = 2,
            Alta = 3
        }

        static void Main(string[] args)
        {
            // La variable solo puede tomar uno de los valores definidos en la enumeración.
            EstadoPedido estadoActual = EstadoPedido.Pagado;
            NivelPrioridad prioridad = NivelPrioridad.Alta;

            // Las enumeraciones se comparan por significado, sin números "mágicos".
            if (estadoActual == EstadoPedido.Pagado)
            {
                estadoActual = EstadoPedido.Enviado;
            }
            Console.WriteLine($"Estado actualizado: {estadoActual}");


            string mensaje;
            switch (estadoActual)
            {
                case EstadoPedido.Pendiente:
                    mensaje = "Esperando el pago.";
                    break;
                case EstadoPedido.Pagado:
                    mensaje = "Preparando el envío.";
                    break;
                case EstadoPedido.Enviado:
                    mensaje = "El paquete está en camino.";
                    break;
                case EstadoPedido.Entregado:
                    mensaje = "Pedido recibido por el cliente.";
                    break;
                case EstadoPedido.Cancelado:
                    mensaje = "El pedido fue cancelado.";
                    break;
                default:
                    mensaje = "Estado desconocido.";
                    break;
            }
            Console.WriteLine(mensaje);

            /*
                string mensaje = estadoActual switch
                {
                    EstadoPedido.Pendiente => "Esperando el pago.",
                    EstadoPedido.Pagado => "Preparando el envío.",
                    EstadoPedido.Enviado => "El paquete está en camino.",
                    EstadoPedido.Entregado => "Pedido recibido por el cliente.",
                    EstadoPedido.Cancelado => "El pedido fue cancelado.",
                    _ => "Estado desconocido."
                };
            */

        }
    }
}
