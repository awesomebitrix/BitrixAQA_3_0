using BitrixAQA.Selenium.Framework;
using OpenQA.Selenium;

namespace BitrixAQA.Selenium.Object_Repository
{
    /// <summary>
    /// Общие объекты
    /// </summary>
    class TO_General
    {
        /// <summary>
        /// Область body
        /// </summary>
        public static WebItem Region_Body(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//body"), "Область body", Driver);
        }

        /// <summary>
        /// Область заголовка страницы
        /// </summary>
        public static WebItem Region_Pagetitle(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//h1[@id='pagetitle']"), "Область заголовка страницы", Driver);
        }
        
        /// <summary>
        /// Область Вся страница
        /// </summary>
        public static WebItem Region_AllPage(IWebDriver Driver = null)
        {

            return new WebItem(By.XPath("//html"), "Область вся страница", Driver);
        }

        /// <summary>
        /// Область ошибки 404
        /// </summary>
        public static WebItem Region_404ErrorMessage(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//td[@class='main-column']//h1[@id='pagetitle' and contains(text(),'404 Not Found')]"), "Область ошибки 404", Driver);
        }

        /// <summary>
        /// Область ошибки Index file is not found.
        /// </summary>
        public static WebItem Region_NotFound(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//body[contains(text(),'Index file is not found.')]"), "Область ошибки Index file is not found.", Driver);
        }

        /// <summary>
        /// Область главной колонки
        /// </summary>
        public static WebItem Region_MainColumn(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//td[@class='main-column']"), "Область главной колонки", Driver);
        }

        /// <summary>
        /// Область картинки в главной колонки
        /// </summary>
        /// <param name="Source">Сорс картинки</param>
        public static WebItem Region_MainColumn_Image(string Source, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//td[@class='main-column']//img[@src='" + Source + "']"), "Область картинки в главной колонки", Driver);
        }

        /// <summary>
        /// Область ошибки при логине
        /// </summary>
        public static WebItem Region_ErrorLogin(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class = 'errortext']"), "Область ошибки при логине", Driver);
        }

        /// <summary>
        /// Текст ошибки
        /// </summary>
        public static WebItem Region_ErrorText(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class = 'feed-add-error']//span[@class = 'feed-add-info-text']"), "Текст ошибки", Driver);
        }

        /// <summary>
        /// Область Табличка Загрузка
        /// </summary>
        public static WebItem Region_Wait(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-core-waitwindow']"), "Область Табличка Загрузка", Driver);
        }
        
        /// <summary>
        /// Область Табличка Загрузка
        /// </summary>
        public static WebItem Region_Wait_New(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='gue_wait']"), "Область Табличка Загрузка", Driver);
        }

        /// <summary>
        /// Область Табличка Загрузка
        /// </summary>
        public static WebItem Region_Wait_Roller(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='wait_bx-admin-prefix']"), "Область Табличка Загрузка", Driver);
        }

        /// <summary>
        /// Область Табличка Загрузка
        /// </summary>
        public static WebItem Region_WaitWindow(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='wait_window_div']"), "Область Табличка Загрузка", Driver);
        }

        #region Авторизация в публичке
        /// <summary>
        /// кнопка войти
        /// </summary>
        public static WebItem Button_Enter(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//header[@class='bx-header']//a[contains(text(), 'Войти')]"), "кнопка войти", Driver);
        }

        /// <summary>
        /// Текстбокс Логин пользователя
        /// </summary>
        public static WebItem Textbox_UserLogin(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='USER_LOGIN']"), "Текстбокс Логин пользователя", Driver);
        }

        /// <summary>
        /// Текстбокс Пароль пользователя
        /// </summary>
        public static WebItem Textbox_UserPassword(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='USER_PASSWORD']"), "Текстбокс Пароль пользователя", Driver);
        }

        /// <summary>
        /// Кнопка Войти
        /// </summary>
        public static WebItem Button_Login(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='Login' and @type = 'submit']"), "Кнопка Войти", Driver);
        }

        /// <summary>
        /// Кнопка Выйти
        /// </summary>
        public static WebItem Button_Logout(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//form//table//tbody//tr//td//input[@type='submit' and @name='logout_butt']"), "Кнопка Выйти", Driver);
        }

        /// <summary>
        /// Кнопка Выйти
        /// </summary>
        public static WebItem Button_Logout_Title(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[@title='Выйти' and text()='Выйти']"), "Кнопка Выйти", Driver);
        }

        /// <summary>
        /// Ссылка Регистрация в форме авторизации
        /// </summary>
        public static WebItem Link_Register(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-system-auth-form']//a[contains(text(),'Регистрация')]"), "Ссылка Регистрация в форме авторизации", Driver);
        }
        #endregion

        /// <summary>
        /// Кнопка Подсветка синтаксиса
        /// </summary>
        public static WebItem Button_BacklightCodeOff(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[@class='bxce-mode-link']"), "Кнопка Подсветка синтаксиса отключена", Driver);
        }

        /// <summary>
        /// Кнопка Подсветка синтаксиса включена
        /// </summary>
        public static WebItem Button_BacklightCodeOn(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[@class='bxce-mode-link bxce-mode-link-on']"), "Кнопка Подсветка синтаксиса включена", Driver);
        }

        /// <summary>
        /// Текстбокс Команда php
        /// </summary>
        public static WebItem Textbox_PhpCommand(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//textarea[@id='query']"), "Текстбокс Команда php", Driver);
        }

        /// <summary>
        /// Кнопка Выполнить
        /// </summary>
        public static WebItem Button_ExecutePhpCommand(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='execute']"), "Кнопка Выполнить", Driver);
        }

        /// <summary>
        /// Пункт горизонтального меню
        /// </summary>
        /// <param name="MenuItem"> Название пункта</param>
        public static WebItem Button_HorizontalMenuItem(string MenuItem, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//ul[@id='horizontal-multilevel-menu']//a[contains(text(), '" + MenuItem + "')]"), "Пункт горизонтального меню " + MenuItem, Driver);
        }

        /// <summary>
        /// Пункт левого меню
        /// </summary>
        /// <param name="MenuItem"> Название пункта</param>
        public static WebItem Button_LeftMenuItem(string MenuItem, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//ul[@class='left-menu']//a[contains(text(), '" + MenuItem + "')]"), "Пункт левого меню " + MenuItem, Driver);
        }

        /// <summary>
        /// Текстбокс URL сайта
        /// </summary>
        public static WebItem Textbox_ServerName(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@type='text' and @name='server_name']"), "Текстбокс URL сайта", Driver);
        }

        /// <summary>
        /// Текстбокс поиск
        /// </summary>
        public static WebItem Textbox_Search(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='search-form']//input[@type='text']"), "Текстбокс поиск", Driver);
        }

        /// <summary>
        /// Текстбокс поиск
        /// </summary>
        public static WebItem Textbox_Search_Admin(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='bx-search-input']"), "Текстбокс поиск", Driver);
        }

        /// <summary>
        /// Область выпадающих подсказок поиска
        /// </summary>
        public static WebItem Region_SearchHelp(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='adm-search-result-wrap']"), "Область выпадающих подсказок поиска", Driver);
        }

        /// <summary>
        /// Выпадающая подсказка поиска
        /// </summary>
        /// <param name="RowName">Имя трочки</param>
        public static WebItem Region_SearchHelp_Row(string RowName, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//td[@class='adm-search-item' and @title='" + RowName + "']"), "Выпадающая подсказка поиска", Driver);
        }

        /// <summary>
        /// Кнопка поиск
        /// </summary>
        public static WebItem Button_Search(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='search-form']//input[@type='submit']"), "Кнопка поиск", Driver);
        }

        /// <summary>
        /// Кнопка переиндексировать
        /// </summary>
        public static WebItem Button_Reindex(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='start_button' and @onclick='StartReindex();']"), "Кнопка переиндексировать", Driver);
        }

        /// <summary>
        /// Кнопка Начать индексацию
        /// </summary>
        public static WebItem Button_Index(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='btn_start' and @onclick='StartIndex()']"), "Кнопка Начать индексацию", Driver);
        }

        /// <summary>
        /// Область количества найденных файлов
        /// </summary>
        /// <param name="Amounth">Ожидаеммое коство</param>
        public static WebItem Region_SearchedAmount(int Amounth, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='search-page']//font[@class='text' and contains(text(), 'из " + Amounth.ToString() + "')]"), "Область количества найденных файлов", Driver);
        }

        /// <summary>
        /// Область результата переиндексации
        /// </summary>
        public static WebItem Region_ReindexResult(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='reindex_result']"), "Область уведомления", Driver);
        } 

        /// <summary>
        /// Область найденной строки
        /// </summary>
        /// <param name="Href"> Ссылка в заголовке найденной строки</param>
        /// <param name="Text"> Текст найденной строки </param>
        public static WebItem Region_SearchedRow(string Href, string Text, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='search-page']//a[contains(@href, '" + Href + "') and contains(text(), '" + Text + "')]"), "Область найденной строки", Driver);
        }

        /// <summary>
        /// Область найденного тега
        /// </summary>
        /// <param name="Text"> Текст тега </param>
        public static WebItem Region_SearchedTeg(string Text, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[contains(text(), '" + Text + "')]"), "Область найденного тега", Driver);
        }

        /// <summary>
        /// Область найденных данных
        /// </summary>
        public static WebItem Region_Searched(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='search-page']"), "Область найденных данных", Driver);
        }

        /// <summary>
        /// Область найденных данных
        /// </summary>
        public static WebItem Region_SearchedResult(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='search-page']/table"), "Область найденных данных", Driver);
        }

        /// <summary>
        /// Область напоминания otp
        /// </summary>
        public static WebItem Region_OTP(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='otpInfoPopup']"), "Область напоминания otp", Driver);
        }

        /// <summary>
        /// Кнопка Напомнить позже
        /// </summary>
        public static WebItem Button_RemindLater(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[text()='Напомнить позже']"), "Кнопка Напомнить позже", Driver);
        }
    }
}
