using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAWS.Infra.Data.Interfaces
{
    public interface IDynamoDBAbstract<TEntity>
    {
        //Task<TEntity> QueryAsync(QueryRequest p_Key);
        //Task<IList<TEntity>> GetListAsync();
        //Task<TEntity> GetByIdAsync(int? id);
        Task<TEntity> PuttItemDynamoDBTableAsync(TEntity entity);
        Task<List<TEntity>> QueryByPartitionKey(string hashKey);
        Task<List<TEntity>> ScanTable();


        //Task<TEntity> UpdateAsync(TEntity entity);
        //Task<TEntity> RemoveAsync(TEntity entity);
    }
}
