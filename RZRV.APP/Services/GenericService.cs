using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RZRV.APP.Data;
using RZRV.APP.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RZRV.APP.Services
{
    public class GenericService<TEntity, TViewModel> : IGenericService<TEntity, TViewModel> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        public GenericService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }


        public virtual async Task<IEnumerable<TViewModel>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TViewModel>>(entities);
        }

        public virtual async Task<TViewModel> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return _mapper.Map<TViewModel>(entity);
        }

        public virtual async Task<TViewModel> CreateAsync(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TViewModel>(entity);
        }

        public virtual async Task<TViewModel> UpdateAsync(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TViewModel>(entity);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}