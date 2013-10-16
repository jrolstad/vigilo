using System;
using vigilo.app.services.web.Models.api;
using vigilo.domain.services.Interfaces;

namespace vigilo.app.services.web.Mappers
{
    public class ValidationResultMapper:IMapper<Simple.Validation.ValidationResult,ValidationResult>
    {
        public ValidationResult Map(Simple.Validation.ValidationResult request)
        {
            return new ValidationResult
            {
                Message = request.Message,
                Severity = Map(request.Severity)
            };
        }

        private ValidationResultSeverity Map(Simple.Validation.ValidationResultSeverity severity)
        {
            switch (severity)
            {
                case Simple.Validation.ValidationResultSeverity.Error:return ValidationResultSeverity.Error;
                case Simple.Validation.ValidationResultSeverity.Informational:return ValidationResultSeverity.Info;
                case Simple.Validation.ValidationResultSeverity.Warning:return ValidationResultSeverity.Warning;
                default: throw new ArgumentOutOfRangeException("severity",severity,"Unsupported Validation type");
            }
        }
    }
}