using LanchesMac.Context;
using LanchesMac.Models;


namespace LanchesMac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }


        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
