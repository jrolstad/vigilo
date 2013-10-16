namespace vigilo.web.Models
{
    public class MonitoredQueueViewModel
    {
        public string Name { get; set; }
 
        public int MessageCount { get; set; }

        public int ConsumerCount { get; set; }
    }
}