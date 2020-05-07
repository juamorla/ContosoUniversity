using ContosoUniversity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> _genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task Delete(int id)
        {
            try
            {
                await _genericRepository.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            try
            {
                return await _genericRepository.Insert(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                return await _genericRepository.Update(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
