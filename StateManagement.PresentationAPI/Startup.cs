using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StateManagement.Business.Interface;
using StateManagement.Business.Service;
using StateManagement.Data.ORM.EF;
using StateManagement.Data.Repository;

namespace StateManagement.PresentationAPI
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
            #region DI
            services.AddDbContext<StateManagementDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("SMDB")));

            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IFlowRepository, FlowRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IStateService, StateService>();
            services.AddTransient<IFlowService, FlowService>();
            services.AddTransient<ITaskService, TaskService>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "State Management Service", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddMvcCore().AddApiExplorer();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StateManagementDBContext stateManagementDBContext)
        {
            //stateManagementDBContext.Database.Migrate();
            stateManagementDBContext.Database.EnsureCreated();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "State Management Service v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
