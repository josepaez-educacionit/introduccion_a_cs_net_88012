/*
7. Arreglos.

Un arreglo, también conocido como array, es una estructura que permite almacenar varios
valores del mismo tipo de dato bajo un único nombre de variable, en lugar de tener que crear
una variable independiente para cada uno de esos valores.

Cada uno de los valores almacenados dentro de un arreglo se conoce como elemento, y se accede a
él mediante un índice, que indica la posición que ese elemento ocupa dentro del arreglo. En
C#, al igual que en la mayoría de los lenguajes de programación, los índices comienzan a
contarse desde cero.

Los arreglos tienen un tamaño fijo, es decir, la cantidad de elementos que pueden almacenar se
define al momento de crearlos y no puede modificarse posteriormente. Esto los diferencia de
otras estructuras más flexibles que permiten crecer o reducirse dinámicamente.

Gracias a los arreglos, es posible trabajar de forma organizada con conjuntos de datos
relacionados entre sí, recorriendo y procesando cada uno de sus elementos mediante estructuras
repetitivas como el for, en lugar de manejar cada valor por separado.

Sintaxis:

    tipo[] nombre = new tipo[tamaño];              // arreglo con tamaño fijo
    tipo[] nombre = { valor1, valor2, valor3 };    // arreglo con valores iniciales
    nombre[índice]                                 // acceso a un elemento
    nombre.Length                                  // cantidad de elementos

Recorrido con for y con foreach:

    for (int i = 0; i < nombre.Length; i++)
    {
        // se accede al elemento con nombre[i]
    }

    foreach (tipo elemento in nombre)
    {
        // en cada repetición, elemento contiene un valor del arreglo
    }

Explicación de cada parte:
- tipo[]: tipo de dato de los elementos seguido de corchetes. Todos los elementos deben ser
  del mismo tipo (int, decimal, string, etc.).
- nombre: identificador de la variable que representa al arreglo completo.
- new tipo[tamaño]: reserva espacio para la cantidad indicada de elementos. Cada uno recibe el
  valor por defecto de su tipo: 0 en los numéricos, false en bool y null en string.
- { valor1, valor2, ... }: lista de valores iniciales. El tamaño del arreglo queda definido por
  la cantidad de valores indicados.
- nombre[índice]: permite leer o modificar un elemento. El primer elemento tiene índice 0 y el
  último tiene índice nombre.Length - 1.
- Length: propiedad que devuelve la cantidad de elementos del arreglo. Es la referencia
  recomendada para el límite de un for, con la condición i < nombre.Length.
- foreach: recorre todos los elementos de principio a fin sin necesidad de índice. La variable
  de iteración es de solo lectura, por lo que no permite reemplazar elementos del arreglo.
- Acceder a un índice menor que 0 o mayor o igual que Length produce, en tiempo de ejecución,
  la excepción IndexOutOfRangeException.

En resumen, un arreglo permite almacenar y organizar múltiples valores del mismo tipo bajo un
único nombre, accediendo a cada uno de ellos mediante su posición o índice dentro de la
estructura.
*/

namespace M3_07_Arreglos.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: declaración con valores iniciales y recorrido con for.
            // El tamaño del arreglo queda determinado por la cantidad de valores indicados (5).
            // Los índices válidos van de 0 a Length - 1.
            int[] notasExamen = { 7, 9, 6, 10, 8 };

            for (int indice = 0; indice < notasExamen.Length; indice++)
            {
                Console.WriteLine("Nota del alumno " + (indice + 1) + " (posición " + indice + "): " + notasExamen[indice]);
            }

            // Ejemplo 2: acceso y modificación de elementos por índice, y cálculo sobre el conjunto.
            int sumaNotas = 0;

            for (int indice = 0; indice < notasExamen.Length; indice++)
            {
                sumaNotas += notasExamen[indice];
            }

            double promedio = (double)sumaNotas / notasExamen.Length;
            Console.WriteLine("Promedio del curso: " + promedio);

            // Se corrige la nota del tercer alumno (índice 2) tras una revisión.
            notasExamen[2] = 8;
            Console.WriteLine("Nota corregida del alumno 3: " + notasExamen[2]);



            // Ejemplo 3: creación de un arreglo con tamaño fijo y carga posterior de valores.
            // Con new se reserva espacio para 4 elementos; los decimales se inicializan en 0.
            // Una vez creado, el tamaño no puede modificarse.
            const int cantidadTrimestres = 4;
            decimal[] ventasPorTrimestre = new decimal[cantidadTrimestres];

            ventasPorTrimestre[0] = 12500.50m;
            ventasPorTrimestre[1] = 9800.00m;
            ventasPorTrimestre[2] = 15200.75m;
            ventasPorTrimestre[3] = 17300.25m;

            decimal ventasAnuales = 0;
            for (int trimestre = 0; trimestre < ventasPorTrimestre.Length; trimestre++)
            {
                Console.WriteLine("Ventas del trimestre " + (trimestre + 1) + ": $" + ventasPorTrimestre[trimestre]);
                ventasAnuales += ventasPorTrimestre[trimestre];
            }

            Console.WriteLine("Ventas anuales: $" + ventasAnuales);


            // Ejemplo 4: búsqueda del mayor valor dentro de un arreglo.
            // Se parte del primer elemento y se compara con el resto.
            string[] nombresClientes = { "Ana", "Bruno", "Carolina", "Diego" };
            string nombreMasLargo = nombresClientes[0];

            for (int indice = 1; indice < nombresClientes.Length; indice++)
            {
                if (nombresClientes[indice].Length > nombreMasLargo.Length)
                {
                    nombreMasLargo = nombresClientes[indice];
                }
            }

            Console.WriteLine("Nombre más largo: " + nombreMasLargo);

            // Ejemplo 5: recorrido con foreach.
            // foreach recorre todos los elementos del arreglo, de principio a fin, entregando
            // en cada vuelta el elemento actual en la variable indicada (aquí, "cliente").
            // No requiere manejar un índice ni consultar Length, lo que evita errores de límites.
            // Es ideal cuando solo se necesita leer cada elemento; la variable de iteración es
            // de solo lectura, por lo que no permite reemplazar elementos del arreglo.
            // Si se necesita la posición del elemento o modificarlo, corresponde usar for.
            Console.WriteLine("Listado de clientes:");

            foreach (string cliente in nombresClientes)
            {
                Console.WriteLine("- " + cliente);
            }

            int notasAprobadas = 0;

            foreach (int nota in notasExamen)
            {
                if (nota >= 6)
                {
                    notasAprobadas++;
                }
            }

            Console.WriteLine("Alumnos aprobados: " + notasAprobadas + " de " + notasExamen.Length);
        }
    }
}
