using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDAL
{
    public class Certificates
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public DateTime CertificateDate { get; set; }
        public DateTime ValidationDate { get; set; }
        public string CertificateName { set; get; }
        public string Description { set; get; }
        public string PhotocopyLink { set; get; }

        public Certificates()
        { }
    }
}
