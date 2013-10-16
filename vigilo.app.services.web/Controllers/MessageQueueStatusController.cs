using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Simple.Validation;
using vigilo.app.services.web.Models.api;
using vigilo.domain.services.Commands;
using vigilo.domain.services.Interfaces;

namespace vigilo.app.services.web.Controllers
{
    public class MessageQueueStatusController : ApiController
    {
        private readonly ICommand<GetRabbitMqServerUrlRequest, GetRabbitMqServerUrlResponse> _rabbitServerUrlCommand;
        private readonly ICommand<GetMonitorableQueuesRequest, GetMonitorableQueuesReponse> _getQueuesToMonitorCommand;
        private readonly ICommand<GetRabbitMqQueueMetadataRequest, GetRabbitMqQueueMetadataResponse> _getQueueMetaDataCommand;
        private readonly IMapper<RabbitMqQueueMetadata, MessageQueueStatus> _messageQueueStatusMapper;

        public MessageQueueStatusController(
            ICommand<GetRabbitMqServerUrlRequest,GetRabbitMqServerUrlResponse> rabbitServerUrlCommand,
            ICommand<GetMonitorableQueuesRequest,GetMonitorableQueuesReponse> getQueuesToMonitorCommand,
            ICommand<GetRabbitMqQueueMetadataRequest,GetRabbitMqQueueMetadataResponse> getQueueMetaDataCommand,
            IMapper<RabbitMqQueueMetadata,MessageQueueStatus> messageQueueStatusMapper
           )
        {
            _rabbitServerUrlCommand = rabbitServerUrlCommand;
            _getQueuesToMonitorCommand = getQueuesToMonitorCommand;
            _getQueueMetaDataCommand = getQueueMetaDataCommand;
            _messageQueueStatusMapper = messageQueueStatusMapper;
        }

        // GET api/messagequeuestatus
        public IEnumerable<MessageQueueStatus> Get()
        {
            var urlResponse = _rabbitServerUrlCommand.Execute(new GetRabbitMqServerUrlRequest());
            var queuesToMonitor = _getQueuesToMonitorCommand.Execute(new GetMonitorableQueuesRequest());

            var metaDataRequest = new GetRabbitMqQueueMetadataRequest
            {
                RabbitMqUrl = urlResponse.Url,
                QueueNames = queuesToMonitor.QueueNames
            };
            var metadata = _getQueueMetaDataCommand.Execute(metaDataRequest);
            
            var models = metadata.Queues
                .Select(_messageQueueStatusMapper.Map)
                .ToList();

            return models;
        }

        // GET api/messagequeuestatus/5
        public MessageQueueStatus Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/messagequeuestatus
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/messagequeuestatus/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/messagequeuestatus/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
