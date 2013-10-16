using System.Linq;
using vigilo.app.services.web.Models.api;
using vigilo.domain.services.Commands;
using vigilo.domain.services.Interfaces;

namespace vigilo.app.services.web.Mappers
{
    public class MessageQueueStatusMapper : IMapper<ValidatedRabbitMqQueueMetadata, MessageQueueStatus>
    {
        private readonly IMapper<Simple.Validation.ValidationResult, ValidationResult> _validationResultMapper;

        public MessageQueueStatusMapper(IMapper<Simple.Validation.ValidationResult,ValidationResult> validationResultMapper)
        {
            _validationResultMapper = validationResultMapper;
        }

        public MessageQueueStatus Map(ValidatedRabbitMqQueueMetadata request)
        {
            var validationResults = request
                .ValidationResults
                .Select(_validationResultMapper.Map)
                .ToList();

            return new MessageQueueStatus
            {
                Name = request.Name,
                ConsumerCount = request.ConsumerCount,
                MessageCount = request.MessageCount,
                QueueExists = request.QueueExists,
                ValidationResults = validationResults
            };
        }
    }
}