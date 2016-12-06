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
using TinyPngApi.Models;

namespace TinyPngApi.Controllers
{
    //[Authorize]
    public class TinyPngController : ApiController
    {
        [HttpPost]
        [Route("TinyPng/Compress")]
        public async Task<IHttpActionResult> Compress(PostData postData)
        {
            try
            {
                var bytes = Convert.FromBase64String(postData.Image);
                var lstKeys = await TinifyHelperExtensions.GenerateTinifyApiKeysLocalAsync();
                var tinify = new TinifyImage(lstKeys, bytes);
                var bytes2 = await tinify.CompressAsync();
                var result = new
                {
                    compressPercent = $"{bytes.Length} -> {bytes2.Length} ({(1-(double)bytes2.Length / bytes.Length).ToString("0.##")}%)",
                    image = Convert.ToBase64String(bytes2)
                };
                return Ok(result) ;
                
            }
            catch (Exception exp)
            {
                return new System.Web.Http.Results.ExceptionResult(exp, this);
            }
        }
        // GET api/values
        
    }
}
