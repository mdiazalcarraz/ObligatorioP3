using LogicaAplicacion.CasosUso.CasosUsoUsuario;
using LogicaAplicacion.CasosUsoUsuario;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.CasosUsoArticulo;
using LogicaAplicacion.CasosUso.CasosUsoArticulo;
using Microsoft.Extensions.DependencyInjection;

namespace ObligatorioP3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddSession();

			builder.Services.AddScoped<ICULoginUsuario, CULoginUsuario>();
            builder.Services.AddScoped<ICUListado<Usuario>, CUListarUsuarios>();
            builder.Services.AddScoped<ICUAlta<Usuario>, CUAltaUsuario>();
            builder.Services.AddScoped<ICUListado<Articulo>, CUListaArticuloOrden>();
            builder.Services.AddScoped<ICUAlta<Articulo>, CUAltaArticulo>();
            builder.Services.AddScoped<ICUBaja<Usuario>, CUBorrarUsuario>();
            builder.Services.AddScoped<ICUBuscarPorId<Usuario>, CUBuscarUsuarioPorId>();
            builder.Services.AddScoped<ICUBaja<Articulo>, CUBorrarArticulo>();
            builder.Services.AddScoped<ICUBuscarPorId<Articulo>, CUBuscarArticuloPorId>();
            builder.Services.AddScoped<ICUModificar<Usuario>, CUEditarUsuario>();

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulosEF>();

            builder.Services.AddDbContext<LibreriaContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
