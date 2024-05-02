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
    public class DetailsModel : PageModel
    {
        private readonly LogicaDatos.Repositorios.LibreriaContext _context;

        public DetailsModel(LogicaDatos.Repositorios.LibreriaContext context)
        {
            _context = context;
        }

        public Articulo Articulo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FirstOrDefaultAsync(m => m.Codigo == id);
            if (articulo == null)
            {
                return NotFound();
            }
            else
            {
                Articulo = articulo;
            }
            return Page();
        }
    }
}
