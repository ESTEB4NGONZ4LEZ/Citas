## MIGRACIONES

Crearemos una carpeta en donde almacenaremos nuestro proyecto
```
mkdir nombre_proyecto
```

Llevaremos la suiguiente estructura:

- API : Esta carpeta guardará el proyecto donde crearemos las diferentes Apis o Endpoints para ser consumidos por las aplicaciones externas.
- Infrastructure : Esta carpeta va a contener todo lo relacionado con el acceso de datos, los repositorios y las unidades de trabajo.
- Core : Esta carpeta contendrá todas las clases entidades e interfaces del projecto.

---

Creamos nuestro archivo de solucion, para esto ejecutaremos el siguiente comando dentro de nuestra carpeta principal:
```
dotnet new sln
```

Vamos a crear nuestro archivo webapi ejecutando el siguiente comando: 
```
dotnet new webapi -o API
```

Siguiendo nuestra estructura crearemos los proyectos de Libreria que son **Core** e **Infrastructure**:
```
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure
```

El siguiente paso va a ser agregar cada uno de nuestros proyectos a la solucion:
```
dotnet sln add .\API\
dotnet sln add .\Core\
dotnet sln add .\Infrastructure\
```

Para ver los proyectos que se encutran asociados a la solucion podemos ejecutar el siguiente comando: 
```
dotnet sln list
```

Ahora estableceremos referencia entre los proyectos:
- Infrastrcuture -> Core
- API -> Infrastructure

Nos ubicamos en la carpeta que se va a relacionar:
- Nos ubicamos en la carpeta Infrastructure y ejecutamos el siguiente comando: 
```
dotnet add reference ..\Core\
```
- Ahora desde la carpeta API:
```
dotnet add reference ..\Infrastructure\
```

---

El siguiente paso sera agregar los paquetes necesarios, para esto podemos usar **NuGet Gallery** que es una extension de VSC o instalarlos directamentes desde la terminal.


Iremos a [NuGet Gallery](https://www.nuget.org/) y buscaremos los siguientes paquetes: 
- Microsoft.EntityFrameworkCore ( Lo instalaremos en API e Infrastructure ).
- Microsoft.EntityFrameworkCore.Design ( Lo instalaremos en API ).
- Pomelo.EntityFrameworkCore.MySql ( Lo instalaremos en Infrastructure ).

Buscaremos las versiones LTS de cada unos de los paquetes, copiamos el comando y lo ejecutaremos en el proyecto respectivo.

---

Lo siguiente que haremos va a ser crear nuestra clase de contexto la cual se usara para la conexion a la base de datos, en **Infrastructure** crearemos una carpeta llamada **Data** y ahi crearemos nuestra clase de contexto, dicha clase debe ser creada con el nombre del proyecto seguido de **context** en CamelCase. 

La clase de contexto heredara de DbContext que perteneque a Entity Framerwork e importamos nuestros paquetes:
```
public class NombreContext : DbContext
```

A continuacion crearemos el contructor de la clase para eso ponemos el cursor en medio de los corchetes de la clase, damos click derecho y nos dirijimos a la opcion **Refactor** seleccionarmos la opcion **Generar el constructor 'NombreContext(options)'** y le agregamos entre llaves diamantes el nombre de la clase de contexto y deberiamos tener algo asi: 
```
public NombreContext(DbContextOptions<NombreContext> options) : base(options)
{
}
```

Luego haremos el metodo para la carga de forma automatica las configuraciones:
```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
```

--- 

Ahora crearemos nuestra Connection String para poder establecer conexion con la base de datos, nos dirigimos a API y buscaremos **appsettings.Development.json** y pegaremos el siguiente codigo:
```
"ConnectionStrings": {
"DefaultConnection" : "host=localhost;user=root;password='';database=nombrebd"
}
```

---

Configuraremos el contenedor de inyeccion de dependencias, para esto iremos a la carpeta **API**, **Program.cs** y pergaremos este codigo y cambiamos el nombre de la clase de contexto ( 5 ):
```
builder.Services.AddDbContext<NombreContext>(optionsBuilder =>
{
string ? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
```

---

El siguiente paso sera crear nuestras Entidades, para eso iremos a **Core** y crearemos una carpeta **Entities** en donde almacenaremos todas nuestras entidades, luego vamos a nuestro archivo de contexto y creamos el DbSet para cada una de nuestras entidades: 
```
public DbSet<NombreClase> ? NombreClases { get; set; }
```

Ahora en **Infrastructure**, **Data**, crearemos una carpeta llamada **Configuration** en donde crearemos las configuraciones de las tablas usando FluentApi. Crearemos las clases con el **nombre de la entidad** seguido de la palabra **Configuration**. La clase heredara de **IEntityTypeConfiguration<NombreEntidad>** y usamos el QuickFix para hacer las importaciones e implementar la interfaz y creamos nuestra configuracion.

--- 

El siguiente paso va a se descargar la herramienta de migraciones, para eso ejecutamos el siguiente comando: 
```
dotnet tool install --global dotnet-ef
```

Para verificar que se ha instalado correctamente podemos ejecutar: 
```
dotnet tool list –g
```

Despues de hacer la instalacion podemos ejecutar el siguiente comando para hacer la migracion: 
```
dotnet ef migrations add InitialCreate --project ./Infrastructure/ --startup-project ./API/ --output-dir ./Data/Migrations
```

Luego ejecutamos `dotnet build` para verificar los errores y warnings.

Para crear la base de datos con nustra configuracion ejecutaremos el siguiente comando: 
```
dotnet ef database update --project ./Infrastructure/ --startup-project ./API/
```

---

## CONTROLADORES 

El primer sera crear una clase llamada **BaseApiController** dentro de **API\Controllers**, esta clase heredara de **ControllerBase**  y pegamos el siguiente codigo arriba de la clase: 

```
[ApiController]
[Route("/api[controller]")]
```

Esto nos va a servir para identificar el enrutamiento hacia nuestros endpoints.

Nos dirigimos a **API\Properties** y en el archivo **launchSettings.json** modificaremos lo siguiente:
- launchBrouwser : false.
- Unificamos los puertos para todos los servidores, profile al 5000, en https primero 5001 y segundo 5000.

Con la URL podemos acceder al swagger, swagger es una pagina en donde podremos ver la documentacion de toda nuestra API.

# Creacion de Controladores

Para crear un controlador el primer paso es crear un ApiController, el nombre del archivo sera **nombre_clase + Controller**, esta clase heredara de la BaseApiController que ha sido creada previamente.

Crearemos los Snippets para el contructor de nuestros controladores, para buscar por id y en general.

```
"Constructor with DbContext" : {
    "prefix": "ctorctx",
    "body": [
        "private readonly DbContext _context;",
        "",
        "public TipoDocumentoController(DbContext context){",
        "    _context = context;", 
        "}"
    ],
    "description": "Constructor with DbContext"
}
```

```
"HttpGet Action with ProducesResponseType" : {
    "prefix": "getaction",
    "body": [
        "[HttpGet]",
        "[ProducesResponseType(StatusCodes.Status200OK)]",
        "[ProducesResponseType(StatusCodes.Status400BadRequest)]",
        "public async Task<ActionResult<IEnumerable<${1:nameDbSet}>>> Get(){",
        "    var ${2:nameVar} = await _context.$1.ToListAsync();",
        "    return Ok($2);",
        "}"
    ],
    "description": "HttpGet Action with ProducesResponseType"
}
```

```
"HttpGet Action with Route and ProducesResponseType" : {
    "prefix": "getactionId",
    "body": [
        "[HttpGet(\"{id}\")]",
        "[ProducesResponseType(StatusCodes.Status200OK)]",
        "[ProducesResponseType(StatusCodes.Status400BadRequest)]",
        "public async Task<ActionResult> Get(int id){",
        "    var ${2:nameVar} = await _context.${3:nameDbSet}.FindAsync(id);",
        "    return Ok($2);",
        "}"
    ],
    "description": "HttpGet action with Route and ProducesResponseType"
}
```

Para comprobar que todo ha salido bien nos dirigimos a **API**, ejecutamos **dotnet run** y por ultimos nos dirigimos al localhost con el puerto que hemos configurado /swagger y hacemos las debidas pruebas.

---

## CORS

CORS es una política de seguridad implementada en los navegadores web que restringe las solicitudes HTTP que se pueden realizar desde un dominio hacia otro, los metodos de Cors se definen como estaticos en una clase estatica.

El primer paso sera crear una carpeta llamada **Extensions** dentro de **API** y dentro de ella crearemos una carpeta llacama **ApplicationServiceExtension**.

```
public static void ConfigureCors(this IServiceCollection services) => 
    services.AddCors(options => {
        options.AddPolicy("CorsPolicy", builder => 
            builder.AllowAnyOrigin()     // withOrigins("https://dominio.com") (definimos un dominio para recibir peticiones)
                   .AllowAnyMethod()     // withMethods("GET", "POST") (definimos los metodos que podemos recibir)
                   .AllowAnyHeader());   // withHeaders("accept", "content-type") ( definimos los headers )
    });
```

Es importante recordar que las **CORS** se definen como estaticas por esa razon tanto la clase como los metodos deben ser estaticos.

Luego nos vamos a nuestro **Program.cs** y agregamos nuestro servicio de Cors:

```
builder.Services.ConfigureCors();
```

Y despues de agregar nuestro servicio debemos usarlo, nos vamos al final del todo y ponemos el siguiente codigo:

```
app.UserCors("nombreCors");
```
---






