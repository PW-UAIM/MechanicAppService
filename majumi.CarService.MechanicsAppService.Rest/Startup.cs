using Microsoft.OpenApi.Models;

namespace majumi.CarService.MechanicsAppService.Rest;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "majumi.CarService.MechanicsDataService", Version = "v1" }); });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "majumi.CarService.MechanicsDataService v1"));
        }
        /* AT
        app.UseHttpsRedirection( );
        */
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
