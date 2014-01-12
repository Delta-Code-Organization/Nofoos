using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
    public class UserSessions
    {
        #region Variables
        DB db;
        #endregion
        #region Properties
        public int ID { set; get; }
        public int SessionID { set; get; }
        public int UserID { set; get; }
        public string OTSessionID { get; set; }
        public int Status { set; get; }
        #endregion

        public override string ToString()
        {
            return "SessionUser";
        }

        public UserSessions()
        {
            db = new DB();
        }

        public void Update() 
        {
        db.Update(this);
        
        }

        public List<UserSessions> Search(Dictionary<string,object> Dic)
        {
            return db.Search(this.GetType(), Dic).Cast<UserSessions>().ToList();
        }

        public List<UserSessions> GetUpcomming(int UserID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("UserID", UserID);
            dic.Add("Status", 0);
            return db.Search(this.GetType(), dic).Cast<UserSessions>().ToList();
        }

        public void GetOnline(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public List<UserSessions> GetPendingForRate(int UserID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("UserID", UserID);
            dic.Add("status", 2);
            return db.Search(this.GetType(), dic).Cast<UserSessions>().ToList();
        }

        public void Refund(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void Cancel(out SystemMessages msg)
        {
            object O = db.GetByID(ID, this.GetType());
            Type type = O.GetType();
            UserSessions US = new UserSessions();
            if (Convert.ToInt32(type.GetProperty("status").GetValue(O,null)) == (int)GDAL.Status.Canceled)
            {
                msg = SystemMessages.AlreadyCancelled;
            }
            else
            {
                db.Update(this);
                msg = SystemMessages.CancelledSuccessfully;
            }
        }

      

        public void Reserve(out SystemMessages msg)
        {
            db.Insert(this);
            msg = SystemMessages.SessionReserved;
        }


        public List<UserSessions> AdvancedSearch(Dictionary<string, object> Dic)
        {
            return db.ExecuteList("AdvancedSessionSearch", this.GetType(), Dic).Cast<UserSessions>().ToList();
        }

        public List<UserSessions> SelectAll()
        {
            return db.ExecuteList("SelectAllSessions", this.GetType(), new Dictionary<string, object>()).Cast<UserSessions>().ToList();
        }

        public void Insert() 
        {
            db.Insert(this);
        }

        
    }
}
