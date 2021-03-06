﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.DrawingCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using Mango.Core;
using Mango.Web.Common;

namespace Mango.Web.Areas.Account.Controllers
{
    [Area("Account")]
    public class LoginController : Controller
    {
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public void OutLogin()
        {
            //清除会话信息
            HttpContext.Session.Clear();
            Response.Redirect("/account/login");
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Models.AccountLoginRequestModel requestModel)
        {
            string postData = JsonConvert.SerializeObject(requestModel);
            var apiResult = HttpCore.HttpPost("/api/Account/Login", postData);
            if (apiResult.Code == 0)
            {
                Models.AccountDataModel model = JsonConvert.DeserializeObject<Models.AccountDataModel>(apiResult.Data.ToString());
                //将登陆的用户Id存储到会话中
                HttpContext.Session.SetInt32("AccountId", model.AccountId);
                HttpContext.Session.SetInt32("GroupId", model.GroupId);
                HttpContext.Session.SetString("AccountName", model.AccountName);
                HttpContext.Session.SetString("NickName", model.NickName);
                HttpContext.Session.SetString("HeadUrl", model.HeadUrl);
                HttpContext.Session.SetString("AccountLoginData", apiResult.Data.ToString());
            }
            return Json(apiResult);
        }
    }
}