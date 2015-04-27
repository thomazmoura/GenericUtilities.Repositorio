using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary><para> Interface responsável por fornecer acesso a repositórios específicos do Entity Framework -
    ///  Acrescenta o acesso ao DbSet específico do repositório. </para>
    /// <para> É útil para repositórios mais específicos, que envolvem mais de uma entidade. </para> </summary>
    /// <typeparam name="T"> Tipo de entidade ao qual esse repositório fornece acesso. </typeparam>
    public interface IEFRepositorio<T>: IRepositorio<T> where T: class
    {
        /// <summary> Obtem o DbSet específico da instância do repositório. </summary>
        /// <returns> O DbSet do repositório. </returns>
        DbSet<T> ObterDbSet { get; }
    }
}
