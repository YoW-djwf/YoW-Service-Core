using YoW.Service.Core.Api.Configurations.Configurations;
using YoW.Service.Core.Api.Configurations;

var builder = WebApplication.CreateBuilder(args)
  .ConfigureAppConfiguration(args)
  .UseSerilog()
  .UseServiceProviderFactory();

// Add services to the container.
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddRouting();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddSwaggerConfiguration("YoW");

var app = builder.AppInitialization().Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwaggerConfiguration("YoW");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
