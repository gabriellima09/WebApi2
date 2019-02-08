using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Comum.Repositorios.Interfaces;

namespace TreinaWeb.Comum.Repositorios.Entity
{
    public abstract class RepositorioTreinaWeb<T, TChave> : IRepositorioTreinaWeb<T, TChave>
        where T : class
    {
        protected DbContext _context;

        public RepositorioTreinaWeb(DbContext context)
        {
            _context = context;
        }

        public void Atualizar(T dominio)
        {
            _context.Entry(dominio).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(T dominio)
        {
            _context.Entry(dominio).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            T dominio = SelecionarPorId(id);
            Excluir(dominio);
        }

        public void Inserir(T dominio)
        {
            _context.Set<T>().Add(dominio);
            _context.SaveChanges();
        }

        public List<T> Selecionar(Expression<Func<T, bool>> where = null)
        {
            DbSet<T> dbSet = _context.Set<T>();

            if (where == null)
                return dbSet.ToList();
            else
                return dbSet.Where(where).ToList();
        }

        public T SelecionarPorId(TChave id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
