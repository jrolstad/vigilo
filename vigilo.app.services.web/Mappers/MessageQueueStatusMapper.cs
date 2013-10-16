using vigilo.app.services.web.Models.api;
using vigilo.domain.services.Commands;
using vigilo.domain.services.Interfaces;

namespace vigilo.app.services.web.Mappers
{
    public class MessageQueueStatusMapper:IMapper<RabbitMqQueueMetadata,MessageQueueStatus>
    {
        public MessageQueueStatus Map(RabbitMqQueueMetadata request)
        {
            return new MessageQueueStatus
            {
                Name = request.Name,
                ConsumerCount = request.ConsumerCount,
                MessageCount = request.MessageCount,
                QueueExists = request.QueueExists
            };
        }
    }
}