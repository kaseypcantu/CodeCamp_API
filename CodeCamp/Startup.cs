using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeCamp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodeCamp {
    public class Startup {
        // private string _saAccessKey = null;
        // private string _connection = null;

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // TODO: figure out the ASP.NET Secrets usage
            // _saAccessKey = Configuration["CodeCampDataBase:SA_PASSWORD"];
            //
            // var builder = new SqlConnectionStringBuilder (
            //     Configuration.GetConnectionString ("CodeCamp"));
            // builder.Password = _saAccessKey;
            // _connection = builder.ConnectionString;
            
            // Commented this out for now, seems to still connect to my DB without this code.
            // services.AddDbContextPool<CampContext> (options => {
            //     options.UseSqlServer (_connection);
            // });

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers ();

            services.AddDbContext<CampContext> ();

            services.AddScoped<ICampRepository, CampRepository> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            var builder = new ConfigurationBuilder ()
                .SetBasePath (env.ContentRootPath)
                .AddJsonFile ("appsettings.json",
                    optional : false,
                    reloadOnChange : true)
                .AddEnvironmentVariables ();

            if (env.IsDevelopment ()) {
                builder.AddUserSecrets<Startup> ();

                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}