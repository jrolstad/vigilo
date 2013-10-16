using System.Web.Mvc;

namespace vigilo.app.services.web.Controllers
{
    public class MessageQueueStatusController : Controller
    {

        public PartialViewResult Summary()
        {
            return PartialView();
        }

    }
}
