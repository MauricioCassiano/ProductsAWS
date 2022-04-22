using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace ProductsAWS.Domain
{
    [DynamoDBTable("Player")]
    public  class Player
    {
        [DynamoDBHashKey]
        public string PersonId { get; set; }
        [DynamoDBRangeKey]
        public string State { get; set; }
        public List<Games> Games { get; set; }
    }
}
