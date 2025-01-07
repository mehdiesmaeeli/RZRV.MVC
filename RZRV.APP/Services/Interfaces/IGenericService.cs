using System.Collections.Generic;
using System.Threading.Tasks;

namespace RZRV.APP.Services.Interfaces
{
    public interface IGenericService<TEntity, TViewModel> where TEntity : class
    {
        Task<IEnumerable<TViewModel>> GetAllAsync();
        Task<TViewModel> GetByIdAsync(int id);
        Task<TViewModel> CreateAsync(TViewModel entity);
        Task<TViewModel> UpdateAsync(TViewModel entity);
        Task<bool> DeleteAsync(int id);
    }
}