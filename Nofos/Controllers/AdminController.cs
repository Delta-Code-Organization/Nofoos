using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GDAL;
using Nofos.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Nofos.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult SearchDoctors()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("CPLogin", "Admin");
            }
            Doctors D = new Doctors();
            List<Doctors> LOD = new List<Doctors>();
            LOD = D.SelectAllDoctors();
            ViewBag.Doctors = LOD;
            return View();
        }

        public JsonResult Filter(string Thirapist, int Status)
        {
            Doctors D = new Doctors();
            List<Doctors> LOD = new List<Doctors>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            if (Status == 2500 && Thirapist != "Empty")
            {
                Dic.Add("@DoctorName", Thirapist);
            }
            if (Thirapist == "Empty" && Status != 2500)
            {
                Dic.Add("@Status", Status);
            }
            if (Status != 2500 && Thirapist != "Empty")
            {
                Dic.Add("@Status", Status);
                Dic.Add("@DoctorName", Thirapist);
            }
            if (Status == 2500 && Thirapist == "Empty")
            {
                LOD = D.SelectAllDoctors();
                return Json(LOD);
            }
            LOD = D.AdvancedFilter(Dic);
            return Json(LOD);
        }

        public ActionResult CreateBlogs()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("CPLogin", "Admin");
            }
            return View();
        }

        public string AddPost(string _Title, int _Type, string _TText, string _ImgURL, string _VideoURL)
        {
            Blog B = new Blog();
            B.Title = _Title;
            B.Type = _Type;
            B.Text = _TText;
            if (_ImgURL != " ")
            {
                Image Img = LoadImage(_ImgURL);
                string Path;
                using (Bitmap image = new Bitmap(Img))
                {
                    var fileName = Guid.NewGuid() + ".png";
                    Path = @"/content/img/knowledgebase/" + fileName;
                    string ImagePath = Server.MapPath(Path);
                    image.Save(ImagePath, ImageFormat.Png);
                }
                B.ImageURL = Path;
            }
            else
            {
                B.ImageURL = _ImgURL;
            }

            if (_VideoURL != " ")
            {
                string VideoUrl = _VideoURL.Replace("watch?v=", "embed/");
                B.VideoURl = VideoUrl;
            }
            else
            {
                B.VideoURl = _VideoURL;
            }

            B.Add();
            return "true";

        }

        public ActionResult CreateAdmin()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("CPLogin", "Admin");
            }
            return View();
        }

        public string SubmitAccount(string _Username, string _Password)
        {
            SystemMessages msg;
            SystemAccounts SA = new SystemAccounts();
            SA.LastLogin = DateTime.Now;
            SA.Password = _Password;
            SA.Status = (int)Status.Enabled;
            SA.Username = _Username;
            SA = SA.CreateAdmin(out msg);
            if (msg == SystemMessages.NewProfileCreated)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public void Cancel(int SessionID)
        {
            Sessions S = new Sessions();
            S.ID = SessionID;
            S.CancelSession();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", SessionID);
            List<Sessions> LOS = new List<Sessions>();
            LOS = S.Search(Dic);
            if (LOS.Count != 0)
            {
                S = LOS.SingleOrDefault();
                Helper H = new Helper();
                H.SendEmail("Nofoos.com - Session Cancelled", S.Therapist.Username, "Administrator Cancelled your session with " + S.Users.SingleOrDefault().DisplayName + " .");
                H.SendEmail("Nofoos.com - Session Cancelled", S.Users.SingleOrDefault().Username, "Administrator Cancelled your session with doctor " + S.Therapist.FirstName + " " + S.Therapist.LastName + " .");
            }
        }

        public ActionResult SearchSessions()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("CPLogin", "Admin");
            }
            Doctors D = new Doctors();
            List<Doctors> LOD = new List<Doctors>();
            Users U = new Users();
            List<Users> LOU = new List<Users>();
            LOD = D.SelectAllDoctors();
            LOU = U.SelectAll();
            ViewBag.Doctors = LOD;
            ViewBag.Users = LOU;
            return View();
        }

        public JsonResult FilterSessions(string Date, int DoctorID, int UserID, int Status)
        {
            List<CustomSession> LOCS = new List<CustomSession>();
            List<UserSessions> LOUS = new List<UserSessions>();
            Sessions S = new Sessions();
            Users U = new Users();
            List<Sessions> LOS = new List<Sessions>();
            UserSessions US = new UserSessions();
            List<Users> LOU = new List<Users>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            LOS = S.Search(Dic);
            foreach (Sessions sess in LOS)
            {
                if (Date != "null")
                {
                    string Day = Date.Split('/')[0];
                    string month = Date.Split('/')[1];
                    string year = Date.Split('/')[2];
                    DateTime SessionDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(Day), 0, 0, 0);
                    string DateOnly = sess.Date.ToShortDateString();
                    if (DateOnly != SessionDate.ToShortDateString())
                    {
                        continue;
                    }
                }
                if (DoctorID != 0)
                {
                    if (sess.TherapistID != DoctorID)
                    {
                        continue;
                    }
                }
                if (Status != 2500)
                {
                    if (sess.Status != Status)
                    {
                        continue;
                    }
                }
                if (UserID != 0)
                {
                    if (sess.Users.Count != 0)
                    {
                        if (sess.Users[0].ID != UserID)
                        {
                            continue;
                        }
                        else
                        {
                            U = sess.Users[0];
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (sess.Users.Count != 0)
                    {
                        U = sess.Users[0];
                    }
                    else
                    {
                        U = new Users();
                    }
                }
                Doctors D = new Doctors();
                CustomSession CS = new CustomSession();
                CustomDoctors CD = new CustomDoctors();
                CustomUsers CU = new CustomUsers();
                Dic.Clear();
                Dic.Add("@ID", sess.TherapistID);
                D = D.Search(Dic)[0];
                Dic.Clear();
                Dic.Add("@SessionID", sess.ID);
                CU.DisplayName = U.DisplayName;
                CU.UserID = U.ID;
                CD.Bio = D.Bio;
                CD.CostPercentage = D.CostPercentage;
                CD.FirstName = D.FirstName;
                CD.ID = D.ID;
                CD.LastName = D.LastName;
                CD.Phone = D.Phone;
                CD.ProfileImageLink = D.ProfileImageLink;
                CD.sessionInfo = D.sessionInfo;
                CD.SP1 = Enum.GetName(typeof(Specialities), D.SP1).Replace("9", " ");
                CD.SP2 = Enum.GetName(typeof(Specialities), D.SP2).Replace("9", " ");
                CD.SP3 = Enum.GetName(typeof(Specialities), D.SP3).Replace("9", " ");
                CD.Status = D.Status;
                CD.Title = D.Title;
                CD.TotalScore = D.TotalScore;
                CD.TotalSession = D.TotalSession;
                CS.Date = sess.Date;
                CS.Time = sess.Date.Hour.ToString() + ":" + sess.Date.Minute.ToString();
                CS.Doctors = CD;
                CS.Users = CU;
                CS.Duration = sess.Duration;
                CS.ElapsedTime = sess.ElapsedTime;
                CS.ID = sess.ID;
                CS.Price = sess.Price;
                CS.SP = Enum.GetName(typeof(Specialities), sess.SP);
                CS.Status = sess.Status;
                CS.Type = sess.Type;
                LOCS.Add(CS);
            }
            return Json(LOCS);
        }

        public void Reschedual(int SessionID, DateTime Date, TimeSpan Time, int Duration)
        {
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Sessions S = new Sessions();
            decimal TO = int.Parse(Session["TO"].ToString());
            DateTime SessDate = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, 0);
            Dic.Add("ID", SessionID);
            S = S.Search(Dic)[0];
            S.Date = SessDate.AddMinutes((double)TO);
            S.Duration = Duration;
            S.ReschdualSession();
            Helper H = new Helper();
            var url = Request.Url;
            string baseurl = url.GetLeftPart(UriPartial.Authority);
            H.SendEmail("Nofoos.com - Session Reschedualed", S.Therapist.Username, "Administrator reschedualed your session with " + S.Users.SingleOrDefault().DisplayName + "<br /> For more details please access your <a href='" + baseurl + "/Doctor/DoctorDashboard'>dashboard</a>");
            H.SendEmail("Nofoos.com - Session Reschedualed", S.Users.SingleOrDefault().Username, "Administrator reschedualed your session with doctor " + S.Therapist.FirstName + " " + S.Therapist.LastName + "<br /> For more details please access your <a href='" + baseurl + "/User/UserDashboard'>dashboard</a>");
        }

        public ActionResult CPLogin()
        {
            return View();
        }

        public string Login(string _Username, string _Password)
        {
            if (_Username == null || _Password == null)
            {
                RedirectToAction("CPLogin", "Admin");
                return "";
            }
            SystemMessages msg;
            SystemAccounts SA = new SystemAccounts();
            SA.Username = _Username;
            SA.Password = _Password;
            SA = SA.Login(out msg);
            if (msg == SystemMessages.LoginFailed)
            {
                return "false";
            }
            else if (msg == SystemMessages.LoginSuccess)
            {
                int temp = int.Parse(Session["TO"].ToString());
                Session.Clear();
                Session["TO"] = temp;
                Session["Admin"] = SA;
                return "true";
            }
            else
            {

                RedirectToAction("CPLogin", "Admin");
                return "false";
            }
        }

        public ActionResult AdminDashboard()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("CPLogin", "Admin");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("CPLogin", "Admin");


        }


        private Image LoadImage(string Base64)
        {
            //get a temp image from bytes, instead of loading from disk
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(Base64);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        public ActionResult SearchBlogs() 
        {
            Blog B = new Blog();
            List<Blog> LOB = new List<Blog>();
            LOB = B.GetAll();
            ViewBag.Blogs = LOB;
            return View();
        }
        public JsonResult FilterBlogs(string _keyword) 
        {
            Blog B = new Blog();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@Title", _keyword);
            List<Blog> LOB = new List<Blog>();
            LOB = B.Search(Dic);
            return Json(LOB);
        
        }
        public void DeleteBlog(int _ID) 
        {
            Blog B = new Blog();
            B.ID = _ID;
            B.Delete();
        }
    }
}
