using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Repositório para leitura de dados somente. </summary>
    /// <typeparam name="T"> Tipo (classe) de dados que esse repositório manipulará. </typeparam>
    public class RepositorioLeitura<T> : IRepositorioLeitura<T> where T : class
    {
        /// <summary> Referência à lista de entidades no contexto de dados. </summary>
        protected IDbSet<T> Entidades { get; set; }
        /// <summary> Referência ao contexto de dados a qual esse repositório pertence. </summary>
        protected DbContext Contexto { get; set; }

        /// <summary> Construtor padrão do Repositório somente Leitura. </summary>
        /// <param name="contextoParam"> O contexto de dados ao qual esse repositório pertence. </param>
        /// <param name="entidadesParam"> DBSet responsável pela manipulação dos objetos do tipo T. </param>
        public RepositorioLeitura(DbContext contextoParam, IDbSet<T> entidadesParam)
        {
            Entidades = entidadesParam;
            Contexto = contextoParam;
        }


        /// <summary> Construtor do Repositório somente Leitura para detecção automática do IDbSet referente a T. </summary>
        /// <param name="contextoParam"> <para>O contexto de dados ao qual esse repositório pertence.</para>
        /// <para> É necessário que o contexto passado possua alguma propriedade que implemente o IDbSet referente a T </para></param>
        /// <exception cref="ArgumentException"> Quando o contexto passado não possui um IDbSet referente a T </exception>
        public RepositorioLeitura(DbContext contextoParam)
        {
            Entidades = contextoParam
                        .GetType()
                        .GetProperties()                            //Aqui obtemos todas as propriedades do contexto informado
                        .Select(p => p.GetValue(contextoParam))     //Obtemos apenas o valor em si (no caso DbSet<T>)
                        .Where(o => o.GetType().IsGenericType               //Filtramos apenas pelas propriedades que sejam genéricas,
                            && o.GetType().GetGenericArguments()            // que possuam apenas um argumento genérico
                                .SingleOrDefault().Name == typeof(T).Name)  // cujo tipo seja o mesmo que T
                        .SingleOrDefault() as IDbSet<T>;            //Por último convertemos o valor obtido para IDbSet<T>

            if (Entidades == null)
                throw new ArgumentException(string.Format("Não foi possível detectar o DbSet correspondente ao tipo {0}. Verifique se o objeto de contexto de dados é válido.", typeof(T).Name));

            Contexto = contextoParam;
            //Desativa a detecção de mudanças para melhorar a performance
            Contexto.Configuration.AutoDetectChangesEnabled = false;
        }

        /// <summary> Obter um objeto específico de acordo com sua ID. </summary>
        /// <param name="ID"> ID do objeto a ser retornado. </param>
        /// <returns> O objeto que possua a ID informada. </returns>
        public virtual T ObterPorId(int id)
        {
            return Entidades.Find(id);
        }

        /// <summary> Lista todos os objetos do repositorio </summary>
        /// <returns> IQueryable contendo todos os objetos do repositorio </returns>
        public virtual IQueryable<T> ListarTodos()
        {
            return Entidades;
        }
    }
}
