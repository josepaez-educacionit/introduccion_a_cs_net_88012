namespace M3_04_InstruccionContinue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: omitir los elementos que no cumplen un criterio.
            // Si el pedido está cancelado se salta el resto del cuerpo (no se suma ni se muestra)
            // y el for continúa con el pedido siguiente.
            string[] estadosPedidos = { "Entregado", "Cancelado", "Entregado", "Pendiente", "Cancelado", "Entregado" };
            decimal[] montosPedidos = { 150m, 80m, 200m, 120m, 60m, 95m };
            decimal totalFacturado = 0;

            for (int numeroPedido = 0; numeroPedido < estadosPedidos.Length; numeroPedido++)
            {
                if (estadosPedidos[numeroPedido] == "Cancelado")
                {
                    continue;
                }

                totalFacturado += montosPedidos[numeroPedido];
                Console.WriteLine("Pedido " + numeroPedido + " (" + estadosPedidos[numeroPedido] + "): $" + montosPedidos[numeroPedido]);
            }

            Console.WriteLine("Total facturado (sin cancelados): $" + totalFacturado);
        }
    }
}
