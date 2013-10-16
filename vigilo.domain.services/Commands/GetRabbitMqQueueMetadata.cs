using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;

namespace vigilo.domain.services.Commands
{
    public class GetRabbitMqQueueMetadataCommand
    {
        private readonly ConnectionFactory _connectionFactory;

        public GetRabbitMqQueueMetadataCommand(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public GetRabbitMqQueueMetadataResponse Execute(GetRabbitMqQueueMetadataRequest request)
        {
            _connectionFactory.Uri = request.RabbitMqUrl;

            using(var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queueData = request
                    .QueueNames
                    .Select(q => GetQueueInfo(q, channel))
                    .ToList();

                return new GetRabbitMqQueueMetadataResponse
                {
                    Queues = queueData
                };
            }
        }

        private RabbitMqQueueMetadata GetQueueInfo(string queueName, IModel channel)
        {
            try
            {
                var response = channel.QueueDeclarePassive(queueName);

                return new RabbitMqQueueMetadata
                {
                    Name = response.QueueName,
                    ConsumerCount = System.Convert.ToInt32(response.ConsumerCount),
                    MessageCount = System.Convert.ToInt32(response.MessageCount),
                    QueueExists = true
                };
            }
            catch (Exception)
            {
                return new RabbitMqQueueMetadata
                {
                    Name = queueName,
                    QueueExists = false
                };
            }
          
        }

    }

    public class GetRabbitMqQueueMetadataRequest
    {
        public string RabbitMqUrl { get; set; }

        public List<string> QueueNames { get; set; } 
    }

    public class GetRabbitMqQueueMetadataResponse
    {
        public List<RabbitMqQueueMetadata> Queues { get; set; } 
    }

    public class RabbitMqQueueMetadata
    {
        public string Name { get; set; }

        public int MessageCount { get; set; }

        public int ConsumerCount { get; set; }

        public bool QueueExists { get; set; }
    }

}