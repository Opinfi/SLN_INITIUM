using Domain.Entities;

namespace Application.Interfaces
{
    public interface IColaRepository : IRepository<Cola>
    {
        Task<Cola> GetColaCodigo(string codigo);
    }
}
