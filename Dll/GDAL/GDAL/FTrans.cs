using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
   public class FTrans
    {

        #region Variables
        DB db = new DB();
        #endregion

        #region Proprties
        public int ID { get; set; }
        public int UserID { get; set; }
        public int SessionID { get; set; }
        public double Amount { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentInfo{ get; set; }
        public DateTime Date { get; set; }
        public Doctors Therapist
        {
            get
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("@ID", SessionID);
                Sessions S = new Sessions();
                S=S.Search(dic)[0];
                return S.Therapist;
            }
        }
        #endregion

        public FTrans()
        {
            db = new DB();
        }
        public override string ToString()
        {
            return "FTrans";
        }
        public void Add()
        {
            db.Insert(this);
        }

        public List<FTrans> GetByUserID(int UserID) 
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@UserID", UserID);
            return db.ExecuteList("GetFTransByUID", this.GetType(),Dic).Cast<FTrans>().ToList();
        
        }
        public List<FTrans> GetbyDate(DateTime FromDate, DateTime ToDate) 
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@FromDate", FromDate);
            Dic.Add("@ToDate", ToDate);
            return db.ExecuteList("GetFTransByDate", this.GetType(),Dic).Cast<FTrans>().ToList();
        
        }


    }
}