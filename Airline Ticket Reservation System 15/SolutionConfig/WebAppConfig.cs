using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConfig
{
    public class WebAppConfig
    {
        public static string ApplicationName { get { return ConfigurationManager.AppSettings["ApplicationName"]; } }
    }
}
