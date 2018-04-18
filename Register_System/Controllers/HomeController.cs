

using Register_System.Models;
using Register_System.Models.Interface_Logic_;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace Register_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic userlogic;
        private readonly ISessionLogic sessionlogic;


        public HomeController(IUserLogic logic)
        {
            this.userlogic = logic;
        }

        public HomeController(IUserLogic logic, ISessionLogic session)
        {
            this.userlogic = logic;
            this.sessionlogic = session;
        }

        // GET: Home
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {

            int Hour = DateTime.Now.Hour;

            ViewBag.Greeting = Hour < 12 ? "Good Morning" : "Good Afternoon" + ":";

            return View();
        }

        [HttpPost]
        public ActionResult Index(Session session)
        {
            return RedirectToAction("CreateSession");
        }
        /********************************************************************************************************************/

        [HttpGet]
        public ActionResult LoginController()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginController(User userinfo)
        {

            if (userinfo.UserName != null && userinfo.Password != null)
            {
                userlogic.GetUserDetails(userinfo);

                if (userlogic.Login(userinfo.UserName, userinfo.Password) > 0)
                {

                    FormsAuthentication.SetAuthCookie(userinfo.UserName, true);

                    Session["UserType"] = userinfo.UserType;
                    Session["UserID"] = userinfo.UserId;

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Try disabling the Caps-Lock button");

                    return View("LoginController");
                }
            }
            else
            {
                return View("LoginController");
            }

        }
        /***************************************************************************************************************/

        [HttpGet]
        public ActionResult RegisterController()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterController(User userinfo)
        {
            if (ModelState.IsValid)
            {
                if ((userlogic.UserExists(userinfo.UserName)) != true)
                {
                    if (userlogic.Register(userinfo.UserName, userinfo.Password, userinfo.Division, userinfo.Position, userinfo.UserType) == true)
                    {
                        return RedirectToAction("LoginController");
                    }
                    else
                    {
                        return View("RegisterController");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username Already exists, Please try a new username.");
                    return View("RegisterController");
                }
            }
            else
            {
                return View("RegisterController");
            }
        }

        /*******************************************************************************************************************/
        [HttpGet]
        public ActionResult CheckInController()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckInController(Session session)
        {
            if (session.UniqueCode.ToString() != "")
            {
                sessionlogic.GetTempSessionResults(session);

                if (sessionlogic.TempSessionExists(session.UniqueCode) > 0)
                {
                    if (sessionlogic.TransferSession(session, Convert.ToInt32(Session["UserID"])) != false)
                    {
                        return RedirectToAction("ViewSessionConroller");
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please make sure the code is correct, Try again.");
                    return View("CheckInController");
                }
            }
            else
            {
                return View("CheckInController");
            }
        }
        /***********************************************************************************************************************/

        [HttpGet]
        public ActionResult CreateSession()
        {
            // Session session = new Session();
            int o = Constants.RandomCode();
            ViewBag.code = o;

            return View();
        }

        [HttpPost]
        public ActionResult CreateSession(Session session)
        {
            if (ModelState.IsValid)
            {
                if (sessionlogic.CreateTempSession(session.SessionTitle, session.SessionDate, session.SessionDescription, session.UniqueCode) != false)
                {
                    Session["UCode"] = session.UniqueCode;

                    return RedirectToAction("CreatedSession");
                }
            }
            else
            {
                ModelState.AddModelError("", "Ensure all session details are correct");
                return View("CreateSession");
            }

            return View(session);
        }
        /****************************************************************************************************************************/

        [HttpGet]
        public ActionResult CreatedSession()
        {
            ViewBag.Code = Session["UCode"];
            return View();
        }

        [HttpPost]
        public ActionResult CreatedSession(Session session)
        {
            session.UniqueCode = Convert.ToInt32(Session["UCode"]);
            if (sessionlogic.DeleteTempSession(session.UniqueCode) != false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some problem occurred");
            }

            return View();
        }
        /*****************************************************************************************************************************/


        [HttpGet]
        public ActionResult ViewAttendedSession(Session session)
        {   

            List<Session> sessions = new List<Session>();

            sessionlogic.GetAttendedSession(session);

            sessions.Add(session);

            return View(sessions);
        }




        [HttpGet]
        [Authorize]
        public ActionResult ViewSessionConroller(Session session)
        {
            List<Session> sessions = new List<Session>();

            int userid = Convert.ToInt32(Session["UserID"]);
            sessionlogic.GetViewSession(session, userid);

            sessions.Add(session);

            return View(sessions);
        }

        [HttpGet]
        public ActionResult UpcomingSessionController()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }


    }
}
