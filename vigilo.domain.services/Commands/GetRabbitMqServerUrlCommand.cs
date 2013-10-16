using System.Configuration;

namespace vigilo.domain.services.Commands
{
    public class GetRabbitMqServerUrlCommand
    {
        public GetRabbitMqServerUrlResponse Execute(GetRabbitMqServerUrlRequest request)
        {
            var url = ConfigurationManager.AppSettings["rabbitmq_server_to_monitor"];

            return new GetRabbitMqServerUrlResponse {Url = url};
        }
    }

    public class GetRabbitMqServerUrlRequest
    {
        
    }

    public class GetRabbitMqServerUrlResponse
    {
        public string Url { get; set; }
    }
}