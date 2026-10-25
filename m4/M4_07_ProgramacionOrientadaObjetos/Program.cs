/*
7. Programación Orientada a Objetos (POO).

Hasta ahora hemos escrito programas como una secuencia de instrucciones, apoyándonos en variables
y en funciones o procedimientos. Cuando un programa crece, esa forma de trabajar se vuelve difícil
de mantener: los datos (por ejemplo, el saldo de una cuenta) quedan por un lado y las operaciones
que los modifican (depositar, retirar) quedan por otro. La Programación Orientada a Objetos propone
una manera distinta de organizar el código: agrupar los datos y las operaciones que les
corresponden en una sola unidad.
 */

namespace M4_07_ProgramacionOrientadaObjetos
{
    /*
    PARTE 1. PENSAR EN OBJETOS

    1.1 Paradigma
    Un paradigma de programación es un enfoque o estilo de programación que define cómo se estructuran
    y se escriben los programas. Existen varios, y un mismo lenguaje puede combinarlos:
      - Programación estructurada: divide el programa en funciones o procedimientos. Es el estilo que
        usamos hasta ahora.
      - Programación orientada a objetos: organiza el programa en objetos que reúnen datos y
        comportamiento. Es el tema de esta clase.
      - Programación funcional: se centra en el uso de funciones puras y evita el estado mutable.
      - Programación lógica: se basa en reglas y hechos; la ejecución se realiza por inferencia lógica.
      - Programación orientada a eventos: se centra en responder a eventos o acciones del usuario.

    1.2 Programación Orientada a Objetos
    Es un paradigma basado en el concepto de "objetos", que reúnen datos y las operaciones que
    trabajan sobre esos datos. El programa pasa a ser un conjunto de objetos que colaboran entre sí.

    1.3 Objeto
    Un objeto representa algo del mundo real o del problema que se resuelve: una cuenta bancaria, un
    cliente, un producto. Todo objeto tiene dos aspectos:
      - Atributos: los datos que lo describen (su estado). Ej.: titular, saldo.
      - Métodos: las acciones que puede realizar (su comportamiento). Ej.: depositar, retirar.

    1.4 Clase
    Es la plantilla o modelo que define qué atributos y qué métodos tendrán los objetos de un mismo
    tipo. La clase se escribe una sola vez. Por sí sola no es una cuenta concreta: describe cómo
    son las cuentas.

    1.5 Instancia
    Es un objeto concreto creado a partir de una clase. Analogía: la clase es el plano de una casa y
    cada instancia es una casa construida con ese plano. A partir de un mismo plano se pueden construir
    muchas casas, y cada una tiene su propio estado (su propio color, sus propios muebles).

          Clase                             Instancias (objetos)
      +-----------------+              +---------------------+   +---------------------+
      | Cuenta          |   new  --->  | cuentaAna           |   | cuentaLuis          |
      |  - titular      |              |  titular: "Ana"     |   |  titular: "Luis"    |
      |  - saldo        |   new  --->  |  saldo:   10000     |   |  saldo:   3000      |
      |  + Depositar()  |              +---------------------+   +---------------------+
      |  + Retirar()    |
      +-----------------+              Misma estructura, valores propios en cada objeto.

    1.6 Diferencia entre clase e instancia
      - Clase: la plantilla. Existe en el código, se define una vez.
      - Instancia: el objeto creado con la plantilla. Existe mientras el programa se ejecuta y puede
        haber tantas como se necesiten, cada una con sus propios datos.

    1.7 Ventajas de la POO
      - Modularidad: el código se organiza en clases y objetos, lo que facilita su mantenimiento.
      - Reutilización: una clase escrita una vez puede usarse en diferentes programas.
      - Escalabilidad: es más sencillo ampliar o modificar el software sin romper lo existente.
      - Mantenimiento: la encapsulación y la modularidad facilitan corregir errores y actualizar el
        código, porque cada clase es responsable de sus propios datos.
    */

    // ---------------------------------------------------------------------------------------------
    // PARTE 2. NUESTRA PRIMERA CLASE
    //
    // Definir una clase en C#:
    //   - Se usa la palabra clave "class" seguida del nombre en PascalCase (CuentaBasica).
    //   - Entre llaves van sus miembros: fields, properties, constructores y métodos.
    //   - Convención: una clase por archivo con el nombre de la clase. Aquí se agrupan en un solo
    //     archivo únicamente por motivos didácticos.
    //
    // Fields (atributos):
    //   - Son variables declaradas directamente dentro de la clase. Guardan el estado del objeto.
    //   - Si no se les asigna un valor, toman el valor por defecto de su tipo (0, false, null...).
    //
    // Métodos:
    //   - Son funciones o procedimientos declarados dentro de la clase. Definen el comportamiento.
    //   - Pueden leer y modificar los fields del propio objeto.
    //   - Se invocan sobre una instancia: objeto.Metodo().
    // ---------------------------------------------------------------------------------------------
    class CuentaBasica
    {
        // Fields. Por ahora son "public": cualquiera puede leerlos y modificarlos. Más adelante
        // veremos por qué esto es un problema.
        public string Titular = "";
        public decimal Saldo;

        // Método: comportamiento del objeto. Trabaja sobre el saldo de ESTA cuenta.
        public void Depositar(decimal monto)
        {
            Saldo += monto;
        }

        public void Mostrar()
        {
            System.Console.WriteLine("Titular: " + Titular + " | Saldo: " + Saldo);
        }
    }

    // ---------------------------------------------------------------------------------------------
    // PARTES 3 Y 4. ENCAPSULAMIENTO, MODIFICADORES DE ACCESO, PROPERTIES Y VALIDACIÓN
    //
    // El problema de CuentaBasica: como el field Saldo es público, nada impide escribir
    // cuenta.Saldo = -5000. El objeto queda en un estado que no tiene sentido y la clase no puede
    // evitarlo.
    //
    // Principio de encapsulamiento:
    //   Consiste en ocultar los datos internos del objeto y permitir su acceso solo mediante
    //   miembros controlados (properties y métodos). Beneficios:
    //     - Protege la integridad de los datos: las reglas se escriben en un solo lugar.
    //     - Permite cambiar la implementación interna sin afectar al código que usa la clase.
    //     - Reduce errores: solo la clase decide cómo cambia su estado.
    //
    // Modificadores de acceso (definen desde dónde se puede usar un miembro):
    //   public     -> desde cualquier parte.
    //   private    -> solo dentro de la propia clase (es el valor por defecto de los miembros).
    //   protected  -> la clase y sus clases derivadas (se verá con herencia).
    //   internal   -> cualquier código del mismo proyecto.
    //   Buena práctica: dar el menor acceso posible. Empezar con private y abrir solo lo necesario.
    //
    // Properties:
    //   - Se usan desde afuera como si fueran un field, pero por dentro ejecutan código.
    //   - "get" devuelve el valor. "set" lo asigna; dentro de set, la palabra "value" es el valor
    //     que se está intentando asignar.
    //   - El bloque set permite validar: aceptar el valor o rechazarlo antes de guardarlo.
    //
    // Diferencia entre fields y properties:
    //   - Field: solo almacena el dato. No puede validar ni controlar el acceso.
    //   - Property: controla cómo se lee y se escribe el dato. Puede validar, calcular o restringir.
    //   - Regla práctica: fields privados (con prefijo _ y camelCase) y properties públicas
    //     (en PascalCase).
    // ---------------------------------------------------------------------------------------------
    class CuentaConPropiedades
    {
        // Fields privados: solo se ven dentro de esta clase.
        private string _titular = "";
        private decimal _saldo;

        // Property con validación: expone el field privado _titular.
        public string Titular
        {
            get { return _titular; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.ArgumentException("El titular no puede estar vacío.");
                }

                _titular = value;
            }
        }

        // Property con validación: el saldo nunca puede quedar negativo.
        public decimal Saldo
        {
            get { return _saldo; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("El saldo no puede ser negativo.");
                }

                _saldo = value;
            }
        }

        // Property auto-implementada: el compilador crea el field oculto. Es la forma abreviada
        // cuando no hace falta ninguna lógica adicional.
        public string Moneda { get; set; } = "ARS";

        public void Depositar(decimal monto)
        {
            Saldo += monto; // Usa la property, por lo que también pasa por la validación.
        }
    }

    // ---------------------------------------------------------------------------------------------
    // PARTES 5 Y 6. CONSTRUCTORES, THIS Y EXPOSICIÓN CONTROLADA
    //
    // Constructor:
    //   - Método especial que se ejecuta automáticamente al crear el objeto con new.
    //   - Tiene el mismo nombre que la clase y no declara tipo de retorno.
    //   - Sirve para dejar el objeto en un estado inicial válido.
    //   - Si la clase no define ninguno, C# genera uno sin parámetros (constructor por defecto).
    //     Si se define uno con parámetros, ese constructor por defecto ya no se genera.
    //
    // Constructor paramétrico:
    //   - Recibe parámetros para inicializar el objeto desde su creación. Obliga a proporcionar
    //     los datos esenciales y evita objetos "a medias".
    //
    // Sobrecarga de constructores:
    //   - Una clase puede tener varios constructores con distinta lista de parámetros (distinta
    //     cantidad o tipo). C# elige cuál ejecutar según los argumentos usados en new.
    //   - Para no repetir código, un constructor puede delegar en otro con ": this(...)".
    //
    // Palabra clave this:
    //   - Hace referencia a la instancia actual: el objeto sobre el que se está ejecutando el código.
    //   - Usos habituales:
    //       1. Distinguir un field o property de un parámetro con el mismo nombre
    //          (this.titular = titular).
    //       2. Encadenar constructores (: this(...)).
    //       3. Pasar o comparar el objeto actual (ver EsLaMismaCuenta).
    //
    // Exposición controlada:
    //   - Titular y Saldo se pueden LEER desde afuera, pero solo la clase puede MODIFICARLOS
    //     ("private set"). Los cambios de estado se hacen mediante métodos con nombre del negocio
    //     (Depositar, Retirar), que aplican las reglas.
    // ---------------------------------------------------------------------------------------------
    class Cuenta
    {
        // Lectura pública, escritura privada.
        public string Titular { get; private set; }
        public decimal Saldo { get; private set; }

        // Constructor por defecto escrito de forma explícita. Delega en el paramétrico con this(...).
        public Cuenta() : this("Sin titular", 0m)
        {
        }

        // Sobrecarga: solo recibe el titular. El saldo inicial es cero.
        public Cuenta(string titular) : this(titular, 0m)
        {
        }

        // Constructor paramétrico: concentra la inicialización y las validaciones.
        public Cuenta(string titular, decimal saldoInicial)
        {
            if (string.IsNullOrWhiteSpace(titular))
            {
                throw new System.ArgumentException("El titular no puede estar vacío.");
            }

            if (saldoInicial < 0)
            {
                throw new System.ArgumentException("El saldo inicial no puede ser negativo.");
            }

            // "this" es el objeto que se está construyendo. Aquí no es obligatorio porque los
            // nombres difieren en mayúsculas, pero deja claro que se asigna a la propia instancia.
            this.Titular = titular;
            this.Saldo = saldoInicial;
        }

        // Los métodos devuelven true/false para informar si la operación pudo realizarse.
        public bool Depositar(decimal monto)
        {
            if (monto <= 0)
            {
                return false;
            }

            Saldo += monto;
            return true;
        }

        public bool Retirar(decimal monto)
        {
            if (monto <= 0 || monto > Saldo)
            {
                return false;
            }

            Saldo -= monto;
            return true;
        }

        // "this" representa a la cuenta sobre la que se llama el método; "otra" es la que se recibe.
        public bool EsLaMismaCuenta(Cuenta otra)
        {
            return ReferenceEquals(this, otra);
        }

        public void Mostrar()
        {
            System.Console.WriteLine("Titular: " + Titular + " | Saldo: " + Saldo);
        }
    }

    // ---------------------------------------------------------------------------------------------
    // PARTE 7. COMPOSICIÓN DE OBJETOS
    //
    // Composición:
    //   - Un objeto contiene a otros objetos como parte de su estado. Es una relación "tiene un".
    //   - Permite construir objetos complejos a partir de otros más simples y reutilizables.
    //   - El objeto contenedor delega parte del trabajo en los objetos que contiene.
    //
    // Aquí: un Cliente TIENE UNA Direccion y TIENE varias Cuentas.
    // ---------------------------------------------------------------------------------------------
    class Direccion
    {
        public string Calle { get; private set; }
        public string Ciudad { get; private set; }

        public Direccion(string calle, string ciudad)
        {
            Calle = calle;
            Ciudad = ciudad;
        }

        public string Descripcion()
        {
            return Calle + ", " + Ciudad;
        }
    }

    class Cliente
    {
        public string Nombre { get; private set; }
        public Direccion Domicilio { get; private set; }

        // El cliente contiene una colección de objetos Cuenta. El field es privado para que nadie
        // agregue cuentas sin pasar por AbrirCuenta.
        private System.Collections.Generic.List<Cuenta> _cuentas = new System.Collections.Generic.List<Cuenta>();

        public Cliente(string nombre, Direccion domicilio)
        {
            Nombre = nombre;
            Domicilio = domicilio;
        }

        // El Cliente crea y guarda sus Cuentas: la cuenta pasa a ser parte del cliente.
        public Cuenta AbrirCuenta(decimal saldoInicial)
        {
            Cuenta nueva = new Cuenta(Nombre, saldoInicial);
            _cuentas.Add(nueva);
            return nueva;
        }

        // Delega en cada Cuenta la consulta de su saldo.
        public decimal SaldoTotal()
        {
            decimal total = 0m;

            foreach (Cuenta cuenta in _cuentas)
            {
                total += cuenta.Saldo;
            }

            return total;
        }

        public int CantidadDeCuentas()
        {
            return _cuentas.Count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------------------------------------------
            // PARTE 2. Clase e instancias
            // -----------------------------------------------------------------------------
            System.Console.WriteLine("--- Parte 2: clase e instancias ---");

            // "new" crea una instancia a partir de la clase. Declarar la variable sola no crea el objeto.
            CuentaBasica cuentaAna = new CuentaBasica();
            cuentaAna.Titular = "Ana";
            cuentaAna.Saldo = 10000m;

            CuentaBasica cuentaLuis = new CuentaBasica();
            cuentaLuis.Titular = "Luis";
            cuentaLuis.Saldo = 3000m;

            // Cada instancia guarda sus propios datos: depositar en una no afecta a la otra.
            cuentaAna.Depositar(2500m);
            cuentaAna.Mostrar();  // Titular: Ana | Saldo: 12500
            cuentaLuis.Mostrar(); // Titular: Luis | Saldo: 3000

            // -----------------------------------------------------------------------------
            // PARTE 3. El problema: el estado queda sin protección
            // -----------------------------------------------------------------------------
            System.Console.WriteLine("--- Parte 3: el problema ---");

            cuentaLuis.Saldo = -5000m; // El compilador lo permite aunque no tiene sentido.
            cuentaLuis.Mostrar();      // Titular: Luis | Saldo: -5000

            // -----------------------------------------------------------------------------
            // PARTE 4. Properties y validación
            // -----------------------------------------------------------------------------
            System.Console.WriteLine("--- Parte 4: properties y validación ---");

            CuentaConPropiedades cuentaProtegida = new CuentaConPropiedades();
            cuentaProtegida.Titular = "Marta";
            cuentaProtegida.Saldo = 4000m;
            cuentaProtegida.Depositar(1000m);
            System.Console.WriteLine(cuentaProtegida.Titular + " | " + cuentaProtegida.Saldo + " " + cuentaProtegida.Moneda); // Marta | 5000 ARS

            // La validación del set rechaza el valor inválido y el saldo anterior se conserva.
            try
            {
                cuentaProtegida.Saldo = -500m;
            }
            catch (System.ArgumentException error)
            {
                System.Console.WriteLine("Valor rechazado: " + error.Message); // El saldo no puede ser negativo.
            }

            System.Console.WriteLine("Saldo conservado: " + cuentaProtegida.Saldo); // 5000

            // -----------------------------------------------------------------------------
            // PARTES 5 Y 6. Constructores, this y exposición controlada
            // -----------------------------------------------------------------------------
            System.Console.WriteLine("--- Partes 5 y 6: constructores y exposición controlada ---");

            // C# elige el constructor según los argumentos usados (sobrecarga).
            Cuenta cuentaVacia = new Cuenta();                  // Constructor por defecto.
            Cuenta cuentaNueva = new Cuenta("Carla");           // Solo titular.
            Cuenta cuentaCompleta = new Cuenta("Diego", 8000m); // Constructor paramétrico.

            cuentaVacia.Mostrar();    // Titular: Sin titular | Saldo: 0
            cuentaNueva.Mostrar();    // Titular: Carla | Saldo: 0
            cuentaCompleta.Mostrar(); // Titular: Diego | Saldo: 8000

            // Los cambios de estado se hacen solo mediante los métodos de la clase.
            cuentaCompleta.Depositar(2000m);
            bool retiroValido = cuentaCompleta.Retirar(1500m);
            bool retiroInvalido = cuentaCompleta.Retirar(50000m);
            System.Console.WriteLine("Retiro de 1500 realizado: " + retiroValido);    // True
            System.Console.WriteLine("Retiro de 50000 realizado: " + retiroInvalido); // False
            System.Console.WriteLine("Saldo actual: " + cuentaCompleta.Saldo);        // 8500

            // El saldo se puede leer pero no asignar desde afuera. Esta línea no compila:
            // cuentaCompleta.Saldo = 999999m; // Error: el set es privado.

            // this como referencia al propio objeto.
            Cuenta otraReferencia = cuentaCompleta; // Apunta al MISMO objeto, no crea uno nuevo.
            System.Console.WriteLine(cuentaCompleta.EsLaMismaCuenta(otraReferencia)); // True
            System.Console.WriteLine(cuentaCompleta.EsLaMismaCuenta(cuentaNueva));    // False

            // -----------------------------------------------------------------------------
            // PARTE 7. Composición de objetos
            // -----------------------------------------------------------------------------
            System.Console.WriteLine("--- Parte 7: composición ---");

            Direccion domicilio = new Direccion("Av. Santa Fe 742", "Buenos Aires");
            Cliente cliente = new Cliente("Elena", domicilio);

            cliente.AbrirCuenta(15000m);
            cliente.AbrirCuenta(5000m);

            System.Console.WriteLine("Cliente: " + cliente.Nombre);                    // Elena
            System.Console.WriteLine("Domicilio: " + cliente.Domicilio.Descripcion()); // Av. Santa Fe 742, Buenos Aires
            System.Console.WriteLine("Cuentas: " + cliente.CantidadDeCuentas());       // 2
            System.Console.WriteLine("Saldo total: " + cliente.SaldoTotal());          // 20000
        }
    }
}
