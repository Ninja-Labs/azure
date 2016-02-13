#Azure Camp Medellín 2016, Creando un Backend con EntityFramework Core y Asp.Net Web Api.

En este laboratorio aprenderemos a trabajar con EntityFramework Core, usando el enfoque Codefirst para crear una base de datos e interactuar con ella, adicionalmente aprenderemos como exponer nuestro modelo conceptual generado por EF, a través de Asp.Net Web Api.

Cuando terminemos tendremos un Backend RestFull expuesto a través de Asp.Net Web Api, para ser consumido desde cualquier tipo de cliente que pueda emitir peticiones HTTP.

## Tecnologías que usaremos

* Microsoft Azure Sql Db: Como base de datos relacional en la nube, para almacenar los datos
* EntityFramework Core: Como ORM para persistencia y acceso a datos
* Asp.Net Web Api: Como marco de trabajo para la creación de servicios Http
* Telerik Fiddler: Como cliente para probar nuestros servicios

## Editor de código

* Para este laboratorio usaremos Microsoft Visual Studio 2015

## Contexto

Para iniciar hablemos un poco del nuevo framework....

## Tarea 1 - Creando la estructura del proyecto

1. Abrir Visual Studio, hacer click en la opción File/New/Project
1. En el cuadro de dialogo, en el Templates elegir "Other Projects Types" opción "Visual Studio Solutions" y crear una solución en blanco.
1. Ahora le daremos el seguiente nombre a la solución "NinjaLab.Azure" este será el NameSpace que manejaremos en toda la solución.
1. Ahora que tenemos creada nuestra solución vamos a hacer click derecho sobre ella, elegimos la opción "Add/New Solution Folder", a esta carpeta le daremos el nombre de "Common".
1. Realizamos el paso anterior una vez más, pero esta oportunidad nombraremos la carpeta como "Apis"
1. Ahora en la carpeta "Common" agregaremos un nuevo proyecto de tipo librería de clases con el siguiente nombre "NinjaLab.Azure.Domain" respetando el NameSpace de la solución, en este proyecto haremos uso de EntityFramework más adelante.
1. Posteriormente agregaremos otro proyecto de tipo librería de clases a la carpeta "Common" esta vez lo llamaremos "NinjaLab.Azure.Dto" este proyecto nos permitirá agrupar las entidades DTO que más adelante explicaremos.
1. Para finalizar con la creación de la estructura de nuestro proyecto vamos a agregar un proyecto a la carpeta "Apis" en este caso el proyecto será de tipo web, y está ubicado en "Visual C#" / "Web" / "Asp.Net Web Application"
1. A este proyecto le daremos el siguiente nombre "NinjaLab.Azure.Apis" y usaremos la plantilla Asp.Net 4.5.2 Web Api, usaremos esta versión para mostrar algunas características que aun no están soportadas en Asp.Net MVC Core.
![Plantilla WebApi](./Img/1-PlantillaWEbApi.JPG?raw=true "Plantilla WebApi")
1. Una vez creemos este proyecto se nos pedirán una serie de datos para alojar nuestras Apis en Microsoft Azure desde su creación, en el servicio de tipo PaaS llamado App Service del cual hablaremos un poco más adelante, para esto debemos estar logueados con la cuenta que tenemos asociada a Microsoft Azure y podemos dejar por defecto los datos que nos llena Visual Studio.
![Datos Azure](./Img/2-DatosAzure.JPG?raw=true "Datos Azure")
1. Para finalizar con la creación del proyecto, hacemos click en el botón "Create"

Hasta Acá Debes tener una solución como esta:
![Estructua solucion](./Img/3-EstructuraSolucion.JPG?raw=true "Estructua solucion")

## Tarea 2 - Creando el modelo conceptual con EntityFramework Core

1. Para crear nuestro modelo conceptual y posteriormente nuestras base de datos con EntityFramework Core lo primero que vamos a hacer es abrir la consola de comando de Nuget, para instalar un par de paquetes.
1. La consola la encontramos en el menú superior, opción "Tools" / "Nuget Package Manager" / "Package Manager Console"
1. Asegurate de tener seleccionado en la consola el proyecto de dominio, Ahora ejecutamos el siguiente comando "Install-Package EntityFramework.MicrosoftSqlServer –Pre" para instalar EF Core con el proveedor para conexión a Sql Server.
1. Y adicional ejecutamos el siguiente comando "Install-Package EntityFramework.Commands –Pre" el cual nos permite ejecutar los diferentes comandos de EF para mantener la base de datos, por ejemplo las migraciones, de las cuales hablaremos más adelante.
1. Ahora vamos a proceder a crear nuestro modelo, usando el enfoque Code First, el cual nos permite codificar nuestras entidades y posteriormente crear la base de datos a partir de ellas, si no estas muy familiarizado con este enfoque te recomiendo leer el siguiente artículo: http://www.eltavo.net/2014/01/entityframework-iniciando-con-code-first.html
1. Para iniciar vamos a agregar la clase Equipo a nuestro proyecto de dominio:

```javascript
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NinjaLab.Azure.Domain
{
    /// <summary>
    /// Entidad que permite mapear objetualmente la tabla Equipos de la base de datos.
    /// </summary>
    public class Equipo
    {
        [Key]
        /// <summary>
        /// Obtiene o establece El identificador único del equipo.
        /// </summary>
        public int IdEquipo { get; set; }

        [Required]
        [MaxLength(200)]
        /// <summary>
        /// Obtiene o establece el nombre del equipo.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apodo del equipo ej: merengues, catalanes, diablos rojos, etc.
        /// </summary>
        public string Apodo { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del presidente del equipo.
        /// </summary>
        public string Presidente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del entrenador del equipo.
        /// </summary>
        public string Entrenador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estadio del equipo.
        /// </summary>
        public string Estadio { get; set; }

        /// <summary>
        /// Obtiene o establece los jugadores del equipo.
        /// </summary>
        public List<Jugador> Jugadores { get; set; }
    }
}
``` 
1. Observa detenidamente que las propiedades IdEquipo y Nombre, esta decoradas con un par de atributos, esto atributos reciben el nombre de DataAnnotations, por esto el using de "System.ComponentModel.DataAnnotations", estos nos permite decorar nuestro atributos de modo que podamos darles explicitamente (Sin dejar a la convención de EF) ciertas características que después serán replicadas en nuestra base de datos, por ejemplo en nuestro caso establecer la llaver primaria (Key), Establecer un campo como requerido (Required) y establece la longitud máxima de un campo (MaxLength(200)). si quieres conocer un poco más acerca de los DataAnnotations puedes leer el siguiente artículo: http://www.eltavo.net/2014/01/entityframework-configurando-nuestras.html
1. Ahora agregaremos la clase Jugador al proyecto de dominio:

```javascript
namespace NinjaLab.Azure.Domain
{
    /// <summary>
    /// Entidad que permite mapear objetualmente la tabla Jugadores de la base de datos.
    /// </summary>
    public class Jugador
    {
        /// <summary>
        /// Obtiene o establece el identificador único del jugador.
        /// </summary>
        public int IdJugador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del jugador.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apodo del jugador.
        /// </summary>
        public string Apodo { get; set; }

        /// <summary>
        /// Obtiene o establece la nacionalidad del jugador.
        /// </summary>
        public string Nacionalidad { get; set; }

        /// <summary>
        /// Obtiene o establece la estatura del jugador.
        /// </summary>
        public decimal Estatura { get; set; }

        /// <summary>
        /// Obtiene o establece el peso del jugador.
        /// </summary>
        public int Peso { get; set; }

        /// <summary>
        /// Obtiene o establece la posición en la cancha del jugador (Delantero, Defensa, etc)
        /// </summary>
        public string Posicion { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del equipo al cual pertenece el jugador.
        /// </summary>
        public int IdEquipo { get; set; }

        /// <summary>
        /// Obtiene o establece el equipo al cual pertenece el jugador.
        /// </summary>
        public Equipo Equipo { get; set; }
    }
}

```

1. Como puedes observar en esta clase no hemos usado DataAnnotations para decorar las propiedades, además de los DataAnnotatios EntityFramework nos ofrece otra posibilidad de configurar las clases llamada FluentApi, la cual veremos en la siguiente clase que vamos a crear.
1. La siguiente clase que vamos a crear es nuestro contexto, el cual nos servirá para crear e interactuar con nuestra base de datos, el código de la clase es el siguiente:

```javascript
using Microsoft.Data.Entity;

namespace NinjaLab.Azure.Domain
{
    public class FutbolModel : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Jugador> Jugadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:{Tuservidor}.database.windows.net,1433;Database=FutbolDb;
User ID=AzureDevCampMde@{Tuservidor};Password={TuPassword};Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>().HasKey(c => c.IdJugador);
            modelBuilder.Entity<Jugador>().Property(c => c.Nombre).IsRequired();
            modelBuilder.Entity<Jugador>().Property(c => c.Nombre).HasMaxLength(200);
        }
    }
}

```

1. Para quienes están familiarizados con EF Code First, no vemos muchas diferencias en el contexto que creamos, tenemos las propidades DbSet de cada tipo de nuestras entidades, para indicar que serán mapeadas a tablas en la base de datos.
1. Y adicional tenemos el método OnConfguring que si es nuevo en EF Core que nos permite especificar configuraciones como por ejemplo el proveedor que usaremos, en este caso Sql Server.
1. Y en el método OnModelCreating, tenemos las respectivas configuraciones para la entidad Jugador, a través de Fluent Api, que nos permite realizar las mismas configuraciones que los DataAnnotations, pero de una forma centralizada usando métodos encadenados y expresiones lambda para lograrlo, como podemos ver hicimos las mismas configuraciones que para la entidad Equipo.
1. Adicional observanos que tenemos establecida una cadena de conexión, la cual usará EntetityFramework una vez haga la migración para crear o actualizar la base de datos según sea el caso, para efectos de nuestro laboratorio dejaremos la cadena en el código, para un escenario real la debemos llevar al archivo de configuración.
1. Para obtener la cadena de conexión, primero debemos crear un servidro en Microsoft Azure, para esto ingresamos al portal https://manage.windowsazure.com y nos autenticamos con nuestra cuenta.
1. Posteriormente elegimos la opción "Bases de datos Sql" y la opción "Nuevo"
  ![Db Azure](./Img/4-CrearDBAzure.jpg?raw=true "Db Azure")
1. Luego elegimos las siguientes opciones para una creación rápida, asegúrate de escribir o recordar el nombre de usuario y contraseña que especifiques pues lo necesitarás más adelante, para el nombre de la base de datos puedes usar cualquier nombre, dado que solo la usaremos para crear el servidor en el que luego EF creará nuestra base de datos.
![Db Azure](./Img/5-OpcionesCReacionDB.jpg?raw=true "Db Azure")
1. Ahora esperemos unos minutos a que se creé el servidor y base de datos en Azure.
1. Una vez este creada la base de datos volvemos a la opción de "Bases de datos Sql" y elegimos la base de datos que acabamos de crear y hacemos click en el link "Consultar las cadenas de conexión..."
 ![Consultar cadenas](./Img/6-ConsultarCadenas.jpg?raw=true "Consultar cadenas")
1. Posteriormente se abrirá un Popup con las diferentes cadenas de conexión, copiamos la cadena correspondiente a Ado.Net y la pegamos en nuestro contexto, recordemos que debemos cambiar la contraseña y el nombre de la base de datos en esta cadena de conexión.
1. Ahora que ya tenemos nuestro contexto y entidades, es hora de activar las migraciones, para que se pueda crear nuestra base de datos y actualizar posteriormente con cambios que surjan.
1. Para activar las migraciones abre la consola de Nuget, asegúrate de tener seleccionado el proyecto de dominio y ejecuta el siguiente comando "Add-Migration MigracionInicial"
1. Podemos observar que una vez que se ejecuta el comando se crear una nueva carpeta en el proyecto de dominio llamada migrations y en su interior una clase que contiene el código necesario para ejecutar la migración.
1. ahora ejecutemos el siguiente comando para aplicar la migración "Update-Database" 
1. veremos que después de ejecutar el comando nuestra base de datos estará creada.

## Tarea 3 - Creando los objetos DTO

Los objetos DTO o Data Transfer Object nos permiten transportar datos de una manera más limpia y estandar, nos permiten transportar la información que realmente necesitamos en entidades livianas, ademñas no evita problemas de serialziación, por ejemplo si quieremos transportar entidades que tengan relaciones de muchos a muchos generadas por EF, Asp.Net web Api tendrá problemas para serializarlas dado las referencias circualares de estas clases para expresar su relación.

1. Ahora greguemos los DTO para las entidades, en el proyecto o librería de clases "NinjaLab.Azure.Dto":

```javascript

namespace NinjaLab.Azure.Dto
{
    /// <summary>
    /// Entidad que permite transportar los datos correspondientes a un equipo.
    /// </summary>
    public class Equipo
    {
        /// <summary>
        /// Obtiene o establece El identificador único del equipo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del equipo.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apodo del equipo ej: merengues, catalanes, diablos rojos, etc.
        /// </summary>
        public string Apodo { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del presidente del equipo.
        /// </summary>
        public string Presidente { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del entrenador del equipo.
        /// </summary>
        public string Entrenador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estadio del equipo.
        /// </summary>
        public string Estadio { get; set; }
    }
}


namespace NinjaLab.Azure.Dto
{
    /// <summary>
    /// Entidad que permite transportar los datos correspondientes a un jugador.
    /// </summary>
    public class Jugador
    {
        /// <summary>
        /// Obtiene o establece el identificador único del jugador.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del jugador.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el apodo del jugador.
        /// </summary>
        public string Apodo { get; set; }

        /// <summary>
        /// Obtiene o establece la nacionalidad del jugador.
        /// </summary>
        public string Nacionalidad { get; set; }

        /// <summary>
        /// Obtiene o establece la estatura del jugador.
        /// </summary>
        public decimal Estatura { get; set; }

        /// <summary>
        /// Obtiene o establece el peso del jugador.
        /// </summary>
        public int Peso { get; set; }

        /// <summary>
        /// Obtiene o establece la posición en la cancha del jugador (Delantero, Defensa, etc)
        /// </summary>
        public string Posicion { get; set; }

        /// <summary>
        /// Obtiene o establece el Id del equipo al cual pertenece el jugador.
        /// </summary>
        public int IdEquipo { get; set; }
    }
}


```

## Tarea 4 - Creando los controladores de las Apis

Ahora vamos a crear los controladores de las Apis, que nos permitiran exponer nuestro contexto e interactuar con nuestra base de datos, para efectos de nuestro laboratorio usaremos el contexto directamente desde nuestras Apis, en un escenario real probablemente usaríamos otro patrón como Repositorio por ejemplo para acceder al contexto.

1. Vamos a iniciar por agregar las referencias a nuestro proyecto de Apis, del proyecto de dominio y el proyecto de Dtos.
1. Ahora vamos a agregar las mismas referencias de EF que agregamos en el proyecto de dominio, ya que recordemos que si referenciamos algún proyecto debemos referenciar también sus dependencias.
1. Adicional vamos a agregar el paquete Nuget AutoMapper, el cual nos permitira mapear información de nuestro contexto a la entidad DTO que será transportada a través del API. para eso ejecutamos el siguiente comando en la consolo de Nuget "Install-Package AutoMapper"
1. Posteriormente en la carpeta de "Controllers" vamos a agregar un controlador llamado "EquipoController" y vamos a codificarlo de la siguiente forma:

```javascript
using AutoMapper;
using NinjaLab.Azure.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace NinjaLab.Azure.Apis.Controllers
{
    public class EquipoController : ApiController
    {
        /// <summary>
        /// Permite obtener los equipos existentes.
        /// </summary>
        /// <returns>Listado de equipos.</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<NinjaLab.Azure.Dto.Equipo>))]
        public IHttpActionResult ObtenerEquipos()
        {
            var contexto = new FutbolModel();
            var equipos = from c in contexto.Equipos
                          select new NinjaLab.Azure.Dto.Equipo
                          {
                              Id = c.IdEquipo,
                              Nombre = c.Nombre,
                              Apodo = c.Apodo,
                              Entrenador = c.Entrenador,
                              Estadio = c.Estadio,
                              Presidente = c.Presidente
                          };
            return Ok(equipos.ToList());
        }

        /// <summary>
        /// Permite obtener un equipo en específico a través de su Id.
        /// </summary>
        /// <param name="id">Id del equipo.</param>
        /// <returns>Equipo.</returns>
        [HttpGet]
        [ResponseType(typeof(NinjaLab.Azure.Dto.Equipo))]
        public IHttpActionResult ObtenerEquipo(int id)
        {
            using (var contexto = new FutbolModel())
            {
                var equipo = contexto.Equipos.FirstOrDefault(c => c.IdEquipo == id);
                return Ok(equipo);
            }
        }

        /// <summary>
        /// Permite agregar un nuevo equipo.
        /// </summary>
        /// <param name="equipo">Equipo a ingresar.</param>
        [HttpPost]
        public void AgregarEquipo([FromBody]NinjaLab.Azure.Dto.Equipo equipo)
        {
            using (var contexto = new FutbolModel())
            {
                var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<NinjaLab.Azure.Dto.Equipo, Equipo>());
                var mapper = mapperConfig.CreateMapper();
                var equipoBd = mapper.Map<Equipo>(equipo);

                contexto.Equipos.Add(equipoBd);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Permite actualizar un equipo existente.
        /// </summary>
        /// <param name="equipo">Equipo a actualizar.</param>
        [HttpPut]
        public void ActualizarEquipo([FromBody]NinjaLab.Azure.Dto.Equipo equipo)
        {
            var contexto = new FutbolModel();
            var equipoBd = contexto.Equipos.FirstOrDefault(c => c.IdEquipo == equipo.Id);

            if (equipoBd != null)
            {
                equipoBd.Nombre = equipo.Nombre;
                equipoBd.Apodo = equipo.Apodo;
                equipoBd.Entrenador = equipo.Entrenador;
                equipoBd.Estadio = equipo.Estadio;
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Permite eliminar un equipo existente.
        /// </summary>
        /// <param name="id">Id del equipo a eliminar.</param>
        [HttpDelete]
        public void EliminarEquipo(int id)
        {
            using (var contexto = new FutbolModel())
            {
                var equipoBd = contexto.Equipos.FirstOrDefault(c => c.IdEquipo == id);
                contexto.Equipos.Remove(equipoBd);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Permite obtener todos los jugadores que pertenecen a un equipo en específico.
        /// </summary>
        /// <param name="idEquipo">Id del equipo.</param>
        /// <returns>Listado de jugadores.</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<NinjaLab.Azure.Dto.Jugador>))]
        [Route("Api/ObtenerJugadoresEquipo/{idEquipo}")]
        public IHttpActionResult ObtenerJugadoresEquipo(int idEquipo)
        {
            var contexto = new FutbolModel();
            var jugadores = from c in contexto.Equipos
                            join d in contexto.Jugadores on c.IdEquipo equals d.IdEquipo
                            where c.IdEquipo == idEquipo
                            select new NinjaLab.Azure.Dto.Jugador
                            {
                                Id = d.IdJugador,
                                Nombre = d.Nombre,
                                Apodo = d.Apodo,
                                Estatura = d.Estatura,
                                Nacionalidad = d.Nacionalidad,
                                Peso = d.Peso,
                                Posicion = d.Posicion
                            };
            return Ok(jugadores);
        }
    }
}

````

## Tarea 5 - Tareas adicionales

1. Ahora con el conocimiento adquirido agrega el Api correspondiente a Jugador, con acciones CRUD de este entidad.
1. Con el conocimiento adquirido agrega un nuevo campo llamado "bandera" a la entidad Equipo, recuerda agregarlo también en la entidad DTO y hacer las migraciones para que se reflejen los cambios.
1. Ahora vamos a desplegar todos los cambios que hemos implementado en el proyecto, para esto primero compilamos la solucón y posteriormente hacemos click derecho sobre el proyecto de las Apis, elegimos la opción publicar, y hacemos click en aceptar, dado que previamente ya habíamos configurado la publicación.
1. Aprendamos a habilitar CORS en las Apis, a través del siguiente vídeo: https://www.youtube.com/watch?v=HBPs5m9T-Jg
