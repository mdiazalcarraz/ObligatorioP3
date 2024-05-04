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
using LogicaAplicacion.CasosUso.CasosUsoUsuario;
using LogicaNegocio.ExcepcionesPropias;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace ObligatorioP3.Controllers
{
    public class UsuariosController : Controller
    {

        public ICUListado<Usuario> CUListado { get; set; }

        public ICUAlta<Usuario> CUAlta { get; set; }

        public ICUBaja<Usuario> CUBajaUsu { get; set; }

        public ICUModificar<Usuario> CUModificar { get; set; }

        public ICUBuscarPorId<Usuario> CUBuscar { get; set; }

        public UsuariosController(ICUListado<Usuario> cuListado, ICUAlta<Usuario> cuAlta, ICUBaja<Usuario> cuBajaUsu, ICUModificar<Usuario> cuModificar, ICUBuscarPorId<Usuario> cUBuscarPorId)
        {
            CUListado = cuListado;
            CUAlta = cuAlta;
            CUModificar = cuModificar;
            CUBajaUsu = cuBajaUsu;
            CUBuscar = cUBuscarPorId;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            List<Usuario> usuarios = CUListado.ObtenerListado();
            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            Usuario u = CUBuscar.Buscar(id);
            return View(u);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario nuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CUAlta.Alta(nuevo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de Usuario";
            }

            return View(nuevo);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario u = CUBuscar.Buscar(id);
            return View(u);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario u)
        {
            try
            {
                u.Id = id;
                CUModificar.Modificar(u);
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

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario u = CUBuscar.Buscar(id);
            return View(u);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario u)
        {
            try
            {
                CUBajaUsu.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Mensaje = "Ocurrió un error, no se pudo realizar accion";
                return View();
            }
        }

        private bool UsuarioExists(int id)
        {
            Usuario u = CUBuscar.Buscar(id);
            
            if (u == null) return false;

            return true;
        }
    }
}
