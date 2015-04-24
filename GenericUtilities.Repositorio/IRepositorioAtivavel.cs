using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Especialização do IRepositorio voltado a entidades que implementem IAtivavel e que possui os métodos de consulta relativos
    ///  ao estado da entidade (ativo ou não). </summary>
    /// <typeparam name="T"></typeparam>
    interface IRepositorioAtivavel<T>: IRepositorio<T> where T: class, IAtivavel
    {
        /// <summary> Retorna apenas as entidades ativas. </summary>
        /// <returns> IQueryable contendo todos os objetos ativos do repositorio. </returns>
        IQueryable<T> ListarTodosAtivos();

        /// <summary> Retorna apenas as entidades inativas. </summary>
        /// <returns> IQueryable contendo todos os objetos inativos do repositorio. </returns>
        IQueryable<T> ListarTodosInativos();
        
        /// <summary> Ativa ou reativa uma entidade no contexto de dados. </summary>
        /// <param name="id"> Chave primária da entidade que será ativada. </param>
        void Ativar(params object[] id);

        /// <summary> Desativa uma entidade no contexto de dados. </summary>
        /// <param name="id"> Chave primária da entidade que será desativada. </param>
        void Desativar(params object[] id);
    }
}
