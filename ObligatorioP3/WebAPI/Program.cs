
using LogicaAplicacion.CasosUsoArticulo;
using LogicaAplicacion.CasosUsoPedido;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICUListado<Articulo>, CUListaArticuloOrden>();
            builder.Services.AddScoped<ICUListarPedidosAnulados, CUListarPedidosAnulados>();

            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulosEF>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();

            builder.Services.AddDbContext<LibreriaContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
