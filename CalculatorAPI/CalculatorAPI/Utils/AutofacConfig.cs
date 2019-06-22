using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using System.Web.Mvc;
using CalculatorAPI.Models;
using System.Configuration;
using System.IO;

namespace CalculatorAPI.Utils
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            
            var path = "Data Source ="+Path.Combine(AppDomain.CurrentDomain.BaseDirectory,ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            builder.RegisterType<ADOManager>().As<IConnectionManager>().WithParameter("connectionString",path).SingleInstance();

            return builder.Build();
        }
    }
}