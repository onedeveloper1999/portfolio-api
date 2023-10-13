using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Portfolio.Api.Endpoints.Helpers;
using Portfolio.Application;
using Portfolio.Infrastructure;
using Portfolio.Infrastructure.Persistence;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Description = "Jwt Bearer Service",
        Name = "Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
       {
         new OpenApiSecurityScheme
         {
           Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
         },
         new string[] {}
       }
  });
});

builder.Services.AddApplication()
                .AddInfrastructure();

var app = builder.Build();

app.UseSwagger()
   .UseSwaggerUI(options =>
   {
       options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
       options.ShowExtensions();
       options.DisplayRequestDuration();
       options.DisplayOperationId();
       options.DocExpansion(DocExpansion.List);
       options.EnableFilter();
       options.EnableTryItOutByDefault();
       options.RoutePrefix = string.Empty;
   });

app.UseHttpsRedirection();

app.MapEndpoints();

app.UseExceptionHandler("/error");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PortfolioContext>();
    await db.Database.MigrateAsync();
}

app.Run();