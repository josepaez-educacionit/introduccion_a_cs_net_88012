/*
3. Estructuras.

Una estructura es un tipo de dato que permite agrupar varias variables relacionadas entre sí
bajo un único nombre, de manera que puedan tratarse en conjunto como si formaran una sola
unidad de información, en lugar de manejarlas por separado.

Cada una de las variables que forman parte de una estructura se conoce como campo, y puede
tener su propio tipo de dato, permitiendo combinar dentro de una misma estructura, por ejemplo,
números, texto o valores lógicos relacionados con un mismo concepto.

Una vez definida una estructura, es posible crear distintas variables basadas en ella, cada una
con sus propios valores para los campos definidos, de la misma manera en que se crean
variables a partir de los tipos de datos básicos vistos anteriormente.

Utilizar estructuras resulta útil cuando existen varios datos que, por su naturaleza, tiene
sentido mantener siempre juntos y tratar como una única unidad de información dentro de un
programa.

En resumen, una estructura permite definir un nuevo tipo de dato que agrupa varios campos
relacionados entre sí, facilitando el manejo conjunto de información que pertenece a un mismo
concepto.
*/

namespace _03_Estructuras
{
    internal class Program
    {
        // Una estructura agrupa campos relacionados con un mismo concepto: aquí, un punto de entrega.
        struct PuntoEntrega
        {
            public string Calle;
            public int Numero;
            public string Ciudad;
            public bool EsResidencial;
        }

        // Otra estructura puede reutilizar a la anterior como tipo de uno de sus campos.
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

            // Las estructuras son tipos por valor: al asignar se copia todo su contenido.
            Pedido copiaPedido = pedidoUno;
            copiaPedido.Total = 0m; // no modifica pedidoUno

            Console.WriteLine("--- Pedidos registrados ---");
            MostrarPedido(pedidoUno);
            MostrarPedido(pedidoDos);

            Console.WriteLine("--- Efecto de la copia ---");
            Console.WriteLine($"Total original: {pedidoUno.Total:C}");
            Console.WriteLine($"Total de la copia: {copiaPedido.Total:C}");
        }
        
        // Recibe el pedido completo como una sola unidad, sin pasar cada campo por separado.
        static void MostrarPedido(Pedido pedido)
        {
            string tipoDestino = pedido.Destino.EsResidencial ? "residencial" : "comercial";
            Console.WriteLine($"Pedido #{pedido.Id} - {pedido.Total:C}");
            Console.WriteLine($"  Destino: {pedido.Destino.Calle} {pedido.Destino.Numero}, {pedido.Destino.Ciudad} ({tipoDestino})");
        }
    }
}
