using System;
using System.Collections.Generic;
using System.Web.Http;
using vigilo.app.services.web.Models.api;

namespace vigilo.app.services.web.Controllers
{
    public class MessageQueueStatusController : ApiController
    {
        // GET api/messagequeuestatus
        public IEnumerable<MessageQueueStatus> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/messagequeuestatus/5
        public MessageQueueStatus Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/messagequeuestatus
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/messagequeuestatus/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/messagequeuestatus/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
