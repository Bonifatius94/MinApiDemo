using Microsoft.OpenApi.Models;
using System.Reflection;

namespace RestaurantTableReservation.Api.Middleware;

internal static class SwaggerSetup
{
    public static WebApplicationBuilder AddSwaggerGeneration(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "My Title",
                    Version = "1.0",
                    Description = "My Description"
                }
            );

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        });
        return builder;
    }

    public static WebApplication AddSwaggerUI(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Table Reservation Service");
            c.RoutePrefix = "";
        });
        return app;
    }
}
