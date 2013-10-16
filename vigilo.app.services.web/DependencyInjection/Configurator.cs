using System.Web.Helpers;
using Ninject;
using Simple.Validation;
using Simple.Validation.Ninject;
using vigilo.app.services.web.Mappers;
using vigilo.app.services.web.Models.api;
using vigilo.domain.services.Commands;
using vigilo.domain.services.Interfaces;
using vigilo.domain.services.Validation;

namespace vigilo.app.services.web.DependencyInjection
{
    public class Configurator
    {
        public static void Configure(IKernel kernel)
        {
            kernel.Bind<IMapper<ValidatedRabbitMqQueueMetadata, MessageQueueStatus>>().To<MessageQueueStatusMapper>();
            kernel.Bind<IMapper<Simple.Validation.ValidationResult, Models.api.ValidationResult>>().To<ValidationResultMapper>();

            kernel.Bind<ICommand<GetRabbitMqServerUrlRequest, GetRabbitMqServerUrlResponse>>().To<GetRabbitMqServerUrlCommand>();
            kernel.Bind<ICommand<GetMonitorableQueuesRequest, GetMonitorableQueuesReponse>>().To<GetMonitorableQueuesCommand>();
            kernel.Bind<ICommand<GetRabbitMqQueueMetadataRequest, GetRabbitMqQueueMetadataResponse>>().To<GetRabbitMqQueueMetadataCommand>();
            kernel.Bind <ICommand<ValidateRabbitMqQueueMetadataRequest, ValidateRabbitMqQueueMetadataRequestResponse>>().To<ValidateRabbitMqQueueMetadataCommand>();

            kernel.Bind<IValidator<RabbitMqQueueMetadata>>().To<RabbitMqQueueMetadataValidator>();
            kernel.Bind<IValidationEngine>().ToMethod((context) => Validator.ValidationEngine);

            IValidatorProvider validatorProvider = new NinjectValidatorProvider(kernel);
            Validator.SetValidationEngine(new DefaultValidationEngine(validatorProvider));
        }
    }
}