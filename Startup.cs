using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiBuro
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";//cors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger Config Jose Daniel de Jesus Perez
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("AppAdministration", new OpenApiInfo()
                {
                    Title = "Api ConsultaSic Produccion ",
                    Version = "V1"
                });


            });
            //Swagger Config

            //Conexion bd por appsetings
            services.AddDbContext<ApiBuro.Models.ApiSICContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Apprecia_Dev")));
            services.AddControllers();

            services.AddCors(options =>//funcion para cors
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); ;
                });
            });// termino de funcion para cors
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //SWAGGER
            app.UseStaticFiles();
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {  
                c.SwaggerEndpoint("AppAdministration/swagger.json", "Api ConsultaSic Produccion");
            });

            //SWAGGER

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);// cors

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
