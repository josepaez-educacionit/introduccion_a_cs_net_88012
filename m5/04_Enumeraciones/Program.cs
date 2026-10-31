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
