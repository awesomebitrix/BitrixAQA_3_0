using BitrixAQA.General;
using BitrixAQA.Selenium.Framework;
using BitrixAQA.Selenium.General;
using BitrixAQA.Selenium.Object_Repository;

namespace BitrixAQA.Selenium.Test_Cases
{
    /// <summary>
    /// Тесты проверки пользователей
    /// </summary>
    class Case_Main_Users
    {
        /// <summary>
        /// Общий раннер класса
        /// </summary>
        public static void Run()
        {
            string edition = "BB";
            Log.Gap();
            Log.MesNormal("---> кейс проверяет регистрацию нового пользователя в публичной и админ частях, их последующие авторизации");
            Clear(edition, "mysql");
            CreateUserAtPublic(edition, "mysql");
            CreateUserAtAdmin(edition, "mysql");
            Log.Gap();
            Log.MesNormal("---> тест завершен");
        }

        /// <summary>
        /// Метод для очистки тестовых данных
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="DBType">Тип базы</param>
        public static void Clear(string edition, string DBType)
        {
            Log.Gap();
            Log.MesNormal("Старт очистки тестовых данных");
            // идем в админку на стр пользователи
            Case_Main.OpenAdmin();
            //Закрываем модальное окно Битрикс24 - Единая авторизация
            if (TO_Main.CheckBox_NetworkDontshow().Displayed())
            {
                TO_Main.CheckBox_NetworkDontshow().ClickAndWait();
                TO_AdminPanel.Button_Close().ClickAndWait();
            }
            Case_Main.AdminLeftMenu("Настройки");
            Case_Main.AdminLeftSubMenu("Пользователи", "Список пользователей");
            if (TO_Users.Region_Admin_UsersList().AssertTextMatching(TestUsers.Petr.Email))
            {
                Log.MesNormal("Найден тестовый пользователь Петров с прошлого теста. Удаляем");
                // удаляем Петрова
                TO_Users.Checkbox_Admin_User(edition, DBType, TestUsers.Petr.Name, TestUsers.Petr.LastName).Click();
                TO_Users.Button_Admin_Delete().Click(false);
                BitrixFramework.BrowserAlert(true);
                TO_General.Region_Wait().WaitWhileElementExists();
                // проверяем что удален
                BitrixFramework.Refresh();
                TO_Users.Link_Admin_UserEmail(TestUsers.Petr.Email).NOTExists("Пользователь " + TestUsers.Petr.Email + " успешно удален", "Пользователь " + TestUsers.Petr.Email + " не удален");
            }
            else
                Log.MesPass("Тестовый пользователь Петров уже удален.");
            if (TO_Users.Region_Admin_UsersList().AssertTextMatching(TestUsers.Semen.Email))
            {
                Log.MesNormal("Найден тестовый пользователь Синичкин с прошлого теста. Удаляем");
                // удаляем Синичкина
                TO_Users.Checkbox_Admin_User(edition, DBType, TestUsers.Semen.Name, TestUsers.Semen.LastName).Click();
                TO_Users.Button_Admin_Delete().Click(false);
                BitrixFramework.BrowserAlert(true);
                TO_General.Region_Wait().WaitWhileElementExists();
                // проверяем что удален
                BitrixFramework.Refresh();
                TO_Users.Link_Admin_UserEmail(TestUsers.Semen.Email).NOTExists("Пользователь " + TestUsers.Semen.Email + " успешно удален", "Пользователь " + TestUsers.Semen.Email + " не удален");
            }
            else
                Log.MesPass("Тестовый пользователь Синичкин уже удален.");
            TO_AdminPanel.Tab_AdminViewTab().Click();
            Case_Main.OpenPublic();
            Case_General_Login.Logout();
            Log.MesPass("Очистка тестовых демо-пользователей завершена");
        }

        /// <summary>
        /// Метод для проверки регистрации и авторизации нового пользователя в публичной части
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="DBType">Тип базы</param>
        protected static void CreateUserAtPublic(string edition, string DBType)
        {
            Log.Gap();
            Log.MesNormal("Тест создания нового пользователя в публичке БУСа");
            Case_General_Login.Login(TestUsers.Admin.Login, TestUsers.Admin.Password);
            // жмем регистрация в блоке Авторизация
            Case_Main.OpenPublic();
            Case_General_Login.Logout();
            TO_General.Link_Register().ClickAndWait();
            // заполянем поля (Имя, Фамилия, Логин, Пароль, Подтверждение пароля, E-Mail, капча)
            TO_Users.Textbox_UserName().SendKeys(TestUsers.Petr.Name);
            TO_Users.Textbox_UserLastName().SendKeys(TestUsers.Petr.LastName);
            TO_Users.Textbox_UserLogin().SendKeys(TestUsers.Petr.Email);
            TO_Users.Textbox_Password().SendKeys(TestUsers.Petr.Password);
            TO_Users.Textbox_ConfirmPassword().SendKeys(TestUsers.Petr.Password);
            TO_Users.Textbox_UserEmail().SendKeys(TestUsers.Petr.Email);
            TO_Users.Textbox_Captcha().SendKeys(Case_Main.GetCaptchaCode(edition, DBType, TO_Users.Textbox_Hidden_Captcha_Code().GetAttribute("value")));
            // жмем регстрация
            TO_Users.Button_Register().ClickAndWait();
            // проверяем что мы сразу же авторизированы на сайте
            if (TO_General.Button_Logout().Exists())
                Log.MesPass("Авторизация на сайте успешно пройдена");
            // проверяем авторизацию: выходим и заходим
            Case_General_Login.Login(TestUsers.Petr.Email, TestUsers.Petr.Password);
            if (TO_General.Button_Logout().Exists())
                Log.MesPass("Повторная авторизация на сайте успешно пройдена");
            Case_General_Login.Logout();
            Log.MesPass("Тест создания нового пользователя в публичке завершен");
        }

        /// <summary>
        /// Метод для проверки регистрации нового пользователя в админ части, его авторизации в публичной части
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="DBType">Тип базы</param>
        protected static void CreateUserAtAdmin(string edition, string DBType)
        {
            Log.Gap();
            Log.MesNormal("Тест создания нового пользователя в админке БУСа");
            Case_General_Login.Login(TestUsers.Admin.Login, TestUsers.Admin.Password);
            Case_Main.OpenAdmin();
            Case_Main.AdminLeftMenu("Настройки");
            Case_Main.AdminLeftSubMenu("Пользователи", "Список пользователей");
            // нажимаем кнопку добавить нового юзера
            TO_Users.Button_Admin_AddNewUser().Click();
            // жмем сохранить
            TO_Users.Button_Admin_Save().Click();
            // проверяем ошибки сохранения (Не указан пароль пользователя. Логин должен быть не менее 3 символов. Неверный E-Mail.)
            TO_AdminPanel.Region_RedMessage().AssertTextMatching("Не указан пароль пользователя.\r\nЛогин должен быть не менее 3 символов.\r\nНеверный E-Mail.",
                "Сообщение об ошибки сохранения верное", "Сообщение об ошибки сохранения не верное");
            // заполняем поля на табе Пользователь
            TO_Users.Textbox_Admin_Name().SendKeys(TestUsers.Semen.Name);
            TO_Users.Textbox_Admin_LastName().SendKeys(TestUsers.Semen.LastName);
            TO_Users.Textbox_Admin_Email().SendKeys(TestUsers.Semen.Email);
            TO_Users.Textbox_Admin_Login().SendKeys(TestUsers.Semen.Email);
            TO_Users.Textbox_Admin_Password().SendKeys(TestUsers.Semen.Password);
            TO_Users.Textbox_Admin_ConfirmPassword().SendKeys(TestUsers.Semen.Password);
            // заполняем поля на табе Группы
            TO_Users.Region_Tab("Группы").Click();
            TO_Users.Checkbox_Admin_Group("Зарегистрированные пользователи").Click();
            // жмем сохранить
            TO_Users.Button_Admin_Save().Click();
            // проверяем что в списке юзеров есть новый юзер
            TO_Users.Region_Admin_UsersList().AssertTextMatching(TestUsers.Semen.Name, "Имя нового пользователя есть в списке юзеров", "Имени нового пользователя нет в списке юзеров");
            TO_Users.Region_Admin_UsersList().AssertTextMatching(TestUsers.Semen.LastName, "Фамилия нового пользователя есть в списке юзеров", "Фамилии нового пользователя нет в списке юзеров");
            TO_Users.Region_Admin_UsersList().AssertTextMatching(TestUsers.Semen.Email, "Емайл нового пользователя есть в списке юзеров", "Емайла нового пользователя нет в списке юзеров");
            // идем в публичку
            Case_Main.OpenPublic();
            Case_General_Login.Logout();
            // логинемся новым юзером
            Case_General_Login.Login(TestUsers.Semen.Email, TestUsers.Semen.Password);
            // проверяем что мы авторизированы
            if (TO_General.Button_Logout().Exists())
                Log.MesPass("Авторизация на сайте успешно пройдена");
            // выходим с сайта
            Case_General_Login.Logout();
            Log.MesPass("Тест создания нового пользователя в админке завершен");
        }
    }
}