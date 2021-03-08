
namespace Tidwit.Libraries.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Text.Json.Serialization;
    using Tidwit.Libraries.Api.Config.Mappers;


    using Middlewares;
    using Constants;
    using Config.Extensions;
    using AutoMapper;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                  builder =>
                        builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .SetIsOriginAllowed((host) => true)
                       .AllowCredentials());
            });
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingProfileConfiguration));
            services.AddServicesInAssembly(Configuration);
            services.AddControllers();
            services.AddControllersWithViews()
               .AddJsonOptions(options =>
               options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(SwaggerConstants.Endpoint, SwaggerConstants.Name);
                options.DocumentTitle = SwaggerConstants.Title;
            });


            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorWrappingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
