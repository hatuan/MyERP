using System.Collections.Generic;


namespace MyERP.Infrastructure
{
    public static class SessionManager
    {
        private static Dictionary<string, object> session = new Dictionary<string, object>();

        public static Dictionary<string, object> Session
        {
            get { return SessionManager.session; }
            set { SessionManager.session = value; }
        }
    }
}
