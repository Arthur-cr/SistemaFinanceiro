using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Domain.Interfaces.IDespesa
{
    public interface InterfaceDespesa : InterfaceGeneric<Despesa>
    {
        Task<IList<Despesa>> ListDespesaUsuario(string emailUsuario);

        Task<IList<Despesa>> ListDespesaUsuarioNaoPagaMesesAnteriores(string emailUsuario);
    }
}
