using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            {      // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("AppAdministrationApi", new OpenApiInfo()
                {
                    Title = "Api ConsultaSIC Producción ",
                    Version = "V1",
                    Description="La Documentacion de esta Api permite comprender la forma correcta de realizar la peticion para consulta a Buro de Credito y probar los metodos disponibles para consumo",
                   
                    Contact= new OpenApiContact
                    { 
                        Name="Jose Daniel De Jesus Perez" ,
                        Email="jose.dejesus@fomepade.com.mx"
                    
                    }
                    
                  

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
                c.SwaggerEndpoint("AppAdministrationApi/swagger.json", "Api ConsultaSIC Producción");
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
