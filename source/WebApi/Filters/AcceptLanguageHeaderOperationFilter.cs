using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Project.WebApi.Filters;
public class AcceptLanguageHeaderOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
        {
            operation.Parameters = [];
        }

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Required = false,
            Description = "Specify the language for the response. Available options: en-US, pt-BR, es-ES.",
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
}

