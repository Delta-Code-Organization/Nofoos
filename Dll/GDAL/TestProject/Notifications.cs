using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDAL;
namespace TestProject
{
    class Notifications 
    {
        DB D = new DB(@"workstation id=192.168.0.1\mssql;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1\mssql;persist security info=False;initial catalog=FDB");

        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationText { get; set; }
        public string RedirectURL { get; set; }
        public bool IsNew { get; set; }
        public int Insert()
        { 
            return 0; 
        }
        public void Update() { }
        public void Delete() { }
        public IObject GetByID(int _ID) 
        {
            return D.GetByID(_ID, this.GetType());
             
        }
        public override string ToString()
        {
            return this.GetType().Name;
        }

        public List<IObject> SearchNotifications(Dictionary<string, object> _d) {
            return  D.Search(this.GetType(), _d);
        }

        public List<IObject> ExecuteList(string SPName , Dictionary<string, object> _d)
        {
            return D.ExecuteList(SPName,this.GetType(), _d);
        }

        public IObject ExecuteObject(string SPName , int _ID)
        {
            return D.ExecuteObject(SPName,_ID, this.GetType());

        }
    }
}
