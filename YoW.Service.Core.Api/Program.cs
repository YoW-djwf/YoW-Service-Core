using YoW.Service.Core.Api.Configurations;

var builder = WebApplication.CreateBuilder(args)
  .UseAppConfiguration(args)
  .UseSerilog()
  .UseServiceProviderFactory()
  .AddCorsConfiguration()
  .AddGzipCompression()
  .AddControllersConfiguration()
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  .AddSwaggerConfiguration("YoW")
  .AddDbContextConfiguration();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwaggerConfiguration("YoW");
}
else
{
  app.UseHsts();
}

app.UseCorsConfiguration();
app.UseGzipCompression();
app.UseHttpsRedirection();
app.UseHealthChecks("/health");
app.UseAuthorization();
app.UseControllersConfiguration();

app.AppInitialization().Run();
