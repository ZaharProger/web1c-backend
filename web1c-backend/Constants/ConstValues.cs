
using web1c_backend.Models.Http;


namespace web1c_backend.Constants
{
    public class ConstValues
    {
        public static readonly string AUTH_SUCCESS = "Authentication success!";
        public static readonly string REG_SUCCESS = "Registration success!";
        public static readonly string REG_FAILED = "Registration failed!";
        public static readonly string AUTH_W_LOGIN = "Wrong Login, try again!";
        public static readonly string AUTH_W_PASS = "Wrong Password, try again!";
        public static readonly int AUTH_TYPE = 0;
        public static readonly int REG_TYPE = 1;
        public static readonly string L_FIELD_TYPE = "login";
        public static readonly string SESSION_ID = "session_id";
        public static readonly string COOKIE_PATH = "/";
        public static readonly string P_FIELD_TYPE = "password";
        public static readonly string SESSION_REMOVED = "Session was ended!";
        public static readonly string SESSION_NOT_FOUND = "Session not found!";
        public static readonly DateTime UNIX_START_DATE = new DateTime(1970, 1, 1);
    }
}
