using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPKG.Web.Config
{
    public class WebConfiguration
    {
        public DataConfiguration Data { get; set; }
    }

    public class DataConfiguration
    {
        public ConnectionString[] ConnectionStrings { get; set; }
    }

    public class ConnectionString
    {
        public string Name { get; set; }
        public string Connection { get; set; }
    }
}
