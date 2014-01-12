using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDAL;
namespace TestProject
{
    class Users:SystemUser
    {
        public string ProfileImageLink { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public int Country { get; set; }
        public int Language { get; set; }
        public float Balance { get; set; }
        public int Status { get; set; }
        //Virtual Col
        public int V_Age { get; set; }
        DB db;
        public override string ToString()
        {
            return "Users";
        }
        public Users() 
        {
            db = new DB(@"workstation id=192.168.0.1\mssql;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1\mssql;persist security info=False;initial catalog=FDB");
        }

        public void UpdateProfile(out SystemMessages msg) {
            try
            {
                db.Update(this);
                msg = SystemMessages.UpdateSuccess;
            }
            catch
            {
                msg = SystemMessages.Error;
            }
        }

        public void Disable(out SystemMessages msg)
        {
            
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@ID", null);
            dic.Add("@UserName", Username);
            dic.Add("@DisplayName", null);
            dic.Add("@ProfileImageLink", null);
            dic.Add("@Gender", null);
            dic.Add("@DateOfBirthFrom", null);
            dic.Add("@DateOfBirthTo", null);
            dic.Add("@Password", null);
            dic.Add("@Country", null);
            dic.Add("@Language", null);
            dic.Add("@Balance", null);
            dic.Add("@Status", null);
            Users User = new Users();
            var TestUser = db.Search(this.GetType(), dic).Cast<Users>().ToList();
            if (TestUser.Count != 0)
            {
                User =TestUser[0];
                this.Balance = User.Balance;
                this.Country = User.Country;
                this.DateofBirth = User.DateofBirth;
                this.DisplayName = User.DisplayName;
                this.Gender = User.Gender;
                this.ID = User.ID;
                this.Language = User.Language;
                this.LastLogin = User.LastLogin;
                this.Password = User.Password;
                this.ProfileImageLink = User.ProfileImageLink;
                this.Status = User.Status;
                this.Username = User.Username;
                if (this.Status != 0)
                {
                    this.Status = (int)GDAL.Status.Disabled;
                    db.Update(this);
                    msg = SystemMessages.UpdateSuccess;
                }
                else { msg = SystemMessages.AccountAlreadyDisabled; }
            }
            else { msg = SystemMessages.Error; }
        }

        public void Register(out SystemMessages msg)
        {
            Users test = new Users();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@ID", null);
            dic.Add("@UserName", Username);
            dic.Add("@DisplayName", null);
            dic.Add("@ProfileImageLink", null);
            dic.Add("@Gender", null);
            dic.Add("@DateOfBirthFrom", null);
            dic.Add("@DateOfBirthTo", null);
            dic.Add("@Password", null);
            dic.Add("@Country", null);
            dic.Add("@Language", null);
            dic.Add("@Balance", null);
            dic.Add("@Status",null);
            var TestUser = db.Search(this.GetType(), dic).Cast<Users>().ToList();
            if (TestUser.Count == 0)
            {
                db.Insert(this);
                msg = SystemMessages.NewProfileCreated;
            }
            else { msg = SystemMessages.ErrorCreatingProfile; }

        }

        public List<Users> Search(Dictionary<string, object> dic)
        {
            return db.Search(this.GetType(), dic).Cast<Users>().ToList();
        }

    }
}
