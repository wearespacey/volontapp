using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using VolontApp.API.Infrastructure;
using VolontApp.DAL;
using VolontApp.DAL.Repositories;

namespace VolontApp.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();

            services.Configure<RavenSettings>(Configuration.GetSection("Raven"));
            services.AddSingleton<IDocumentStoreHolder, DocumentStoreHolder>();
            services.AddScoped<CoordinatorRepository>();
            services.AddScoped<DisplayRepository>();
            services.AddScoped<ChildRepository>();
            services.AddScoped<VolunteerRepository>();
            services.AddScoped<CaseRepository>();

            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    options.OperationFilter<SwaggerDefaultValues>();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "api/v{version:apiVersion}/{controller=Child}/{action=GetAll}/{id?}");
            });

            #region CORS config
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
            #endregion

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                    c.DefaultModelExpandDepth(2);
                    c.DefaultModelRendering(ModelRendering.Example);
                    //c.DefaultModelsExpandDepth(-1);
                    c.EnableDeepLinking();
                    c.RoutePrefix = "swagger";
                    c.DocumentTitle = "Glue API - Docs | ChildFocus";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Glue API - v1");
                    c.DocExpansion(DocExpansion.List);
                    //c.DisplayOperationId();
                });
            #endregion
        }
    }
}
