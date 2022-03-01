using DustCompact.Bussiones.Repositories;
using DustCompact.Data;
using Microsoft.OpenApi.Models;

namespace DustCompactA
{
    public class Startup
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gett de la gestion de la conexion de la base de datos
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// heredando un isercollection para services
        /// cadena de coneccion para la inyeccion de dependencias
        /// </summary>
        /// <param name="services"> coleccion de servicios</param>
        /// /// <param name="postgresSQLConnectionConfiguration"> Engloba la cadena de conexxion</param>
        /// /// <param name="AddScoped"> Inyeccion de dependencias</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var postgresSQLConnectionConfiguration = new PostgreSQLConfiguration(Configuration.GetConnectionString("PostgreSQLConnection"));
            services.AddSingleton(postgresSQLConnectionConfiguration);
            services.AddScoped<IBasuraRepositoy, BasuraRespository>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DustCompactA", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
          //  app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
