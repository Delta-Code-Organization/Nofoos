using System.Collections.Generic;
using System.Linq;

namespace GDAL
{
    public class Admin:SystemUser
    {
        #region Properties
        public int Status { get; set; }
        #endregion
        
        public override string ToString()
        {
            return "SystemAccounts";
        }
        DB db;
        public Admin()
        {
            db = new DB();
        }

       
        
    }
}
