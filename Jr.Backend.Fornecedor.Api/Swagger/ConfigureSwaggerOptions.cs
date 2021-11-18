﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;

namespace Jr.Backend.Fornecedor.Api.Swagger
{
    /// <inheritdoc/>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        /// <inheritdoc/>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc/>
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }

            options.OperationFilter<SwaggerVersioningOperationFilter>();
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ApiVersioning.xml"));
        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Jr.Backend.Fornecedor",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
                info.Description += "[deprecated]";

            return info;
        }
    }
}