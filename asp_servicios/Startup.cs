using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using lib_repositorios;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup //Este resuelve la inyeccion de dependencias del lado del servidor
    {
        private readonly string _MyCors = ""; //Para identificar las politicas del CORS

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Inyecciones que requiero hacer: Repositorio necesita Conexion (la inyecto), aplicacion necesita Repositorio (la inyecto), el controlador
            //necesita aplicacion y token (los inyecto)

            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();

            // Aplicaciones
            services.AddScoped<IProductoAplicacion, ProductoAplicacion>();
            // Controladores
            //services.AddScoped<TokenController, TokenController>();

            //CONFIGURAR EL CORS: Se especifica que servidores van a poder acceder a nuestro programa del lado del Backend (En este caso, todos)

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: _MyCors, builder =>
            //    {
            //        //builder.WithOrigins("http://127.0.0.1:5500/") Metodo1
            //        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "127.0.0.1:5000") //Metodo2
            //        .AllowAnyHeader().AllowAnyMethod();
            //    });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin() // Asegúrate de incluir tu dominio frontend
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAllOrigins"); //Primero se corre el app.UseCors, por ultimo el app.Run()
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            //app.UseCors(_MyCors); //Habilitar los CORS que le especifiqué
        }
    }
}
