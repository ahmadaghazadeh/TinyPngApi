using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace TinyPngApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {

        [HttpPost]
        [Route("TinyPng/Compress")]
        public IHttpActionResult Compress(JObject jsonData)
        {
            try
            {
                dynamic json = jsonData;

                return ;

                return qrBytes;
            }
            catch (Exception exp)
            {
                ErrorSignal.FromCurrentContext().Raise(exp);
                return new System.Web.Http.Results.ExceptionResult(exp, this);
            }
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
