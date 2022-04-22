using Amazon.DynamoDBv2.DataModel;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductsAWS.Domain;
using ProductsAWS.Infra.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DynamoWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        //private readonly IDynamoDBContext _dynamoDBContext;
        private readonly IPlayerPersistence _playerPersistence;
        private readonly IAmazonSQS _sqs;
        private readonly string _exampleQueueUrl = "http://localhost:4566/000000000000/example-queue";
        private readonly string _processedMessageQueueUrl = "http://localhost:4566/000000000000/processed-messages";

        public Worker(ILogger<Worker> logger, IPlayerPersistence playerPersistence, IAmazonSQS sqs)
        {
            _logger = logger;
            _playerPersistence = playerPersistence;
            _sqs = sqs;
        }

        //public Worker(ILogger<Worker> logger, IDynamoDBContext dynamoDBContext, IAmazonSQS sqs)
        //{
        //    _logger = logger;
        //    _dynamoDBContext = dynamoDBContext;
        //    _sqs = sqs;
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var request = new ReceiveMessageRequest
                    {
                        QueueUrl = _exampleQueueUrl,
                        MaxNumberOfMessages = 10,

                        WaitTimeSeconds = 5
                    };

                    var result = await _sqs.ReceiveMessageAsync(request);

                    if (result.Messages.Any())
                    {
                        foreach (var message in result.Messages)
                        {
                            // Some Processing code would live here
                            _logger.LogInformation("Processing Message: {message} | {time}", message.Body, DateTimeOffset.Now);

                            //var obj = JsonConvert.DeserializeObject<Player>(message.Body);

                            //await _playerPersistence.PuttItemDynamoDBTableAsync(obj);

                            var player = _playerPersistence.ScanTable().Result;


                            //var deleteResult = await _sqs.DeleteMessageAsync(_exampleQueueUrl, message.ReceiptHandle, stoppingToken);


                            //var processedMessage = new ProcessedMessage(message.Body);

                            //var sendRequest = new SendMessageRequest(_processedMessageQueueUrl, JsonConvert.SerializeObject(processedMessage));

                            //var sendResult = await _sqs.SendMessageAsync(sendRequest, stoppingToken);
                            //if (sendResult.HttpStatusCode == System.Net.HttpStatusCode.OK)
                            //{
                          //  var deleteResult = await _sqs.DeleteMessageAsync(_exampleQueueUrl, message.ReceiptHandle, stoppingToken);
                            //}
                        }
                    }
                    else _logger.LogInformation("NOT Processing Message: {message} | {time}", result.Messages.Count, DateTimeOffset.Now);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.InnerException.ToString());
                }

                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
