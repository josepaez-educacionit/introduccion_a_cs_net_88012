/*
6. Instrucción goto.

La instrucción goto permite transferir la ejecución de un programa directamente a otra parte
del código, identificada mediante una etiqueta, en lugar de seguir el orden habitual de
ejecución secuencial o el definido por las estructuras de control de flujo tradicionales.

Una etiqueta es simplemente un nombre asignado a un punto específico dentro del código. Al
utilizar goto seguido del nombre de una etiqueta, el programa salta de inmediato hacia ese
punto, sin importar en qué parte del bloque de código se encontraba antes.

Si bien goto puede resultar útil en situaciones muy puntuales, como salir de varios niveles de
estructuras anidadas al mismo tiempo, su uso suele desaconsejarse en la mayoría de los casos,
ya que puede hacer que el flujo del programa se vuelva difícil de seguir y de mantener.

Por esta razón, en la práctica se prefiere resolver la mayoría de las situaciones utilizando
las estructuras de control de flujo ya vistas, como if, switch, while, do...while, for, break y
continue, reservando goto solo para casos muy específicos.

Sintaxis:

    goto etiqueta;          // salto a una etiqueta
    goto case valor;        // salto a otro case dentro de un switch
    goto default;           // salto al caso default dentro de un switch

    etiqueta:               // definición de la etiqueta
        instrucción;

Explicación de cada parte:
- goto: palabra reservada que transfiere la ejecución de forma incondicional.
- etiqueta: identificador, con las mismas reglas que el nombre de una variable, seguido de dos
  puntos (:) en el lugar del código al que se quiere saltar.
- ; (punto y coma): obligatorio al final de la instrucción goto, pero no después de los dos
  puntos de la etiqueta.
- La etiqueta debe estar dentro del mismo método y ser visible desde el goto: es posible saltar
  hacia afuera de un bloque (por ejemplo, salir de ciclos anidados), pero no hacia el interior
  de un bloque ni hacia otro método.
- goto case y goto default solo pueden utilizarse dentro de un switch. En C# un case no puede
  continuar en el siguiente, y estas formas permiten hacerlo de manera explícita.
- Una etiqueta que se declara pero nunca se utiliza genera una advertencia del compilador.

En resumen, la instrucción goto permite saltar directamente a otra parte del código mediante
una etiqueta, aunque su uso debe limitarse por el impacto que tiene en la claridad del
programa.
*/

namespace M3_06_InstruccionGoto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo 1: reintentar una operación saltando hacia una etiqueta anterior.
            // Funciona, pero se desaconseja su uso general. Es equivalente a un ciclo; en la práctica se prefiere while o do...while.
            int intentosRealizados = 0;
            const int maximoIntentos = 3;

        reintentarConexion:
            intentosRealizados++;
            Console.WriteLine("Conectando con el servidor... intento " + intentosRealizados);

            // Se simula que la conexión solo se logra en el tercer intento.
            bool conexionExitosa = intentosRealizados == 3;

            if (!conexionExitosa && intentosRealizados < maximoIntentos)
            {
                goto reintentarConexion;
            }

        }
    }
}
