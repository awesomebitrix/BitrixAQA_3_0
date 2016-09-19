using BitrixAQA.General;
using BitrixAQA.Selenium.Framework;
using OpenQA.Selenium;

namespace BitrixAQA.Selenium.Object_Repository
{
    /// <summary>
    /// Класс объектов для работы с сотрудниками
    /// </summary>
    class TO_Users
    {

        #region объекты публичной части
        /// <summary>
        /// Текстбокс Имя пользователя
        /// </summary>
        public static WebItem Textbox_UserName(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='USER_NAME']"), "Текстбокс Имя пользователя", Driver);
        }

        /// <summary>
        /// Текстбокс Фамилия пользователя
        /// </summary>
        public static WebItem Textbox_UserLastName(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='USER_LAST_NAME']"), "Текстбокс Фамилия пользователя", Driver);
        }

        /// <summary>
        /// Текстбокс Логин
        /// </summary>
        public static WebItem Textbox_UserLogin(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='USER_LOGIN']"), "Текстбокс Логин", Driver);
        }

        /// <summary>
        /// Текстбокс Пароль
        /// </summary>
        public static WebItem Textbox_Password(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='USER_PASSWORD']"), "Текстбокс Пароль", Driver);
        }

        /// <summary>
        /// Текстбокс Подтверждение пароля
        /// </summary>
        public static WebItem Textbox_ConfirmPassword(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='USER_CONFIRM_PASSWORD']"), "Текстбокс Подтверждение пароля", Driver);
        }

        /// <summary>
        /// Текстбокс E-Mail
        /// </summary>
        public static WebItem Textbox_UserEmail(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='USER_EMAIL']"), "Текстбокс E-Mail", Driver);
        }

        /// <summary>
        /// Скрытое поле с id-капчи - значение нужно для выбора кода капчи из таблички
        /// </summary>
        public static WebItem Textbox_Hidden_Captcha_Code(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='captcha_sid']"), "Скрытое поле с id-капчи", Driver);
        }

        /// <summary>
        /// Текстбокс Капча-код
        /// </summary>
        public static WebItem Textbox_Captcha(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='captcha_word']"), "Текстбокс Капча-код", Driver);
        }

        /// <summary>
        /// Кнопка Регистрация
        /// </summary>
        public static WebItem Button_Register(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-auth']//input[@name='Register']"), "Кнопка Регистрация", Driver);
        }
        #endregion

        #region объекты админ части

        #region контекстаня панель
        /// <summary>
        /// Кнопка Добавить пользователя
        /// </summary>
        public static WebItem Button_Admin_AddNewUser(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='adm-list-table-top']//a[@id='btn_new']"), "Кнопка Добавить пользователя", Driver);
        }
        #endregion

        #region табы
        /// <summary>
        /// табы формы редактирования юзера
        /// </summary>
        /// <param name="name">название таба</param>
        public static WebItem Region_Tab(string name, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='user_edit_tabs']//span[contains(text(),'" + name + "')]"), "таб " + name, Driver);
        }
        #endregion

        #region таб Пользователь
        /// <summary>
        /// Текстбокс Имя
        /// </summary>
        public static WebItem Textbox_Admin_Name(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='edit1']//tr[@id='tr_NAME']//input[@name='NAME']"), "Текстбокс Имя", Driver);
        }

        /// <summary>
        /// Текстбокс Фамилия
        /// </summary>
        public static WebItem Textbox_Admin_LastName(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='edit1']//tr[@id='tr_LAST_NAME']//input[@name='LAST_NAME']"), "Текстбокс Фамилия", Driver);
        }

        /// <summary>
        /// Текстбокс E-Mail
        /// </summary>
        public static WebItem Textbox_Admin_Email(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='edit1']//tr[@id='tr_EMAIL']//input[@name='EMAIL']"), "Текстбокс E-Mail", Driver);
        }

        /// <summary>
        /// Текстбокс Логин (мин. 3 символа)
        /// </summary>
        public static WebItem Textbox_Admin_Login(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='edit1']//tr[@id='tr_LOGIN']//input[@name='LOGIN']"), "Текстбокс Логин (мин. 3 символа)", Driver);
        }

        /// <summary>
        /// Текстбокс Новый пароль
        /// </summary>
        public static WebItem Textbox_Admin_Password(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='edit1']//tr[@id='bx_pass_row']//input[@name='NEW_PASSWORD']"), "Текстбокс Новый пароль", Driver);
        }

        /// <summary>
        /// Текстбокс Подтверждение нового пароля
        /// </summary>
        public static WebItem Textbox_Admin_ConfirmPassword(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='edit1']//tr[@id='bx_pass_confirm_row']//input[@name='NEW_PASSWORD_CONFIRM']"), "Текстбокс Подтверждение нового пароля", Driver);
        }
        #endregion

        #region таб Группы
        /// <summary>
        /// чекбокс группа пользователей
        /// </summary>
        /// <param name="group_name">название группы пользователей</param>
        public static WebItem Checkbox_Admin_Group(string group_name, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='edit2']//label[contains(text(),'" + group_name + "')]//..//..//label[@class='adm-designed-checkbox-label']"), "Чекбокс " + group_name, Driver);
        }
        #endregion

        #region кнопки управления
        /// <summary>
        /// Кнопка Сохранить
        /// </summary>
        public static WebItem Button_Admin_Save(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='user_edit_buttons_div']//input[@name='save']"), "Кнопка Сохранить", Driver);
        }
        #endregion

        /// <summary>
        /// Область с ошибками сохранения
        /// </summary>
        public static WebItem Region_Admin_Info(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='adm-info-message']"), "Область с ошибками сохранения", Driver);
        }

        /// <summary>
        /// чекбокс пользователя
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="DBType">Тип базы</param>
        /// <param name="user_name">имя юзера</param>
        /// <param name="user_lastname">фамилия юзера</param>
        public static WebItem Checkbox_Admin_User(string DBType, string edition, string user_name, string user_lastname, IWebDriver Driver = null)
        {
            string user_id = SQL.SQLQuery(DBType, edition, "SELECT ID FROM b_user WHERE NAME = '" + user_name + "' AND LAST_NAME = '" + user_lastname + "'");
            return new WebItem(By.XPath("//table[@id='tbl_user']//input[@name='ID[]' and @value='" + user_id + "']//..//..//td"), "Чекбокс пользователя с id равным " + user_id, Driver);
        }

        /// <summary>
        /// Кнопка Удалить в меню действий 
        /// </summary>
        public static WebItem Button_Admin_Delete(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='tbl_user_footer']//a[@id='action_delete_button']"), "Кнопка Удалить в меню действий", Driver);
        }

        /// <summary>
        /// ссылка с емайлом пользователя
        /// </summary>
        /// <param name="email">емайл пользователя</param>
        public static WebItem Link_Admin_UserEmail(string email, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//table[@id='tbl_user']//td[@class='adm-list-table-cell']//a[contains(text(),'" + email + "')]"), "Ссылка с емайлом юзера " + email, Driver);
        }

        /// <summary>
        /// область со списком юзеров в админке
        /// </summary>
        public static WebItem Region_Admin_UsersList(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//table[@id='tbl_user']"), "область со списком юзеров в админке", Driver);
        }
        #endregion

    }
}
