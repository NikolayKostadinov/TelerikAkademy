using EntityFramework.Data;

namespace EntityFramework.Library
{
    public static class SessionState
    {
        public static NORTHWNDEntities _db = new NORTHWNDEntities();
        public static NORTHWNDEntities db
        {
            get
            {
                return _db;
            }
        }
    }
}
