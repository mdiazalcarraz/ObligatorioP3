using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioVariableEF : IRepositorioVariable
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioVariableEF(LibreriaContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(Variable variable)
        {
            if (variable != null)
            {
                variable.Validar();
                Contexto.Variables.Add(variable);
            }
        }

        public List<Variable> FindAll()
        {
            return Contexto.Variables.ToList();
        }

        public Variable FindById(int id)
        {
            return Contexto.Variables
                 .Where(Variable => Variable.Id == id)
                 .SingleOrDefault();
        }

        public void Remove(int id)
        {
            Variable aBorrar = FindById(id);

            if (aBorrar != null)
            {
                Contexto.Variables.Remove(aBorrar);
            }
            else
            {
                throw new Exception("No se encontro la variable");
            }
        }

        public void Update(Variable variable)
        {
            variable.Validar();
            Contexto.Update(variable);
            Contexto.SaveChanges();
        }

        public Variable FindByNombre(string nombre)
        {
            return Contexto.Variables
                 .Where(Variable => Variable.Nombre.ToUpper() == nombre.ToUpper())
                 .SingleOrDefault();
        }
    }
}
