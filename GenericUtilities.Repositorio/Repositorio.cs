using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Repositório padrão para CRUD básico. </summary>
    /// <typeparam name="T"> Tipo (classe) de dados que esse repositório manipulará. </typeparam>
    public class Repositorio<T>: IRepositorio<T> where T:class
    {
        /// <summary> Referência à lista de entidades no contexto de dados. </summary>
        protected IDbSet<T> Entidades { get; set; }
        /// <summary> Referência ao contexto de dados a qual esse repositório pertence. </summary>
        protected DbContext Contexto { get; set; }

        /// <summary> Construtuor padrão do Repositório Padrão. </summary>
        /// <param name="contextoParam"> O contexto de dados ao qual esse repositório pertence. </param>
        /// <param name="entidadesParam"> DBSet responsável pela manipulação dos objetos do tipo T. </param>
        public Repositorio(DbContext contextoParam, IDbSet<T> entidadesParam)
        {
            Entidades = entidadesParam;
            Contexto = contextoParam;
        }

        /// <summary> Obter um objeto específico de acordo com sua ID. </summary>
        /// <param name="ID"> ID do objeto a ser retornado. </param>
        /// <returns> O objeto que possua a ID informada. </returns>
        public virtual T ObterPorId(int id)
        {
            return Entidades.Find(id);
        }

        /// <summary> Acrescenta um objeto ao repositório. </summary>
        /// <param name="objeto"> O objeto a ser acrescentado ao repositório. </param>
        public virtual void Acrescentar(T objeto)
        {
            Entidades.Add(objeto);
        }

        /// <summary> Edita um objeto existente no repositório com base em sua ID. </summary>
        /// <param name="objeto"> O objeto que será usado como base para editar o objeto existente. </param>
        public virtual void Editar(T objeto)
        {
            Entidades.Attach(objeto);
            Contexto.Entry<T>(objeto).State = EntityState.Modified;
        }

        /// <summary> Exclui um objeto existente no repositorio </summary>
        /// <param name="objeto"> A ID do objeto a ser excluído</param>
        public virtual void Excluir(int id)
        {
            var objeto = Entidades.Find(id);
            Entidades.Remove(objeto);
        }

        /// <summary> Exclui um objeto existente no repositorio </summary>
        /// <param name="objeto"> O objeto a ser excluído</param>
        public virtual void Excluir(T objeto)
        {
            Entidades.Remove(objeto);
        }

        /// <summary> Lista todos os objetos do repositorio </summary>
        /// <returns> IQueryable contendo todos os objetos do repositorio </returns>
        public virtual IQueryable<T> ListarTodos()
        {
            return Entidades;
        }

        /// <summary> Efetiva as mudanças realizadas na fonte </summary>
        public virtual void SaveChanges()
        {
            Contexto.SaveChanges();
        }

        /// <summary> Libera o contexto de dados da memória </summary>
        public virtual void Dispose()
        {
            Contexto.Dispose();
        }
    }
}
