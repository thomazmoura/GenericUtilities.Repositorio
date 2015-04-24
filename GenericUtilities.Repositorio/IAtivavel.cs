using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Representa entidades que devem ser desativadas ao invés de excluídas. </summary>
    public interface IAtivavel
    {
        /// <summary> Indica se o elemento está ativado ou não. </summary>
        bool Ativo { get; set; }
    }
}
