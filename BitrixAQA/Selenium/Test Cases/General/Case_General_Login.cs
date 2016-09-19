using BitrixAQA.Selenium.General;
using BitrixAQA.Selenium.Object_Repository;

namespace BitrixAQA.Selenium.Test_Cases
{
    /// <summary>
    /// Здесь Методы для входа и выхода на разных редакциях - БУС, КП, Админка
    /// Для скорости рекомендуется использовать методы входа выхода персональные для каждой редакции.
    /// </summary>
    class Case_General_Login
    {

        /// <summary>
        /// Метод реализует логаут с сайта БУС
        /// </summary>
        public static void Logout()
        {
            if (TO_AdminPanel.Button_Logout().Exists())
                TO_AdminPanel.Button_Logout().ClickAndWait();

            if (TO_General.Button_Logout().Exists())
                TO_General.Button_Logout().ClickAndWait();
            if (TO_General.Button_Logout_Title().Exists())
                TO_General.Button_Logout_Title().ClickAndWait();
        }

        /// <summary>
        /// Метод реализует логаут с админской части
        /// </summary>
        public static void LogoutAdmin()
        {
            if (TO_AdminPanel.Button_Logout().Exists())
                TO_AdminPanel.Button_Logout().ClickAndWait();
        }

        /// <summary>
        /// Метод реализует кейс релогина на сайте БУС. Если залогинены, то перед входом выходим
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        public static void Login(string Login, string Password)
        {
            //выходим
            Logout();
            if (TO_General.Button_Enter().Exists())
                TO_General.Button_Enter().ClickAndWait();

            //входим, КП, БУС
            if (TO_General.Textbox_UserLogin().Exists() && TO_General.Textbox_UserPassword().Exists() && TO_General.Button_Login().Exists() && TO_General.Textbox_UserLogin().Displayed() &&
                TO_General.Textbox_UserPassword().Displayed() && TO_General.Button_Login().Displayed())
            {
                TO_General.Textbox_UserLogin().SendKeys(Login);
                TO_General.Textbox_UserPassword().SendKeys(Password);
                TO_General.Button_Login().ClickAndWait(NoRefresh: true);
            }
        }

        /// <summary>
        /// Метод реализует кейс релогина в админке. Если залогинены, то перед входом выходим
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        public static void LoginAdminArea(string Login, string Password)
        {
            //идем в админку
            GM.Go2AdminArea();

            //выходим
            LogoutAdmin();

            //входим, КП, БУС
            if (TO_General.Textbox_UserLogin().Exists() && TO_General.Textbox_UserPassword().Exists() && TO_General.Button_Login().Exists())
            {
                TO_General.Textbox_UserLogin().SendKeys(Login);
                TO_General.Textbox_UserPassword().SendKeys(Password);
                TO_General.Button_Login().ClickAndWait();
                TO_General.Textbox_UserLogin().WaitWhileElementExists(15);
            }
        }
    }
}