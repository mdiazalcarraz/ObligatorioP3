﻿using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoDireccion
{
    public class CUBajaDireccion : ICUBaja<Direccion>
    {
        public IRepositorioDireccion Repo { get; set; }

        public CUBajaDireccion(IRepositorioDireccion repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}