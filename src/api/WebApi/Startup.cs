using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Filters;

namespace WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddApplication();
      services.AddInfrastructure(Configuration);
      services.AddCors();
      services.AddControllersWithViews(options =>
            options.Filters.Add(new ApiExceptionFilterAttribute()))
         .AddFluentValidation();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors(builder =>
      {
        builder.AllowAnyHeader()
          .AllowAnyMethod()
          .WithOrigins("http://localhost:3000")
          .AllowCredentials();
      });
      
      app.UseRouting();
      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}