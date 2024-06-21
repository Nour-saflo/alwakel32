using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Wakel_Pro_move_1.Core
{
    public static class ConnectionString
    {

        public static string GetConnectionString()
        {
            string metadata = "res://*/Model.AlwakelDataBase.csdl|res://*/Model.AlwakelDataBase.ssdl|res://*/Model.AlwakelDataBase.msl";
            string provider = "System.Data.SqlClient";
            string providerConnectionString = "data source=.;initial catalog=Alwakel;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

            return $"metadata={metadata};provider={provider};provider connection string=\"{providerConnectionString}\"";
        }
    }
}
