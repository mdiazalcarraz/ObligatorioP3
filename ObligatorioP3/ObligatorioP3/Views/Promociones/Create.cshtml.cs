﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;

namespace ObligatorioP3.Views.Promociones
{
    public class CreateModel : PageModel
    {
        private readonly LogicaDatos.Repositorios.LibreriaContext _context;

        public CreateModel(LogicaDatos.Repositorios.LibreriaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Promocion Promocion { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Promociones.Add(Promocion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}