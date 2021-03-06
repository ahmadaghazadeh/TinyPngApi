﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TinyPngApi.Core;

namespace TinyPngApi.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var lstKeys = await TinifyHelperExtensions.GenerateTinifyApiKeysLocalAsync();
            var bytes = new byte[1];
            var tinify = new TinifyImage(lstKeys, bytes);
            ViewBag.Title = "Home Page";
            ViewBag.CountRemain = tinify.CompressRemainCount().ToString();
            return View();
        }

        public async Task<ActionResult> SyncCompressRemain()
        {
            var lstKeys = await TinifyHelperExtensions.GenerateTinifyApiKeysOnlineAsync();
            await lstKeys.SaveCompressRemainCountAsync();
            var bytes = new byte[1];
            var tinify = new TinifyImage(lstKeys, bytes);
            ViewBag.Title = "Home Page";
            ViewBag.CountRemain = tinify.CompressRemainCount().ToString();
            return View();
        }
    }
}
