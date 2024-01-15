using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioUsuarioSistemaFinanceiro : RepositoryGenerics<UsuarioSistemaFinanceiro>, InterfaceUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositorioUsuarioSistemaFinanceiro()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioSistemaFinanceiro>> ListUsuariosSistemaFinanceiro(int IdSistema)
        {
            using (var banco = new ContextBase(_OptionBuilder))
            {
                return await
                    banco.UsuarioSistemaFinanceiro
                    .Where(s => s.IdSistema == IdSistema).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionBuilder))
            {
                return await
                    banco.UsuarioSistemaFinanceiro.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuario(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new ContextBase(_OptionBuilder))
            {
                banco.UsuarioSistemaFinanceiro
               .RemoveRange(usuarios);
                 
                await banco.SaveChangesAsync();
            }
        }
    }
}
