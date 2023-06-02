namespace GameLibrary.DataAccess
{
    internal interface IRepository<TEntity, TKey>
    {
        Task<TEntity> Get(TKey key);
        Task<List<TEntity>> GetAll();
        Task<int> Insert(TEntity item);
        Task<int> Update(TEntity item);
        Task<int> Delete(TEntity item);
    }
}