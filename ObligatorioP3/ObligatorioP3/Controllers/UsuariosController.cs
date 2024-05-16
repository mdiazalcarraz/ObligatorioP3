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
using ObligatorioP3.Models;
using DTOs;
using Humanizer;
using LogicaNegocio.VOs;
using ObligatorioP3.Filters;

namespace ObligatorioP3.Controllers
{
    [Admin]
    public class UsuariosController : Controller
    {

        public ICUListado<Usuario> CUListado { get; set; }

        public ICUAlta<DTOAltaUsuario> CUAlta { get; set; }

        public ICUBaja<Usuario> CUBajaUsu { get; set; }

        public ICUModificar<DTOEditarUsuario> CUModificar { get; set; }

        public ICUBuscarPorId<Usuario> CUBuscar { get; set; }

        public ICUEncriptarContraseniaUsuario CUEncriptar {  get; set; }

        public UsuariosController(ICUListado<Usuario> cuListado, ICUAlta<DTOAltaUsuario> cuAlta, ICUBaja<Usuario> cuBajaUsu, ICUModificar<DTOEditarUsuario> cuModificar, ICUBuscarPorId<Usuario> cUBuscarPorId, ICUEncriptarContraseniaUsuario cUEncriptar)
        {
            CUListado = cuListado;
            CUAlta = cuAlta;
            CUModificar = cuModificar;
            CUBajaUsu = cuBajaUsu;
            CUBuscar = cUBuscarPorId;
            CUEncriptar = cUEncriptar;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModelAlta vm)
        {
            try
            {
                DTOAltaUsuario nuevo = new DTOAltaUsuario()
                {
                    NombreYApellido = vm.NombreYApellido,
                    Contrasenia = vm.Contrasenia,
                    Administrador = vm.Administrador,
                    Email = vm.Email,
                    ContraseniaEncriptada = CUEncriptar.EncriptarContrasenia(vm.Contrasenia),
                };
                    CUAlta.Alta(nuevo);
                    return RedirectToAction(nameof(Index));
               
            }
            catch (DatosInvalidosException ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado. No se hizo el alta de Usuario";
            }

            return View(vm);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario u = CUBuscar.Buscar(id);
            UsuarioViewModelEditar vm = new UsuarioViewModelEditar()
            {
                NombreYApellido = u.NombreYApellido.NombreValue,
                Contrasenia = u.Contrasenia,
                Administrador = u.Administrador,
                Email = u.Email,
                Id = id,
            };
            return View(vm);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioViewModelEditar vm)
        {
            try
            {
                DTOEditarUsuario nuevo = new DTOEditarUsuario()
                {
                    NombreYApellido = vm.NombreYApellido,
                    Contrasenia = vm.Contrasenia,
                    Administrador = vm.Administrador,
                    Email = vm.Email,
                    Id = vm.Id,
                    ContraseniaEncriptada = CUEncriptar.EncriptarContrasenia(vm.Contrasenia),
                };
                CUModificar.Modificar(nuevo);
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
