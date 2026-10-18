/*
2. Instrucción for.

La instrucción for es una estructura cíclica que permite repetir un bloque de código un
número de veces determinado, resultando especialmente adecuada cuando se conoce de antemano
cuántas repeticiones se necesitan realizar.

A diferencia del while, que solo se basa en una condición, el for reúne en una única
instrucción tres elementos: una inicialización, que establece el punto de partida antes de
comenzar las repeticiones; una condición, que se evalúa antes de cada repetición para decidir
si debe continuar; y una actualización, que se ejecuta al final de cada vuelta del ciclo.

Gracias a esta organización, el for permite controlar de forma clara y compacta el avance de
una repetición, siendo muy utilizado, por ejemplo, para recorrer un rango de valores desde un
número inicial hasta un número final.

Al igual que con el while, si la condición del for nunca llega a ser falsa, el ciclo se
repetirá de forma indefinida, por lo que es importante asegurarse de que la actualización
lleve eventualmente a que la condición deje de cumplirse.

Sintaxis:

    for (inicialización; condición; actualización)
    {
        // instrucciones que se ejecutan en cada repetición
    }

Explicación de cada parte:
- for: palabra reservada que da inicio a la estructura.
- inicialización: se ejecuta una sola vez, antes de la primera repetición. Habitualmente declara
  e inicializa la variable de control, por ejemplo int i = 0. Esa variable solo existe dentro
  del for.
- condición: expresión booleana que se evalúa antes de cada repetición, incluida la primera. Si
  es true, se ejecuta el bloque; si es false, el ciclo termina. Por esta razón, si la condición
  es falsa desde el inicio, el bloque no se ejecuta nunca.
- actualización: se ejecuta al final de cada repetición, después del bloque y antes de volver a
  evaluar la condición. Normalmente incrementa o decrementa la variable de control, por ejemplo
  i++ o i--.
- { ... }: bloque de instrucciones que se repite.
- Los tres elementos se separan con punto y coma y cualquiera de ellos puede omitirse, aunque
  deben mantenerse los dos punto y coma. No se coloca punto y coma al final de la instrucción.

Orden de ejecución: inicialización (una vez) -> condición -> bloque -> actualización -> condición
-> bloque -> actualización -> ... hasta que la condición sea falsa.

En resumen, la instrucción for permite repetir un bloque de código controlando en un mismo
lugar su punto de partida, la condición de continuidad y el avance en cada repetición.
*/

namespace M3_02_InstruccionFor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: recorrido de un rango conocido de valores.
            // Inicialización: numeroCuota = 1 | Condición: numeroCuota <= totalCuotas | Actualización: numeroCuota++
            int totalCuotas = 6;
            decimal montoPrestamo = 12000m;
            decimal valorCuota = montoPrestamo / totalCuotas;

            for (int numeroCuota = 1; numeroCuota <= totalCuotas; numeroCuota++)
            {
                Console.WriteLine("Cuota " + numeroCuota + " de " + totalCuotas + ": $" + valorCuota);
            }


            // Ejemplo 2: recorrido de un arreglo usando su longitud como límite.
            // El índice comienza en 0 y la condición usa < Length para no salirse del arreglo.
            string[] productos = { "Teclado", "Mouse", "Monitor", "Auriculares" };
            decimal[] precios = { 45.50m, 20.00m, 210.99m, 35.75m };
            decimal totalCompra = 0;

            for (int indice = 0; indice < productos.Length; indice++)
            {
                Console.WriteLine(productos[indice] + ": $" + precios[indice]);
                totalCompra += precios[indice];
            }

            //Console.WriteLine("Total de la compra: $" + totalCompra);

            // Ejemplo 3: cuenta regresiva con actualización decreciente.
            // La actualización no tiene por qué ser un incremento de uno en uno.
            for (int segundosRestantes = 10; segundosRestantes > 0; segundosRestantes -= 2)
            {
                Console.WriteLine("Tiempo restante: " + segundosRestantes + " segundos");
            }

            Console.WriteLine("Tiempo agotado.");
        }
    }
}
