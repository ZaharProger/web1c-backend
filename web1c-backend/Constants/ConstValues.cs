
using Microsoft.Extensions.Logging;
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
        public static readonly int LOGIN_TYPE = 0;
        public static readonly int ID_TYPE = 1;
        public static readonly int SESSION_TYPE = 2;

        public static readonly string L_FIELD_TYPE = "login";
        public static readonly string SESSION_ID = "session_id";
        public static readonly string COOKIE_PATH = "/";
        public static readonly string P_FIELD_TYPE = "password";

        public static readonly string SESSION_REMOVED = "Сессия окончена";
        public static readonly string SESSION_NOT_FOUND = "Сессия не найдена";
        public static readonly string EMPTY_STRING = "Заполните все поля";
        public static readonly string TYPE_FAILURE = "Некорректный тип запроса";

        public static readonly DateTime UNIX_START_DATE = new DateTime(1970, 1, 1);

        public static readonly Dictionary<Routes, string> ROUTES = new Dictionary<Routes, string>()
        {
            { Routes.MAIN, "/" },
            { Routes.AUTH, "/auth" },
            { Routes.NOT_FOUND, "/*" },
            { Routes.CLASSES, "/classes" },
            { Routes.DOCUMENTS, "/docs" },
            { Routes.SETTINGS, "/settings" },
            { Routes.SOCIETIES, "/societies" },
            { Routes.WORK_TYPES, "/work-types" },
            { Routes.DEBTORS, "/debtors" },
            { Routes.EVENTS, "/events" },
            { Routes.DEBTOR_CONTRACTS, "/debtor-contracts" },
            { Routes.SIDES, "/sides" },
            { Routes.SANCTIONS, "/sanctions" },
            { Routes.CURRENCIES, "/currencies" },
            { Routes.BDDS_NOTES, "/bdds-notes" },
            { Routes.BUDGET_NOTES, "/budget-notes" },
            { Routes.SETTLEMENTS, "/settlements" },
            { Routes.EXTERNAL_IS, "/external-is" },
            { Routes.MARKETS, "/markets" },
            { Routes.COUNTERAGENTS_CATEGORIES, "/counteragents-categories" },
            { Routes.USERS, "/users" },
            { Routes.EVENT_STATES, "/event-states" }
        };
    }
}
