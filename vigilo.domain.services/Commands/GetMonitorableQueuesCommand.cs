using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace vigilo.domain.services.Commands
{
    public class GetMonitorableQueuesCommand
    {
        public GetMonitorableQueuesReponse Execute(GetMonitorableQueuesRequest request)
        {
            var queuesToMonitorSetting = ConfigurationManager.AppSettings["queues_to_monitor"];

            const char delimiter = '|';

            var queues = queuesToMonitorSetting
                .Split(delimiter)
                .ToList();

            var response = new GetMonitorableQueuesReponse {QueueNames = queues};

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