## Uso de Migraciones

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

A continuacion crearemos el contructor de la clase para eso ponemos el cursor en medio de los corchetes de la clase, damos click derecho y nos dirijimos a la opcion **Refactor** seleccionarmos la opcion **Generar el constructor 'NombreContext(options)'** y le agragamos entre llaves diamantes el nombre de la clase de contexto y deberiamos tener algo asi: 
```
public NombreContext(DbContextOptions<NombreContext> options) : base(options)
{
}
```


