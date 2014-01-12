using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GDAL;
using Nofos.Models;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Nofos.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Login(string URL)
        {
            var url = Request.Url;
            string baseurl = url.GetLeftPart(UriPartial.Authority);
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (URL != null)
                {
                    TempData["URL"] = URL;
                    TempData.Keep();
                }
                if (Request.Cookies["UserData"] != null && Request.Cookies["UserData"].Value != string.Empty)
                {
                    string UserData = Request.Cookies["UserData"].Value;
                    int start = UserData.IndexOf("(");
                    int end = UserData.IndexOf(")");
                    string Username = UserData.Substring(start + 1, end - start - 1);
                    int start1 = UserData.IndexOf("[");
                    int end1 = UserData.IndexOf("]");
                    string Type = UserData.Substring(start1 + 1, end1 - start1 - 1);
                    Dictionary<string, object> Dic = new Dictionary<string, object>();
                    if (Type == "Doctor")
                    {
                        Dic.Add("@Username", Username);
                        Doctors Doc = new GDAL.Doctors();
                        Doc = Doc.Search(Dic)[0];
                        Session["Doctor"] = Doc;
                        return RedirectToAction("DoctorDashboard", "Doctor");
                    }
                    else
                    {
                        Dic.Add("@Username", Username);
                        Users u = new GDAL.Users();
                        u = u.Search(Dic)[0];
                        Session["user"] = u;
                        return RedirectToAction("UserDashboard", "User");
                    }
                }
                return View("LoginAr");
            }
            else 
            {
                if (URL != null)
                {
                    TempData["URL"] = URL;
                    TempData.Keep();
                }
                if (Request.Cookies["UserData"] != null && Request.Cookies["UserData"].Value != string.Empty)
                {
                    string UserData = Request.Cookies["UserData"].Value;
                    int start = UserData.IndexOf("(");
                    int end = UserData.IndexOf(")");
                    string Username = UserData.Substring(start + 1, end - start - 1);
                    int start1 = UserData.IndexOf("[");
                    int end1 = UserData.IndexOf("]");
                    string Type = UserData.Substring(start1 + 1, end1 - start1 - 1);
                    Dictionary<string, object> Dic = new Dictionary<string, object>();
                    if (Type == "Doctor")
                    {
                        Dic.Add("@Username", Username);
                        Doctors Doc = new GDAL.Doctors();
                        Doc = Doc.Search(Dic)[0];
                        Session["Doctor"] = Doc;
                        return RedirectToAction("DoctorDashboard", "Doctor");
                    }
                    else
                    {
                        Dic.Add("@Username", Username);
                        Users u = new GDAL.Users();
                        u = u.Search(Dic)[0];
                        Session["user"] = u;
                        return RedirectToAction("UserDashboard", "User");
                    }
                }
                return View("");
            
            }
        }
        public ActionResult sendreset()
        {
            return View();
        }
        public string sendresetemail(string _Email)
        {
            Users U = new Users();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@Username", _Email);
            var lst = U.Search(Dic);
            if (lst.Count > 0)
            {
                U = lst[0];
                string VURL = System.Web.HttpUtility.UrlEncode(U.HashCode);
                Helper H = new Helper();
                var url = Request.Url;
                string baseurl = url.GetLeftPart(UriPartial.Authority);
                H.SendEmail("Nofoos.com - Reset Password", _Email, "<a href='" + baseurl + "/User/reset/" + VURL + "'>Click here to reset your password</a>");
                return "true";
            }
            Doctors doc = new Doctors();
            var Dlst = doc.Search(Dic);
            if (Dlst.Count > 0)
            {
                doc = Dlst[0];
                string VURL = System.Web.HttpUtility.UrlEncode(doc.HashCode);
                Helper H = new Helper();
                var url = Request.Url;
                string baseurl = url.GetLeftPart(UriPartial.Authority);
                H.SendEmail("Nofoos.com - Reset Password", _Email, "<a href='" + baseurl + "/User/reset/" + VURL + "'>Click here to reset your password</a>");
                return "true";

            }

            return "false";

        }
        public ActionResult Register()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                string URL = (string)TempData["URL"];
                TempData["URL"] = URL;
                TempData.Keep();
                return View("RegisterAr");
            }
            else 
            {
                string URL = (string)TempData["URL"];
                TempData["URL"] = URL;
                TempData.Keep();
                return View();
            
            }
        }
        public string SetTO(string _LocalTime)
        {
            Session["TO"] = (int)(DateTime.UtcNow.TimeOfDay.TotalMinutes - DateTime.Parse(_LocalTime).TimeOfDay.TotalMinutes);
            return "OK";
        }

        public static bool ScrambledEquals(int[] list1, int[] list2)
        {
            int FiveCounterList1 = 0;
            int FiveCounterList2 = 0;
            foreach (int item in list1)
            {
                if (item == 5)
                {
                    FiveCounterList1++;
                }
            }
            foreach (int item in list2)
            {
                if (item == 5)
                {
                    FiveCounterList2++;
                }
            }
            if (FiveCounterList1 == FiveCounterList2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string CheckUpdatedDashboardSessions()
        {
            int[] ForCompare = TempData["UserSessionToCompare"] as int[];
            Users user = ((Users)Session["user"]);
            List<Sessions> UserPendingSessions = new List<Sessions>();
            UserPendingSessions = new Sessions().GetPendingSessions(user.ID);
            int[] Comparer = new int[UserPendingSessions.Count];
            int counter = 0;
            foreach (Sessions item in UserPendingSessions)
            {
                Comparer[counter] = item.Status;
                counter++;
            }
            bool Equality = ScrambledEquals(ForCompare, Comparer);
            TempData["UserSessionToCompare"] = Comparer;
            if (Equality == true)
            {
                return "No";
            }
            else
            {
                return "OK";
            }
        }

        public ActionResult UserDashboard()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (Session["user"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                Users user = ((Users)Session["user"]);
                List<Sessions> UserPendingSessions = new List<Sessions>();
                ViewBag.TO = int.Parse(Session["TO"].ToString());
                UserPendingSessions = new Sessions().GetPendingSessions(user.ID);
                ViewBag.UserPendingSessions = UserPendingSessions;
                int[] Comparer = new int[UserPendingSessions.Count];
                int counter = 0;
                foreach (Sessions item in UserPendingSessions)
                {
                    Comparer[counter] = item.Status;
                    counter++;
                }
                TempData["UserSessionToCompare"] = Comparer;
                TempData.Keep();
                ViewBag.CurrentUser = user;
                return View("UserDashboardAr");
            }
            else 
            {
                if (Session["user"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                Users user = ((Users)Session["user"]);
                List<Sessions> UserPendingSessions = new List<Sessions>();
                ViewBag.TO = int.Parse(Session["TO"].ToString());
                UserPendingSessions = new Sessions().GetPendingSessions(user.ID);
                int[] Comparer = new int[UserPendingSessions.Count];
                int counter = 0;
                foreach (Sessions item in UserPendingSessions)
                {
                    Comparer[counter] = item.Status;
                    counter++;
                }
                TempData["UserSessionToCompare"] = Comparer;
                TempData.Keep();
                ViewBag.UserPendingSessions = UserPendingSessions;
                ViewBag.CurrentUser = user;
                return View();
            
            }
        }
        public string RegisterUser(string _Email, string _DisplayName, string _Password)
        {
            SystemMessages Msg;
            Users U = new Users();
            U.Username = _Email;
            U.DisplayName = _DisplayName;
            U.HashCode = Guid.NewGuid().ToString();
            U.DateofBirth = DateTime.UtcNow;
            U.Gender = 0;
            U.Password = _Password;
            U.LastLogin = DateTime.UtcNow;
            U.ProfileImageLink = "/images/UsersImgs/Users/Default46549878465465.png";
            U.Status = (int)Status.InvalidatedEmail;
            U.Register(out Msg);
            Doctors Doc = new Doctors();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@Username", U.Username);
            List<Doctors> LOD = new List<Doctors>();
            LOD = Doc.Search(dic);
            if (Msg == SystemMessages.UsernameExist || LOD.Count != 0)
            {
                return "false";
            }
            else
            {
                dic.Clear();
                dic.Add("@Username", U.Username);
                List<Users> LOU = new List<Users>();
                LOU = U.Search(dic);
                U = LOU[0];
                Session["user"] = U;
                string VURL = System.Web.HttpUtility.UrlEncode(U.HashCode);
                Helper H = new Helper();
                var url = Request.Url;
                string baseurl = url.GetLeftPart(UriPartial.Authority);
                H.SendEmail("Nofoos.com - Email Validation", _Email, "<a href='" + baseurl + "/User/Activate/" + VURL + "'>Activate now</a>");

                if (TempData["URL"] != null)
                {
                    return (string)TempData["URL"];
                }
                return "true";
            }
        }

        public string LoginUser(string _Email, string _Password, string Rem)
        {
            int temp = int.Parse(Session["TO"].ToString());
            Session.Clear();
            Session["TO"] = temp;
            SystemMessages msg;
            Users u = new Users();
            u.Username = _Email;
            u.Password = _Password;
            if (_Email == null || _Password == null)
            {
                return "Null Username";
            }
            bool result = u.Login(out msg);
            if (result == true)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("Username", u.Username);
                List<Users> lou = new List<Users>();
                lou = u.Search(dic);
                u = lou[0];
                if (u.Status == (int)Status.Disabled)
                {
                    return "UserSuspended";
                }
                else
                {
                    if (TempData["URL"] != null)
                    {
                        Session["user"] = u;
                        string URL = (string)TempData["URL"];
                        return URL;
                    }
                    Session["user"] = u;
                    if (Rem == "true")
                    {
                        Response.Cookies.Remove("UserData");
                        HttpCookie Cook = new HttpCookie("UserData");
                        Cook.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies["UserData"].Value = "(" + u.Username + "){" + u.Password + "}[User]";
                    }
                    return "Usertrue";
                }
            }
            else
            {

                Doctors doc = new Doctors();
                doc.Username = _Email;
                doc.Password = _Password;
                result = doc.Login(out msg);
                if (result == true)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("Username", doc.Username);
                    List<Doctors> LOD = new List<Doctors>();
                    LOD = doc.Search(dic);
                    doc = LOD[0];
                    if (doc.Status == (int)Status.Pending)
                    {
                        return "DoctorPending";
                    }
                    if (doc.Status == (int)Status.Disabled)
                    {
                        return "DoctorSuspended";
                    }

                    Session["Doctor"] = doc;
                    if (Rem == "true")
                    {
                        Response.Cookies.Remove("UserData");
                        HttpCookie Cook = new HttpCookie("UserData");
                        Cook.Expires = DateTime.Now.AddYears(1);
                        Response.Cookies["UserData"].Value = "(" + doc.Username + "){" + doc.Password + "}[Doctor]";
                    }
                    return "Doctortrue";
                }
                else
                {
                    return "false";
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Response.Cookies["UserData"].Value = string.Empty;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PatientSession(int? id)
        {
            Sessions SSS = new GDAL.Sessions();
            List<Sessions> LOSSS = new List<GDAL.Sessions>();
            Dictionary<string, object> Diccc = new Dictionary<string, object>();
            Diccc.Add("@ID", id);
            LOSSS = SSS.Search(Diccc);
            if (LOSSS.Count != 0)
            {
                SSS = LOSSS[0];
                if (SSS.Status == 8)
                {
                    return RedirectToAction("UserDashboard", "User");
                }
            }
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (Session["Doctor"] != null || Session["user"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }


                UserSessions US = new UserSessions();
                List<UserSessions> LOUS = new List<UserSessions>();
                US.SessionID = (int)id;
                TempData["ID"] = (int)id;
                TempData.Keep();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@SessionID", US.SessionID);
                LOUS = US.Search(Dic);
                if (LOUS.Count == 0)
                {
                    return RedirectToAction("UserDashboard", "User");
                }
                US = LOUS[0];
                if ((Session["user"] as Users).ID != US.UserID)
                {
                    return RedirectToAction("UserDashboard", "User");
                }
                Dictionary<string, object> MyDic = new Dictionary<string, object>();
                MyDic.Add("@ID", id);
                ViewBag.S = new Sessions().Search(MyDic)[0];
                if ((ViewBag.S as Sessions).Status == 5)
                {
                    return View("PatientSessionAr");
                }
                else if ((ViewBag.S as Sessions).Status == 8)
                {
                    return View("PatientSessionAr");
                }
                else if (((ViewBag.S as Sessions).Status == 2))
                {
                    return View("PatientSessionAr");
                }
                else
                {
                    return RedirectToAction("UserDashboard", "User");

                }
            }
            else 
            {
            
                if (Session["Doctor"] != null || Session["user"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }


                UserSessions US = new UserSessions();
                List<UserSessions> LOUS = new List<UserSessions>();
                US.SessionID = (int)id;
                TempData["ID"] = (int)id;
                TempData.Keep();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@SessionID", US.SessionID);
                LOUS = US.Search(Dic);
                if (LOUS.Count == 0)
                {
                    return RedirectToAction("UserDashboard", "User");
                }
                US = LOUS[0];
                if ((Session["user"] as Users).ID != US.UserID)
                {
                    return RedirectToAction("UserDashboard", "User");
                }
                Dictionary<string, object> MyDic = new Dictionary<string, object>();
                MyDic.Add("@ID", id);
                ViewBag.S = new Sessions().Search(MyDic)[0];
                if ((ViewBag.S as Sessions).Status == 5)
                {
                    return View();
                }
                else if ((ViewBag.S as Sessions).Status == 8)
                {
                    return View();
                }
                else if (((ViewBag.S as Sessions).Status == 2))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("UserDashboard", "User");

                }
            
            }
        }

        public string ChechSessionElapsed()
        {
            Sessions S = new GDAL.Sessions();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", (int)TempData["ID"]);
            S = S.Search(Dic)[0];
            if (S.ElapsedTime == S.Duration || S.Status == (int)Status.Ended)
            {
                return "Finished";
            }
            else
            {
                return "";
            }
        }

        public JsonResult GetSessionData()
        {
            OpenTokSDK OpenTok = new OpenTokSDK();
            OpenTokData Data = new OpenTokData();
            int ID = (int)TempData["ID"];
            TempData["ID"] = ID;
            TempData.Keep();
            UserSessions US = new UserSessions();
            List<UserSessions> LOUS = new List<UserSessions>();
            US.SessionID = ID;
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@SessionID", US.SessionID);
            LOUS = US.Search(Dic);
            US = LOUS[0];
            if (US.OTSessionID == null || US.OTSessionID == "")
            {
                UserSessions usersession = new UserSessions();
                Data.SessionID = OpenTok.CreateSession(Request.ServerVariables["REMOTE_ADDR"]);
                Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.PUBLISHER);
                Data.Token = OpenTok.GenerateToken(Data.SessionID, tokenOptions);
                usersession.ID = US.ID;
                usersession.OTSessionID = Data.SessionID;
                usersession.SessionID = US.SessionID;
                usersession.Status = (int)Status.Pending;
                usersession.UserID = US.UserID;
                usersession.Update();
                return Json(Data);
            }
            else
            {
                Data.SessionID = US.OTSessionID;
                Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.PUBLISHER);
                Data.Token = OpenTok.GenerateToken(US.OTSessionID, tokenOptions);
                return Json(Data);
            }
        }

        public ActionResult GroupSession(int id)
        {
            if (Session["Doctor"] != null || Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["ID"] = id;
            TempData.Keep();
            UserSessions US = new UserSessions();
            List<UserSessions> LOUS = new List<UserSessions>();
            US.ID = id;
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", US.ID);
            LOUS = US.Search(Dic);
            UserSessions UUSS = new UserSessions();
            UUSS = LOUS.Find(p => p.UserID == ((Users)Session["user"]).ID);
            if (UUSS == null)
            {
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public JsonResult GetGroupSessionData()
        {
            OpenTokSDK OpenTok = new OpenTokSDK();
            OpenTokData Data = new OpenTokData();
            int ID = (int)TempData["ID"];
            UserSessions US = new UserSessions();
            List<UserSessions> LOUS = new List<UserSessions>();
            US.ID = ID;
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", US.ID);
            LOUS = US.Search(Dic);
            US = LOUS[0];
            if (US.OTSessionID == null || US.OTSessionID == "")
            {
                UserSessions usersession = new UserSessions();
                Data.SessionID = OpenTok.CreateSession(Request.ServerVariables["REMOTE_ADDR"]);
                Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.PUBLISHER);
                Data.Token = OpenTok.GenerateToken(Data.SessionID, tokenOptions);
                usersession.ID = US.ID;
                usersession.OTSessionID = Data.SessionID;
                usersession.SessionID = US.SessionID;
                usersession.Status = (int)Status.Pending;
                usersession.UserID = US.UserID;
                usersession.Update();
                return Json(Data);
            }
            else
            {
                Data.SessionID = US.OTSessionID;
                Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.PUBLISHER);
                Data.Token = OpenTok.GenerateToken(US.OTSessionID, tokenOptions);
                return Json(Data);
            }
        }

        public ActionResult Activate(String ID)
        {
            SystemMessages Msg;
            Users U = new Users();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@HashCode", ID);
            U = U.Search(Dic)[0];
            U.Status = (int)Status.Enabled;
            U.UpdateProfile(out Msg);
            Session["user"] = (Users)U;
            return RedirectToAction("UserDashboard", "User");
        }
        public ActionResult Reset(String ID)
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                Users U = new Users();
                Doctors D = new Doctors();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@HashCode", ID);
                List<Users> LOU = new List<Users>();
                LOU = U.Search(Dic);
                if (LOU.Count == 0)
                {
                    D = D.Search(Dic)[0];
                    Session["Doctor"] = (Doctors)D;
                    return View("resetpassAr");
                }
                U = LOU[0];
                Session["user"] = (Users)U;
                return View("resetpassAr");
            }
            else
            {
                Users U = new Users();
                Doctors D = new Doctors();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@HashCode", ID);
                List<Users> LOU = new List<Users>();
                LOU = U.Search(Dic);
                if (LOU.Count == 0)
                {
                    D = D.Search(Dic)[0];
                    Session["Doctor"] = (Doctors)D;
                    return View("resetpass");
                }
                U = LOU[0];
                Session["user"] = (Users)U;
                return View("resetpass");
            
            }
        }
        public string ResetPassword(String ID)
        {
            SystemMessages Msg;
            if (Session["user"] == null)
            {
                Doctors doc = new Doctors();
                doc = (Doctors)Session["Doctor"];
                doc.Password = ID;
                doc.UpdateProfile(out Msg);
                Session["Doctor"] = doc;
                return "true";

            }
            Users U = (Users)Session["user"];
            U.Password = ID;
            U.UpdateProfile(out Msg);
            Session["user"] = (Users)U;
            return "true";
        }

        public ActionResult UserHistory()
        {

            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (Session["user"] == null)
                {
                    return RedirectToAction("Login", "User");
                }
                return View("UserHistoryAr");
            }
            else 
            {
                if (Session["user"] == null)
                {
                    return RedirectToAction("Login", "User");
                }
                return View();
            
            
            }

        }

        public JsonResult FilterSessions(string Date, int Status)
        {

            Users current = new Users();
            current = (Users)Session["user"];
            int currentUID = current.ID;
            UserSessions US = new UserSessions();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@UserID", currentUID);
            List<UserSessions> LOUS = new List<UserSessions>();
            LOUS = US.Search(Dic);
            List<Sessions> LOS = new List<Sessions>();
            List<Sessions> FilteredSession = new List<Sessions>();
            foreach (UserSessions USESSION in LOUS)
            {
                Dic.Clear();
                Dic.Add("@ID", USESSION.SessionID);
                Sessions S = new Sessions();
                S = S.Search(Dic)[0];
                LOS.Add(S);

            }
            if ((Int32)Status != 2500 && Date != "null")
            {
                string Day = Date.Split('/')[0];
                string month = Date.Split('/')[1];
                string year = Date.Split('/')[2];
                DateTime SessionDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(Day), 0, 0, 0);
                foreach (Sessions X in LOS)
                {
                    string DateOnly = X.Date.ToShortDateString();
                    if (DateOnly == SessionDate.ToShortDateString() && X.Status == (Int32)Status)
                    {
                        FilteredSession.Add(X);
                    }
                }
                return Json(FilteredSession);

            }
            if ((Int32)Status != 2500 && Date == "null")
            {

                foreach (Sessions X in LOS)
                {
                    if (X.Status == (Int32)Status)
                    {
                        FilteredSession.Add(X);
                    }
                }
                return Json(FilteredSession);

            }
            if ((Int32)Status == 2500 && Date == "null")
            {
                List<Sessions> LLOS = new List<Sessions>();
                for (int i = 0; i < LOS.Count(); i++)
                {
                    if (LOS[i].Status == 6)
                    {

                    }
                    else
                    {
                        LLOS.Add(LOS[i]);
                    }
                }

                if (LLOS.Count() == 0)
                {

                    return Json(LOS);
                }
                return Json(LLOS);
            }
            if ((Int32)Status == 2500 && Date != "null")
            {
                string Day = Date.Split('/')[0];
                string month = Date.Split('/')[1];
                string year = Date.Split('/')[2];
                DateTime SessionDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(Day), 0, 0, 0);
                foreach (Sessions X in LOS)
                {
                    if (X.Status != 6)
                    {
                        string DateOnly = X.Date.ToShortDateString();
                        if (DateOnly == SessionDate.ToShortDateString())
                        {
                            FilteredSession.Add(X);
                        }
                    }
                }
                return Json(FilteredSession);
            }


            return Json(LOS);
        }

        public ActionResult PaymentsHistory()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                return View("PaymentsHistoryAr");
            }
            else 
            {
                return View();
            }
        }

        public JsonResult FilterFTrans(string _fromDate, string _ToDate)
        {
            FTrans FT = new FTrans();
            Users U = new Users();
            List<FTrans> LOFT = new List<FTrans>();
            U = (Users)Session["user"];
            if (U == null)
            {
                return Json("NotLogged");
            }
            if (_fromDate == "" || _ToDate == "")
            {

                LOFT = FT.GetByUserID(U.ID);
                return Json(LOFT);

            }
            else
            {
                string FromDay = _fromDate.Split('/')[0];
                string Frommonth = _fromDate.Split('/')[1];
                string Fromyear = _fromDate.Split('/')[2];
                DateTime FromDate = new DateTime(Convert.ToInt32(Fromyear), Convert.ToInt32(Frommonth), Convert.ToInt32(FromDay), 0, 0, 0);
                string ToDay = _ToDate.Split('/')[0];
                string Tomonth = _ToDate.Split('/')[1];
                string Toyear = _ToDate.Split('/')[2];
                DateTime ToDate = new DateTime(Convert.ToInt32(Toyear), Convert.ToInt32(Tomonth), Convert.ToInt32(ToDay), 0, 0, 0);
                LOFT = FT.GetbyDate(FromDate, ToDate);
                return Json(LOFT);
            }

        }

        public JsonResult FindSessionNow()
        {
            Sessions S = new Sessions();
            if (S.GetSessionNow().Count != 0)
            {
                S = S.GetSessionNow()[0];
                return Json(S);
            }
            else
            {
                return Json("NoSessions");
            }
            

       
        }
    }
}
