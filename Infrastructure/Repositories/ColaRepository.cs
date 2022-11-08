using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ColaRepository : Repository<Cola>, IColaRepository
    {
        private readonly InitiumDbContext _context;
        public ColaRepository(InitiumDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cola> GetColaCodigo(string codigo)
        {
            return _context.Colas.FirstOrDefault(x => x.Codigo.Trim() == codigo.Trim());
        }
    }
}
