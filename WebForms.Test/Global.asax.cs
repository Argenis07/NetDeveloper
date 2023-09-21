using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebForms.Test
{
    public class Global : HttpApplication
    {
        private ILog _logger;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            log4net.Config.XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(typeof(Global));
            _logger.Debug("Logger activado");

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is ThreadAbortException)
                return;
            _logger = LogManager.GetLogger(typeof(Global));
            _logger.Error(ex);
            Response.Redirect("~/Error.aspx");
        }
    }
}