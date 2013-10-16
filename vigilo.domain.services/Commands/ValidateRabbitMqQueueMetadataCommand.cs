using System.Collections.Generic;
using System.Linq;
using Simple.Validation;
using vigilo.domain.services.Interfaces;

namespace vigilo.domain.services.Commands
{
    public class ValidateRabbitMqQueueMetadataCommand : ICommand<ValidateRabbitMqQueueMetadataRequest, ValidateRabbitMqQueueMetadataRequestResponse>
    {
        private readonly IValidationEngine _validationEngine;

        public ValidateRabbitMqQueueMetadataCommand(IValidationEngine validationEngine)
        {
            _validationEngine = validationEngine;
        }

        public ValidateRabbitMqQueueMetadataRequestResponse Execute(ValidateRabbitMqQueueMetadataRequest request)
        {
            var validatedQueues = new List<ValidatedRabbitMqQueueMetadata>();

            foreach (var queue in request.Queues)
            {
                var validationResults = _validationEngine
                    .Validate(queue)
                    .ToList();

                var validatedQueue = new ValidatedRabbitMqQueueMetadata
                {
                    ConsumerCount = queue.ConsumerCount,
                    MessageCount = queue.MessageCount,
                    Name = queue.Name,
                    QueueExists = queue.QueueExists,
                    ValidationResults = validationResults
                };

                validatedQueues.Add(validatedQueue);
            }


            return new ValidateRabbitMqQueueMetadataRequestResponse
            {
                Queues = validatedQueues
            };
        }
    }

    public class ValidateRabbitMqQueueMetadataRequest
    {
        public List<RabbitMqQueueMetadata> Queues { get; set; } 
    }

    public class ValidateRabbitMqQueueMetadataRequestResponse
    {
        public List<ValidatedRabbitMqQueueMetadata> Queues { get; set; } 
    }

    public class ValidatedRabbitMqQueueMetadata
    {
        public string Name { get; set; }

        public int MessageCount { get; set; }

        public int ConsumerCount { get; set; }

        public bool QueueExists { get; set; }

        public List<ValidationResult> ValidationResults { get; set; } 
    }
}