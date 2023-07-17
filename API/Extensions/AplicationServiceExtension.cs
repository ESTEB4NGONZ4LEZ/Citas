

namespace API.Extensions;

public static class AplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) => 
    services.AddCors(options => {
        options.AddPolicy("CorsPolicy", builder => 
            builder.AllowAnyOrigin()     // withOrigins("https://dominio.com") (definimos un dominio para recibir peticiones)
                   .AllowAnyMethod()     // withMethods("GET", "POST") (definimos los metodos que podemos recibir)
                   .AllowAnyHeader());   // withHeaders("accept", "content-type") ( definimos los headers )
    });
}
