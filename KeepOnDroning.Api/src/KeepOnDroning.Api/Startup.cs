using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Business;
using KeepOnDroning.Api.Data;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.SwaggerGen;

namespace KeepOnDroning.Api
{
    public class Startup
    {
        private readonly IApplicationEnvironment _appEnv;
        private readonly IHostingEnvironment _hostingEnv;

        public Startup(IHostingEnvironment hostingEnv, IApplicationEnvironment appEnv)
        {
            _hostingEnv = hostingEnv;
            _appEnv = appEnv;

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{hostingEnv.EnvironmentName}.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        //public Startup(IHostingEnvironment env)
        //{
        //    // Set up configuration sources.
        //    var builder = new ConfigurationBuilder()
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
        //        .AddEnvironmentVariables();

        //    Configuration = builder.Build();
        //}

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DroningDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
            
            // Add framework services.
            services.AddMvc();

            //var pathToDoc = Configuration["Swagger:Path"];
            services.AddSwaggerGen();

            services.ConfigureSwaggerDocument(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Droning API",
                    Description = "Things for droning",
                    TermsOfService = "None"
                });
                options.OperationFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlActionComments(GetXmlCommentPath()));
            });

            services.ConfigureSwaggerSchema(options =>
            {
                options.DescribeAllEnumsAsStrings = true;
                options.ModelFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlTypeComments(GetXmlCommentPath()));
            });

            //services.AddScoped<ISearchProvider, SearchProvider>();

            // Config
            services.AddTransient<DancerBusiness, DancerBusiness>();
            services.AddTransient<NoFlyingBusiness, NoFlyingBusiness>();
            services.AddTransient<EternityBusiness, EternityBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();


            app.UseStaticFiles();

            app.UseMvc();

            app.UseSwaggerGen();
            app.UseSwaggerUi();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);


        private string GetXmlCommentPath()
        {
            var applicationName = this._appEnv.ApplicationName;
            var applicationVersion = this._appEnv.ApplicationVersion;
            var basePath = GetSolutionBasePath();
            var configuration = this._appEnv.Configuration;
            var runtimeIdentifier = this._appEnv.RuntimeFramework.Identifier;
            var runtimeVersion = this._appEnv.RuntimeFramework.Version.ToString().Replace(".", string.Empty);

            if (this._hostingEnv.IsDevelopment())
            {
                return Configuration["Swagger:Path"];
            }

            // Azure file path
            return $@"{basePath}\packages\{applicationName}\{applicationVersion}\lib\{runtimeIdentifier}{runtimeVersion}\{applicationName}.xml";
        }

        private string GetSolutionBasePath()
        {
            var directory = Directory.CreateDirectory(this._appEnv.ApplicationBasePath);

            while (directory.Parent != null)
            {
                if (directory.GetFiles("global.json").Any())
                {
                    return directory.FullName;
                }

                directory = directory.Parent;
            }

            throw new InvalidOperationException("Failed to detect solution base path - global.json not found.");
        }
    }
}
