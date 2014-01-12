using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDAL
{
    public class Doctors : SystemUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageLink { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public string bioAr { get; set; }
        public int TotalSession { get; set; }
        public double TotalScore { get; set; }
        public int Status { get; set; }
        public double CostPercentage { get; set; }
        public string sessionInfo { get; set; }
        public int SP1 { get; set; }
        public int SP2 { get; set; }
        public int SP3 { get; set; }
        public string Phone { get; set; }
        public int Language { get; set; }
        public string HashCode { get; set; }


        public override string ToString()
        {
            return "Therapist";
        }
        DB db;
        public Doctors()
        {
            db = new DB();
        }

        public void AddCertificate(Certificates certificate, out SystemMessages msg,int DocID)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("CertificateName", certificate.CertificateName);
            dic.Add("DoctorID", DocID);
            var cer = db.Search(certificate.GetType(), dic).Cast<Certificates>().ToList();
            if (cer.Count == 0)
            {
                db.Insert(certificate);
                msg = SystemMessages.CertificateAddedSuccessfully;
            }
            else { msg = SystemMessages.CertificateAlreadyExist; }

        }

        public void RemoveCertificate(Certificates certificate, out SystemMessages msg)
        {
            db.Delete(certificate);
            msg = SystemMessages.CertificateDeletedSuccessfully;
        }

        public void CreateProfile(out SystemMessages msg)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@Username", Username);
            var TestDoctor = db.Search(this.GetType(), dic).Cast<Doctors>().ToList();
            if (TestDoctor.Count == 0)
            {
            
                db.Insert(this);
                msg = SystemMessages.NewProfileCreated;
            }
            else { msg = SystemMessages.ErrorCreatingProfile; }

        }

        public void UpdateProfile(out SystemMessages msg)
        {
            db.Update(this);
            msg = SystemMessages.UpdateSuccess;
        }

        public void Disable(out SystemMessages msg)
        {
            Doctors test = new Doctors();
            Dictionary<string, object> dic = new Dictionary<string, object>();
          
            dic.Add("@Username", Username);
            var TestDoctor = db.Search(this.GetType(), dic).Cast<Doctors>().ToList();
            if (TestDoctor.Count > 0)
            {
                test = TestDoctor[0];
                if (test.Status == (int)GDAL.Status.Disabled)
                {
                    msg = SystemMessages.AccountAlreadyDisabled;
                }
                else
                {
                    test.Status = (int)GDAL.Status.Disabled;
                    db.Update(test);
                    msg = SystemMessages.UpdateSuccess;
                }
            }
            else { msg = SystemMessages.Empty; }

        }

        public List<Doctors> Search(Dictionary<string, object> dic)
        {
            return db.Search(this.GetType(), dic).Cast<Doctors>().ToList();
        }

        public List<Certificates> GetMyCertificates()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("DoctorID", this.ID);
            return db.Search(new Certificates().GetType(), dic).Cast<Certificates>().ToList();
        }
      
       

       public void Delete(Doctors Doc)
        {
            db.Delete(Doc);
        }

        public List<Doctors> SelectAllDoctors()
        {
            return db.ExecuteList("SelectAllDoctors",this.GetType(),new Dictionary<string,object>()).Cast<Doctors>().ToList();
        }

        public List<Doctors> Filter(Dictionary<string,object> Dic)
        { 
            return db.ExecuteList("DoctorFilterSearch",this.GetType(),Dic).Cast<Doctors>().ToList();
        }

        public List<Doctors> FilterBySP(Dictionary<string, object> Dic)
        { 
            return db.ExecuteList("DoctorSpSearch",this.GetType(),Dic).Cast<Doctors>().ToList();
        }

        
    public List<Doctors> GetTopFive()
        {
            return db.ExecuteList("GetFirstFiveDoctors", this.GetType(), new Dictionary<string, object>()).Cast<Doctors>().ToList();
        }

        public List<Doctors> AdvancedFilter(Dictionary<string,object> Dic)
        {
            return db.ExecuteList("AdvancedDoctorFilter", this.GetType(), Dic).Cast<Doctors>().ToList();
        }
        public Certificates GetCertificate(Certificates C)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@ID", C.ID);
            return db.Search(new Certificates().GetType(), dic).Cast<Certificates>().First();
        }

        public void Suspend(int ID)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", ID);
            Dic.Add("@Status", 0);
            db.ExecuteList("UpdateDoctorStatus", this.GetType(), Dic).Cast<Doctors>().ToList();
        }

        public void Approve(int ID,string URL)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", ID);
            Dic.Add("@Status", 1);
            db.ExecuteList("UpdateDoctorStatus", this.GetType(), Dic).Cast<Doctors>().ToList();
            Helper H = new Helper();
            Dic.Clear();
            Dic.Add("@ID", ID);
            List<Doctors> LOD = new List<Doctors>();
            LOD = db.Search(this.GetType(), Dic).Cast<Doctors>().ToList();
            if (LOD.Count != 0)
            {
                Doctors D = new Doctors();
                D = LOD.SingleOrDefault();
                H.SendEmail("Nofoos.com - Account Approved", D.Username, "<h1>Congratulation</h1><br />Our Administrator Approved Your Account Successfully , You Can Update Your Profile Now And Start Creating Sessions ... <br /> <a href='" + URL + "'>Click here</a>");
            }
        }

        public void Unsuspend(int ID)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", ID);
            Dic.Add("@Status", 1);
            db.ExecuteList("UpdateDoctorStatus", this.GetType(), Dic).Cast<Doctors>().ToList();
        }

        public List<Doctors> CustomSearch(Dictionary<string, object> Dic)
        {
            return db.ExecuteList("SearchDoctors", this.GetType(), Dic).Cast<Doctors>().ToList();
        }


    }
}
