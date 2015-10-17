using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionConfig
{
    public class SolutionConfigSettings
    {
        public const FlightsDataProvider SolutionMode = FlightsDataProvider.MyApi;
    }

    public enum FlightsDataProvider
    {
        MyApi,
        Google
    }
}
