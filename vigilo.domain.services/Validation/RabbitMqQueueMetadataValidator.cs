using System.Collections.Generic;
using Simple.Validation;
using vigilo.domain.services.Commands;

namespace vigilo.domain.services.Validation
{
    public class RabbitMqQueueMetadataValidator:IValidator<RabbitMqQueueMetadata>
    {
        public bool AppliesTo(string rulesSet)
        {
            return true;
        }

        public IEnumerable<ValidationResult> Validate(RabbitMqQueueMetadata value)
        {
            if (value.ConsumerCount == 0)
            {
                yield return new ValidationResult
                {
                    Message = "Queue must have at least 1 consumer",
                    Context = value,
                    Severity = ValidationResultSeverity.Error
                };
            }

            if (!value.QueueExists)
            {
                yield return new ValidationResult
                {
                    Message = "Queue does not exist",
                    Context = value,
                    Severity = ValidationResultSeverity.Error
                };
            }

            if (value.Name.EndsWith(".Error") && value.MessageCount > 0)
            {
                yield return new ValidationResult
                {
                    Message = "Queue contains errors",
                    Context = value,
                    Severity = ValidationResultSeverity.Error
                };
            }
        }

       
    }
}