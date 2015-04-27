using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Interface responsável por dar acesso a EFRepositorios de elementos que implementam IAtivavel e tratá-los de acordo com seu estado. </summary>
    /// <typeparam name="T"> Tipo de entidade IAtivavel retornada pelo Repositorio. </typeparam>
    public interface IEFRepositorioAtivavel<T> : IEFRepositorio<T>, IRepositorioAtivavel<T> where T: class, IAtivavel
    { }
}
