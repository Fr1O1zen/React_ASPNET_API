using Chempions.BindingModel;
using Chempions.Data.Sql;
using Chempions.Data.Sql.Migrations;
using Chempions.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Chempions;

public class Startup
{
    
    public IConfiguration Configuration { get; }
        
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        
        //rejestracja DbContextu, użycie providera MySQL i pobranie danych o bazie z appsettings.json
        services.AddDbContext<ChempionsDbContext>(options => options
            .UseMySQL(Configuration.GetConnectionString("ChempionsDbContext")));
        services.AddTransient<DatabaseSeed>();
        services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .AddFluentValidation();
        services.AddTransient<IValidator<EditProduct>, EditProductValidator>();
        
        //Zezwala na request z Reacta na porcie 3000
        services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }));

        services.AddSignalR();

    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<ChempionsDbContext>();
            var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            databaseSeed.Seed();
        }

        app.UseCors("MyPolicy");
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<NotificationHub>("/notificationHub");
            endpoints.MapControllers();
        });

    }

    
}