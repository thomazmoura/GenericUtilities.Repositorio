using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericUtilities.Repositorio
{
    /// <summary> Interface para acesso às funções do sistema. </summary>
    public interface IFuncao
    {
        /// <summary> Descrição ou código identificador da Funcao </summary>
        string Chave { get; }
    }
}
