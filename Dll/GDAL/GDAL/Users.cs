using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GDAL
{
    public class Users:SystemUser
    {
        public string ProfileImageLink { get; set; }
        public string DisplayName { get; set; }
        public string HashCode { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Gender { get; set; }
        public int Country { get; set; }
        public int Language { get; set; }
        public int Status { get; set; }
        public int SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        
        DB db;
        public override string ToString()
        {
            return "Users";
        }
        public Users() 
        {
            db = new DB();
        }

        public void UpdateProfile(out SystemMessages msg)
        {
            db.Update(this);
            msg = SystemMessages.UpdateSuccess;
        }

        public void Disable(out SystemMessages msg)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Username", Username);
            Users User = new Users();
            var TestUser = db.Search(this.GetType(), dic).Cast<Users>().ToList();
            if (TestUser.Count != 0)
            {
                User =TestUser[0];
                
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
                this.SecretQuestion = User.SecretQuestion;
                this.SecretAnswer = User.SecretAnswer;
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
            dic.Add("Username", Username);
            var TestUser = db.Search(this.GetType(), dic).Cast<Users>().ToList();
            if (TestUser.Count == 0)
            {
                db.Insert(this);
                msg = SystemMessages.NewProfileCreated;
            }
            else { msg = SystemMessages.UsernameExist; }
        }

        public List<Users> Search(Dictionary<string, object> dic)
        {
            return db.Search(this.GetType(), dic).Cast<Users>().ToList();
        }

        public List<Users> CustomSearch(Dictionary<string,object> Dic)
        {
            return db.ExecuteList("SearchUsers", this.GetType(), Dic).Cast<Users>().ToList();
        }

        public void DeleteUser(Users U)
        {
            db.Delete(U);
        }

        public List<Users> SelectAll() { 
        
        return db.ExecuteList("SelectAllUsers",this.GetType(),new Dictionary<string,object>()).Cast<Users>().ToList();
        }

    }
}
