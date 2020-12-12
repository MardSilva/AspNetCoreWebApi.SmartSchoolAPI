using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI
{
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
            //contexto para gerenciar o ND
            services.AddDbContext<SmartSchoolContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default")));
            
            services.AddScoped<IRepository, Repository>();
            
            //versionamento da API
            services.AddVersionedApiExplorer( options => 
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;

            })
            .AddApiVersioning(optionsversion =>
            {
                //se não definir a versão, sempre será uma versão padrão como v1 (1.0).
                optionsversion.DefaultApiVersion = new ApiVersion(1, 0);
                optionsversion.AssumeDefaultVersionWhenUnspecified = true;
                optionsversion.ReportApiVersions = true;
            });

            //foreach para determinar todas as versões da API
            var apiProviderDescricao = services.BuildServiceProvider()
                                    .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(
                optSwagger => {

                    foreach(var itemdescricao in apiProviderDescricao.ApiVersionDescriptions)
                    {
                        optSwagger.SwaggerDoc(
                        itemdescricao.GroupName,
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "SmartSchool API",
                            Version = itemdescricao.ApiVersion.ToString(),
                            Description = "Swagger que contém a descrição completa da WebAPI do SmartSchool.",
                            License = new Microsoft.OpenApi.Models.OpenApiLicense
                            {
                                Name = "Licença do SmartSchool API",
                                Url = new Uri("https://opensource.org/licenses/MIT")
                            },
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact
                            {
                                Name = "Eymard Silva",
                                Email = "eym_silva@outlook.com",
                                Url = new Uri("https://github.com/MardSilva")
                            }
                        }
                    );

                    }

                    var xmlSwaggerComentario = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlSwaggerCaminho = Path.Combine(AppContext.BaseDirectory, xmlSwaggerComentario);

                    optSwagger.IncludeXmlComments(xmlSwaggerCaminho);
                });

            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling  = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            //Assemblies para o AutoMapper - ele procura nos assemblies (dlls) quem tem herança de profile
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI(options =>
               {
                   foreach(var itemdescricao in apiVersionDescriptionProvider.ApiVersionDescriptions)
                   {
                       options.SwaggerEndpoint($"swagger/{itemdescricao.GroupName}/swagger.json", itemdescricao.GroupName.ToUpperInvariant());
                   }
                   
                   options.RoutePrefix = "";
                   
               });

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
