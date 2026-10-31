namespace _03_Estructuras
{
    internal class Program
    {
        struct PuntoEntrega
        {
            public string Calle;
            public int Numero;
            public string Ciudad;
            public bool EsResidencial;
        }

        struct Pedido
        {
            public int Id;
            public decimal Total;
            public PuntoEntrega Destino;
        }

        static void Main(string[] args)
        {
            // Cada variable de tipo Pedido tiene su propia copia de los campos.
            Pedido pedidoUno;
            pedidoUno.Id = 1001;
            pedidoUno.Total = 149.90m;
            pedidoUno.Destino.Calle = "Av. Corrientes";
            pedidoUno.Destino.Numero = 1234;
            pedidoUno.Destino.Ciudad = "Buenos Aires";
            pedidoUno.Destino.EsResidencial = true;

            // Los campos también pueden asignarse al crear la variable (inicializador de objeto).
            Pedido pedidoDos = new Pedido
            {
                Id = 1002,
                Total = 89.50m,
                Destino = new PuntoEntrega
                {
                    Calle = "Calle Mayor",
                    Numero = 8,
                    Ciudad = "Madrid",
                    EsResidencial = false
                }
            };
        }
    }
}
