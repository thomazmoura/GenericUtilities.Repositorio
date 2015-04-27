using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Implementação do IEFRepositorioAtivavel que extende o RepositorioAtivavel para acessar o DbSet da instância do repositorio.  </summary>
    /// <typeparam name="T"> Tipo da entidade que será retornada por esse repositorio. </typeparam>
    public class EFRepositorioAtivavel<T>: RepositorioAtivavel<T>, IEFRepositorioAtivavel<T> where T: class, IAtivavel
    {
        /// <summary> Retorna o DbSet da instância para operações específicas do EF (como .Include()). </summary>
        public DbSet<T> ObterDbSet { get { return Entidades as DbSet<T>; } }

        /// <summary> Construtor do EFRepositório para detecção automática do DbSet referente a T. </summary>
        /// <param name="contextoParam"> <para>O contexto de dados ao qual esse repositório pertence.</para>
        /// <para> É necessário que o contexto passado possua alguma propriedade que implemente o DbSet referente a T </para></param>
        /// <exception cref="ArgumentException"> Quando o contexto passado não possui um DbSet referente a T </exception>
        public EFRepositorioAtivavel(DbContext contextoParam)
            :base(contextoParam)
        {
            Entidades = contextoParam
                        .GetType()
                        .GetProperties()                            //Aqui obtemos todas as propriedades do contexto informado
                        .Select(p => p.GetValue(contextoParam))     //Obtemos apenas o valor em si (no caso DbSet<T>)
                        .Where(o => o.GetType().IsGenericType               //Filtramos apenas pelas propriedades que sejam genéricas,
                            && o.GetType().GetGenericArguments()            // que possuam apenas um argumento genérico
                                .SingleOrDefault().Name == typeof(T).Name)  // cujo tipo seja o mesmo que T
                        .SingleOrDefault() as DbSet<T>;            //Por último convertemos o valor obtido para DbSet<T>

            if (Entidades == null)
                throw new ArgumentException(string.Format("Não foi possível detectar o DbSet correspondente ao tipo {0}. Verifique se o objeto de contexto de dados é válido.", typeof(T).Name));

            Contexto = contextoParam;
        }

        /// <summary> Construtor padrão do EFRepositório. </summary>
        /// <param name="contextoParam"> O contexto de dados ao qual esse repositório pertence. </param>
        /// <param name="entidadesParam"> DBSet responsável pela manipulação dos objetos do tipo T. </param>
        public EFRepositorioAtivavel(DbContext contextoParam, DbSet<T> entidadesParam)
            :base(contextoParam, entidadesParam)
        {
            Entidades = entidadesParam;
            Contexto = contextoParam;
        }
    }
}
