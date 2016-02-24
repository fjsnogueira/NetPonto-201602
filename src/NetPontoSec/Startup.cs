namespace NetPontoSec
{
    using Microsoft.AspNet.Authorization;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using NetPontoSec.Authorization;
    using NetPontoSec.Repository;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostInMemoryRepository>();
            services.AddTransient<INetPontoUserRepository, NetPontoUserInMemoryRepository>();

            services.AddAuthorization(
                config =>
                    {
                        config.AddPolicy("NoPhpees", builder => builder.AddRequirements(new NoPhpeesRequirement()));
                        config.AddPolicy("AuthorsOnly", builder => builder.AddRequirements(new OperationRequirement()));
                    });

            services.AddTransient<IAuthorizationHandler, NoPehpeesHandler>();
            services.AddTransient<IAuthorizationHandler, NetPontoOperationHandler>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            { 
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();
   
            app.UseCookieAuthentication(
                config =>
                    {
                        config.AuthenticationScheme = "bolachinhas";
                        config.CookieName = "maria";
                        config.LoginPath = new PathString("/account/login");
                        config.AccessDeniedPath = new PathString("/account/forbidden");
                        config.AutomaticAuthenticate = true;
                        config.AutomaticChallenge = true;

                    });
             
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
