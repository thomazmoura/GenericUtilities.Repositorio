using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericUtilities.Repositorio
{
    /// <summary> Interface para acesso aos perfis do sistema. </summary>
    public interface IPerfil
    {
        /// <summary> Chave primária (código de identificação) do perfil. </summary>
        int PerfilId { get;  }
        /// <summary> Nome ou descrição do perfil. </summary>
        string Descricao { get; }
        /// <summary> Funções que o perfil selecionado possui acesso. </summary>
        IEnumerable<IFuncao> Funcoes { get; }
    }
}