using Ninject;
using Simple.Validation;
using Simple.Validation.Ninject;
using vigilo.app.services.web.Mappers;
using vigilo.app.services.web.Models.api;
using vigilo.domain.services.Commands;
using vigilo.domain.services.Interfaces;

namespace vigilo.app.services.web.DependencyInjection
{
    public class Configurator
    {
        public static void Configure(IKernel kernel)
        {
            kernel.Bind<IMapper<RabbitMqQueueMetadata, MessageQueueStatus>>().To<MessageQueueStatusMapper>();

            kernel.Bind<ICommand<GetRabbitMqServerUrlRequest, GetRabbitMqServerUrlResponse>>().To<GetRabbitMqServerUrlCommand>();
            kernel.Bind<ICommand<GetMonitorableQueuesRequest, GetMonitorableQueuesReponse>>().To<GetMonitorableQueuesCommand>();
            kernel.Bind<ICommand<GetRabbitMqQueueMetadataRequest, GetRabbitMqQueueMetadataResponse>>().To<GetRabbitMqQueueMetadataCommand>();

            var validatorProvider = new NinjectValidatorProvider(kernel);
            Validator.SetValidatorProvider(validatorProvider);
        }
    }
}