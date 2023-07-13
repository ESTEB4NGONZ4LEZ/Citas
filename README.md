## Uso de Migraciones

Crearemos una carpeta en donde almacenaremos nuestro proyecto
```
mkdir **nombre_proyecto**
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
dotnet new webapi -o **API**
```

Siguiendo nuestra estructura crearemos los proyectos de Libreria que son Core e Infrastructure:
```
dotnet new classlib -o **Core**
dotnet new classlib -o **Infrastructure**
```

El siguiente paso va a ser agregar cada uno de nuestros proyectos a la solucion:
```
- dotnet sln add nombre_proyecto
    - dotnet sln add **.\API\**
    - dotnet sln add **.\Core\**
    - dotnet sln add **.\Infrastructure\**
```

Para ver los proyectos que se encutran asociados a la solucion podemos ejecutar el siguiente comando: 
```
dotnet sln list
```

Ahora estableceremos referencia entre los proyectos
- Infrastrcuture -> Core
- API -> Infrastructure

Nos ubicamos en la carpeta que se va a relacionar:
- Nos ubicamos en la carpeta Infrastructure y ejecutamos el siguiente comando: 
```
dotnet add reference **..\Core\**
```
- Ahora desde la carpeta API:
```
dotnet add reference **..\Infrastructure\
```



