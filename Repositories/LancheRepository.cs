using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        //retorna lanhes e categorias
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        //retorna lanches preferidos e categorias.
        public IEnumerable<Lanche> LanchesPreferidos =>
            _context.Lanches.Where(p => p.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
           return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
