using GDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDAL;
namespace TestProject
{
    class Sessions
    {
        public int ID { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public Users User { set; get; }
        public int Doctor { set; get; }
        public float UserRating { set; get; }
        public string UserFeedBack { set; get; }
        public DateTime ReserverOn { set; get; }
        public int Status { set; get; }
        DB db;
        public override string ToString()
        {
            return "Session";
        }
        public Sessions() 
        {
            db = new DB(@"workstation id=192.168.0.1\mssql;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1\mssql;persist security info=False;initial catalog=FDB");
        }
        public void Start(out SystemMessages msg) {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@Username", User.Username);
            var TestSession = db.Search(this.GetType(), Dic).Cast<Sessions>().ToList();
            if (TestSession.Count != 0)
            {
                Sessions session = new Sessions();
                session = TestSession[0];
                if (session.Status != (int)GDAL.Status.Ended)
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

           // msg = SystemMessages.Error;
        }
        
        public void Close(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void Rate(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void Search(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void GetUpcomming(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void GetOnline(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void GetPendingForRate(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void Refund(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void Cancel(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void Reschedule(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }

        public void Reserve(out SystemMessages msg)
        {
            msg = SystemMessages.Error;
        }
    }
}
