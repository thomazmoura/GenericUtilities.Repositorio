using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Interface para interação com entidades do Entity FrameWork </summary>
    public interface IEntity
    {
        /// <summary> Fornece acesso à chave primária da entidade </summary>
        int Key { get; }
    }
}
