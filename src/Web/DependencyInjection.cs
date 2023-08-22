using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddFluentValidationAutoValidation();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen( c =>
        {
            c.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Example = new OpenApiString("00:00:00")
            });

            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CinemaBooking API", Version = "v1" });
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "CinemaBooking.xml");
            c.IncludeXmlComments(filePath);
        });

        return services;
    }
}
