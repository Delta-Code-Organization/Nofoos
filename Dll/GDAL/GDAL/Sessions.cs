using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace GDAL
{
    public class Sessions
    {
        #region Variables
        DB db = new DB();
        #endregion
        #region Proprties
        public int ID { get; set; }
        public int TherapistID { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public int SP { get; set; }
        public double Price { get; set; }
        public int Type { get; set; }
        public int ElapsedTime { get; set; }
        public int Status { get; set; }
        public string RemainingToStart
        {
            get
            {
                string _rem = "";
                TimeSpan RemValue = Date - DateTime.UtcNow;
                if (RemValue.Days > 0)
                    _rem += RemValue.Days + " Days, ";
                if (RemValue.Hours > 0)
                    _rem += RemValue.Hours + " Hours , ";
                if (RemValue.Minutes > 0)
                    _rem += RemValue.Minutes + " Minutes ";
                if (_rem == "")
                {
                    if (RemValue.Days < 0)
                        _rem += Math.Abs(RemValue.Days) + " Days, ";
                    if (RemValue.Hours < 0)
                        _rem += Math.Abs(RemValue.Hours) + " Hours , ";
                    if (RemValue.Minutes < 0)
                        _rem += Math.Abs(RemValue.Minutes) + " Minutes ";
                    _rem += " Ago";
                }
                else
                    _rem += " Left";
                return _rem;
            }
        }
        public string RemainingToStartAr
        {
            get
            {
                string _rem = "";
                TimeSpan RemValue = Date - DateTime.UtcNow;
                if (RemValue.Days > 0)
                    _rem += RemValue.Days + " يوم, ";
                if (RemValue.Hours > 0)
                    _rem += RemValue.Hours + " ساعه , ";
                if (RemValue.Minutes > 0)
                    _rem += RemValue.Minutes + " دقيقه ";
                if (_rem == "")
                {
                    if (RemValue.Days < 0)
                        _rem += Math.Abs(RemValue.Days) + " يوم, ";
                    if (RemValue.Hours < 0)
                        _rem += Math.Abs(RemValue.Hours) + " ساعه , ";
                    if (RemValue.Minutes < 0)
                        _rem += Math.Abs(RemValue.Minutes) + " دقيقه ";
                    _rem += " مضت";
                }
                else
                    _rem += " متبقيه";
                return _rem;
            }
        }
        public Doctors Therapist
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ID", TherapistID);
                return new Doctors().Search(dic)[0];
            }
        }
        public List<Users> Users
        {
            get
            {
                UserSessions US = new UserSessions();
                List<UserSessions> LOUS = new List<UserSessions>();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@SessionID", ID);
                LOUS = US.Search(dic);
                Users U = new Users();
                List<Users> LOU = new List<Users>();
                foreach (UserSessions LUS in LOUS)
                {

                    dic.Clear();
                    dic.Add("@ID", LUS.UserID);
                    LOU = U.Search(dic);
                }
                return LOU;
            }
        }
        #endregion
        public Sessions()
        {
            db = new DB();
        }
        public override string ToString()
        {
            return "Sessions";
        }
        public List<Sessions> Search(Dictionary<string, object> Dic)
        {
            return db.Search(this.GetType(), Dic).Cast<Sessions>().ToList();
        }

        public List<Sessions> GetAllSessions()
        {
            return db.ExecuteList("GetAllSessions", this.GetType(), new Dictionary<string, object>()).Cast<Sessions>().ToList();
        }

        public void Purchase(int SessionID, int UserID)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", SessionID);
            Sessions TestSession = Search(Dic)[0];
            this.Date = TestSession.Date;
            this.Duration = TestSession.Duration;
            this.ElapsedTime = TestSession.ElapsedTime;
            this.ID = SessionID;
            this.Price = TestSession.Price;
            this.SP = TestSession.SP;
            this.Status = 8;
            this.TherapistID = TestSession.TherapistID;
            this.Type = TestSession.Type;
            db.Update(this);
            UserSessions US = new UserSessions();
            US.OTSessionID = "";
            US.SessionID = SessionID;
            US.Status = 10;
            US.UserID = UserID;
            US.Insert();
            Dic.Clear();


        }

        public void ReschdualSession()
        {
            db.Update(this);
        }

        public void Update()
        {
            db.Update(this);
        }

        public void Add()
        {
            db.Insert(this);
        }

        public Sessions GetLastResqadualSession()
        {
            return db.ExecuteList("GetLastResSession", this.GetType(), new Dictionary<string, object>()).Cast<Sessions>().ToList().FirstOrDefault();
        }

        public void Delete()
        {
            db.Delete(this);
        }

        public void PurchaseGroup(int SessionID, int UserID)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", SessionID);
            Sessions TestSession = Search(Dic)[0];
            this.Date = TestSession.Date;
            this.Duration = TestSession.Duration;
            this.ElapsedTime = TestSession.ElapsedTime;
            this.ID = SessionID;
            this.Price = TestSession.Price;
            this.SP = TestSession.SP;
            this.Status = 10;
            this.TherapistID = TestSession.TherapistID;
            this.Type = TestSession.Type;
            db.Update(this);
            UserSessions US = new UserSessions();
            US.OTSessionID = "";
            US.SessionID = SessionID;
            US.Status = 10;
            US.UserID = UserID;
            US.Insert();
        }

        public List<Sessions> GetPendingSessions(int _UserID)
        {
            List<UserSessions> lst = new List<UserSessions>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@UserID", _UserID);
            lst = new UserSessions().Search(dic);
            List<Sessions> LOUS = new List<Sessions>();
            foreach (UserSessions Session in lst)
            {
                dic.Clear();
                dic.Add("@ID", Session.SessionID);
                Sessions CurrentSession = new Sessions();
                CurrentSession = CurrentSession.Search(dic)[0];
                if (CurrentSession.Status == 5 || CurrentSession.Status == 8 || CurrentSession.Status == 12 || CurrentSession.Status == 2)
                {
                    LOUS.Add(CurrentSession);
                }
            }
            return LOUS.OrderBy(p => p.Date).ToList();
        }

        public List<Sessions> GetPendingSessionsD(int _DocID)
        {
            List<Sessions> lst = new List<Sessions>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@TherapistID", _DocID);
            lst = new Sessions().Search(dic);
            List<Sessions> LOUS = new List<Sessions>();
            foreach (Sessions Session in lst)
            {



                if (Session.Status == 5 || Session.Status == 8 || Session.Status == 2)
                {
                    LOUS.Add(Session);
                }
            }
            return LOUS.OrderBy(p => p.Date).ToList();
        }


        public Sessions GetlastByDoctorId(int DocID)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@DocID", DocID);
            return db.ExecuteList("GetLastCreatedSession", this.GetType(), Dic).Cast<Sessions>().FirstOrDefault();
        }

        public List<Sessions> Filter(Dictionary<string, object> Dic)
        {
            return db.ExecuteList("CustomNewFilter", this.GetType(), Dic).Cast<Sessions>().OrderBy(x => x.Date).ToList();
        }

        public void CancelSession()
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", this.ID);
            Sessions S = new Sessions();
            S = S.Search(Dic)[0];
            S.Status = 7;
            db.Update(S);
        }

        public List<Sessions> GetSessionNow()
        {
            DateTime Timenow = DateTime.UtcNow;
            DateTime TimeAfterThirty = DateTime.UtcNow.AddMinutes(30);
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@FromDate", Timenow);
            Dic.Add("@ToDate", TimeAfterThirty);
            return db.ExecuteList("FindSessionNow", this.GetType(), Dic).Cast<Sessions>().OrderBy(x => x.Date).ToList();
        }

        public void SetTemporary()
        {
            this.Status = 13;
            db.Update(this);
            System.Threading.Thread th = new System.Threading.Thread(delegate()
            {
                NotPaidAfterFiveMinutes(this.ID);
            });
            th.Start();
        }

        public void NotPaidAfterFiveMinutes(int SessionID)
        {
            TimeSpan TimeToSleep = new TimeSpan(0, 5, 0);
            System.Threading.Thread.Sleep(TimeToSleep);
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", this.ID);
            Sessions S = new Sessions();
            List<Sessions> LOS = new List<Sessions>();
            LOS = db.Search(typeof(Sessions), Dic).Cast<Sessions>().ToList();
            if (LOS.Count != 0)
            {
                S = LOS.SingleOrDefault();
                if (S.Status != 8 && S.Status != 5 && S.Status != 2 && S.Status != 7)
                {
                    this.Status = 6;
                    db.Update(this);
                }
            }
        }

        public List<Sessions> CheckOverlapping(DateTime StartDate, int Duration, int DID)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@StartDate", StartDate);
            Dic.Add("@Duration", Duration);
            Dic.Add("@DID", DID);
            return db.ExecuteList("CheckOverlapping", this.GetType(), Dic).Cast<Sessions>().ToList();
        }
    }
}