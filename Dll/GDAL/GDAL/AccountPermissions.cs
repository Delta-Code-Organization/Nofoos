using System;
using GDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
    public class AccountPermissions
    {
        #region Variables
        DB Gate = new DB();
        #endregion Variables
        #region Properties
        public int ID { set; get; }
        public int AccountID { set; get; }
        public int PermissionGroup { set; get; }
        #endregion Properties
    }
}