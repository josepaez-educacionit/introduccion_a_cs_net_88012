/*
2. Entorno de desarrollo.

Un entorno de desarrollo es el conjunto de programas y herramientas que un desarrollador
utiliza para escribir, organizar, ejecutar y corregir el código de una aplicación. En el caso
de .NET, las opciones más utilizadas son Visual Studio y Visual Studio Code.

Estas herramientas ofrecen, entre otras funciones, un editor de código (donde se escribe el
programa), un depurador (que permite ejecutar el código paso a paso para observar su
comportamiento y detectar errores) y utilidades para compilar el código, es decir, traducirlo
a un formato que la computadora pueda ejecutar.

También facilitan la organización de proyectos, entendiendo un proyecto como el conjunto de
archivos y configuraciones que forman una aplicación, así como la gestión de las dependencias,
que son componentes o bibliotecas externas que el proyecto necesita para funcionar.

Adicionalmente, el entorno de desarrollo de .NET se integra con sistemas de control de
versiones (herramientas que permiten registrar y administrar los cambios realizados en el
código a lo largo del tiempo), con mecanismos de pruebas automatizadas (que verifican que el
programa funcione como se espera) y con procesos de despliegue, que consisten en poner la
aplicación a disposición de sus usuarios finales.

En conclusión, contar con un entorno de desarrollo adecuado es fundamental para trabajar de
forma ordenada y productiva, ya que reúne en un solo lugar todas las herramientas necesarias
para pasar de una idea a una aplicación funcional.
*/

// ===== Crear un proyecto =====
// Un proyecto de .NET es la unidad que agrupa el código fuente, las dependencias y la
// configuración necesarias para producir una aplicación (por ejemplo, un archivo .csproj
// más las carpetas y archivos asociados). Visual Studio y Visual Studio Code ofrecen
// asistentes para crear esta estructura automáticamente, sin tener que escribirla a mano.
//
// Pasos para crear un proyecto en Visual Studio:
// 1. Abrir Visual Studio.
// 2. Seleccionar "Crear un nuevo proyecto".
// 3. Elegir una plantilla según el tipo de aplicación (por ejemplo, "Aplicación de consola"
//    para un programa que se ejecuta en una terminal, o "Aplicación web" para un sitio o API).
// 4. Indicar el nombre del proyecto, la carpeta donde se guardará y la versión de .NET a usar.
// 5. Hacer clic en "Crear". Visual Studio genera automáticamente los archivos iniciales,
//    incluyendo el archivo de proyecto (.csproj) y un archivo fuente con un ejemplo mínimo.
//
// (En Visual Studio Code, el equivalente es ejecutar "dotnet new console" desde la terminal,
// dentro de la carpeta donde se quiere crear el proyecto.)

// ===== Archivo fuente =====
// Un archivo fuente es el archivo de texto donde se escribe el código en un lenguaje de
// programación; en C# estos archivos usan la extensión ".cs". Un mismo proyecto puede
// contener muchos archivos fuente, cada uno con una o varias clases, métodos y demás
// elementos que, en conjunto, definen el comportamiento completo de la aplicación.
// El compilador de C# toma todos los archivos .cs del proyecto y los combina para generar
// un único programa ejecutable.

// ===== Compilar el proyecto =====
// Compilar significa traducir el código fuente (que las personas pueden leer) a un formato
// binario que la computadora puede ejecutar directamente. Durante este proceso, el compilador
// revisa que el código respete las reglas sintácticas de C#; si encuentra un error, detiene
// la compilación y lo reporta en lugar de generar un ejecutable incorrecto.
// En Visual Studio, esto se hace desde el menú "Compilar" o con el atajo Ctrl+Shift+B.
// Desde la terminal, el comando equivalente es "dotnet build".

// ===== Bloque principal ( Main() ) =====
// Toda aplicación de consola en C# necesita un punto de entrada: la primera instrucción que
// se ejecuta al iniciar el programa. Ese punto de entrada es el método estático Main, definido
// dentro de una clase (por convención, llamada Program). Cuando el programa se ejecuta, el
// entorno de .NET busca este método y comienza a ejecutar, en orden, las instrucciones que
// contiene.
//
// Ejemplo:
// class Program
// {
//     static void Main(string[] args)
//     {
//         // Código a ejecutar al iniciar la aplicación
//         Console.WriteLine("Hola, mundo!");
//     }
// }
//
// El parámetro "string[] args" permite recibir argumentos desde la línea de comandos al
// iniciar el programa; si la aplicación no los necesita, también es válido declarar el
// método como "static void Main()", sin parámetros.

// ===== Primer paso: "Hola Mundo" =====
// El primer programa que suele escribirse al aprender un lenguaje es uno que muestra un
// mensaje de saludo en pantalla, conocido tradicionalmente como "Hola Mundo". Sirve para
// comprobar que el entorno de desarrollo está correctamente instalado y configurado, y que
// es posible escribir, compilar y ejecutar código con éxito antes de abordar temas más
// complejos. El ejemplo de la sección anterior (la clase Program con el método Main que
// llama a Console.WriteLine) es exactamente ese primer programa.

// ===== Compilación =====
// Para compilar la aplicación "Hola Mundo", se utiliza el mismo mecanismo descrito antes:
// la opción "Compilar" en Visual Studio (o Ctrl+Shift+B), o el comando "dotnet build" desde
// la terminal. El resultado de una compilación exitosa es un archivo ejecutable (o una
// biblioteca, según el tipo de proyecto) que ya puede ejecutarse sin necesidad de volver a
// traducir el código fuente, a menos que este cambie.

// ===== Ejecución =====
// Ejecutar un programa significa poner en marcha el archivo generado por la compilación para
// observar su comportamiento. En Visual Studio, esto se logra con "Iniciar depuración" (F5),
// que además permite pausar la ejecución y revisar el estado del programa paso a paso; o con
// "Iniciar sin depurar" (Ctrl+F5) cuando solo se quiere ver el resultado. Desde la terminal,
// el comando "dotnet run" compila y ejecuta el proyecto en un solo paso. En el caso del
// programa "Hola Mundo", el resultado visible será el mensaje "Hola, mundo!" impreso en la
// consola.

// ===== Indentación =====
// La indentación es la práctica de desplazar visualmente el código hacia la derecha usando
// espacios, para que su estructura (qué instrucciones están dentro de qué bloque) se perciba
// de un vistazo, sin necesidad de leer cada línea. No afecta el comportamiento del programa:
// el compilador ignora los espacios adicionales. Aun así, es una convención fundamental, ya
// que un código bien indentado es mucho más fácil de leer, revisar y mantener. En C# es
// habitual usar cuatro espacios por cada nivel de anidamiento (cada vez que el código entra
// en una nueva clase, método, condición o repetición). Por ejemplo:
// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hola, mundo!");
//     }
// }
// Nótese cómo el contenido de la clase está un nivel más adentro que la clase misma, y el
// contenido del método Main está un nivel más adentro que el método.

// ===== Comentarios =====
// Los comentarios son texto que se escribe junto al código pero que el compilador ignora por
// completo; no forman parte del programa en ejecución. Su propósito es explicar la intención
// detrás del código, aclarar decisiones que no son evidentes a simple vista, o dejar notas
// para quien lea el archivo más adelante (incluyendo al propio autor, en el futuro).
// En C# existen dos formas de escribir comentarios:
// - Comentario de una sola línea: comienza con "//" y se extiende hasta el final de esa línea.
// - Comentario de múltiples líneas: comienza con "/*" y termina con "*/", y puede abarcar
//   tantas líneas como sea necesario.
//
// Ejemplos:
// Comentario de una sola línea
/*
   Comentario
   de múltiples líneas
*/
