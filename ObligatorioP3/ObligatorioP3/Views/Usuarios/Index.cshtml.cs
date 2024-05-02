using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;

namespace ObligatorioP3.Views.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly LogicaDatos.Repositorios.LibreriaContext _context;

        public IndexModel(LogicaDatos.Repositorios.LibreriaContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Usuario = await _context.Usuarios.ToListAsync();
        }
    }
}
