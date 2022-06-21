using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Kendo.Mvc.Examples.Extensions;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Console;

namespace Kendo.Mvc.Examples
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            WebRootPath = env.WebRootPath;
        }

        public IConfiguration Configuration { get; }

        public static string WebRootPath { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.Configure<IISServerOptions>(options =>
			{
				options.AllowSynchronousIO = true;
			});
			services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            // // Add Entity Framework services to the services container.
            services.AddDbContext<SampleEntitiesDataContext>();
            services.AddDbContext<CustomerEntitiesDataContext>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => {
                    builder.WithOrigins("https://netcorerepl.telerik.com");
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            // Add MVC services to the services container.
            services
                .AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services
                .AddDistributedMemoryCache()
                .AddSession(opts => {
                    opts.Cookie.IsEssential = true;
                });

            // Add Kendo UI services to the services container
            services.AddKendo();

            // Add Demo database services to the services container
            services.AddKendoDemo();
            services.AddSingleton<ReportingConfigurationService>();

            services.AddRouting(op => op.LowercaseUrls = true);
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
           	    app.UseHsts();
            }
			app.UseHttpsRedirection();
            // Add static files to the request pipeline.
            app.UseStaticFiles();

            app.UseSession();
			app.UseCookiePolicy();
            app.UseCors();
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.AddHyphenatedRoute();

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        public class ReportingConfigurationService
        {
            public IConfiguration Configuration { get; private set; }

            public IWebHostEnvironment Environment { get; private set; }

            public ReportingConfigurationService(IWebHostEnvironment environment)
            {
                this.Environment = environment;

                var configFileName = System.IO.Path.Combine(environment.ContentRootPath, "appsettings.json");
                var config = new ConfigurationBuilder()
                                .AddJsonFile(configFileName, true)
                                .Build();

                this.Configuration = config;
            }
        }
    }
}