using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
    public class SessionRates
    {
        #region Variables
        DB db = new DB();
        #endregion

        #region Properties
        public int ID { get; set; }
        public int UserID { get; set; }
        public int SessionID { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
        #endregion

        public SessionRates()
        {
            db = new DB();
        }

        public override string ToString()
        {
            return "SessionRates";
        }

        public void RateSession(out SystemMessages Msg)
        {
            db.Insert(this);
            Msg = SystemMessages.GroupRatedSuccessfully;
        }
    }
}
