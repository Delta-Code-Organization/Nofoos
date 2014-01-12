using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nofos.Models
{
    public class CustomDoctors
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageLink { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public int TotalSession { get; set; }
        public double TotalScore { get; set; }
        public int Status { get; set; }
        public double CostPercentage { get; set; }
        public string sessionInfo { get; set; }
        public string SP1 { get; set; }
        public string SP2 { get; set; }
        public string SP3 { get; set; }
        public string Phone { get; set; }
        public string Language { get; set; }
    }

    public class CustomUsers
    {
        public int UserID { get; set; }
        public string DisplayName { get; set; }
       
    }

    public class CustomUsersession
    {
        public int ID { set; get; }
        public int SessionID { set; get; }
        public string OTSessionID { get; set; }
        public int Status { set; get; }

        public CustomSession Session { get; set; }
        public CustomUsers Users { get; set; }
    }

    public class CustomSession
    {
        public int ID { get; set; }
        public CustomDoctors Doctors { get; set; }
        public CustomUsers Users { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Duration { get; set; }
        public string SP { get; set; }
        public double Price { get; set; }
        public int Type { get; set; }
        public int ElapsedTime { get; set; }
        public int Status { get; set; }
        public string AvOrNot { get; set; }
    }
}