using System.Collections.Generic;
using System.Web.Helpers;

namespace vigilo.app.services.web.Models.api
{
    public class MessageQueueStatus
    {
        public string Name { get; set; }

        public int MessageCount { get; set; }

        public int ConsumerCount { get; set; }

        public bool QueueExists { get; set; } 

        public List<ValidationResult> ValidationResults { get; set; }
    }
}