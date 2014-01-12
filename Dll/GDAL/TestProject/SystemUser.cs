using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDAL;
namespace TestProject
{
    class SystemUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public override string ToString()
        {
            return "SystemAccounts";
        }
        DB db;
        public SystemUser()
        {
            db = new DB(@"workstation id=192.168.0.1\mssql;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1\mssql;persist security info=False;initial catalog=FDB");
        }
        public void ChangePassword(string NewPassword,string ConfirmNewPassword ,out SystemMessages msg)
        {
            if (Login())
            {
                if (NewPassword == ConfirmNewPassword)
                {
                    Password = NewPassword;
                    db.Update(this);
                    msg = SystemMessages.UpdateSuccess;
                }
                else { msg = SystemMessages.PasswordFail; }
            }
            else { msg = SystemMessages.PasswordFail; }
        }


        public bool Login()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@Username", Username);
            dic.Add("@Password", Password);
            List<SystemUser> lst = db.Search(this.GetType(), dic).Cast<SystemUser>().ToList();

            if (lst.Count > 0) 
            {
                ID = lst[0].ID;
                Username = lst[0].Username;
                Password = lst[0].Password;
                LastLogin = lst[0].LastLogin;
                return true; 
            } 
            else
            { 
                return false; 
            }
        }


        public void Logout()
        {

        }


        public void ResetPassword(string UserName)
        {
            
        }


        public void ChangeProfileImage()
        {

        }
    }
}
