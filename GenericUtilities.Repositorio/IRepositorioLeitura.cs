using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Interface padrão para repositórios do sistema que permitem leitura. Possui apenas métodos para leitura com o tipo informado. </summary>
    /// <typeparam name="T"> O tipo específico do repositório. </typeparam>
    interface IRepositorioLeitura<T>
    {
        /// <summary> Obter um objeto específico de acordo com sua ID. </summary>
        /// <param name="ID"> ID do objeto a ser retornado. </param>
        /// <returns> O objeto que possua a ID informada. </returns>
        T ObterPorId(params object[] id);

        /// <summary> Lista todos os objetos do repositorio </summary>
        /// <returns> IEnumerable contendo todos os objetos do repositorio </returns>
        IQueryable<T> ListarTodos();
    }
}
