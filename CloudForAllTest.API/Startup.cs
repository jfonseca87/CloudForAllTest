using AutoMapper;
using CloudForAllTest.API.Utilities;
using CloudForAllTest.Domain.Models;
using CloudForAllTest.Repository.Interfaces;
using CloudForAllTest.Repository.MongoImplementations;
using CloudForAllTest.Service.Implementations;
using CloudForAllTest.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CloudForAllTest.API
{
    public class Startup
    {
        private readonly IConfiguration conf;
        private const string corsPolicy = "CloudCommercePolicy";

        public Startup(IConfiguration _conf)
        {
            conf = _conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(cors =>
                cors.AddPolicy(corsPolicy, 
                conf => {
                    conf.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                        // WithOrigins("http://localhost:4200");
                })
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Cloud For All test v1", Version = "v1" });
            });

            Global.MongoConn = conf["MongoConnection:MongoUrl"];
            Global.MongoDatabase = conf["MongoConnection:Database"];

            // Repository DI Container
            services.AddTransient<IFacturaRepository, FacturaRepository>();
            services.AddTransient<IPreventaRepository, PreventaRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Service DI Container
            services.AddTransient<IFacturaService, FacturaService>();
            services.AddTransient<IPreventaService, PreventaService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAutoMapper(typeof(Startup));

            // Seed First Data if not exists any data yet
            SeedData seedData = new SeedData(services);
            seedData.SeedFirstData();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(corsPolicy);

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Cloud For All Test v1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
