namespace Ej08_DepuracionDeCiclos
{
    // Ejercicio 8 (solución): Depuración de un programa con errores en ciclos y arreglos.

    class Program
    {
        static void Main()
        {
            string titular = "Luis Morales";
            decimal saldo = 1200.00m;
            decimal[] cargas = { 200.00m, 350.00m, -50.00m, 500.00m, 0m, 150.00m };
            string[] clavesIngresadas = { "1111", "2222", "2468" };
            const string claveCorrecta = "2468";
            const int maximoIntentos = 3;
            const decimal tasaMensual = 2.0m;

            Console.WriteLine("Titular: " + titular);

            // Bloque 1: total y promedio de las cargas válidas (mayores que cero).
            decimal totalCargas = 0m;
            int cantidadValidas = 0;
            // Corrección 1 (ejecución): el índice válido llega hasta Length - 1; con <= se accedía fuera del arreglo.
            for (int i = 0; i < cargas.Length; i++)
            {
                if (cargas[i] <= 0)
                {
                    continue;
                }
                // Corrección 2 (compilación): el nombre correcto de la variable es totalCargas (no totalCarga).
                totalCargas += cargas[i];
                cantidadValidas++;
            }
            // Corrección 3 (lógica): el promedio se divide por la cantidad de cargas válidas, no por Length.
            decimal promedio = cantidadValidas > 0 ? totalCargas / cantidadValidas : 0m;
            Console.WriteLine("Cargas válidas: " + cantidadValidas + " | Total: $ " + totalCargas.ToString("N2") + " | Promedio: $ " + promedio.ToString("N2"));

            // Bloque 2: bonificación de $ 10,00 por cada carga, mostrada con foreach.
            // Corrección 4 (compilación): la variable de foreach es de solo lectura; se usa otra variable para el cálculo.
            foreach (decimal carga in cargas)
            {
                decimal cargaConBonificacion = carga + 10.00m;
                Console.WriteLine("Carga $ " + carga.ToString("N2") + " -> con bonificación $ " + cargaConBonificacion.ToString("N2"));
            }

            // Bloque 3: validación de clave con intentos limitados.
            int intentos = 0;
            bool accesoOtorgado = false;
            do
            {
                string claveIngresada = clavesIngresadas[intentos];
                // Corrección 5 (ejecución): el contador debe modificarse dentro del ciclo; sin esto, el ciclo no termina.
                intentos++;
                if (claveIngresada == claveCorrecta)
                {
                    accesoOtorgado = true;
                }
            } while (intentos < maximoIntentos && !accesoOtorgado);
            Console.WriteLine("Acceso: " + (accesoOtorgado ? "concedido" : "denegado") + " tras " + intentos + " intento(s).");

            // Bloque 4: conteo de cargas descartadas con while y continue.
            int posicion = 0;
            int descartadas = 0;
            while (posicion < cargas.Length)
            {
                if (cargas[posicion] <= 0)
                {
                    descartadas++;
                    // Corrección 6 (ejecución): antes de continue hay que avanzar la posición; si no, se repite el mismo elemento.
                    posicion++;
                    continue;
                }
                posicion++;
            }
            Console.WriteLine("Cargas descartadas: " + descartadas);

            // Bloque 5: recordatorios de vencimiento.
            // Corrección 7 (compilación): el punto y coma después del for lo convertía en un ciclo vacío y dejaba "cuota" fuera de alcance.
            for (int cuota = 1; cuota <= 3; cuota++)
            {
                Console.WriteLine("Recordatorio de vencimiento: cuota " + cuota);
            }

            // Bloque 6: proyección del saldo a 3 meses con interés compuesto.
            decimal saldoProyectado = saldo;
            // Corrección 8 (lógica): para repetir 3 veces la condición es <= 3 (o < 4).
            for (int mes = 1; mes <= 3; mes++)
            {
                saldoProyectado += saldoProyectado * tasaMensual / 100m;
            }
            // Corrección 9 (compilación): la sentencia debe terminar con punto y coma.
            Console.WriteLine("Saldo proyectado a 3 meses: $ " + saldoProyectado.ToString("N2"));
        }
    }
}
