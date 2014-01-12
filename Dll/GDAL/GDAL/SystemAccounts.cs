using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
    public class SystemAccounts
    {
        #region Variables
        DB db = new DB();
        #endregion Variables
        #region Properties
        public int ID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public DateTime LastLogin { set; get; }
        public int Status { get; set; }

        #endregion Properties

        public override string ToString()
        {
            return "SystemAccounts";
        }

        public SystemAccounts CreateAdmin(out SystemMessages Msg)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@Username", this.Username);
            SystemAccounts Admin = db.Search(this.GetType(), Dic).Cast<SystemAccounts>().FirstOrDefault();
            if (Admin != null)
            {
                Msg = SystemMessages.UsernameExist;
                return Admin;
            }
            else
            {
                db.Insert(this);
                Msg = SystemMessages.NewProfileCreated;
                return db.Search(this.GetType(), Dic).Cast<SystemAccounts>().FirstOrDefault();
            }
        }

        public SystemAccounts Login(out SystemMessages Msg)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@Username", this.Username);
            Dic.Add("@Password", this.Password);
            var Admin = db.ExecuteList("SystemAccountsCustomSearch", this.GetType(), Dic).Cast<SystemAccounts>().ToList();
            if (Admin.Count != 0)
            {
                Msg = SystemMessages.LoginSuccess;
                return Admin[0];
            }
            else
            {
                Msg = SystemMessages.LoginFailed;
                return new SystemAccounts();
            }
        }
    }
}