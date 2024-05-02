using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;

namespace ObligatorioP3.Views.Articulos
{
    public class IndexModel : PageModel
    {
        private readonly LogicaDatos.Repositorios.LibreriaContext _context;

        public IndexModel(LogicaDatos.Repositorios.LibreriaContext context)
        {
            _context = context;
        }

        public IList<Articulo> Articulo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Articulo = await _context.Articulos.ToListAsync();
        }
    }
}
