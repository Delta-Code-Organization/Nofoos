using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDAL;

namespace FDll
{
    class Program
    {
        static SystemMessages Msg;

        static void Main(string[] args)
        {
            TestAdd_DoctorsAvailability();
            TestAddCertificate_Admin();
            TestBuy_Offer();
            TestCancelGroup_Groups();
            TestChangePassword_SystemAdmin();
            TestClose_Offers();
            TestComment_Posts();
            TestCreate_Offers();
            TestCreate_SystemAdmin();
            TestCreateGroup_Groups();
            TestCreatePost_Posts();
            TestCreateProfile_Admin();
            TestDelete_DoctorsAvailability();
            TestDelete_Offer();
            TestDelete_Posts();
            TestDisable_Admin();
            TestDisable_SystemAdmin();
            TestDisable_Users();
            TestEndSession_Admin();
            TestGetAvailable_Offer();
            TestGetComments_Posts();
            TestGetLatestPosts_Posts();
            TestGetLikes_Posts();
            TestGetMyCertificates_Admin();
            TestGetMyPosts_Posts();
            TestGetTopPosts_Posts();
            TestLike_Posts();
            TestLogin_SystemAdmin();
            TestRate_Groups();
            TestRegister_Users();
            TestRemoveCertificate_Admin();
            TestRemoveComment_PostComments();
            TestSearch_Admin();
            TestSearch_Groups();
            TestSearch_Offer();
            TestSearch_SystemAdmin();
            TestSearch_Users();
            TestStartSession_Admin();
            TestUnlike_PostLikes();
            TestUpdate_Offers();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                                ");
            Console.WriteLine("                            All Methods Works Great                             ");
            Console.WriteLine("                                                                                ");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }

        static void TestAddCertificate_Admin()
        {
            Admin A = new Admin();
            Certificates Cer = new Certificates();
            Cer.DoctorID = 1;
            Cer.CertificateName = "Certificate Name";
            Cer.CertificateDate = DateTime.Now;
            Cer.ValidationDate = DateTime.Now;
            Cer.Description = "Desc";
            Cer.PhotocopyLink = "PhotoLink";
            A.AddCertificate(Cer, out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test AddCertificate Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestRemoveCertificate_Admin()
        {
            Admin A = new Admin();
            Certificates Cer = new Certificates();
            Cer.ID = 6;
            A.RemoveCertificate(Cer, out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test RemoveCertificate Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestStartSession_Admin()
        {
            Admin A = new Admin();
            UserSessions S = new UserSessions();
            S.ID = 2;
            A.StartSession(S, out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test StartSession Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestEndSession_Admin()
        {
            Admin A = new Admin();
            UserSessions S = new UserSessions();
            S.ID = 2;
            A.EndSession(S, out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test EndSession Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestCreateProfile_Admin()
        {
            Admin A = new Admin();
            A.Title = "Title";
            A.FirstName = "FirstName";
            A.LastName = "LastName";
            A.ProfileImageLink = "ProfileImageLink";
            A.Bio = "Bio";
            A.CostPercentage = 2.5;
            A.LastLogin = DateTime.Now;
            A.Password = "Password";
            A.SessionPrice = 150.25;
            A.status = 5;
            A.TotalScore = 18.07;
            A.TotalSession = 99;
            A.Type = "Admin";
            A.Username = "Username";
            A.CreateProfile(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test CreateProfile Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestDisable_Admin()
        {
            Admin A = new Admin();
            A.ID = 13;
            A.Disable(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test Disable Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }
 
        static void TestSearch_Admin()
        {
            Admin A = new Admin();
            List<Admin> LOA = new List<Admin>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("Username", "Username");
            LOA = A.Search(Dic);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test Search Method Result :");
            foreach (Admin item in LOA)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Password :" + item.Password);
            }
            Console.ReadLine();
        }

        static void TestGetMyCertificates_Admin()
        {
            Admin A = new Admin();
            Doctors D = new Doctors();
            List<Certificates> LOC = new List<Certificates>();
            D.ID = 6;
            LOC = A.GetMyCertificates(D);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Admin Class :");
            Console.WriteLine("             Test GetMyCertificates Method Result :");
            foreach (Certificates item in LOC)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("CertificateName :" + item.CertificateName);
            }
            Console.ReadLine();
        }

        static void TestAdd_DoctorsAvailability()
        {
            DoctorsAvailability DA = new DoctorsAvailability();
            DA.Day = 5;
            DA.DoctorID = 6;
            DA.FromTime = new TimeSpan(2,25,59);
            DA.ToTime = new TimeSpan(5, 25, 59);
            DA.type = 10;
            DA.Add(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("DoctorsAvailability Class :");
            Console.WriteLine("             Test Add Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestDelete_DoctorsAvailability()
        {
            DoctorsAvailability DA = new DoctorsAvailability();
            DA.ID = 1;
            DA.Delete(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("DoctorsAvailability Class :");
            Console.WriteLine("             Test Delete Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestCreateGroup_Groups()
        {
            Groups G = new Groups();
            G.ActualStartTime = DateTime.Now.ToString();
            G.AdminID = 5;
            G.Descriptions = "Desc";
            G.EndTime = DateTime.Now.ToString();
            G.GroupCategory = 5;
            G.SupposedTime = DateTime.Now.ToString();
            G.Title = "GroupTitleForTest";
            G.CreateGroup(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Groups Class :");
            Console.WriteLine("             Test CreateGroup Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestCancelGroup_Groups()
        {
            Groups G = new Groups();
            G.ID = 55;
            G.CancelGroup(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Groups Class :");
            Console.WriteLine("             Test CancelGroup Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestSearch_Groups()
        {
            Groups G = new Groups();
            List<Groups> LOG = new List<Groups>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("Title", "GroupTitleForTest");
            LOG = G.Search(Dic);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Groups Class :");
            Console.WriteLine("             Test Search Method Result :");
            foreach (Groups item in LOG)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Group Descriptions :" + item.Descriptions);
            }
            Console.ReadLine();
        }

        static void TestRate_Groups()
        {
            Groups G = new Groups();
            GroupRates GR = new GroupRates();
            GR.Date = DateTime.Now;
            GR.GroupID = 55;
            GR.Rate = 9.5;
            GR.UserID = 5;
            G.Rate(out Msg, GR);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Groups Class :");
            Console.WriteLine("             Test RateGroup Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestCreate_Offers()
        {
            Offers O = new Offers();
            O.OfferName = "OfferName20";
            O.Description = "Description";
            O.AvailableFrom = DateTime.Now;
            O.AvailableTo = DateTime.Now;
            O.NumberOfSessions = 120;
            O.SessionPrice = 20;
            O.OverAllPrice = 20;
            O.DiscountPercentage = 20;
            O.Create(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Offers Class :");
            Console.WriteLine("             Test Create Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestUpdate_Offers()
        {
            Offers O = new Offers();
            O.ID = 3;
            O.OfferName = "OfferName38";
            O.Description = "Description";
            O.AvailableFrom = DateTime.Now;
            O.AvailableTo = DateTime.Now;
            O.NumberOfSessions = 120;
            O.SessionPrice = 20;
            O.OverAllPrice = 20;
            O.DiscountPercentage = 20;
            O.Update(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Offers Class :");
            Console.WriteLine("             Test Update Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestClose_Offers()
        {
            Offers O = new Offers();
            O.ID = 3;
            O.Close(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Offers Class :");
            Console.WriteLine("             Test Close Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestDelete_Offer()
        {
            Offers O = new Offers();
            O.ID = 1;
            O.Delete(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Offers Class :");
            Console.WriteLine("             Test Delete Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestGetAvailable_Offer()
        {
            List<Offers> LOO = new List<Offers>();
            Offers O = new Offers();
            LOO = O.GetAvailable();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Offers Class :");
            Console.WriteLine("             Test GetAvailable Method Result :");
            foreach (Offers item in LOO)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Offer Name : " + item.OfferName);
            }
            Console.ReadLine();
        }

        static void TestSearch_Offer()
        {
            Offers O = new Offers();
            List<Offers> LOO = new List<Offers>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("ID", 3);
            LOO = O.Search(Dic);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Offers Class :");
            Console.WriteLine("             Test Search Method Result :");
            foreach (Offers item in LOO)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Offer Name : " + item.OfferName);
            }
            Console.ReadLine();
        }

        static void TestBuy_Offer()
        {
            Offers O = new Offers();
            UserPayments UP = new UserPayments();
            UP.Amount = 10;
            UP.Date = DateTime.Now;
            UP.PaymentBy = 20;
            UP.PaymentDescription = "PaymentDescription";
            UP.PaymentReferenceCode = "PaymentReferenceCode";
            UP.Session = 5;
            UP.status = (int)Status.Purchased;
            UP.UsedInDate = DateTime.Now;
            UP.UserID = 6;
            O.Buy(out Msg, UP);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Offers Class :");
            Console.WriteLine("             Test Buy Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestCreatePost_Posts()
        {
            Posts P = new Posts();
            P.PostDate = DateTime.Now;
            P.PostText = "PostsText";
            P.TotalComments = 15;
            P.TotalLikes = 120;
            P.UserID = 6;
            P.CreatePost(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test CreatePost Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestComment_Posts()
        {
            Posts P = new Posts();
            PostComments PC = new PostComments();
            PC.CommentDate = DateTime.Now;
            PC.CommentText = "CommentText";
            PC.PostID = 5;
            PC.UserID = 6;
            P.Comment(out Msg, PC);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test Comment Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestLike_Posts()
        {
            Posts P = new Posts();
            PostLikes PL = new PostLikes();
            PL.Date = DateTime.Now;
            PL.PostID = 5;
            PL.UserID = 6;
            P.Like(out Msg, PL);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test Like Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestDelete_Posts()
        {
            Posts P = new Posts();
            P.ID = 4;
            P.UserID = 3;
            P.Delete(out Msg); Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test Delete Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestGetComments_Posts()
        {
            Posts P = new Posts();
            PostComments PC = new PostComments();
            List<PostComments> LOPC = new List<PostComments>();
            PC.PostID = 5;
            LOPC = P.GetComments(PC);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test GetComments Method Result :");
            foreach (PostComments item in LOPC)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Comment : " + item.CommentText);
            }
            Console.ReadLine();
        }

        static void TestGetLikes_Posts()
        {
            Posts P = new Posts();
            PostLikes PL = new PostLikes();
            List<PostLikes> LOPL = new List<PostLikes>();
            PL.PostID = 5;
            LOPL = P.GetLikes(PL);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test GetLikes Method Result :");
            foreach (PostLikes item in LOPL)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Like : " + item.UserID);
            }
            Console.ReadLine();
        }

        static void TestGetMyPosts_Posts()
        {
            Posts P = new Posts();
            List<Posts> LOP = new List<Posts>();
            P.UserID = 6;
            LOP = P.GetMyPosts(P);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test GetMyPosts Method Result :");
            foreach (Posts item in LOP)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Post :" + item.PostText);
            }
            Console.ReadLine();
        }

        static void TestGetLatestPosts_Posts()
        {
            Posts P = new Posts();
            List<Posts> LOP = new List<Posts>();
            LOP = P.GetLatestPosts();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test GetLatestPosts Method Result :");
            foreach (Posts item in LOP)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Post : " + item.PostText);
            }
            Console.ReadLine();
        }

        static void TestGetTopPosts_Posts()
        {
            Posts P = new Posts();
            List<Posts> LOP = new List<Posts>();
            LOP = P.GetTopPosts();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Posts Class :");
            Console.WriteLine("             Test GetTopPosts Method Result :");
            foreach (Posts item in LOP)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Post : " + item.ID);
            }
            Console.ReadLine();
        }

        static void TestRemoveComment_PostComments()
        {
            PostComments PC = new PostComments();
            PC.ID = 6;
            PC.UserID = 2;
            PC.PostID = 2;
            PC.RemoveComment(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("PostComments Class :");
            Console.WriteLine("             Test RemoveComment Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestUnlike_PostLikes()
        {
            PostLikes PL = new PostLikes();
            PL.ID = 3;
            PL.UserID = 2;
            PL.PostID = 1;
            PL.Unlike(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("PostLikes Class :");
            Console.WriteLine("             Test Unlike Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestCreate_SystemAdmin()
        {
            SystemAdmin SA = new SystemAdmin();
            SA.LastLogin = DateTime.Now;
            SA.Username = "SystemAdminUsername";
            SA.Password = "Password";
            SA.Status = (int)Status.Available;
            SA.Create(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("SystemAdmin Class :");
            Console.WriteLine("             Test Create Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestDisable_SystemAdmin()
        {
            SystemAdmin SA = new SystemAdmin();
            SA.Username = "SystemAdminUsername";
            SA.Disable(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("SystemAdmin Class :");
            Console.WriteLine("             Test Disable Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestSearch_SystemAdmin()
        {
            SystemAdmin SA = new SystemAdmin();
            List<SystemAdmin> LOSA = new List<SystemAdmin>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("Username", "SystemAdminUsername");
            LOSA = SA.Search(Dic);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("SystemAdmin Class :");
            Console.WriteLine("             Test Search Method Result :");
            foreach (SystemAdmin item in LOSA)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Password : " + item.Password);
            }
            Console.ReadLine();
        }

        static void TestChangePassword_SystemAdmin()
        {
            SystemAdmin SA = new SystemAdmin();
            SA.ID = 1;
            SA.Username = "sasa";
            SA.Password = "123123";
            SA.ChangePassword("New Password", "New Password", out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("SystemAdmin Class :");
            Console.WriteLine("             Test ChangePassword Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestLogin_SystemAdmin()
        {
            bool OK = false;
            SystemAdmin SA = new SystemAdmin();
            SA.Username = "SystemAdminUsername";
            SA.Password = "New Password";
            OK = SA.Login();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("SystemAdmin Class :");
            Console.WriteLine("             Test Login Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(OK);
            Console.ReadLine();
        }

        static void TestRegister_Users()
        {
            Users U = new Users();
            U.Balance = 200.75;
            U.Country = 10;
            U.DateofBirth = DateTime.Now;
            U.DisplayName = "Hegab";
            U.Gender = 0;
            U.Language = 3;
            U.LastLogin = DateTime.Now;
            U.Password = "1263456";
            U.ProfileImageLink = "Profile Image Link";
            U.Status = 2;
            U.Username = "M.Hegab";
            U.Register(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Users Class :");
            Console.WriteLine("             Test Register Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestDisable_Users()
        {
            Users U = new Users();
            U.Username = "Username";
            U.Disable(out Msg);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Users Class :");
            Console.WriteLine("             Test Disable Method Result :");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(Msg.ToString());
            Console.ReadLine();
        }

        static void TestSearch_Users()
        {
            Users U = new Users();
            List<Users> LOU = new List<Users>();
            Dictionary<string, object> Dic = new Dictionary<string, object>();
            Dic.Add("ID", 4);
            LOU = U.Search(Dic);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Users Class :");
            Console.WriteLine("             Test Search Method Result :");
            foreach (Users item in LOU)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(item.Username);
            }
            Console.ReadLine();
        }
    }
}

