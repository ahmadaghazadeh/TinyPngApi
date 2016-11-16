﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyPngApi.Core
{
    public class TinifyApiKeyPair
    {
        public string Key { get; set; }
        public int CompressCount { get; set; }
        public int CompressRemainCount => TinifyImage.MaxCompressCount - CompressCount;

        public static TinifyApiKeyPair Create(string key, int count)
        {
            return new TinifyApiKeyPair()
            {
                Key = key,
                CompressCount = count
            };
        }
    }
}