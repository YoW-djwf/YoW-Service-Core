using Microsoft.OpenApi.Models;
using YoW.Service.Core.Api.Configurations.Filters;

namespace YoW.Service.Core.Api.Configurations
{
  public static class SwaggerConfiguration
  {
    public static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder builder, string name)
    {
      builder.Services.AddEndpointsApiExplorer();

      builder.Services.AddSwaggerGen(action =>
      {
        action.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = $"{name} Api",
          Version = "v1"
        });

        action.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
          Type = SecuritySchemeType.OAuth2,
          Flows = new OpenApiOAuthFlows
          {
            AuthorizationCode = new OpenApiOAuthFlow
            {
              AuthorizationUrl = new Uri("https://localhost:44345/connect/authorize"),
              TokenUrl = new Uri("https://localhost:44345/connect/token"),
              Scopes = new Dictionary<string, string>
                      {
                              {"api1", $"{name} API - full access"}
                      }
            }
          }
        });
        action.OperationFilter<AuthorizeCheckOperationFilter>();
      });

      return builder;
    }

    public static WebApplication UseSwaggerConfiguration(this WebApplication app, string name)
    {
      app.UseSwagger();
      app.UseSwaggerUI(action =>
      {
        action.SwaggerEndpoint("v1/swagger.json", $"{name} Api v1");

        action.OAuthClientId("api_swagger");
        action.OAuthAppName($"{name} API - Swagger");
        action.OAuthUsePkce();
      });

      return app;
    }
  }
}