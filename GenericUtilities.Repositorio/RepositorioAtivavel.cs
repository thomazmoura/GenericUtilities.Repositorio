using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Repositorio especializado que, ao listar todos as entidades, retorna apenas as ativas
    ///     e ao excluir um elemento, apenas o desativa. </summary>
    public class RepositorioAtivavel<T> : Repositorio<T> where T: class, IAtivavel
    {
        /// <summary> Construtor do RepositorioAtivavel responsável pela detecção automática do IDbSet referente a T. </summary>
        /// <param name="contextoParam"> <para>O contexto de dados ao qual esse repositório pertence.</para>
        /// <para> É necessário que o contexto passado possua alguma propriedade que implemente o IDbSet referente a T </para></param>
        /// <exception cref="ArgumentException"> Quando o contexto passado não possui um IDbSet referente a T </exception>
        public RepositorioAtivavel(DbContext contextoParam)
            : base(contextoParam) { }

        /// <summary> Construtor padrão do Repositório Padrão. </summary>
        /// <param name="contextoParam"> O contexto de dados ao qual esse repositório pertence. </param>
        /// <param name="entidadesParam"> DBSet responsável pela manipulação dos objetos do tipo T. </param>
        public RepositorioAtivavel(DbContext contextoParam, IDbSet<T> entidadesParam)
            :base(contextoParam, entidadesParam) { }

        /// <summary> Lista todos as entidades presentes no contexto de dados que estão ativas. </summary>
        /// <returns> IQueryable referente à pesquisa de entidades ativas do repositorio. </returns>
        public IQueryable<T> ListarTodosAtivos()
        {
            return Entidades.Where(e => e.Ativo);
        }

        /// <summary> Lista todos as entidades presentes no contexto de dados que estão inativas. </summary>
        /// <returns> IQueryable referente à pesquisa de entidades inativas do repositorio. </returns>
        public IQueryable<T> ListarTodosInativos()
        {
            return Entidades.Where(e => !e.Ativo);
        }

        /// <summary> Ativa ou reativa o elemento no contexto de dados utilizado. </summary>
        /// <param name="id"> A chave primária do elemento a ser ativado. </param>
        public void Ativar(params object[] id)
        {
            var entidade = Entidades.Find(id);
            entidade.Ativo = true;
        }

        /// <summary> Desativa o elemento no contexto de dados utilizado. </summary>
        /// <param name="id"> A chave primária do elemento a ser desativado. </param>
        public void Desativar(params object[] id)
        {
            var entidade = Entidades.Find(id);
            entidade.Ativo = false;
        }
    }
}
