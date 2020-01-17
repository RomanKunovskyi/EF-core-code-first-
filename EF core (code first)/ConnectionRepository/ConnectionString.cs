using System;
using System.Collections.Generic;
using System.Text;

namespace EF_core__code_first_.ConnectionRepository
{
    class ConnectionString
    {
        private ConnectionString()
        {
        }

        public static string GetDefaultConnectionString()
        {
            return GetLocalConnectionString();
        }

        public static string GetLocalConnectionString()
        {
            return "Data Source=DESKTOP-9MS6PJH;Initial Catalog=Shop;Integrated Security=SSPI";
        }
    }
}
