using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using vigilo.domain.services.Interfaces;

namespace vigilo.domain.services.Commands
{
    public class GetMonitorableQueuesCommand : ICommand<GetMonitorableQueuesRequest,GetMonitorableQueuesReponse>
    {
        public GetMonitorableQueuesReponse Execute(GetMonitorableQueuesRequest request)
        {
            var appSettings = ConfigurationManager.AppSettings;

            var queuesToMonitorSettings = appSettings
                .AllKeys
                .Where(key => key.ToLower().StartsWith("queue_to_monitor"))
                .Select(key => appSettings[key])
                .ToList();

            var response = new GetMonitorableQueuesReponse { QueueNames = queuesToMonitorSettings };

            return response;
        }
    }

    public class GetMonitorableQueuesRequest
    {
    }

    public class GetMonitorableQueuesReponse
    {
        public List<string> QueueNames { get; set; } 
    }

}