﻿using System;
using Examples.Common.Services;
using Unity.Attributes;

namespace WebFormsDemo.UnityBuildUp
{
    public partial class Default : System.Web.UI.Page
    {
        [Dependency]
        public IMessageService HelloService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 在網頁上輸出一段字串訊息。訊息內容由 HelloService 提供。
            Response.Write(this.HelloService.Hello("DI in ASP.NET Web Forms!"));
        }
    }
}