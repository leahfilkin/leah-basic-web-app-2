using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BasicWebApp.Classes
{
    public class CustomHeaderSwaggerAttribute : IOperationFilter
    {
     
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
 
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-apiKey",
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string" 
                }
            });
        }
    }
}