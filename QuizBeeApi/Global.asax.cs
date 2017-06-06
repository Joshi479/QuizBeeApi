using Owin;
using QuizBee.Infrastructure;
using QuizBeeApi.Configuration;
using System;
using System.Web.Http;

namespace QuizBeeApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(QuizBeeApiConfig.Register);
        }

       
    }
}