using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDAL;

namespace TestProject
{
    class SystemAdmin : SystemUser
    {
        public int Status { get; set; }
        public override string ToString()
        {
            return "SystemAccounts";
        }
        DB db;
        public SystemAdmin() {
            db = new DB(@"workstation id=192.168.0.1\mssql;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1\mssql;persist security info=False;initial catalog=FDB");
        }
        public void Create(out SystemMessages Msg)
        {
            SystemAdmin SysAdmin = new SystemAdmin();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@Username", Username);
            if (db.Search(this.GetType(), Dic).Count == 0) {
                db.Insert(this);
                Msg = SystemMessages.NewProfileCreated;
            }
            else
            {
                Msg = SystemMessages.AccountAlreadyExist;
            }
            
        }
        public void Disable(out SystemMessages Msg)
        {
            
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@Username", Username);
            var TestSysAdmin=db.Search(this.GetType(), Dic).Cast<SystemAdmin>().ToList();
            if (TestSysAdmin.Count!=0)
            {
                SystemAdmin SysAdmin = new SystemAdmin();
                SysAdmin = TestSysAdmin[0];
                if (SysAdmin.Status != 0)
                {
                    SysAdmin.Status = (int)GDAL.Status.Disabled;
                    db.Update(SysAdmin);
                    Msg = SystemMessages.UpdateSuccess;
                }
                else
                {
                    Msg = SystemMessages.AccountAlreadyDisabled;
                }
            }
            else
            {
                Msg = SystemMessages.Error;
            }
        }
        public List<SystemAdmin> Search(Dictionary<string, object> dic)
        {
            return db.Search(this.GetType(), dic).Cast<SystemAdmin>().ToList();
        }
    }
}
