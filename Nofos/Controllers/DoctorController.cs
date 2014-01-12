using GDAL;
using Nofos.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Nofos.Controllers
{
    public class PaymentRequest
    {
        public PaymentRequest()
        {
            Version = "1";
            Command = "pay";
            AccessCode = "F05FC469";
            MerchTxnRef = "";
            Merchant = "TEST512345USD";
            OrderInfo = "";
            Amount = "100";
            ReturnUrl = "http://YOURDOMAINNAMECOMESHERE.com.au/payment/paymentconfirm";
            Locale = "en";
        }
        public PaymentRequest(int dollars, int cents, string orderInfo)
            : this()
        {
            this.Amount = (dollars * 100 + cents).ToString();
            this.OrderInfo = orderInfo;
        }
        public string Version { get; set; }
        public string Command { get; set; }
        public string AccessCode { get; set; }
        public string MerchTxnRef { get; set; }
        public string Merchant { get; set; }
        public string OrderInfo { get; set; }
        public string Amount { get; set; }
        public string ReturnUrl { get; set; }
        public string Locale { get; set; }
        public Dictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string> {
                { "vpc_Version" ,Version},
                { "vpc_Command",Command},
                { "vpc_AccessCode" ,AccessCode},
                { "vpc_MerchTxnRef" ,MerchTxnRef},
                { "vpc_Merchant" ,Merchant},
                { "vpc_OrderInfo",OrderInfo},
                { "vpc_Amount" ,Amount},
                { "vpc_ReturnURL", ReturnUrl},
                { "vpc_Locale",Locale}
            };
            return parameters;
        }
    }
    public class PaymentHelperMethods
    {
        public static string getResponseDescription(string vResponseCode)
        {
            string result = "Unknown";
            if (vResponseCode.Length > 0)
            {
                switch (vResponseCode)
                {
                    case "0": result = "Transaction Successful"; break;
                    case "1": result = "Transaction Declined"; break;
                    case "2": result = "Bank Declined Transaction"; break;
                    case "3": result = "No Reply from Bank"; break;
                    case "4": result = "Expired Card"; break;
                    case "5": result = "Insufficient Funds"; break;
                    case "6": result = "Error Communicating with Bank"; break;
                    case "7": result = "Payment Server detected an error"; break;
                    case "8": result = "Transaction Type Not Supported"; break;
                    case "9": result = "Bank declined transaction (Do not contact Bank)"; break;
                    case "A": result = "Transaction Aborted"; break;
                    case "B": result = "Transaction Declined - Contact the Bank"; break;
                    case "C": result = "Transaction Cancelled"; break;
                    case "D": result = "Deferred transaction has been received and is awaiting processing"; break;
                    case "F": result = "3-D Secure Authentication failed"; break;
                    case "I": result = "Card Security Code verification failed"; break;
                    case "L": result = "Shopping Transaction Locked (Please try the transaction again later)"; break;
                    case "N": result = "Cardholder is not enrolled in Authentication scheme"; break;
                    case "P": result = "Transaction has been received by the Payment Adaptor and is being processed"; break;
                    case "R": result = "Transaction was not processed - Reached limit of retry attempts allowed"; break;
                    case "S": result = "Duplicate SessionID"; break;
                    case "T": result = "Address Verification Failed"; break;
                    case "U": result = "Card Security Code Failed"; break;
                    case "V": result = "Address Verification and Card Security Code Failed"; break;
                    default: result = "Unable to be determined"; break;
                }
            }
            return result;
        }
        public static string displayAVSResponse(string vAVSResultCode)
        {
            string result = "Unknown";

            if (vAVSResultCode.Length > 0)
            {
                if (vAVSResultCode.Equals("Unsupported"))
                {
                    result = "AVS not supported or there was no AVS data provided";
                }
                else
                {
                    switch (vAVSResultCode)
                    {
                        case "X": result = "Exact match - address and 9 digit ZIP/postal code"; break;
                        case "Y": result = "Exact match - address and 5 digit ZIP/postal code"; break;
                        case "S": result = "Service not supported or address not verified (international transaction)"; break;
                        case "G": result = "Issuer does not participate in AVS (international transaction)"; break;
                        case "A": result = "Address match only"; break;
                        case "W": result = "9 digit ZIP/postal code matched, Address not Matched"; break;
                        case "Z": result = "5 digit ZIP/postal code matched, Address not Matched"; break;
                        case "R": result = "Issuer system is unavailable"; break;
                        case "U": result = "Address unavailable or not verified"; break;
                        case "E": result = "Address and ZIP/postal code not provided"; break;
                        case "N": result = "Address and ZIP/postal code not matched"; break;
                        case "0": result = "AVS not requested"; break;
                        default: result = "Unable to be determined"; break;
                    }
                }
            }
            return result;
        }
        public static string displayCSCResponse(string vCSCResultCode)
        {
            string result = "Unknown";
            if (vCSCResultCode.Length > 0)
            {
                if (vCSCResultCode.Equals("Unsupported"))
                {
                    result = "CSC not supported or there was no CSC data provided";
                }
                else
                {
                    switch (vCSCResultCode)
                    {
                        case "M": result = "Exact code match"; break;
                        case "S": result = "Merchant has indicated that CSC is not present on the card (MOTO situation)"; break;
                        case "P": result = "Code not processed"; break;
                        case "U": result = "Card issuer is not registered and/or certified"; break;
                        case "N": result = "Code invalid or not matched"; break;
                        default: result = "Unable to be determined"; break;
                    }
                }
            }
            return result;
        }
        public static System.Collections.Hashtable splitResponse(string rawData)
        {
            System.Collections.Hashtable responseData = new System.Collections.Hashtable();
            try
            {
                if (rawData.IndexOf("=") > 0)
                {
                    // Extract the key/value pairs for each parameter
                    foreach (string pair in rawData.Split('&'))
                    {
                        int equalsIndex = pair.IndexOf("=");
                        if (equalsIndex > 1 && pair.Length > equalsIndex)
                        {
                            string paramKey = System.Web.HttpUtility.UrlDecode(pair.Substring(0, equalsIndex));
                            string paramValue = System.Web.HttpUtility.UrlDecode(pair.Substring(equalsIndex + 1));
                            responseData.Add(paramKey, paramValue);
                        }
                    }
                }
                else
                {
                    responseData.Add("vpc_Message", "The data contained in the response was not a valid receipt.<br/>\nThe data was: <pre>" + rawData + "</pre><br/>\n");
                }
                return responseData;
            }
            catch (Exception ex)
            {
                // There was an exception so create an error
                responseData.Add("vpc_Message", "\nThe was an exception parsing the response data.<br/>\nThe data was: <pre>" + rawData + "</pre><br/>\n<br/>\nException: " + ex.ToString() + "<br/>\n");
                return responseData;
            }
        }
        public static string CreateMD5Signature(string RawData)
        {
            var hasher = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
            var HashValue = hasher.ComputeHash(Encoding.ASCII.GetBytes(RawData));
            return string.Join("", HashValue.Select(b => b.ToString("x2"))).ToUpper();
            #region commented code
            //string strHex = "";
            //foreach(byte b in HashValue) 
            //{
            //    strHex += b.ToString("x2");
            //}
            //return strHex.ToUpper();
            #endregion
        }
    }
    public class PaymentResponse
    {
        #region common properties
        public string ResponseCode { get; set; }
        public string ResponseCodeDescription { get; set; }
        public string Amount { get; set; }
        public string Command { get; set; }
        public string Version { get; set; }
        public string OrderInfo { get; set; }
        public string MerchantID { get; set; }
        #endregion
        #region on-successful-payment properties
        public string BatchNo { get; set; }
        public string CardType { get; set; }
        public string ReceiptNo { get; set; }
        public string AuthorizeID { get; set; }
        public string MerchTxnRef { get; set; }
        public string AcqResponseCode { get; set; }
        public string TransactionNo { get; set; }
        #endregion
        public string Message { get; set; }
        public PaymentResponse(HttpRequestBase Request)
        {
            Func<string, string> GetQueryStringValue = key =>
            {
                if (Request.QueryString.AllKeys.Contains(key))
                {
                    var result = Request.QueryString[key];
                    return result;
                }
                return "Unknown";
            };
            // Get the standard receipt data from the parsed response
            this.ResponseCode = GetQueryStringValue("vpc_TxnResponseCode");
            this.ResponseCodeDescription = PaymentHelperMethods.getResponseDescription(ResponseCode);
            this.Amount = GetQueryStringValue("vpc_Amount");
            this.Command = GetQueryStringValue("vpc_Command");
            this.Version = GetQueryStringValue("vpc_Version");
            this.OrderInfo = GetQueryStringValue("vpc_OrderInfo");
            this.MerchantID = GetQueryStringValue("vpc_Merchant");

            // only display this data if not an error condition
            if (this.ResponseCode.Equals("7"))
            {
                this.BatchNo = GetQueryStringValue("vpc_BatchNo");
                this.CardType = GetQueryStringValue("vpc_Card");
                this.ReceiptNo = GetQueryStringValue("vpc_ReceiptNo");
                this.AuthorizeID = GetQueryStringValue("vpc_AuthorizeId");
                this.MerchTxnRef = GetQueryStringValue("vpc_MerchTxnRef");
                this.AcqResponseCode = GetQueryStringValue("vpc_AcqResponseCode");
                this.TransactionNo = GetQueryStringValue("vpc_TransactionNo");
            }
            var message = GetQueryStringValue("vpc_Message");
        }
    }
    public class VPCStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var myComparer = CompareInfo.GetCompareInfo("en-US");
            return myComparer.Compare(x, y, System.Globalization.CompareOptions.Ordinal);
        }
    }
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/

        public ActionResult SearchSessions()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (Session["Doctor"] != null)
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");
                }
                Doctors D = new Doctors();
                List<Doctors> LOD = new List<Doctors>();
                LOD = D.SelectAllDoctors();
                ViewBag.Doctors = LOD;
                string[] SPS = Enum.GetNames(typeof(SpecialitiesAr));
                ViewBag.SPS = SPS;
                return View("SearchSessionsAr");
            }
            else
            {
                if (Session["Doctor"] != null)
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");
                }
                Doctors D = new Doctors();
                List<Doctors> LOD = new List<Doctors>();
                LOD = D.SelectAllDoctors();
                ViewBag.Doctors = LOD;
                string[] SPS = Enum.GetNames(typeof(Specialities));
                ViewBag.SPS = SPS;
                return View();

            }
        }

        public JsonResult GetFilteredDoctors(int _ID, int _SP, int Ty, int Lang, int CDate)
        {
            Sessions S = new Sessions();
            List<Sessions> LOS = new List<Sessions>();
            List<Doctors> LOD = new List<Doctors>();
            List<CustomSession> LOCS = new List<CustomSession>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            if (_ID == 0 && _SP == 0 && Ty == 0 && Lang == 0 && CDate == 0)
            {
                Dic.Add("@Lang", Lang);
                Dic.Add("@Status", (int)Status.Created);
                //Dic.Add("@Status1", (int)Status.Purchased);
                LOS = S.Filter(Dic);
                Dic.Clear();
                Dic.Add("@Status", (int)Status.Purchased);
                LOS.AddRange(S.Filter(Dic));
                foreach (Sessions sess in LOS)
                {
                    if (sess.Date < DateTime.UtcNow)
                    {
                        continue;
                    }
                    Doctors D = new Doctors();
                    CustomSession CS = new CustomSession();
                    CustomDoctors CD = new CustomDoctors();
                    Dic.Clear();
                    Dic.Add("@ID", sess.TherapistID);
                    D = D.Search(Dic)[0];
                    CD.Bio = D.Bio;
                    CD.CostPercentage = D.CostPercentage;
                    CD.FirstName = D.FirstName;
                    CD.ID = D.ID;
                    CD.LastName = D.LastName;
                    CD.Phone = D.Phone;
                    CD.ProfileImageLink = D.ProfileImageLink;
                    CD.sessionInfo = D.sessionInfo;
                    if (Request.Cookies["Lang"].Value == "Ar")
                    {
                        CD.SP1 = Enum.GetName(typeof(SpecialitiesAr), D.SP1).Replace("_", " ");
                        CD.SP2 = Enum.GetName(typeof(SpecialitiesAr), D.SP2).Replace("_", " ");
                        CD.SP3 = Enum.GetName(typeof(SpecialitiesAr), D.SP3).Replace("_", " ");
                    }
                    else
                    {
                        CD.SP1 = Enum.GetName(typeof(Specialities), D.SP1).Replace("9", " ");
                        CD.SP2 = Enum.GetName(typeof(Specialities), D.SP2).Replace("9", " ");
                        CD.SP3 = Enum.GetName(typeof(Specialities), D.SP3).Replace("9", " ");
                    }
                    CD.Status = D.Status;
                    CD.Title = D.Title;
                    CD.Language = Enum.GetName(typeof(Language), D.Language);
                    CD.TotalScore = D.TotalScore;
                    CD.TotalSession = D.TotalSession;
                    CS.Date = sess.Date;
                    decimal TO = int.Parse(Session["TO"].ToString());
                    CS.Time = sess.Date.AddMinutes(-(int)TO).ToString("hh:mm tt");
                    CS.Doctors = CD;
                    CS.Duration = sess.Duration;
                    CS.ElapsedTime = sess.ElapsedTime;
                    CS.ID = sess.ID;
                    CS.Price = sess.Price;
                    CS.SP = Enum.GetName(typeof(Specialities), sess.SP);
                    CS.Status = sess.Status;
                    CS.Type = sess.Type;
                    if (CS.Status == (int)Status.Purchased)
                    {
                        CS.AvOrNot = "Not available";
                    }
                    else
                    {
                        CS.AvOrNot = "Available";
                    }
                    LOCS.Add(CS);
                }
                return Json(LOCS.OrderBy(x => x.Date));
            }
            if (Ty != 0)
            {
                Dic.Add("@Type", Ty);
            }
            if (_ID != 0)
            {
                Dic.Add("@DID", _ID);
            }
            Dic.Add("@Status", (int)Status.Created);
            if (Lang > 0)
                Dic.Add("@Lang", Lang);
            //Dic.Add("@Status1", (int)Status.Purchased);
            LOS = S.Filter(Dic);
            Dic.Remove("@Status");
            Dic.Add("@Status", (int)Status.Purchased);
            LOS.AddRange(S.Filter(Dic));
            foreach (Sessions sess in LOS)
            {
                if (sess.Date < DateTime.UtcNow)
                {
                    continue;
                }
                if (CDate == 1)
                {
                    if (sess.Date > DateTime.UtcNow.AddDays(7))
                    {
                        continue;
                    }
                }
                if (CDate == 2)
                {
                    if (sess.Date > DateTime.UtcNow.AddDays(14))
                    {
                        continue;
                    }
                }
                if (CDate == 3)
                {
                    if (sess.Date > DateTime.UtcNow.AddDays(30))
                    {
                        continue;
                    }
                }
                if (sess.Therapist.SP1 != _SP && sess.Therapist.SP2 != _SP && sess.Therapist.SP3 != _SP && _SP != 0)
                {
                    continue;
                }
                Doctors D = new Doctors();
                CustomSession CS = new CustomSession();
                CustomDoctors CD = new CustomDoctors();
                Dic.Clear();
                Dic.Add("@ID", sess.TherapistID);
                D = D.Search(Dic)[0];
                CD.Bio = D.Bio;
                CD.CostPercentage = D.CostPercentage;
                CD.FirstName = D.FirstName;
                CD.ID = D.ID;
                CD.LastName = D.LastName;
                CD.Phone = D.Phone;
                CD.ProfileImageLink = D.ProfileImageLink;
                CD.sessionInfo = D.sessionInfo;
                if (Request.Cookies["Lang"].Value == "Ar")
                {
                    CD.SP1 = Enum.GetName(typeof(SpecialitiesAr), D.SP1).Replace("_", " ");
                    CD.SP2 = Enum.GetName(typeof(SpecialitiesAr), D.SP2).Replace("_", " ");
                    CD.SP3 = Enum.GetName(typeof(SpecialitiesAr), D.SP3).Replace("_", " ");
                }
                else
                {
                    CD.SP1 = Enum.GetName(typeof(Specialities), D.SP1).Replace("9", " ");
                    CD.SP2 = Enum.GetName(typeof(Specialities), D.SP2).Replace("9", " ");
                    CD.SP3 = Enum.GetName(typeof(Specialities), D.SP3).Replace("9", " ");
                }
                CD.Status = D.Status;
                CD.Language = Enum.GetName(typeof(Language), D.Language);
                CD.Title = D.Title;
                CD.TotalScore = D.TotalScore;
                CD.TotalSession = D.TotalSession;
                CS.Date = sess.Date;
                decimal TO = int.Parse(Session["TO"].ToString());
                CS.Time = sess.Date.AddMinutes(-(int)TO).ToString("hh:mm tt");
                CS.Doctors = CD;
                CS.Duration = sess.Duration;
                CS.ElapsedTime = sess.ElapsedTime;
                CS.ID = sess.ID;
                CS.Price = sess.Price;
                CS.SP = Enum.GetName(typeof(Specialities), sess.SP);
                CS.Status = sess.Status;
                if (CS.Status == (int)Status.Purchased)
                {
                    CS.AvOrNot = "Not available";
                }
                else
                {
                    CS.AvOrNot = "Available";
                }
                CS.Type = sess.Type;
                LOCS.Add(CS);
            }
            return Json(LOCS.OrderBy(x => x.Date));
        }

        public JsonResult GetSessionData()
        {
            OpenTokSDK OpenTok = new OpenTokSDK();
            OpenTokData Data = new OpenTokData();
            int ID = (int)TempData["ID"];
            UserSessions US = new UserSessions();
            List<UserSessions> LOUS = new List<UserSessions>();
            US.SessionID = ID;
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@SessionID", US.SessionID);
            LOUS = US.Search(Dic);
            US = LOUS[0];
            Sessions ses = new Sessions();
            Dic.Clear();
            Dic.Add("@ID", ID);
            ses = ses.Search(Dic)[0];
            ses.Status = (int)Status.Online;
            ses.Update();
            Helper H = new Helper();
            var url = Request.Url;
            string baseurl = url.GetLeftPart(UriPartial.Authority);
            H.SendEmail("Nofoos.com - Doctor " + ses.Therapist.FirstName + " " + ses.Therapist.LastName + " Waiting You", ses.Users.SingleOrDefault().Username, "<h1>Doctor " + ses.Therapist.FirstName + " " + ses.Therapist.LastName + " Joined Session Now</h1><br />Please <a href='" + baseurl + "/User/PatientSession/" + ses.ID + "'>Join</a> Now To Start Session<br />");
            if (US.OTSessionID == null || US.OTSessionID == "")
            {
                UserSessions usersession = new UserSessions();
                Data.SessionID = OpenTok.CreateSession(Request.ServerVariables["REMOTE_ADDR"]);
                Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.MODERATOR);
                Data.Token = OpenTok.GenerateToken(Data.SessionID, tokenOptions);
                usersession.ID = US.ID;
                usersession.OTSessionID = Data.SessionID;
                usersession.SessionID = US.SessionID;
                usersession.Status = (int)Status.Started;
                usersession.UserID = US.UserID;
                usersession.Update();
                return Json(Data);
            }
            else
            {
                Data.SessionID = US.OTSessionID;
                Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.MODERATOR);
                Data.Token = OpenTok.GenerateToken(US.OTSessionID, tokenOptions);
                return Json(Data);
            }
        }


        public ActionResult DoctorSession(int? id)
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (Session["user"] != null || Session["Doctor"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                Doctors Doc = new Doctors();

                Doc = (Doctors)Session["Doctor"];
                ViewBag.CurrentDoctor = Doc;

                string[] specilaities = Enum.GetNames(typeof(Specialities));
                ViewBag.SPS = specilaities;
                TempData["ID"] = id;
                UserSessions US = new UserSessions();
                Sessions S = new Sessions();
                List<UserSessions> LOUS = new List<UserSessions>();
                US.SessionID = (int)id;
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dictionary<string, object> SDic = new Dictionary<string, object>();
                Dic.Add("@SessionID", US.SessionID);
                LOUS = US.Search(Dic);
                if (LOUS.Count == 0)
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");
                }
                US = LOUS[0];
                SDic.Add("@ID", US.SessionID);
                S = S.Search(SDic)[0];
                TempData["Session"] = S;
                TempData.Keep();
                ViewBag.S = S;
                if ((Session["Doctor"] as Doctors).ID != S.TherapistID)
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");
                }
                if ((ViewBag.S as Sessions).Status == 5)
                {
                    return View("DoctorSessionAr");
                }
                else if ((ViewBag.S as Sessions).Status == 8)
                {
                    return View("DoctorSessionAr");
                }
                else if (((ViewBag.S as Sessions).Status == 2))
                {
                    return View("DoctorSessionAr");
                }
                else
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");

                }
            }
            else
            {
                if (Session["user"] != null || Session["Doctor"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                Doctors Doc = new Doctors();

                Doc = (Doctors)Session["Doctor"];
                ViewBag.CurrentDoctor = Doc;

                string[] specilaities = Enum.GetNames(typeof(Specialities));
                ViewBag.SPS = specilaities;
                TempData["ID"] = id;
                UserSessions US = new UserSessions();
                Sessions S = new Sessions();
                List<UserSessions> LOUS = new List<UserSessions>();
                US.SessionID = (int)id;
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dictionary<string, object> SDic = new Dictionary<string, object>();
                Dic.Add("@SessionID", US.SessionID);
                LOUS = US.Search(Dic);
                if (LOUS.Count == 0)
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");
                }
                US = LOUS[0];
                SDic.Add("@ID", US.SessionID);
                S = S.Search(SDic)[0];
                TempData["Session"] = S;
                TempData.Keep();
                ViewBag.S = S;
                if ((Session["Doctor"] as Doctors).ID != S.TherapistID)
                {
                    return RedirectToAction("DoctorDashboard", "Doctor");
                }
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
                    return RedirectToAction("DoctorDashboard", "Doctor");

                }

            }
        }


        public void UpdateElapsed(string Time)
        {
            int Duration = (TempData["Session"] as Sessions).Duration;
            TempData.Keep();
            int start = Time.IndexOf(":");
            string Minutes = Time.Substring(start + 1, 2);
            string Hours = Time.Substring(0, 2);
            int TotalMinutes = Convert.ToInt32(Minutes) + (Convert.ToInt32(Hours) * 60);
            int Elapsed = Duration - (Convert.ToInt32(TotalMinutes));
            Sessions S = new Sessions();
            S = TempData["Session"] as Sessions;
            TempData.Keep();
            S.ElapsedTime = Elapsed;
            S.Update();
        }

        public int GetDuration()
        {

            int Duration = (TempData["Session"] as Sessions).Duration - (TempData["Session"] as Sessions).ElapsedTime;
            TempData.Keep();
            return Duration;
        }


        public ActionResult Pay(int id)
        {
            if (Session["user"] == null)
            {
                return Redirect("/user/login?URL=/Doctor/purchase/" + id);
            }
            Session["SID"] = id;
            Sessions s = new Sessions();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", id);
            s = s.Search(Dic)[0];
            s.SetTemporary();
            try
            {
                #region parameters
                var VPC_URL = "https://migs.mastercard.com.au/vpcpay";
                var paymentRequest = new PaymentRequest
                {
                    Amount = (s.Price * 100).ToString(),
                    ReturnUrl = Request.Url.AbsoluteUri.Replace("Pay/" + id, "Booked"),
                    AccessCode = "F05FC469",
                    MerchTxnRef = id.ToString(),
                    Merchant = "TEST512345USD",
                    OrderInfo = "Visa Assessment",
                };
                // SECURE_SECRET can be found in Merchant Administration/Setup page
                string hashSecrest = "E49780B4C8FDB4E38222ADE7F3B97CCA";
                #endregion
                #region redirect to payment gateway
                var transactionData = paymentRequest.GetParameters().OrderBy(t => t.Key, new VPCStringComparer()).ToList();
                // Add custom data, transactionData.Add(new KeyValuePair<string, string>("Title", title));
                var redirectUrl = VPC_URL + "?" + string.Join("&", transactionData.Select(item => HttpUtility.UrlEncode(item.Key) + "=" + HttpUtility.UrlEncode(item.Value)));
                if (!string.IsNullOrEmpty(hashSecrest))
                    redirectUrl += "&vpc_SecureHash=" + PaymentHelperMethods.CreateMD5Signature(hashSecrest + string.Join("", transactionData.Select(item => item.Value)));
                return Redirect(redirectUrl);
                #endregion
            }
            catch (Exception ex)
            {
                var message = "(51) Exception encountered. " + ex.Message;
                return View("PaymentError", ex);
            }
        }


        public void SessionFinished()
        {
            Sessions S = new Sessions();
            S = TempData["Session"] as Sessions;
            TempData.Keep();
            S.Status = (int)Status.Ended;
            S.Update();
        }

        public string Suspend(int ID)
        {
            Doctors D = new Doctors();
            D.Suspend(ID);
            return "true";
        }

        public string Approve(int ID)
        {
            Doctors D = new Doctors();
            var url = Request.Url;
            string baseurl = url.GetLeftPart(UriPartial.Authority);
            D.Approve(ID, baseurl);
            return "true";
        }

        public string Unsuspend(int ID)
        {
            Doctors D = new Doctors();
            D.Unsuspend(ID);
            return "true";
        }

        public string Delete(int ID) {
            Doctors D = new Doctors();
            D.ID=ID;
            D.Delete(D);
            return "true";
        }


        public ActionResult GroupSessionAdmin(int id)
        {
            if (Session["user"] != null || Session["Doctor"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["ID"] = id;
            UserSessions US = new UserSessions();
            Sessions S = new Sessions();
            List<UserSessions> LOUS = new List<UserSessions>();
            US.ID = id;
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dictionary<string, object> SDic = new Dictionary<string, object>();
            Dic.Add("@ID", US.ID);
            LOUS = US.Search(Dic);
            US = LOUS[0];
            SDic.Add("@ID", US.SessionID);
            S = S.Search(SDic)[0];
            TempData["Session"] = S;
            TempData.Keep();
            if ((Session["Doctor"] as Doctors).ID != S.TherapistID)
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
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.MODERATOR);
                Data.Token = OpenTok.GenerateToken(Data.SessionID, tokenOptions);
                usersession.ID = US.ID;
                usersession.OTSessionID = Data.SessionID;
                usersession.SessionID = US.SessionID;
                usersession.Status = (int)Status.Started;
                usersession.UserID = US.UserID;
                usersession.Update();
                return Json(Data);
            }
            else
            {
                Data.SessionID = US.OTSessionID;
                Dictionary<string, object> tokenOptions = new Dictionary<string, object>();
                tokenOptions.Add(TokenPropertyConstants.ROLE, RoleConstants.MODERATOR);
                Data.Token = OpenTok.GenerateToken(US.OTSessionID, tokenOptions);
                return Json(Data);
            }
        }

        public ActionResult View(int id)
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                Doctors Doc = new Doctors();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", id);
                List<Doctors> LOD = new List<Doctors>();
                LOD = Doc.Search(Dic);
                if (LOD.Count == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                Doc = LOD[0];
                ViewBag.CurrentDoctor = Doc;
                return View("ViewAr");
            }
            else
            {
                Doctors Doc = new Doctors();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", id);
                List<Doctors> LOD = new List<Doctors>();
                LOD = Doc.Search(Dic);
                if (LOD.Count == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                Doc = LOD[0];
                ViewBag.CurrentDoctor = Doc;
                return View();

            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Response.Cookies["UserData"].Value = string.Empty;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult SubmitTherapistAccount()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                return View("SubmitTherapistAccountAr");
            }
            else
            {
                return View();

            }
        }

        public ActionResult DoctorDashboard()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {

                if (Session["Doctor"] == null)
                {
                    return RedirectToAction("Login", "User");
                }

                Doctors Doc = new Doctors();
                ViewBag.TO = int.Parse(Session["TO"].ToString());
                Doc.ID = ((Doctors)Session["Doctor"]).ID;
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", Doc.ID);
                Doc = (Doc.Search(Dic))[0];
                ViewBag.currentDoctor = Doc;
                Sessions S = new Sessions();
                List<Sessions> LOS = new List<Sessions>();
                LOS = S.GetPendingSessionsD(Doc.ID);
                ViewBag.DoctorSessions = LOS;
                return View("DoctorDashboardAr");
            }
            else
            {
                if (Session["Doctor"] == null)
                {
                    return RedirectToAction("LoginUser", "User");
                }

                Doctors Doc = new Doctors();
                ViewBag.TO = int.Parse(Session["TO"].ToString());
                Doc.ID = ((Doctors)Session["Doctor"]).ID;
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", Doc.ID);
                Doc = (Doc.Search(Dic))[0];
                ViewBag.currentDoctor = Doc;
                Sessions S = new Sessions();
                List<Sessions> LOS = new List<Sessions>();
                LOS = S.GetPendingSessionsD(Doc.ID);
                ViewBag.DoctorSessions = LOS;
                return View();


            }
        }
        public string SubmitAccount(string _Email, string _Bio, string _FirstName, string _LastName, string _Password, string _Phone,string _BioAr)
        {
            SystemMessages msg;
            Doctors doc = new Doctors();
            doc.Username = _Email;
            doc.FirstName = _FirstName;
            doc.LastName = _LastName;
            doc.Bio = _Bio;
            doc.bioAr = _BioAr;
            doc.sessionInfo = "";
            doc.SP1 = 1;
            doc.SP2 = 2;
            doc.SP3 = 3;
            doc.ProfileImageLink = "";
            doc.TotalSession = 0;
            doc.TotalScore = 0;
            doc.CostPercentage = 70;
            doc.Language = 0;
            doc.LastLogin = DateTime.Now;
            doc.Title = "";
            doc.Password = _Password;
            doc.Phone = _Phone;
            doc.LastLogin = DateTime.Now;
            doc.Status = (int)Status.Pending;
            doc.ProfileImageLink = @"/content/img/UserImages/Doctors/Default46549878465465.png";
            doc.HashCode = Guid.NewGuid().ToString();
            Users U = new Users();
            List<Users> LOU = new List<Users>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("@Username", doc.Username);
            LOU = U.Search(dic);
            if (LOU.Count != 0)
            {
                return "false";
            }
            doc.CreateProfile(out msg);
            if (msg == SystemMessages.ErrorCreatingProfile)
            {
                return "false";
            }
            else
            {
                return "true";

            }

        }

        public ActionResult UpdateProfile()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (Session["Doctor"] == null)
                {
                    return RedirectToAction("Login", "User");

                }
                Doctors Doc = new Doctors();
                Doc = (Doctors)Session["Doctor"];
                List<Certificates> LOC = new List<Certificates>();
                LOC = Doc.GetMyCertificates();
                string[] specilaities = Enum.GetNames(typeof(SpecialitiesAr));
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@TherapistID", Doc.ID);
                Dic.Add("@Status", (int)Status.Created);
                Sessions S = new Sessions();
                List<Sessions> LOS = new List<Sessions>();
                LOS = S.Search(Dic);
                ViewBag.DoctorSessions = LOS;
                ViewBag.DoctorCertificates = LOC;
                ViewBag.CurrentDoctor = Doc;
                ViewBag.SPS = specilaities;
                string[] langs = Enum.GetNames(typeof(Language));
                ViewBag.langs = langs;
                return View("UpdateProfileAr");
            }
            else
            {

                if (Session["Doctor"] == null)
                {
                    return RedirectToAction("Login", "User");

                }
                Doctors Doc = new Doctors();
                Doc = (Doctors)Session["Doctor"];
                List<Certificates> LOC = new List<Certificates>();
                LOC = Doc.GetMyCertificates();
                string[] specilaities = Enum.GetNames(typeof(Specialities));
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@TherapistID", Doc.ID);
                Dic.Add("@Status", (int)Status.Created);
                Sessions S = new Sessions();
                List<Sessions> LOS = new List<Sessions>();
                LOS = S.Search(Dic);
                ViewBag.DoctorSessions = LOS;
                ViewBag.DoctorCertificates = LOC;
                ViewBag.CurrentDoctor = Doc;
                ViewBag.SPS = specilaities;
                string[] langs = Enum.GetNames(typeof(Language));
                ViewBag.langs = langs;
                return View();

            }
        }

        public string UpdateBasicData(string _Email, string _FirstName, string _LastName, string _Password, string _Phone, string _ProfileImageLink, string _Bio, string _Title, int _SP1, int _SP2, int _SP3, int _Lang, string _BioAr)
        {
            SystemMessages msg;
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Doctors doc = new Doctors();
            doc.ID = (Session["Doctor"] as Doctors).ID;
            Dic.Add("@ID", doc.ID);
            List<Doctors> LOD = new List<Doctors>();
            LOD = doc.Search(Dic);
            Doctors doctor = new Doctors();
            doctor = LOD[0];
            doctor.Username = _Email;
            doctor.FirstName = _FirstName;
            doctor.LastName = _LastName;
            doctor.Password = _Password;
            doctor.Phone = _Phone;
            doctor.Bio = _Bio;
            doctor.bioAr = _BioAr;
            doctor.Title = _Title;
            doctor.SP1 = _SP1;
            doctor.SP2 = _SP2;
            doctor.SP3 = _SP3;
            doctor.Language = _Lang;
            if (_ProfileImageLink != null)
            {
                Image Img = LoadImage(_ProfileImageLink);
                string Path;
                using (Bitmap image = new Bitmap(Img))
                {
                    var fileName = _Email + ".png";
                    Path = @"/content/img/UserImages/Doctors/" + fileName;
                    string ImagePath = Server.MapPath(Path);
                    image.Save(ImagePath);
                }
                doctor.ProfileImageLink = Path;
            }
            doctor.UpdateProfile(out msg);
            if (msg == SystemMessages.UpdateSuccess)
            {

                Session["Doctor"] = doctor;
                return "true";
            }
            else
            {
                return "false";

            }


        }


        public string AddCertificate(string _CertName, string _CertDesc, string _CImage)
        {
            SystemMessages msg;
            Doctors Doc = new Doctors();
            Doc = (Doctors)Session["Doctor"];
            Certificates Cert = new Certificates();
            Cert.CertificateName = _CertName;
            Cert.Description = _CertDesc;
            Cert.DoctorID = Doc.ID;

            if (_CImage != null)
            {
                Image Img = LoadImage(_CImage);
                string Path;
                using (Bitmap image = new Bitmap(Img))
                {
                    var fileName = Guid.NewGuid() + ".png";
                    Path = @"/content/img/UserImages/Doctors/certificate/" + fileName;
                    string ImagePath = Server.MapPath(Path);
                    image.Save(ImagePath);
                }
                Cert.PhotocopyLink = Path;
            }
            Cert.CertificateDate = DateTime.Now;
            Cert.ValidationDate = DateTime.Now;
            Doc.AddCertificate(Cert, out msg, Doc.ID);
            if (msg == SystemMessages.CertificateAddedSuccessfully)
            {
                return "true";

            }
            else
            {
                return "false";

            }

        }

        public void DeleteCertificate(int _CertID)
        {
            SystemMessages msg;
            Doctors Doc = new Doctors();
            Doc = (Doctors)Session["Doctor"];
            Certificates C = new Certificates();
            C.ID = _CertID;
            C = Doc.GetCertificate(C);
            Doc.RemoveCertificate(C, out msg);
        }

        public JsonResult AddSessionExtended(DateTime _SDate, TimeSpan _STime, int _Speciality, int _Duration, double _Price, int _Type)
        {
            Doctors Doc = new Doctors();
            Doc = (Doctors)Session["Doctor"];
            Sessions S = new Sessions();
            S.TherapistID = Doc.ID;
            decimal TO = int.Parse(Session["TO"].ToString());
            DateTime SessionDate = new DateTime(_SDate.Year, _SDate.Month, _SDate.Day, _STime.Hours, _STime.Minutes, 0);
            S.Date = SessionDate.AddMinutes((double)TO);
            S.SP = _Speciality;
            S.Duration = _Duration;
            S.Price = _Price;
            S.Type = _Type;
            S.ElapsedTime = 0;
            S.Status = (int)Status.UnPaid;
            S.Add();
            Sessions LastSession = new Sessions();
            LastSession = S.GetlastByDoctorId(Doc.ID);
            int SessionID = LastSession.ID;
            Users U = new Users();
            U = (Users)TempData["SessionUser"];
            UserSessions US = new UserSessions();
            US.SessionID = SessionID;
            US.UserID = U.ID;
            US.Status = (int)Status.UnPaid;
            US.OTSessionID = "";
            US.Insert();
            Helper H = new Helper();
            var url = Request.Url;
            string baseurl = url.GetLeftPart(UriPartial.Authority);
            H.SendEmail("Nofoos.com - Session Schedualed", LastSession.Users.SingleOrDefault().Username, "Doctor " + LastSession.Therapist.FirstName + " " + LastSession.Therapist.LastName + " schedualed new session with you , Please access your <a href='" + baseurl + "/User/UserDashboard'>dashboard</a> to Pay It Now .");
            return Json(LastSession);
        }

        public void RemoveSession(int _ID)
        {

            Sessions S = new Sessions();
            S.ID = _ID;
            S.Delete();

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

        public void SetAsStarted()
        {
            Sessions S = new Sessions();
            S = (Sessions)TempData["Session"];
            TempData["Session"] = S;
            TempData.Keep();
            S.Status = (int)Status.Started;
            S.Update();

        }

        public ActionResult ScheduleSession()
        {

            if (Request.Cookies["Lang"].Value == "Ar")
            {
                Doctors Doc = new Doctors();
                Doc = (Doctors)Session["Doctor"];
                ViewBag.CurrentDoctor = Doc;
                Sessions S = new Sessions();
                S = (Sessions)TempData["Session"];
                TempData.Keep();
                Users SessionUser = new Users();
                SessionUser = S.Users[0];
                TempData["SessionUser"] = SessionUser;
                TempData.Keep();
                ViewBag.SessionUser = SessionUser;
                string[] specilaities = Enum.GetNames(typeof(Specialities));
                ViewBag.SPS = specilaities;
                return View("ScheduleSessionAr");
            }
            else
            {
                Doctors Doc = new Doctors();
                Doc = (Doctors)Session["Doctor"];
                ViewBag.CurrentDoctor = Doc;
                Sessions S = new Sessions();
                S = (Sessions)TempData["Session"];
                TempData.Keep();
                Users SessionUser = new Users();
                SessionUser = S.Users[0];
                TempData["SessionUser"] = SessionUser;
                TempData.Keep();
                ViewBag.SessionUser = SessionUser;
                string[] specilaities = Enum.GetNames(typeof(Specialities));
                ViewBag.SPS = specilaities;
                return View();

            }

        }

        public JsonResult AddSession(DateTime _SDate, TimeSpan _STime, int _Duration, double _Price, int _Type)
        {
            Doctors Doc = new Doctors();
            decimal TO = int.Parse(Session["TO"].ToString());
            Doc = (Doctors)Session["Doctor"];
            Sessions S = new Sessions();
            DateTime SessionDateForCheck = new DateTime(_SDate.Year, _SDate.Month, _SDate.Day, _STime.Hours, _STime.Minutes, 0).AddMinutes((double)TO);
            List<Sessions> LOS = new List<Sessions>();
            LOS= S.CheckOverlapping(SessionDateForCheck, _Duration, Doc.ID);
            if (SessionDateForCheck < DateTime.Now) 
            {

                return Json("Past");
            
            }
            if (LOS.Count == 0)
            {
                S.TherapistID = Doc.ID;
               
                DateTime SessionDate = new DateTime(_SDate.Year, _SDate.Month, _SDate.Day, _STime.Hours, _STime.Minutes, 0);
                S.Date = SessionDate.AddMinutes((double)TO);
                S.SP = 0;
                S.Duration = _Duration;
                S.Price = _Price;
                S.Type = _Type;
                S.ElapsedTime = 0;
                S.Status = (int)Status.Created;
                S.Add();
                Sessions LastSession = new Sessions();
                LastSession = S.GetlastByDoctorId(Doc.ID);
                int SessionID = LastSession.ID;
                return Json(LastSession);
            }
            else 
            {
                return Json("TimeError");
            
            }
        }

        public ActionResult Purchase(int? id)
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (id == null)
                {
                    return RedirectToAction("SearchSessions", "Doctor");
                }
                Sessions S = new Sessions();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", id);
                S = S.Search(Dic)[0];
                ViewBag.Session = S;
                if ((ViewBag.Session as Sessions).Status == 6 && (ViewBag.Session as Sessions).Date > DateTime.UtcNow.Date)
                {
                    ViewBag.MSG = null;
                    if (Request.QueryString.Count != 0)
                    {
                        string rem = S.RemainingToStartAr.Replace(" متبقيه", "");
                        ViewBag.MSG = " لقد عثرنا لك على جلسة بعد" + rem + "إضغط على زر الحجز لتقوم بحجز الجلسة ";
                    }
                    //S.SetTemporary();
                    return View("PurchaseAr");
                }
                else
                {
                    return RedirectToAction("SearchSessions", "Doctor");
                }
            }
            else
            {
                if (id == null)
                {
                    return RedirectToAction("SearchSessions", "Doctor");
                }
                Sessions S = new Sessions();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", id);
                S = S.Search(Dic)[0];
                ViewBag.Session = S;
                if ((ViewBag.Session as Sessions).Status == 6 && (ViewBag.Session as Sessions).Date > DateTime.UtcNow.Date)
                {
                    ViewBag.MSG = null;
                    if (Request.QueryString.Count != 0)
                    {
                        string rem = S.RemainingToStart.Replace("Left", "");
                        ViewBag.MSG = "Our team recommend a session After " + rem + " for you, click book now button to get that session";
                    }
                    //S.SetTemporary();
                    return View();
                }
                else
                {
                    return RedirectToAction("SearchSessions", "Doctor");
                }

            }

        }

        public ActionResult DoctorHistory()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                if (Session["Doctor"] == null)
                {
                    return RedirectToAction("Login", "User");
                }
                return View("DoctorHistoryAr");
            }
            else
            {
                if (Session["Doctor"] == null)
                {
                    return RedirectToAction("Login", "User");
                }
                return View();

            }
        }

        public JsonResult FilterSessions(string Date, int Status)
        {
            Doctors current = new Doctors();
            current = (Doctors)Session["Doctor"];
            int currentUID = current.ID;

            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@TherapistID", currentUID);
            List<Sessions> LOS = new List<Sessions>();
            Sessions S = new Sessions();
            LOS = S.Search(Dic);
            List<Sessions> FilteredSession = new List<Sessions>();
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
                        if (X.Status == 6)
                        {

                        }
                        else
                        {
                            FilteredSession.Add(X);
                        }

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
                        if (X.Status == 6)
                        {

                        }
                        else
                        {
                            FilteredSession.Add(X);
                        }

                    }
                }
                return Json(FilteredSession);

            }
            if ((Int32)Status == 2500 && Date == "null")
            {
                List<Sessions> mylist = new List<Sessions>();
                foreach (Sessions mm in LOS)
                {
                    if (mm.Status != 6)
                    {
                        mylist.Add(mm);
                    }
                }

                return Json(mylist);
            }
            if ((Int32)Status == 2500 && Date != "null")
            {
                string Day = Date.Split('/')[0];
                string month = Date.Split('/')[1];
                string year = Date.Split('/')[2];
                DateTime SessionDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(Day), 0, 0, 0);
                foreach (Sessions X in LOS)
                {
                    string DateOnly = X.Date.ToShortDateString();
                    if (DateOnly == SessionDate.ToShortDateString())
                    {
                        if (X.Status == 6)
                        {

                        }
                        else
                        {
                            FilteredSession.Add(X);
                        }


                    }
                }
                return Json(FilteredSession);
            }


            return Json(LOS);
        }

        private string CreateMD5Signature(string RawData)
        {
            /*
             <summary>Creates a MD5 Signature</summary>
             <param name="RawData">The string used to create the MD5 signautre.</param>
             <returns>A string containing the MD5 signature.</returns>
             */

            System.Security.Cryptography.MD5 hasher = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
            byte[] HashValue = hasher.ComputeHash(Encoding.ASCII.GetBytes(RawData));

            string strHex = "";
            foreach (byte b in HashValue)
            {
                strHex += b.ToString("x2");
            }
            return strHex.ToUpper();
        }

        public ActionResult Booked()
        {
            bool CheckPayment = false;
            try
            {
                // SECURE_SECRET can be found in Merchant Administration/Setup page
                string hashSecrest = "E49780B4C8FDB4E38222ADE7F3B97CCA";
                var secureHash = Request.QueryString["vpc_SecureHash"];
                if (!string.IsNullOrEmpty(secureHash))
                {
                    if (!string.IsNullOrEmpty(hashSecrest))
                    {
                        var rawHashData = hashSecrest + string.Join("", Request.QueryString.AllKeys.Where(k => k != "vpc_SecureHash").Select(k => Request.QueryString[k]));
                        var signature = PaymentHelperMethods.CreateMD5Signature(rawHashData);
                        string status = Request.QueryString["vpc_VerStatus"];
                        if (signature != secureHash)
                        {
                            return RedirectToAction("PaymentError", "Doctor");
                        }
                        else
                        {
                            if (status == "M" || status == "Y" || status == "A")
                            {
                                CheckPayment = true;
                            }
                            else
                            {
                                return RedirectToAction("PaymentError", "Doctor");

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = "(51) Exception encountered. " + ex.Message;
                return View("Error", ex);
            }
            string Response = Request.RawUrl;
            if (CheckPayment)
            {
                Sessions S = new Sessions();
                Helper H = new Helper();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", Session["SID"]);
                S = S.Search(Dic)[0];
                if (S.Type == 1)
                {
                    int UserID = (Session["user"] as Users).ID;
                    S.Purchase((int)Session["SID"], UserID);
                    FTrans FT = new FTrans();
                    FT.UserID = UserID;
                    FT.SessionID = (int)Session["SID"];
                    FT.PaymentMethod = (int)PaymentMethods.CreditCard;
                    FT.PaymentInfo = "null";
                    FT.Date = DateTime.Now;
                    FT.Amount = S.Price;
                    FT.Add();
                    var url = Request.Url;
                    string baseurl = url.GetLeftPart(UriPartial.Authority);
                    H.SendEmail("Nofoos.com - New Session", S.Therapist.Username, (Session["user"] as Users).DisplayName + " booked new session with you . <br /> For more details click <a href='" + baseurl + "/User/Login'>HERE</a>");
                    H.SendEmail("Nofoos.com - New Session", S.Users.SingleOrDefault().Username, "Session Booked Successfully . <br /> For more details click <a href='" + baseurl + "/User/Login'>HERE</a>");
                    return RedirectToAction("UserDashboard", "User");
                }
                else
                {
                    Dic.Clear();
                    UserSessions US = new UserSessions();
                    Dic.Add("@SessionID", Session["SID"]);
                    List<UserSessions> LOUS = new List<UserSessions>();
                    LOUS = US.Search(Dic);
                    if (LOUS.Count() == 4)
                    {
                        int UserID = (Session["user"] as Users).ID;
                        S.Purchase((int)Session["SID"], UserID);
                        var url = Request.Url;
                        string baseurl = url.GetLeftPart(UriPartial.Authority);
                        H.SendEmail("Nofoos.com - New Session", S.Therapist.Username, (Session["user"] as Users).DisplayName + "booked new session with you . <br /> For more details click <a href='" + baseurl + "/User/Login'>HERE</a>");
                        return RedirectToAction("UserDashboard", "User");
                    }
                    else
                    {
                        int UserID = (Session["user"] as Users).ID;
                        S.PurchaseGroup((int)Session["SID"], UserID);
                        var url = Request.Url;
                        string baseurl = url.GetLeftPart(UriPartial.Authority);
                        H.SendEmail("Nofoos.com - New Session", S.Therapist.Username, (Session["user"] as Users).DisplayName + " booked new session with you . <br /> For more details click <a href='" + baseurl + "/User/Login'>HERE</a>");
                        return RedirectToAction("UserDashboard", "User");
                    }
                }
            }
            else
            {
                return RedirectToAction("Dashboard", "user");
            }

        }

        public ActionResult PaymentError()
        {
            if (Request.Cookies["Lang"].Value == "Ar")
            {
                ViewBag.Msg = "حدث خطأ أثناء عملية الدفع يرجى المحاولة مرة أخرى";
                return View("PaymentErrorAr");
            }
            else
            {
                ViewBag.Msg = "An error occured during transaction please try again ";
                return View();
            }
        }

        public ActionResult PayAfter(int id)
        {
           
            Session["SID"] = id;
            Sessions s = new Sessions();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("@ID", id);
            s = s.Search(Dic)[0];
            try
            {
                #region parameters
                var VPC_URL = "https://migs.mastercard.com.au/vpcpay";
                var paymentRequest = new PaymentRequest
                {
                    Amount = (s.Price * 100).ToString(),
                    ReturnUrl = Request.Url.AbsoluteUri.Replace("PayAfter/" + id, "BookedAfter").Replace("User", "Doctor"),
                    AccessCode = "F05FC469",
                    MerchTxnRef = id.ToString(),
                    Merchant = "TEST512345USD",
                    OrderInfo = "Visa Assessment",
                };
                // SECURE_SECRET can be found in Merchant Administration/Setup page
                string hashSecrest = "E49780B4C8FDB4E38222ADE7F3B97CCA";
                #endregion
                #region redirect to payment gateway
                var transactionData = paymentRequest.GetParameters().OrderBy(t => t.Key, new VPCStringComparer()).ToList();
                // Add custom data, transactionData.Add(new KeyValuePair<string, string>("Title", title));
                var redirectUrl = VPC_URL + "?" + string.Join("&", transactionData.Select(item => HttpUtility.UrlEncode(item.Key) + "=" + HttpUtility.UrlEncode(item.Value)));
                if (!string.IsNullOrEmpty(hashSecrest))
                    redirectUrl += "&vpc_SecureHash=" + PaymentHelperMethods.CreateMD5Signature(hashSecrest + string.Join("", transactionData.Select(item => item.Value)));
                return Redirect(redirectUrl);
                #endregion
            }
            catch (Exception ex)
            {
                var message = "(51) Exception encountered. " + ex.Message;
                return View("PaymentError", ex);
            }
        }
          public ActionResult BookedAfter()
        {
            bool CheckPayment = false;
            try
            {
                // SECURE_SECRET can be found in Merchant Administration/Setup page
                string hashSecrest = "E49780B4C8FDB4E38222ADE7F3B97CCA";
                var secureHash = Request.QueryString["vpc_SecureHash"];
                if (!string.IsNullOrEmpty(secureHash))
                {
                    if (!string.IsNullOrEmpty(hashSecrest))
                    {
                        var rawHashData = hashSecrest + string.Join("", Request.QueryString.AllKeys.Where(k => k != "vpc_SecureHash").Select(k => Request.QueryString[k]));
                        var signature = PaymentHelperMethods.CreateMD5Signature(rawHashData);
                        string status = Request.QueryString["vpc_VerStatus"];
                        if (signature != secureHash)
                        {
                            return RedirectToAction("PaymentError", "Doctor");
                        }
                        else
                        {
                            if (status == "M" || status == "Y" || status == "A")
                            {
                                CheckPayment = true;
                            }
                            else
                            {
                                return RedirectToAction("PaymentError", "Doctor");

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = "(51) Exception encountered. " + ex.Message;
                return View("Error", ex);
            }
            string Response = Request.RawUrl;
            if (CheckPayment)
            {
                Sessions S = new Sessions();
                Helper H = new Helper();
                Dictionary<string, object> Dic = new Dictionary<string, object>();
                Dic.Add("@ID", Session["SID"]);
                S = S.Search(Dic)[0];
                if (S.Type == 1)
                {
                    int UserID = (Session["user"] as Users).ID;
                   
                    FTrans FT = new FTrans();
                    FT.UserID = UserID;
                    FT.SessionID = (int)Session["SID"];
                    FT.PaymentMethod = (int)PaymentMethods.CreditCard;
                    FT.PaymentInfo = "null";
                    FT.Date = DateTime.Now;
                    FT.Amount = S.Price;
                    FT.Add();
                    S.Status = (int)Status.Purchased;
                    S.Update();
                     H.SendEmail("Nofoos.com - New Session", S.Therapist.Username, (Session["user"] as Users).DisplayName + " booked new session with you . <br /> For more details click <a href='http://localhost:8410/User/Login'>HERE</a>");
                    H.SendEmail("Nofoos.com - New Session", S.Users.SingleOrDefault().Username, "Session Booked Successfully . <br /> For more details click <a href='http://localhost:8410/User/Login'>HERE</a>");
                    return RedirectToAction("UserDashboard", "User");
                }
                else
                {
                    Dic.Clear();
                    UserSessions US = new UserSessions();
                    Dic.Add("@SessionID", Session["SID"]);
                    List<UserSessions> LOUS = new List<UserSessions>();
                    LOUS = US.Search(Dic);
                    if (LOUS.Count() == 4)
                    {
                        int UserID = (Session["user"] as Users).ID;
                        S.Purchase((int)Session["SID"], UserID);
                        H.SendEmail("Nofoos.com - New Session", S.Therapist.Username, (Session["user"] as Users).DisplayName + "booked new session with you . <br /> For more details click <a href='http://localhost:8410/User/Login'>HERE</a>");
                        return RedirectToAction("UserDashboard", "User");
                    }
                    else
                    {
                        int UserID = (Session["user"] as Users).ID;
                        S.PurchaseGroup((int)Session["SID"], UserID);
                        H.SendEmail("Nofoos.com - New Session", S.Therapist.Username, (Session["user"] as Users).DisplayName + " booked new session with you . <br /> For more details click <a href='http://localhost:8410/User/Login'>HERE</a>");
                        return RedirectToAction("UserDashboard", "User");
                    }
                }
            }
            else
            {
                return RedirectToAction("Dashboard", "user");
            }

        }
    }
}
