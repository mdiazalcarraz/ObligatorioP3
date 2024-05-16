using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;

namespace ObligatorioP3.Views.Articulos
{
    public class EditModel : PageModel
    {
        private readonly LogicaDatos.Repositorios.LibreriaContext _context;

        public EditModel(LogicaDatos.Repositorios.LibreriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Articulo Articulo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long id)
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
            Articulo = articulo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(Articulo.Codigo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticuloExists(long id)
        {
            return _context.Articulos.Any(e => e.Codigo == id);
        }
    }
}
