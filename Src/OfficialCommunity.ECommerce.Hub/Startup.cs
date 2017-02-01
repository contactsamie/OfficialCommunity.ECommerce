using System;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using OfficialCommunity.ECommerce.Hub.Serilog;
using OfficialCommunity.Necropolis.Web;
using Serilog;
using Serilog.Enrichers.HttpContextData;
using Serilog.Events;
using Serilog.Sinks.Email;

[assembly: UserSecretsId("aspnet-OfficialCommunity.ECommerce.Hub-97f1e665-918e-48d9-8447-4378613347fd")]

namespace OfficialCommunity.ECommerce.Hub
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                ;

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();

                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            builder.AddEnvironmentVariables();

            Application.Startup(builder);

            Configuration = builder.Build();

            var emailConnectionInfo = new EmailConnectionInfo
            {
                EmailSubject = Configuration["SerilogSinkEmail:EmailSubject"],
                FromEmail = Configuration["SerilogSinkEmail:FromEmail"],
                MailServer = Configuration["SerilogSinkEmail:MailServer"],
                NetworkCredentials = new NetworkCredential(Configuration["SerilogSinkEmail:Username"], Configuration["SerilogSinkEmail:Password"]),
                Port = int.Parse(Configuration["SerilogSinkEmail:Port"]),
                ToEmail = Configuration["SerilogSinkEmail:ToEmail"]
            };

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .Enrich.WithHttpContextData()
                .Enrich.With<ExceptionEnricher>()
                //.WriteTo.Email(emailConnectionInfo, restrictedToMinimumLevel: LogEventLevel.Error)
                .WriteTo.ApplicationInsights(Configuration["ApplicationInsights:InstrumentationKey"]
                                        , SerilogHelpers.ConvertLogEventsToCustomTraceTelemetry
                                        , restrictedToMinimumLevel: LogEventLevel.Information)
                //.WriteTo.AzureDocumentDB(Configuration["DocumentDB:Uri"]
                //                            , Configuration["DocumentDB:SecureKey"]
                //                            )
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddLogging();
            services.AddOptions();

            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddKendo();

            services.AddAuthentication(
                sharedOptions => sharedOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));

            Application.ConfigureServices(Configuration, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
            , IHostingEnvironment env
            , ILoggerFactory loggerFactory
            , IServiceProvider provider
            )
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseCookieAuthentication();

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                ClientId = Configuration["Authentication:AzureAd:ClientId"],
                Authority = Configuration["Authentication:AzureAd:AADInstance"] + Configuration["Authentication:AzureAd:TenantId"],
                CallbackPath = Configuration["Authentication:AzureAd:CallbackPath"]
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseKendo(env);

            Application.Configure(Configuration, provider, loggerFactory);
        }
    }
}
