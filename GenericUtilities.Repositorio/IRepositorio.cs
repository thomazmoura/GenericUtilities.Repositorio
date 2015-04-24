using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Interface padrão para repositórios do sistema. Possui métodos para CRUD com o tipo informado. </summary>
    /// <typeparam name="T"> O tipo específico do repositório. </typeparam>
    public interface IRepositorio<T> where T : class
    {
        /// <summary> Obter um objeto específico de acordo com sua ID. </summary>
        /// <param name="ID"> ID do objeto a ser retornado. </param>
        /// <returns> O objeto que possua a ID informada. </returns>
        T ObterPorId(params object[] id);

        /// <summary> Acrescenta um objeto ao repositório. </summary>
        /// <param name="objeto"> O objeto a ser acrescentado ao repositório. </param>
        void Acrescentar(T objeto);

        /// <summary> Edita um objeto existente no repositório com base em sua ID. </summary>
        /// <param name="objeto"> O objeto que será usado como base para editar o objeto existente. </param>
        void Editar(T objeto);

        /// <summary> Exclui um objeto existente no repositorio. </summary>
        /// <param name="objeto"> A ID do objeto a ser excluído. </param>
        void Excluir(params object[] id);

        /// <summary> Exclui um objeto existente no repositorio. </summary>
        /// <param name="objeto"> O objeto a ser excluído</param>
        void Excluir(T objeto);

        /// <summary> Lista todos os objetos do repositorio. </summary>
        /// <returns> IQueryable contendo todos os objetos do repositorio. </returns>
        IQueryable<T> ListarTodos();

        /// <summary> Efetiva as mudanças realizadas na fonte. </summary>
        void SaveChanges();
    }
}
