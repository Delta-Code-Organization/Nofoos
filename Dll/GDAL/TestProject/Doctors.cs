using GDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
    class Doctors : SystemUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageLink { get; set; }
        public string Title { get;set;}
        public string Bio { get; set; }
        public int TotalSession { get; set; }
        public float TotalScore { get; set; }
        public int status { get; set; }
        public float SessionPrice { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public float CostPercentage { get; set; }
        public string V_test { get; set; }


        public override string ToString()
        {
            return "Doctors_Admins";
        }
        DB db;
        public Doctors()
        {
            db = new DB(@"workstation id=192.168.0.1\mssql;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1\mssql;persist security info=False;initial catalog=FDB");
        }

        public void AddCertificate(Certificates certificate,out SystemMessages msg)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("DoctorID", null);
            dic.Add("CertificateDate", null);
            dic.Add("ValidationDate", null);
            dic.Add("CertificateName", certificate.CertificateName);
            dic.Add("Description", null);
            dic.Add("PhotocopyLink", null);
            var cer = db.Search(certificate.GetType(),dic).Cast<Certificates>().ToList();
             if(cer.Count>0){
                     db.Insert(certificate);
                     msg = SystemMessages.CertificateAddedSuccessfully;
             }
             else { msg = SystemMessages.CertificateAlreadyExist; }

        }

        public void RemoveCertificate(Certificates certificate,out SystemMessages msg) {
            try
            {
                db.Delete(certificate);
                msg = SystemMessages.CertificateDeletedSuccessfully;
            }
            catch {msg=SystemMessages.Error; }
        }


        public void StartSession(Sessions session,out SystemMessages msg) 
        {
           
            session = (Sessions)db.GetByID(session.ID, session.GetType());
            if (session.Status != (int)Status.Started)
            {
                session.Status = (int)Status.Started;
                db.Update(session);
                msg = SystemMessages.SessionStarted;
            }
            else
            {
                msg = SystemMessages.SessionAlreadyOpenned;
            }
        }

      

        public void EndSession(Sessions session, out SystemMessages msg)
        {
            session = (Sessions)db.GetByID(session.ID, session.GetType());
            if (session.Status != (int)Status.Ended)
            {
                session.Status = (int)Status.Ended;
                db.Update(session);
                msg = SystemMessages.SessionEnded;
            }
            else
            {
                msg = SystemMessages.SystemAlreadyEnded;
            }
        }

        public void CreateProfile(out SystemMessages msg)  {
            Doctors test = new Doctors();
            Dictionary<string,object> dic=new Dictionary<string,object>();
            dic.Add("@ID",null);    
            dic.Add("@FirstName",null);
            dic.Add("@LastName",null);
            dic.Add("@ProfileImageLink",null);
            dic.Add("@title",null);
            dic.Add("@bio",null);
            dic.Add("@TotalSessions", null);
            dic.Add("@TotalScore",null);
            dic.Add("@SessionPrice",null);
            dic.Add("@CostPercentage",null);
            dic.Add("@type","Doctor");
            dic.Add("@Username",Username);
            dic.Add("@Password",null);
            dic.Add("@Status", null);
           var TestDoctor = db.Search(this.GetType(), dic).Cast<Doctors>().ToList();
           if (TestDoctor.Count == 0)
           {
               db.Insert(this);
               msg = SystemMessages.NewProfileCreated;
           }
           else { msg = SystemMessages.ErrorCreatingProfile; }
            
        }

        public void UpdateProfile(out SystemMessages msg) {
            try
            {
                db.Update(this);
                msg = SystemMessages.UpdateSuccess;
            }
            catch {
                msg = SystemMessages.Error;
            }
        }

        public void Disable(out SystemMessages msg)
        {
            Doctors test = new Doctors();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@type", "Doctor");
            dic.Add("@Username", Username);
            var TestDoctor = db.Search(this.GetType(), dic).Cast<Doctors>().ToList();
            if (TestDoctor.Count > 0)
            {
                test = TestDoctor[0];
                if (test.status == (int)Status.Disabled)
                {
                    msg = SystemMessages.AccountAlreadyDisabled;
                }
                else 
                {
                    test.status = (int)GDAL.Status.Disabled;
                    db.Update(test);
                    msg = SystemMessages.UpdateSuccess;
                }
            }
            else { msg = SystemMessages.Empty; }

        }

        public List<Doctors> Search(Dictionary<string,object> dic) {
           return  db.Search(this.GetType(), dic).Cast<Doctors>().ToList();
        }

        public List<Certificates> GetMyCertificates(Certificates certificate) {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("DoctorID", certificate.DoctorID);
                dic.Add("CertificateDate", null);
                dic.Add("ValidationDate", null);
                dic.Add("CertificateName", null);
                dic.Add("Description", null);
                dic.Add("PhotocopyLink", null);
            return  db.Search(certificate.GetType(), dic).Cast<Certificates>().ToList();
        }

}
}
