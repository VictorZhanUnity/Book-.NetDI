﻿using Examples.Common.Services;
using System;
using Unity;

namespace WebFormsDemo.Unity
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new UnityContainer();
            Application["Container"] = container; // 把容器物件保存在共用變數裡

            // 註冊型別
            container.RegisterType<IMessageService, MessageService>();
        }
    }
}