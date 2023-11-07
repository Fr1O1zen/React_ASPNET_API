using Chempions;

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          
            webBuilder.UseStartup<Startup>();
        });
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000");
    });

});

var app = builder.Build();
app.UseCors("CORSPolicy");
CreateHostBuilder(args).Build().Run();

