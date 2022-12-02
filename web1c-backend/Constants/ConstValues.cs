
using web1c_backend.Models.Http;


namespace web1c_backend.Constants
{
    public class ConstValues
    {
        public static readonly string AUTH_SUCCESS = "Вы успешно авторизовались!";
        public static readonly string REG_SUCCESS = "Вы успешно зарегестрировались!";
        public static readonly string REG_FAILED = "Данный пользователь уже существует!";
        public static readonly string AUTH_W_LOGIN = "Неправильный логин, попытайтесь еще!";
        public static readonly string AUTH_W_PASS = "Неправильный пароль, попытайтесь еще!";
        public static readonly int AUTH_TYPE = 0;
        public static readonly int REG_TYPE = 1;
        public static readonly string L_FIELD_TYPE = "login";
        public static readonly string SESSION_ID = "session_id";
        public static readonly string COOKIE_PATH = "/";
        public static readonly string P_FIELD_TYPE = "password";
        public static readonly string SESSION_REMOVED = "Сессия окончена";
        public static readonly string SESSION_NOT_FOUND = "Сессия не найдена";
        public static readonly DateTime UNIX_START_DATE = new DateTime(1970, 1, 1);
    }
}
