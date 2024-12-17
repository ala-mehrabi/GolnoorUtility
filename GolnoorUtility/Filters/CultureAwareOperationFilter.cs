using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Filters
{
    public class CultureAwareOperationFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }
            operation.Parameters.Add(new OpenApiParameter()
            {
                Schema = new OpenApiSchema()
                {
                    Default = new OpenApiString("fa-IR"),
                    Enum = new List<IOpenApiAny>()
                     {
                        new OpenApiString("fa-IR"),
                        new OpenApiString("en-US"),
                     },
                },
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Required = true,

            });

        }
    }
}
