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
