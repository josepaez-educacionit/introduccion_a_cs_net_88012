/*
7. Instrucción switch.

La instrucción switch es una estructura de control de flujo que permite comparar el valor de
una misma expresión con distintos valores posibles, ejecutando el bloque de código
correspondiente al primero que coincida.

A diferencia de encadenar varias condiciones con if y else if, el switch está pensado para los
casos en los que se compara un mismo valor contra varias opciones concretas, conocidas como
casos o cases. Cada case indica un valor posible y el bloque de instrucciones que debe
ejecutarse cuando la expresión coincide con él.

Además de los distintos casos, el switch puede incluir un caso especial, llamado default, que
se ejecuta cuando el valor evaluado no coincide con ninguno de los casos definidos, cumpliendo
una función similar a la del else en una condicional.

El uso del switch suele hacer que el código resulte más claro y ordenado cuando existen
muchas alternativas posibles para un mismo valor, en comparación con una larga cadena de
condiciones if y else if.

En resumen, la instrucción switch permite seleccionar, entre varias opciones definidas, el
bloque de código que corresponde ejecutar según el valor de una expresión determinada.
*/

namespace M2_07_InstruccionSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string categoriaProducto = "Electrónica";
            string estadoPedido = "Enviado";
            int opcionMenu = 2;
            decimal totalCompraEjemplo = 150m;

            // Caso 1: switch sobre un string para asignar un valor según la categoría.
            // Cada case compara la expresión con un valor concreto, y break evita que
            // la ejecución continúe en el case siguiente. El bloque default cubre
            // cualquier categoría que no esté contemplada.
            decimal porcentajeImpuesto;

            switch (categoriaProducto)
            {
                case "Electrónica":
                    porcentajeImpuesto = 0.21m;
                    break;
                case "Ropa":
                    porcentajeImpuesto = 0.16m;
                    break;
                case "Alimentos":
                    porcentajeImpuesto = 0.05m;
                    break;
                default:
                    porcentajeImpuesto = 0.19m;
                    break;
            }

            // Caso 2: varios case que comparten un mismo bloque de código.
            // Los estados "Pendiente" y "Preparando" se tratan igual, por lo que sus
            // etiquetas se escriben una debajo de la otra, sin instrucciones entre ellas.
            switch (estadoPedido)
            {
                case "Pendiente":
                case "Preparando":
                    Console.WriteLine("Su pedido aún no ha sido despachado.");
                    break;
                case "Enviado":
                    Console.WriteLine("Su pedido está en camino.");
                    break;
                case "Entregado":
                    Console.WriteLine("Su pedido fue entregado. ¡Gracias por su compra!");
                    break;
                default:
                    Console.WriteLine("Estado de pedido desconocido.");
                    break;
            }

            // Caso 3: switch sobre un número entero, habitual en menús de opciones.
            switch (opcionMenu)
            {
                case 1:
                    Console.WriteLine("Ver catálogo de productos.");
                    break;
                case 2:
                    Console.WriteLine("Ver carrito de compras.");
                    break;
                case 3:
                    Console.WriteLine("Finalizar compra.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Seleccione un valor entre 1 y 3.");
                    break;
            }

            // Caso 4: expresión switch (C# 8.0 o superior).
            // A diferencia de la instrucción switch, es una expresión: devuelve un valor
            // que se puede asignar directamente a una variable. Cada brazo usa la forma
            // "valor => resultado", no requiere break y el descarte (_) cumple la función
            // de default. Es una alternativa más concisa cuando cada caso solo produce un valor.
            decimal porcentajeImpuestoCategoria = categoriaProducto switch
            {
                "Electrónica" => 0.21m,
                "Ropa" => 0.16m,
                "Alimentos" => 0.05m,
                _ => 0.19m
            };

            Console.WriteLine($"Impuesto calculado con expresión switch: {porcentajeImpuestoCategoria:P0}.");

            // La expresión switch también admite condiciones relacionales mediante patrones.
            // Se evalúan en orden, por lo que el primer brazo que coincide determina el resultado.
            string nivelEnvio = totalCompraEjemplo switch
            {
                >= 200m => "Envío gratis y prioritario",
                >= 100m => "Envío gratis",
                > 0m => "Envío con costo estándar",
                _ => "Total no válido"
            };

            Console.WriteLine($"Total: {totalCompraEjemplo:C}. Beneficio: {nivelEnvio}.");
        }
    }
}
