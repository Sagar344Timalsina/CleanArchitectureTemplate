using Microsoft.OpenApi.Models;

namespace WebApi.Extentions
{
    public static class SwaggerExtensions
    {
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    Description = "REST API",
                });
                //options.DocInclusionPredicate((version, apiDescription) =>
                //{
                //    var versions = apiDescription.ActionDescriptor.EndpointMetadata
                //        .OfType<ApiVersionAttribute>()
                //        .SelectMany(attribute => attribute.Versions)
                //        .ToList();

                //    return versions.Contains(new ApiVersion(1, 0)) || versions.Contains(new ApiVersion(2, 0)); // Adjust versions as needed
                //});

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()

                    }
                });

                //options.IncludeXmlComments(XmlCommentsFilePath);
            });

            return services;
        }

    }
}
