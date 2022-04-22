
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using ProductsAWS.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAWS.Infra.Data.Implementation
{
    public abstract class DynamoDBAbstract<TEntity> : IDynamoDBAbstract<TEntity>
        where TEntity : class, new()
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly IAmazonDynamoDB _amazonDynamoDBClient;
        public DynamoDBAbstract(IDynamoDBContext dynamoDBContext, IAmazonDynamoDB amazonDynamoDBClient)
        {
            _dynamoDBContext = dynamoDBContext;
            _amazonDynamoDBClient = amazonDynamoDBClient;
        }

        public async Task<List<TEntity>> ScanTable()
        {
            return await _dynamoDBContext.ScanAsync<TEntity>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<List<TEntity>> QueryByPartitionKey(string hashKey)
        {
            return await _dynamoDBContext.QueryAsync<TEntity>(hashKey).GetRemainingAsync();
        }
        
        public async Task<TEntity> PuttItemDynamoDBTableAsync(TEntity entity)
        {
            await _dynamoDBContext.SaveAsync(entity);

            return entity;
        }
    }
}
