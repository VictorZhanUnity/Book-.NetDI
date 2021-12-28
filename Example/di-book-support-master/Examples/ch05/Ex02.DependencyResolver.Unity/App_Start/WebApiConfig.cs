﻿using System;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Ch05.Common.Services;
using Ex02.DependencyResolver.Unity.Infrastructue;


namespace Ex02.DependencyResolver.Unity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 使用簡易的 MyDependencyResolver 來取代預設的 EmptyResolver
            //config.DependencyResolver = new MyDependencyResolver();

            // 使用 UnityDependencyResolver 來解析
            var container = new UnityContainer();
            var childLifetimeManager = new HierarchicalLifetimeManager();
            container.RegisterType<ICustomerService, CustomerService>(childLifetimeManager);
            var resolver = new UnityDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}
