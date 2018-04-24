using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register_System.Models.Interface_Logic_
{
     public interface ISessionLogic
    {
        int TempSessionExists(int sessscode);
        bool DeleteTempSession(int sesscode);
        void GetTempSessionResults(Session session);
        bool TransferSession(Session session, int userid);
        void GetViewSession(Session session, int userid);
        List<Session> GetAttendedSession(Session session);
        bool CreateTempSession(string temptitle, string tempdate, string tempdescr, int tempcode);
    }
}
