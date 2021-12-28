﻿using System;
using Ch07.Common.Contracts;
using Ch07.Common.Services;
using Unity.Injection;
using Unity;

namespace Ex07.OverrideAutoWiring
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            container.RegisterType<IMessageService, EmailService>("email");
            container.RegisterType<IMessageService, SmsService>("sms");
            //container.RegisterType<NotificationManager>(
            //    new InjectionConstructor(
            //        new ResolvedParameter<IMessageService>("email"),
            //        new ResolvedParameter<IMessageService>("sms")
            //    )
            //);

            //container.RegisterType<NotificationManager>(
            //    new InjectionConstructor(
            //        new ResolvedParameter<IMessageService>("email"),
            //        500
            //    ));

            container.RegisterType<NotificationManager>(
                new InjectionConstructor(new ResolvedParameter<IMessageService>("email")),
                new InjectionProperty("Timeout", 500));

            var obj = container.Resolve<NotificationManager>();
            Console.WriteLine("Timeout 屬性值 = " + obj.Timeout);
        }
    }

    class NotificationManager
    {
        public NotificationManager()
        {
            Console.WriteLine("呼叫了無參數的建構函式。");
        }

        public NotificationManager(IMessageService svc)
        {
            Console.WriteLine("呼叫了一個參數的建構函式。");
        }
        public NotificationManager(IMessageService svc1, IMessageService svc2)
        {
            Console.WriteLine("呼叫了兩個參數的建構函式。");
        }

        public NotificationManager(IMessageService svc, int timeout)
        {
            Console.WriteLine("示範傳入需解析的型別以及簡單型別。timeout={0}", timeout);
        }

        public int Timeout { get; set; }
    }
}
