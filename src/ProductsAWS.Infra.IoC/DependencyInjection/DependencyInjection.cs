using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsAWS.Infra.IoC.Implementation;
using ProductsAWS.Infra.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAWS.Infra.IoC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureAWS(this IServiceCollection services)
        {
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
            
            services.AddSingleton<IPlayerPersistence, PlayerPersistence>();

            return services;
        }
    }
}