using Register_System.Models.Interface_Logic_;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Register_System.Models.Class_Logic_
{
    public class SessionLogic : ISessionLogic
    {
        public bool CreateTempSession(string temptitle, string tempdate, string tempdescr, int tempcode)
        {
            bool result = false;

            using (var context = new Model1())
            {
                var session = new TempSession()
                {
                    TempSessTitle = temptitle,
                    TempSessDate = tempdate,
                    TempSessDescription = tempdescr,
                    TempSessCode = tempcode
                };

                context.TempSessions.Add(session);
                result = Convert.ToBoolean(context.SaveChanges());
            }
            
            return result;
        }

        public bool DeleteTempSession(int sesscode)
        {
            bool isTrue = false;

            using (var context = new Model1())
            {
                var result = (from d in context.TempSessions
                              where d.TempSessCode == sesscode
                              select d).Single();

                context.TempSessions.Remove(result);
                isTrue = Convert.ToBoolean(context.SaveChanges());
            }

            return isTrue;
        }

        public void GetAttendedSession(Session session)
        {
            using (var context = new Model1())
            {
                var result = context.Sessions.ToList();

                foreach(var d in result)
                {
                    session.UserID = d.UserID;
                    session.SessionTitle = d.SessionTitle;
                    session.SessionDate = d.SessionDate;
                    session.SessionDescription = d.SessionDescription;
                    session.UniqueCode = d.UniqueCode;
                }
            }
        }

        public void GetTempSessionResults(Session session)
        {
            using (var context = new Model1())
            {
                var result = context.TempSessions.Where(x=>x.TempSessCode == session.UniqueCode);

                foreach(var d in result)
                {
                    session.SessionTitle = d.TempSessTitle;
                    session.SessionDate = d.TempSessDate;
                    session.SessionDescription = d.TempSessDescription;
                    session.UniqueCode = d.TempSessCode;
                }
            }
        }

        public void GetViewSession(Session session, int userid)
        {
            using (var context = new Model1())
            {
                var result = context.Sessions.Where(x => x.UserID == userid).ToList();

                foreach (var d in result)
                {
                    session.SessionTitle = d.SessionTitle;
                    session.SessionDate = d.SessionDate;
                    session.SessionDescription = d.SessionDescription;
                    session.UniqueCode = d.UniqueCode;
                }
            }
        }

        public int TempSessionExists(int sessscode)
        {
            int isTrue = 0;

            using (var context = new Model1())
            {
                isTrue = Convert.ToInt32(context.TempSessions.Any(x=>x.TempSessCode == sessscode));
            }

                return isTrue;
        }

        public bool TransferSession(Session session, int userid)
        {
            bool result = false;

            using (var context = new Model1())
            {
                var newsession = new Session()
                {
                    UserID = userid,
                    SessionTitle = session.SessionTitle,
                    SessionDate = session.SessionDate,
                    SessionDescription = session.SessionDescription,
                    UniqueCode = session.UniqueCode
                };

                context.Sessions.Add(newsession);
                result = Convert.ToBoolean(context.SaveChanges());
            }
                return result;
        }

        
    }


}