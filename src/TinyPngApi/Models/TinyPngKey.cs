using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyPngApi.Models
{
    public class TinyPngKey
    {
        public string TinyName { get; set; }

        public string ApiKey { get; set; }
        public int CompressRemain { get; set; }
    }
}