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
    public class DeleteModel : PageModel
    {
        private readonly LogicaDatos.Repositorios.LibreriaContext _context;

        public DeleteModel(LogicaDatos.Repositorios.LibreriaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                Articulo = articulo;
                _context.Articulos.Remove(Articulo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
