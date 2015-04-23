using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericUtilities.Repositorio
{
    /// <summary> Define que a classe atribuída é um objeto do Entity Framework. </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute: Attribute
    {}
}
