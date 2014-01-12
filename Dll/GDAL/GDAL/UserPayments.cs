using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
using System.Reflection;

namespace GDAL
{
    public class UserPayments
    {
        #region Variables
        DB db = new DB();
        #endregion Variables
        #region Properties
        public int ID { set; get; }
        public DateTime Date { set; get; }
        public float Amount { set; get; }
        public int SessionID { set; get; }
        public string PaymentReferenceCode { set; get; }
        public string PaymentDescription { set; get; }
        public int Status { get; set; }
        public int UserID { get; set; }
        #endregion Properties

        public UserPayments()
        {
            db = new DB(); 
        }

        public override string ToString()
        {
            return "UserPayments";
        }

        public void MakePayment(out SystemMessages Msg)
        {
            db.Insert(this);
            Msg = SystemMessages.PaymentCreatedSuccessfully;
        }


        public List<UserPayments> Search(Dictionary<string, object> dic)
        {
            return db.Search(this.GetType(), dic).Cast<UserPayments>().ToList();
        }
        
        public List<UserPayments> GetAvailablePayments(UserPayments UserPayment)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("UserID", UserID);
            return db.Search(UserPayment.GetType(), dic).Cast<UserPayments>().ToList();
        }

        public void RefundPayment(out SystemMessages Msg)
        {
            db.Update(this);
            Msg = SystemMessages.PaymentRefunded;
        }
    }
}