using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Amazon.DynamoDBv2;
using System.IO;
using Amazon.SQS;
using ProductsAWS.Infra.IoC.DependencyInjection;

namespace DynamoWorkerService
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var options = hostContext.Configuration.GetAWSOptions();
                    services.AddDefaultAWSOptions(options);
                    services.AddInfrastructureAWS();
                    //services.AddAWSService<IAmazonDynamoDB>();
                    services.AddAWSService<IAmazonSQS>();
                    //services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

                    services.AddHostedService<Worker>();

                });
    }
}
