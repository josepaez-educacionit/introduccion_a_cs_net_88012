/*
1. Qué es .NET.

.NET es una plataforma de desarrollo creada por Microsoft que permite construir y ejecutar
aplicaciones utilizando distintos lenguajes de programación, entre ellos C#, F# y Visual Basic.
Una plataforma, en este contexto, es un conjunto de herramientas y componentes de software
que trabajan juntos para que un programa pueda crearse y funcionar correctamente.

.NET está formado principalmente por dos elementos: un conjunto de bibliotecas (código ya
escrito y listo para reutilizar, que resuelve tareas comunes como trabajar con archivos,
texto o fechas) y un entorno de ejecución (el componente encargado de tomar el código que
escribimos y hacerlo funcionar en la computadora).

Con esta plataforma, es posible desarrollar aplicaciones de escritorio, sitios y
servicios web, aplicaciones móviles y soluciones en la nube, utilizando en gran medida las
mismas herramientas y conceptos, sin importar el tipo de aplicación que se esté creando.

Además, .NET se encarga de tareas importantes que el programador no siempre necesita resolver
manualmente, como administrar la memoria que usa un programa o gestionar errores durante su
ejecución. Esto permite que los desarrolladores, especialmente quienes recién comienzan,
puedan concentrarse en aprender la lógica de programación sin preocuparse desde el inicio
por aspectos internos más avanzados.

En síntesis, .NET es la base sobre la cual se construyen las aplicaciones que estudiaremos en
este curso, y comprender su propósito general es el primer paso para entender cómo encaja el
lenguaje C# dentro de esta plataforma.
*/

// Implementaciones de .NET
// Algunas de las implementaciones más conocidas de .NET incluyen:
// - .NET Core: Una implementación multiplataforma de .NET que permite desarrollar aplicaciones para Windows, macOS y Linux.
// - .NET Framework: La implementación original de .NET, principalmente para aplicaciones de Windows.
// - Xamarin/Mono: Implementaciones de .NET orientadas al desarrollo de aplicaciones móviles y multiplataforma.
// - .NET 5/6/7 y posteriores: La evolución unificada de .NET Core y .NET Framework, que busca consolidar todas las implementaciones en una sola plataforma.

// Casos de uso reales de .NET y C# (referencia 2026)
// Los ejemplos siguientes muestran cómo se usa .NET en la práctica. Los nombres de productos
// y empresas son ilustrativos; conviene verificar los detalles actuales antes de citarlos.

// Aplicaciones web y APIs:
// - Sitios de alto tráfico y APIs REST o gRPC, como Stack Overflow, construidos con ASP.NET Core.
// - Servicios backend de Microsoft 365 y Azure, donde C# es el lenguaje principal de gran parte de la infraestructura.

// Aplicaciones de escritorio:
// - Herramientas internas de empresas, como sistemas de punto de venta, facturación o gestión de inventario,
//   desarrolladas con WinForms o WPF.
// - Software de diseño e ingeniería, y paneles de control (HMI) en plantas industriales.

// Aplicaciones móviles y multiplataforma:
// - Apps para Android, iOS, Windows y macOS con .NET MAUI, compartiendo gran parte del código entre plataformas.

// Videojuegos:
// - Unity usa C# como lenguaje de scripting. Juegos conocidos como Beat Saber, Hollow Knight y Subnautica
//   fueron desarrollados con Unity.
// - Godot también ofrece soporte para C#.

// Nube, microservicios y sistemas distribuidos:
// - Azure Functions permite ejecutar código C# sin administrar servidores (serverless).
// - Microsoft Orleans, un framework de "actores virtuales", se usa en servicios de juegos con muchos jugadores
//   simultáneos, como el backend de la franquicia Halo.

// Inteligencia artificial:
// - Semantic Kernel y Microsoft Agent Framework permiten crear agentes de IA y conectar modelos de lenguaje
//   a aplicaciones .NET.
// - ML.NET permite entrenar y usar modelos de aprendizaje automático directamente desde C#.

// Sectores de la economía:
// - Finanzas y banca: sistemas de pagos, procesamiento de transacciones y APIs de core bancario.
// - Salud: sistemas de gestión hospitalaria, historias clínicas y aplicaciones de telemedicina.
// - Gobierno: plataformas de trámites, registros civiles y servicios ciudadanos en línea.
// - Manufactura e industria: automatización, control de maquinaria e integración con sistemas IoT.
// - Retail y comercio electrónico: catálogos, carritos de compra, logística y puntos de venta.
// - Energía y logística: monitoreo de redes, gestión de flotas y planificación de rutas.

// Que es c# 
// C# es un lenguaje de programación moderno, orientado a objetos y desarrollado por Microsoft.
// Forma parte del ecosistema .NET y se utiliza para crear aplicaciones de escritorio, web, móviles,
// videojuegos y servicios en la nube.
// C# combina la simplicidad de lenguajes como Java con la potencia de C++, ofreciendo características
// como tipado fuerte, recolección de basura, programación asíncrona y soporte para LINQ.
