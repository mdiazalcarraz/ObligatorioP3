using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.ExcepcionesPropias;

namespace ObligatorioP3.Controllers
{
    public class VariablesController : Controller
    {
        public ICUModificar<Variable> CUModificar { get; set; }
        public ICUBuscarPorId<Variable> CUBuscar { get; set; }
        public ICUListado<Variable> CUListado { get; set; }
        public VariablesController(ICUModificar<Variable> cUModificar, ICUListado<Variable> cuListado, ICUBuscarPorId<Variable> cUBuscarPorId)
        {
            CUModificar = cUModificar;
            CUListado = cuListado;
            CUBuscar = cUBuscarPorId;
        }

        // GET: Variables
        public async Task<IActionResult> Index()
        {
            List<Variable> variables = CUListado.ObtenerListado();
            return View(variables);
        }

        // GET: Variables/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Variable v = CUBuscar.Buscar(id);
            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Variable v)
        {
            try
            {
                v.Id = id;
                CUModificar.Modificar(v);
                return RedirectToAction(nameof(Index));
            }
            catch (DatosInvalidosException e)
            {
                ViewBag.Mensaje = e.Message;

            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error, no se pudo realizar la modificación";
            }

            return View();
        }
    }
}
