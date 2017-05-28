// <copyright file="Startup.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using SupplierCatalogue.API.Configuration;
    using SupplierCatalogue.API.Datastore;
    using SupplierCatalogue.API.Services;
    using Swashbuckle.AspNetCore.Swagger;

    /// <summary>
    /// The application startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env)
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"settings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        /// <summary>
        /// Gets or sets the application configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// Confiugre Services
        /// </summary>
        /// <param name="services">The service collection for the application</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<Settings>(this.Configuration);
            var clientUrls = this.Configuration.GetSection("clientUrls")
                .AsEnumerable()
                .Select(x => x.Value)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder => builder
                    .WithOrigins(clientUrls)
                    .AllowAnyHeader()
                    .Build());
                options.DefaultPolicyName = "AllowSpecificOrigin";
            });
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters()
                .AddMvcOptions(options =>
                {
                    options.RespectBrowserAcceptHeader = true;
                });
            services.AddSingleton<IDatastore, MongoDatastore>();
            services.AddSingleton<IHealthCheckService, HealthCheckService>();
            services.AddSingleton<ISupplierService, SupplierService>();
            services.AddLogging();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v0.1.0", new Info
                {
                    Title = "Supplier Catlogue API",
                    Description = "The Hithched supplier catalogue API",
                    Version = "0.1.0",
                    Contact = new Contact
                    {
                        Name = "Simon Williams",
                        Email = "simon.williams@immediate.co.uk",
                    },
                });
                options.IncludeXmlComments(this.Configuration.GetValue<string>("documentationPath"));
            });
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app">The builder for the application</param>
        /// <param name="env">The hosting environment for the application</param>
        /// <param name="loggerFactory">The logger for the application</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </remarks>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v0.1.0/swagger.json", "Supplier Catalogue API");
            });
            app.Run(async (context) =>
            {
                await Task.Run(() => context.Response.Redirect("/swagger"));
            });
        }
    }
}
