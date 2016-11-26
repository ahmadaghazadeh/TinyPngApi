using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using TinyPngApi.Core;
using System.Web.Script.Serialization;

namespace TinyPngApi.Controllers
{
    //[Authorize]
    public class TinyPngController : ApiController
    {
        [HttpPost]
        [Route("TinyPng/Compress/")]
        public async Task<IHttpActionResult> Compress(HttpRequestMessage request)
        {
            try
            {
                var content = request.Content;
                var dict = HttpUtility.ParseQueryString(content.ReadAsStringAsync().Result);
                var javaScript = new JavaScriptSerializer().Serialize(
                        dict.AllKeys.ToDictionary(k => k, k => dict[k])
                );
                var json = JObject.Parse(javaScript);
                var bytes = Convert.FromBase64String(json["base64"].ToString());
                var lstKeys = await TinifyHelperExtensions.GenerateTinifyApiKeysLocalAsync();
                var tinify = new TinifyImage(lstKeys, bytes);
                var bytes2 = await tinify.CompressAsync();
                return Ok(Convert.ToBase64String(bytes2)) ;
                
            }
            catch (Exception exp)
            {
                return new System.Web.Http.Results.ExceptionResult(exp, this);
            }
        }
        // GET api/values
        
    }
}
