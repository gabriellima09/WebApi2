using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.Comum.Repositorios.Interfaces
{
    public interface IRepositorioTreinaWeb<T, TChave> where T : class
    {
        List<T> Selecionar(Expression<Func<T, bool>> where = null);
        T SelecionarPorId(TChave id);
        void Inserir(T dominio);
        void Atualizar(T dominio);
        void Excluir(T dominio);
        void ExcluirPorId(TChave id);
    }
}
