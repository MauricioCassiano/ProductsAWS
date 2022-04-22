using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using ProductsAWS.Domain;
using ProductsAWS.Infra.Data.Implementation;
using ProductsAWS.Infra.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAWS.Infra.IoC.Implementation
{
    public class PlayerPersistence : DynamoDBAbstract<Player>, IPlayerPersistence
    {
        public PlayerPersistence(IDynamoDBContext dynamoDBContext, IAmazonDynamoDB amazonDynamoDBClient) 
            : base(dynamoDBContext, amazonDynamoDBClient)
        { }
    }
}
