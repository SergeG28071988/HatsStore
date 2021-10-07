﻿using HatsStore.App_Start;
using System;
using System.Web.Optimization;
using System.Web.Routing;

namespace HatsStore
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}