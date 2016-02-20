#AzureCamp Bogotá 2016 - ASPNET Web API, DocumentDB y Azure

[ASPNET WebAPI](http://www.asp.net/web-api) es un framework de la familia ASPNET diseñado para crear servicios REST o APIs HTTP; mientras que por
su lado, [DocumentDB](https://azure.microsoft.com/en-us/documentation/services/documentdb/) es la oferta de Microsoft en el mundo de las bases de datos NoSQL. En este HOL se va a crear un servicio HTTP
que se conecte a una base de datos DocumentDB en [Microsoft Azure](https://azure.microsoft.com/en-us/).

### Requisitos

* Para este laboratorio utilizaremos **Visual Studio 2015**, recuerda que puedes descargar la versión [Community](https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx) que es gratuita
y ofrece las mismas características que la versión Professional.

* Una cuenta activa de Microsoft Azure.

* [Fiddler](http://www.telerik.com/fiddler) para validar el servicio [Opcional]

## Tarea 1: Creación de la base DocumentDB

En esta primer tarea vamos a crear la base de datos de DocumentDB.

* Ir al portal de [Azure](http://portal.azure.com) y loguearse.

* En el portal de Azure, en New > Data + Storage > Azure DocumentDB:

![Azure DocumentDB](http://res.cloudinary.com/julitogtu/image/upload/v1455228666/HOLWebAPI1_rnjknk.png)

* En la siguiente parte del wizard, ingresar los datos de la cuenta de DocumentDB:

![Azure DocumentDB Account](http://res.cloudinary.com/julitogtu/image/upload/v1455228731/HOLWebAPI2_ckn3ey.png)

* Una vez creada la cuenta de DocumentDB, en el panel principal se tiene el acceso directo a dicha cuenta, seleccionarla:

![Pin Azure DocumentDB Account](http://res.cloudinary.com/julitogtu/image/upload/v1455229081/HOLWebAPI3_wzgyvp.png)

* En este momento, se ha creado la cuenta de DocumentDB, sin embargo, no se crea ninguna base de datos, así que en el menú seleccionar **Add Database**:

![Add DocumentDB Database](http://res.cloudinary.com/julitogtu/image/upload/v1455229254/HOLWebAPI4_xuxh8h.png)

* Luego, ingresar el nombre de la base de datos y dar clic en OK en la parte inferior:

![DocumentDB Database Name](http://res.cloudinary.com/julitogtu/image/upload/v1455229331/HOLWebAPI5_rbyaxh.png)

* En el panel de cuenta de DocumentDB en el tile de Databases ya se observa la nueva base de datos:

![DocumentDB Databases](http://res.cloudinary.com/julitogtu/image/upload/v1455229464/HOLWebAPI6_vrybzi.png)

* DocumentDB al igual que otras bases de datos NoSQL como MongoDB trabaja con colecciones, así que el siguiente paso 
es crear una colección para nuestra base de datos, para este pase seleccionar la base creada anteriormente y seleccionar
**Add Collection**:

![Add Collection](http://res.cloudinary.com/julitogtu/image/upload/v1455229766/HOLWebAPI7_b3icr1.png)

* En el panel ingresar el nombre de la colección, el nivel de servicio (cuánto quieres pagar) y la política de indexación:

![Collection Settings](http://res.cloudinary.com/julitogtu/image/upload/v1455229923/HOLWebAPI8_jjo0jb.png)

* Ahora, en la base de datos, en el tile de Collections se ve la colección que se acabo de crear:

![DocumentDB Collections](http://res.cloudinary.com/julitogtu/image/upload/v1455231669/HOLWebAPI9_ony32m.png)

## Tarea 2: Adición de un documento

Los registros en las bases de datos documentales de conocen como documentos, una colección como la creada anterioremente puede tener
1 o más documentos. Los documentos en DocumentDB son registros en formato JSON y pueden crear desde el portal o usando el API.
En esta tarea se va crear el documento desde el portal.

* Seleccionamos la colección creada anteriormente, y posteriormente **Create Document**:

![Create Document](http://res.cloudinary.com/julitogtu/image/upload/v1455232456/HOLWebAPI10_pc2ko2.png)

* Se abre un nuevo panel en donde se muestra un registro en formato JSON:

![JSON Format](http://res.cloudinary.com/julitogtu/image/upload/v1455282758/WebAPIAndNoSQL11_ygvgp2.png)

* JSON o JavaScript Object Notation, es un formato en el cuál basicamente tenemos propiedades separadas por comas, así que editamos el documento con la siguiente información (el id es opcional,
en caso de no ingresar valor para este campo se genera un GUID):

```javascript
{
  "id": "1",  
  "name": "Deadpool",
  "year": "2016",
  "description": "Based upon Marvel Comics’ most unconventional anti-hero, DEADPOOL tells the origin story of former Special Forces operative turned mercenary Wade Wilson, who after being subjected to a rogue experiment that leaves him with accelerated healing powers, adopts the alter ego Deadpool. Armed with his new abilities and a dark, twisted sense of humor, Deadpool hunts down the man who nearly destroyed his life.",
  "genre": "Action"
}
```

* Luego de ingresada la información, dar clic en **Save** para guardar el registro.

* Para consultar el registrado ingresado, en la colección seleccionamos **Query Documents**:

![Query Documents Option](http://res.cloudinary.com/julitogtu/image/upload/v1455283662/WebAPIAndNoSQL12_nkhhan.png)

* Se abre en **Query Explorer**, allí es posible definir filtros para la consulta, para este caso lo dejaremos como viene por defecto y seleccionamos **Run query**:

![Query Explorer](http://res.cloudinary.com/julitogtu/image/upload/v1455283875/WebAPIAndNoSQL13_ja6cih.png)

* Una vez ejecutado el query, se puede ver el registro que se ha ingresado,y efectivamente la propiedad tiene como calor un GUID:

![Query Results](http://res.cloudinary.com/julitogtu/image/upload/v1455284279/WebAPIAndNoSQL14_mpvk0v.png)

* Vamos a añadir los siguientes documentos a la colección para contar con varios documentos:

```javascript
//Kung FU Panda 3
{
  "id": "2",
  "name": "Kung FU Panda 3",
  "year": "2016",
  "description": "In 2016, one of the most successful animated franchises in the world returns with its biggest comedy adventure yet, KUNG FU PANDA 3. When Po's long-lost panda father suddenly reappears, the reunited duo travels to a secret panda paradise to meet scores of hilarious new panda characters. But when the supernatural villain Kai begins to sweep across China defeating all the kung fu masters, Po must do the impossible—learn to train a village full of his fun-loving, clumsy brethren to become the ultimate band of Kung Fu Pandas!",
  "genre": "Animation"
}
//X-Men: Apocalypse
{
    "id": "3",
	"name": "X-Men: Apocalypse",
	"year": "2016",
	"description": "Following the critically acclaimed global smash hit X-Men: Days of Future Past, director Bryan Singer returns with X-MEN: APOCALYPSE. Since the dawn of civilization, he was worshipped as a god. Apocalypse, the first and most powerful mutant from Marvel’s X-Men universe, amassed the powers of many other mutants, becoming immortal and invincible. Upon awakening after thousands of years, he is disillusioned with the world as he finds it and recruits a team of powerful mutants, including a disheartened Magneto (Michael Fassbender), to cleanse mankind and create a new world order, over which he will reign. As the fate of the Earth hangs in the balance, Raven (Jennifer Lawrence) with the help of Professor X (James McAvoy) must lead a team of young X-Men to stop their greatest nemesis and save mankind from complete destruction.",
	"genre": "Action"
}
//The Revenant
{
  "id": "4",
  "name": "The Revenant",
  "year": "2016",
  "description": "Inspired by true events, THE REVENANT is an immersive and visceral cinematic experience capturing one man’s epic adventure of survival and the extraordinary power of the human spirit. In an expedition of the uncharted American wilderness, legendary explorer Hugh Glass (Leonardo DiCaprio) is brutally attacked by a bear and left for dead by members of his own hunting team. In a quest to survive, Glass endures unimaginable grief as well as the betrayal of his confidant John Fitzgerald (Tom Hardy). Guided by sheer will and the love of his family, Glass must navigate a vicious winter in a relentless pursuit to live and find redemption. THE REVENANT is directed and co-written by renowned filmmaker, Academy Award® winner Alejandro G. Iñárritu (Birdman, Babel).",
  "genre": "Action"
}
```
* Una herramienta importante en DocumentDB es el **Document Explorer**, se encuentra en la colección en la sección de **Developer Tools**:

![Document Explorer](http://res.cloudinary.com/julitogtu/image/upload/v1455285289/WebAPIAndNoSQL15_hzwxi3.png)

* Una vez seleccionado, se abre un nuevo panel es posible buscar documentos fácilmente por su id o bien crear filtros personalizados:

![Document Explorer Panel](http://res.cloudinary.com/julitogtu/image/upload/v1455285538/WebAPIAndNoSQL16_gk6l6e.png)

* Al seleccionar uno de los documentos, es posible editarlo o eliminarlo:

![Document](http://res.cloudinary.com/julitogtu/image/upload/v1455285683/WebAPIAndNoSQL17_aibcrx.png)

## Tarea 3: Creación del proyecto y repositorio

ASPNET WebAPI es una de las ofertas (si, WCF sigue vivo) de Microsoft para crear servicios basados en HTTP, ahora con ASPNET Core,
Web API se ha fusionado a ASPNET MVC, así que en este caso haremos vamos a crear el servicio con ASPNET Core.

![ASPNET 4.6 and ASPNET Core 1.0](http://res.cloudinary.com/julitogtu/image/upload/v1455288304/WebAPIAndNoSQL19_dpakad.png)

* En Visual Studio 2015, creamos un nuevo proyecto de tipo Web Application, y seleccionamos la plantilla **Empty** en **ASPNET 5 Templates**

![ASP.NET Web Application](http://res.cloudinary.com/julitogtu/image/upload/v1455289384/WebAPIAndNoSQL20_grutj1.png)

![ASP.NET 5 Empty Template](http://res.cloudinary.com/julitogtu/image/upload/v1455289570/WebAPIAndNoSQL21_fgjq7v.png)

* Una vez creada la solución, lo primero es añadir la referencia a ASPNET MVC, para ello ir al arcchivo **project.json** y en dependencies
añadir la referencia al paquete `Microsoft.AspNet.Mvc`:

```javascript
"dependencies": {
    "Microsoft.AspNet.IISPlatformHandler": "1.0.0-rc1-final",
    "Microsoft.AspNet.Server.Kestrel": "1.0.0-rc1-final",
    "Microsoft.AspNet.Mvc": "6.0.0-rc1-final"
}
```

* Ahora es necesario registrar ASPNET MVC para su uso, esto se hace en la clase `Startup.cs`:

```javascript
public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc();
	}

	public void Configure(IApplicationBuilder app)
	{
		app.UseIISPlatformHandler();

		app.UseMvc();
	}

	public static void Main(string[] args) => WebApplication.Run<Startup>(args);
}
```

* El siguiente paso es añadir una carpeta con el nombre **Controllers** en la raiz del proyecto, y dentro de esta carpeta creamos una clase
`ValuesController` para crear un simple servicio y validar que todo va bien:

```javascript
[Route("api/[controller]")]
public class ValuesController : Controller
{
    [HttpGet]
    public string Get()
    {
        return "Hello ASPNET Core 1";
    }
}
```

* Al ejecutar, en la URL añadir `api/values`: 

![Test](http://res.cloudinary.com/julitogtu/image/upload/v1455291970/WebAPIAndNoSQL22_jyg1vw.png)

* Necesitamos ahora añadir una referencia al paquete Nuget para conectarnos a DocumentDB, así que nuevamente en el archivo
**project.json** en dependencies referenciamos `Microsoft.Azure.DocumentDB`:

```javascript
"dependencies": {
	"Microsoft.AspNet.IISPlatformHandler": "1.0.0-rc1-final",
	"Microsoft.AspNet.Server.Kestrel": "1.0.0-rc1-final",
	"Microsoft.AspNet.Mvc": "6.0.0-rc1-final",
	"Microsoft.Azure.DocumentDB": "1.5.2"
}
```

* Una vez agregada dicha referencia, vamos a encontrar un error con dicho paquete que podemos observar en las referencias del proyecto,
dicho error se da porque el paquete todavía no soporta el `DNXCore`:

![Error Nuget Package](http://res.cloudinary.com/julitogtu/image/upload/v1455295146/WebAPIAndNoSQL23_ptqitm.png)

* Para solucionar el error, vamos a eliminar del proyecto dicho target, esto lo hacemos en el archivo **project.json**, en la propiedad 
`frameworks` eliminado `dnxcore50`:

```javascript
"frameworks": {
	"dnx451": { }
}
```

* El siguiente paso, es crear una clase, que va a ser el modelo de la aplicación, para ello crear una carpeta **Models** y en dicha carpeta
agregar una nueva clase con el nombre `Movie.cs`

* En la clase `Movie` se definirán las propiedades que hemos insertado anteriormente,
cada una de las propiedades se van a decorar con el atributo `JSONProperty` para personaizar el nombre de la propiedad,
en resumen, la clase `Movie` debe quedar:

```javascript
public class Movie
{
	[JsonProperty(PropertyName = "id")]
	public override string Id { get; set; }

	[JsonProperty(PropertyName = "name")]
	public string Name { get; set; }

	[JsonProperty(PropertyName = "description")]
	public string Description { get; set; }

	[JsonProperty(PropertyName = "year")]
	public int Year { get; set; }

	[JsonProperty(PropertyName = "genre")]
	public string Genre { get; set; }
}
```

* Es momento de crear la clase que se va a conectar a **DocumentDB**, creamos un folder llamado `Data`
y en dicho folder agregamos una nueva clase con el nombre `MovieRepository`.

* Antes de seguir, necesitamos dos datos de la cuenta de **DocumentDB**, dichos datos son la **URI**
y la **Primary Key**, para obtener los datos, sobre la DocumentDB Account, seleccionamos la llave para obtener
todas las keys de la cuenta y en especial las dos que nosotros necesitamos:

![DocumentDB Account Key](http://res.cloudinary.com/julitogtu/image/upload/v1455306386/WebAPIAndNoSQL24_c4ody5.png)

* Ahora en la clase `MovieRepository` agregamos cuatro constantes: **URI** del servicio, **Primary Key** de
la cuenta y el nombre de la colección y de la base de datos a consultar:

```javascript
private const string EndpointUrl = "<URI>";
private const string AuthorizationKey = "<Primary Key>";
private const string CollectionId = "movies";
private const string DatabaseId = "azurecampdb";    
```

* Creamos una propiedad de solo lectura de tipo `DocumentClient`, DocumentClient es la clase que permite
ejecutar cualquier acción contra DocumentDB:

```javascript
private static DocumentClient client;

private static DocumentClient Client
{
	get
	{
		if (client == null)
			client = new DocumentClient(new Uri(EndpointUrl), AuthorizationKey);

		return client;
	}
}    
```

* El siguiente paso, es crear una propiedad de solo lectura de tipo `Database`, Database es la clase que 
representa una base de datos de DocumentDB, en este caso también se crea un método
auxiliar que tiene con función obtener la referencia a la base de datos `azurecampdb`, en caso que no
exista la crea:

```javascript
private static Database database;
private static Database Database
{
	get
	{
		if (database == null)
			database = GetOrCreateDatabase(DatabaseId);

		return database;
	}
}

public static Database GetOrCreateDatabase(string databaseId)
{
	var db = Client.CreateDatabaseQuery()
					.Where(d => d.Id == databaseId)
					.AsEnumerable()
					.FirstOrDefault();

	if (db == null)
		db = client.CreateDatabaseAsync(new Database { Id = databaseId }).Result;

	return db;
}    
```

* Nuevamente creamos otra propiedad de solo lectura, en este caso de tipo `DocumentCollection`, DocumentCollection
es la clase que representa una colección en una base de datos de DocumentDB, y al igual que en 
el paso anterior se tiene un método de apoyo para obtener la colección `movies` o crearla si no existe:

```javascript
private static DocumentCollection collection;
private static DocumentCollection Collection
{
	get
	{
		if (collection == null)
		{
			collection = GetOrCreateCollection(Database.SelfLink, CollectionId);
		}

		return collection;
	}
}

public static DocumentCollection GetOrCreateCollection(string databaseLink, string collectionId)
{
	var col = Client.CreateDocumentCollectionQuery(databaseLink)
					  .Where(c => c.Id == collectionId)
					  .AsEnumerable()
					  .FirstOrDefault();

	if (col == null)
	{
		col = client.CreateDocumentCollectionAsync(databaseLink,
			new DocumentCollection { Id = collectionId },
			new RequestOptions { OfferType = "S1" }).Result;
	}

	return col;
}   
```

* El siguiente paso, es crear un método llamado `GetAllMovies()` que como el nombre lo dice, será el encargado
de retornar todos los documentos (movies) que existen:

```javascript
public static IEnumerable<Movie> GetAllMovies()
{
	var movies = Client.CreateDocumentQuery<Movie>(Collection.SelfLink)
					   .AsEnumerable();
	return movies;
}
```

* La siguiente función a implementar es `GetMovieById` y va a permitir consultar un documento
por su id:

```javascript
public static Movie GetMovieById(string id)
{
	var movie = Client.CreateDocumentQuery<Movie>(Collection.SelfLink)
		.Where(d => d.Id == id)
		.AsEnumerable()
		.FirstOrDefault();

	return movie;
}
``` 

* Ahora, se va a crear el método `CreateMovie` el cual va a permitir crear un nuevo documento:

```javascript
public static async Task<Movie> CreateMovie(Movie entity)
{
	Document doc = await Client.CreateDocumentAsync(Collection.SelfLink, entity);
	Movie movie = (Movie)(dynamic)doc;

	return movie;
}
```

* Seguimos con el método que permite eliminar un documento, así que creamos el método
`DeleteMovieAsync` el cual va a recibir como parámetro el id del documento:

```javascript
public static async Task DeleteMovieAsync(string id)
{
    await Client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
}
```

## Tarea 4: Creando el controlador

En esta tarea se va a crear el controlador que va exponer las funciones para interactuar 
con la base de datos de DocumentDB utilizando el repositorio creado en la tarea anterior.

* En la carpeta **Controllers** creamos una nueva clase `MoviesController`, dicha clase debe heredar de `Controller`,
y se decora con el atributo `Route`, ya que usaremos routing por atributos: 

```javascript
[Route("api/[controller]")]
public class MoviesController : Controller
{

}
```

* El primer método a desarrollar, va a retornar el listado de todos los documentos existentes
en la colección, dicho método se va a llamar `GetAllMovies()`, su tipo de retorno es `IActionResult`:

```javascript
[HttpGet]
public IActionResult GetAllMovies()
{
    var movies = MovieRepository.GetAllMovies();
    if (movies == null)
        return HttpNotFound();

    return Ok(movies);
}
```

Para validar el método, podemos usar **Fiddler** y hacer un llamado Get a `http://localhost:port/api/movies`:

![Fiddler Test GetAllMovies](http://res.cloudinary.com/julitogtu/image/upload/v1455309699/WebAPIAndNoSQL25_kmnxhj.png) 

* El siguiente método es `GetMovieById` el cual recibe por parámetro el id del documento a consultar, en caso de
no encontrar el documento retorna un `HttpNotFound()` que corresponde al código HTTP 404, en caso
contrario un `Ok()` que corresponde al código HTTP 200:

```javascript
[HttpGet("{id}", Name = "GetMovie")]
public IActionResult GetMovieById(string id)
{
	var movie = MovieRepository.GetMovieById(id);
	if (movie == null)
		return HttpNotFound();

	return Ok(movie);
}
```

Nuevamente desde **Fiddler**, hacemos un llamado Get a `http://localhost:port/api/movies/1` para validar el método:

![Fiddler Test GetMovieById](http://res.cloudinary.com/julitogtu/image/upload/v1455309951/WebAPIAndNoSQL26_ov5gzt.png)

* Ahora vamos a crear el método `Create`, dicho método va a permitir crear un nuevo documento, como parámetro
va a recibir un objeto de tipo `Movie`, se debe decorar con el atributo `HttpPost`, en este caso 
se va a retornar un 'CreatedAtRoute' el cual corresponde al código HTTP 201 que está diseñado para indicar 
que el registro se creó correctamente, y por buena prática se retorna la URI en la cual es posible consultar
dicho registro:

```javascript
[HttpPost]
public async Task<IActionResult> Create([FromBody] Movie entity)
{
	var movie = await MovieRepository.CreateMovie(entity);
	return CreatedAtRoute("GetMovie", new { controller = "Movie", id = entity.Id }, entity);
}
```

Para validar el método, en **Fiddler** seleccionamos **POST**, en el header del request agregamos
`Content-Type: application/json`, y en el body del request definimos los datos en formato **JSON**:

```javascript
//Ice Age: Collision Course
{
  "id": "6",
  "name": "Ice Age: Collision Course",
  "year": "2016",
  "description": "Scrat’s epic pursuit of the elusive acorn catapults him into the universe where he accidentally sets off a series of cosmic events that transform and threaten the Ice Age World. To save themselves, Sid, Manny, Diego, and the rest of the herd must leave their home and embark on a quest full of comedy and adventure, traveling to exotic new lands and encountering a host of colorful new characters.",
  "genre": "Adventure"
}
```

![Fiddler Create Post](http://res.cloudinary.com/julitogtu/image/upload/v1455310833/WebAPIAndNoSQL27_hmm8zf.png)

![Fiddler Test Create](http://res.cloudinary.com/julitogtu/image/upload/v1455310861/WebAPIAndNoSQL28_ay8xxc.png)

* Ahora vamos a implementar la acción que permita realizar la eliminación del documento, en este caso, creamos una
nueva acción con el nombre `Delete`, dicha acción debe decorarse con el atributo `HttpDelete`
para que pueda responder para la acción HTTP de eliminar:

```javascript
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(string id)
{
	await MovieRepository.DeleteMovieAsync(id);
	return Ok();
}
```

Para validar el método, en **Fiddler** seleccionamos el verbo **DELETE**, y en la URL adicionamos
el id de la película que deseamos eliminar:

![Fiddler Test Delete](http://res.cloudinary.com/julitogtu/image/upload/v1455937036/labdelete_eurxya.png)

* El controlador `MoviesController` debe verse:

```javascript
[Route("api/[controller]")]
public class MoviesController : Controller
{

	[HttpGet]
	public IActionResult GetAllMovies()
	{
		var movies = MovieRepository.GetAllMovies();
		if (movies == null)
			return HttpNotFound();

		return Ok(movies);
	}

	[HttpGet("{id}", Name = "GetMovie")]
	public IActionResult GetMovieById(string id)
	{
		var movie = MovieRepository.GetMovieById(id);
		if (movie == null)
			return HttpNotFound();

		return Ok(movie);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] Movie entity)
	{
		var movie = await MovieRepository.CreateMovie(entity);
		return CreatedAtRoute("GetMovie", new { controller = "Movie", id = entity.Id }, entity);
	}
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await MovieRepository.DeleteMovieAsync(id);
        return Ok();
    }
}
 ```

A este punto, ya tenemos listo nuestro servicio, en la siguiente tarea vamos a publicarlo en **Microsoft Azure**.
 
## Tarea 5: Publicación del Servicio

En este tarea, vamos a crear la página index.html y así mismo se va a usar los componentes creados anteriormente.

* Ir al portal de [Azure](http://portal.azure.com) y loguearse.

* En el portal de Azure, en New > Web + Mobile > Web App:

![New Web App](http://res.cloudinary.com/julitogtu/image/upload/v1455311613/WebAPIAndNoSQL29_bsxvuf.png)

* En la parte del wizard en la derecha, ingresamos los datos del sitio Web:

![Settings Web App](http://res.cloudinary.com/julitogtu/image/upload/v1455312272/WebAPIAndNoSQL30_dsdygl.png)

* Una vez creada la Web App, seleccionarla, y en la parte superior seleccionar la opción 
**Get Publish Profile** para descargar el perfil de publicación, dicho perfil ya tiene toda la información necesaria 
para desplegar el proyecto a Azure:

![Get Publish Profile](http://res.cloudinary.com/julitogtu/image/upload/v1455312567/WebAPIAndNoSQL31_ob3teq.png)

* Y ya tenemos todo listo en **Azure**, volvemos al proyecto en Visual Studio, damos clic derecho y seleccionamos
la opción **Publish**:

![Visual Studio Publish Option](http://res.cloudinary.com/julitogtu/image/upload/v1455312761/WebAPIAndNoSQL32_stzdgr.png)

* En la siguiente ventana, seleccionamos la opción **Import** y en la caja de dialogo que se muestra
seleccionamos el perfil que acabamos de descargar:

![Import Publish Profile](http://res.cloudinary.com/julitogtu/image/upload/v1455313021/WebAPIAndNoSQL33_yymswm.png)

* En la siguiente ventana se carga la información del perfil de publicación, igualmente es posible validar la configuración
dando clic en **Validate Connection**, y finalmente seleccionamos **Publish** para iniciar con la publicación:

![Validate Configuration](http://res.cloudinary.com/julitogtu/image/upload/v1455313161/WebAPIAndNoSQL34_wdag3y.png)

* Una vez finalizada la publicación, en la ventana de **Output** es posible ver el resultado de la operación:

![Output](http://res.cloudinary.com/julitogtu/image/upload/v1455313533/WebAPIAndNoSQL35_n8jqmr.png)

* Finalmente, para validar los métodos, nuevamente hacemos uso de **Fiddler**, el único cambio que debemos hacer es modificar
el `localhost:port` por la url de nuestra Web App.

## Enhorabuena! Hemos construido un servicio HTTP que se conecta a una base de datos DocumentDB y lo hemos publicado en Azure!

#### HOL by [@julitogtu](https://twitter.com/julitogtu)