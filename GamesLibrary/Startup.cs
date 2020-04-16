
using Games.Library.Application.Interfaces;
using Games.Library.Application.Mappers;
using Games.Library.Application.Services;
using Games.Library.Domain.Configurations;
using Games.Library.Domain.DataContracts;
using Games.Library.Domain.Model;
using Games.Library.Infra.SQL.Factory;
using Games.Library.Infra.SQL.Intefaces;
using Games.Library.Infra.SQL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Configuration;

namespace GamesLibrary
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
            services.AddControllers();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<GameDTOToGame>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();

            var dbConfiguration = new DBConfiguration();
            dbConfiguration.ConnectionString = Configuration.GetConnectionString("connectionString");

            services.AddSingleton<DBConfiguration>(dbConfiguration);

            //DBConfiguration.ConnectionString = 

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GamesLibraryy", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamesLibraryy");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
