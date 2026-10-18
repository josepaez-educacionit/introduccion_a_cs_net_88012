/*
5. Instrucción return.

La instrucción return se utiliza para finalizar la ejecución de un método, entendiendo por
método un bloque de código identificado con un nombre, que agrupa instrucciones destinadas a
resolver una tarea específica dentro de un programa.

Cuando el programa encuentra una instrucción return dentro de un método, abandona de
inmediato ese método y devuelve el control al punto del programa desde el cual había sido
invocado, sin ejecutar ninguna instrucción adicional que se encuentre después del return
dentro de ese mismo método.

Además de finalizar la ejecución, el return puede utilizarse para indicar el valor que un
método debe entregar como resultado, en aquellos casos en los que el método está diseñado
para producir un valor de salida en lugar de simplemente realizar una acción.

Gracias a esta instrucción, es posible finalizar un método de manera anticipada en cuanto se
ha obtenido el resultado necesario, sin depender de que la ejecución llegue naturalmente hasta
el final del bloque de código.

Sintaxis:

    return;              // en métodos que no devuelven un valor (void)
    return expresión;    // en métodos que devuelven un valor

Uso habitual dentro de un método:

    tipoDeRetorno NombreDelMétodo(parámetros)
    {
        // instrucciones
        return expresión;
    }

Explicación de cada parte:
- return: palabra reservada que finaliza de inmediato la ejecución del método y devuelve el
  control al punto desde el cual fue invocado.
- expresión: valor, variable o cálculo que el método entrega como resultado. Su tipo debe ser
  compatible con el tipo de retorno declarado en la firma del método.
- tipoDeRetorno: tipo de dato que devuelve el método (int, decimal, string, etc.). Si el método
  no devuelve ningún valor, se declara como void y el return no lleva expresión.
- ; (punto y coma): obligatorio al final de la instrucción.
- Un método puede tener varios return, por ejemplo para salir de forma anticipada según una
  condición, pero en cada ejecución solo se ejecuta uno.
- En un método con tipo de retorno distinto de void, todos los caminos de ejecución deben
  terminar en un return; de lo contrario, se produce un error de compilación.
- En un método void, el return es opcional: si se omite, el método finaliza al llegar al final
  de su bloque.
- Las instrucciones escritas después de un return en el mismo bloque son código inalcanzable y
  el compilador emite una advertencia.

En resumen, la instrucción return finaliza la ejecución de un método y, cuando corresponde,
entrega el valor de resultado obtenido dentro de él.
*/


namespace M3_05_InstruccionReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejecucion Ejemplo 1
            decimal precioConIva = CalcularPrecioConIva(100m, 21m);
            Console.WriteLine("Precio con IVA: $" + precioConIva);

            // Ejecucion Ejemplo 2
            int edad = 30;
            string clasificacionEdad = ClasificarEdad(edad);
            Console.WriteLine("Clasificación de edad: " + clasificacionEdad);

            // Ejecucion Ejemplo 3
            string[] sinProductos = { }; 
            MostrarResumenCarrito(sinProductos);

            string[] conProductos = {"Camiseta", "Pantalón", "Zapatos" };
            MostrarResumenCarrito(conProductos);


            // Ejecucion Ejemplo 4
            int[] numeros = { 1, 3, 5, 7, 8, 9 };
            int primerPar = BuscarPrimerPar(numeros);
            Console.WriteLine("Primer número par encontrado: " + primerPar);

            // Un return en Main finaliza el programa; las instrucciones posteriores no se ejecutan.
            Console.WriteLine("Fin del programa.");
            return;
        }

        // Ejemplo 1: return con valor.
        // El método calcula un resultado y lo entrega a quien lo invocó; al ejecutar return termina.
        static decimal CalcularPrecioConIva(decimal precioNeto, decimal porcentajeIva)
        {
            decimal precioFinal = precioNeto + precioNeto * porcentajeIva / 100;
            return precioFinal;
        }

        // Ejemplo 2: return anticipado (cláusula de guarda) en un método con valor de retorno.
        // Apenas se conoce el resultado se sale del método, sin evaluar el resto de las condiciones.
        static string ClasificarEdad(int edad)
        {
            if (edad < 0)
            {
                return "Edad inválida";
            }

            if (edad < 18)
            {
                return "Menor de edad";
            }

            if (edad < 65)
            {
                return "Adulto";
            }

            return "Adulto mayor";
        }

        // Ejemplo 3: return sin valor en un método void.
        // Finaliza el método de forma anticipada cuando no hay nada que procesar.
        static void MostrarResumenCarrito(string[] productos)
        {
            if (productos.Length == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            Console.WriteLine("Productos en el carrito: " + productos.Length);
            foreach (string producto in productos)
            {
                Console.WriteLine("- " + producto);
            }
        }

        // Ejemplo 4: return dentro de un ciclo.
        // Al encontrar el primer número par se abandona el método completo, no solo el ciclo.
        static int BuscarPrimerPar(int[] numeros)
        {
            foreach (int numero in numeros)
            {
                if (numero % 2 == 0)
                {
                    return numero;
                }
            }

            // Si el ciclo termina sin encontrar un par, se devuelve un valor que indica "no encontrado".
            return -1;
        }
    }
}
