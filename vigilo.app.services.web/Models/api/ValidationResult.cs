namespace vigilo.app.services.web.Models.api
{
    public class ValidationResult
    {
        public string Message { get; set; }
 
        public ValidationResultSeverity Severity { get; set; }
    }

    public enum ValidationResultSeverity
    {
        Info,
        Warning,
        Error
    }
}