using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
    public class Doctors_Admins
    {
        #region Variables
        DB Gate = new DB();
        #endregion Variables
        #region Properties
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string ProfileImageLink { set; get; }
        public string Title { set; get; }
        public string Bio { set; get; }
        public int TotalSession { set; get; }
        public float TotalScore { set; get; }
        public float SessionPrice { set; get; }
        public float CostPercentage { set; get; }
        public string Type { set; get; }
        public string SP1 { get; set; }
        public string SP2 { get; set; }
        public string SP3 { get; set; }
        #endregion Properties
    }
}