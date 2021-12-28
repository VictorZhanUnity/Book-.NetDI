﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Examples.Common.Services;

namespace WcfDemo.ServerApp.Unity
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private IMessageService _helloService;

        public Service1(IMessageService helloService)
        {
            _helloService = helloService;
        }

        public string Hello()
        {
            return _helloService.Hello("DI in WCF service.");
        }
    }
}
