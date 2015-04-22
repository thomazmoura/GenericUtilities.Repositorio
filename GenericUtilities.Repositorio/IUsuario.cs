using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericUtilities.Repositorio
{
    /// <summary> Interface padrão para acesso aos usuários do sistema. </summary>
    public interface IUsuario
    {
        /// <summary> Nome do Usuário. </summary>
        string Nome { get; }
        /// <summary> Perfis que esse usuário possui. </summary>
        IEnumerable<IPerfil> Perfis { get; }
    }
}
