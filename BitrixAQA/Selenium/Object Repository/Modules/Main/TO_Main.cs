using BitrixAQA.Selenium.Framework;
using OpenQA.Selenium;

namespace BitrixAQA.Selenium.Object_Repository
{
    /// <summary>
    /// Класс объектов главного модуля
    /// </summary>
    class TO_Main
    {
        /// <summary>
        /// Кнопка Окно JS ошибок в ИЕ Закрыть
        /// </summary>
        public static WebItem Button_IEJSErrorWindow_Close(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='footer']//button[text()='Закрыть']"), "Кнопка Окно JS ошибок в ИЕ Закрыть", Driver);
        }

        /// <summary>
        /// Кнопка Окно JS ошибок в ИЕ Копировать сведения
        /// </summary>
        public static WebItem Button_IEJSErrorWindow_CopyError(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//button[contains(text(), 'копировать сведения')]"), "Кнопка Окно JS ошибок в ИЕ Копировать сведения", Driver);
        }
        
        /// <summary>
        /// Таб Система обновлений
        /// </summary>
        public static WebItem Tab_UpdateSystem(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//span[@id='tab_cont_edit5']"), "Таб Система обновлений", Driver);
        }

        /// <summary>
        /// Таб Система обновлений Старый
        /// </summary>
        public static WebItem Tab_UpdateSystem_OLD(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//td[@id='tab_cont_edit5']"), "Таб Система обновлений (Старый)", Driver);
        }

        /// <summary>
        /// Выпадающий список Режим вывода ошибок
        /// </summary>
        public static WebItem DropDown_ErrorReporting(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//select[@name='error_reporting']"), "Выпадающий список Режим вывода ошибок", Driver);
        }

        /// <summary>
        /// Текстбокс Ключ сервиса Яндекс.Перевод
        /// </summary>
        public static WebItem TextBox_YandexTranslateKey(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='translate_key_yandex']"), "Текстбокс Ключ сервиса Яндекс.Перевод", Driver);
        }

        /// <summary>
        /// Кнопка Применить
        /// </summary>
        public static WebItem Button_Apply(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@value='Применить']"), "Кнопка Применить", Driver);
        }

        /// <summary>
        /// Текстбокс Лицензионный ключ
        /// </summary>
        public static WebItem TextBox_LicenseKey(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='SET_LICENSE_KEY']"), "Текстбокс Лицензионный ключ", Driver);
        }

        /// <summary>
        /// Текстбокс Сервер обновлений
        /// </summary>
        public static WebItem TextBox_UpdateSite(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='update_site']"), "Текстбокс Сервер обновлений", Driver);
        }

        /// <summary>
        /// Выпадающий список Автоматически проверять обновления
        /// </summary>
        public static WebItem DropDown_UpdateAutocheck(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//select[@name='update_autocheck']"), "Выпадающий список Автоматически проверять обновления", Driver);
        }

        /// <summary>
        /// Мета тег страницы или раздела
        /// </summary>
        /// <param name="tagName">имя тега, пример robots</param>
        public static WebItem MetaTag(string tagName, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//meta[@name='" + tagName + "']"), "Мета тег " + tagName, Driver);
        }

        /// <summary>
        /// Наименование страницы в админке
        /// </summary>
        public static WebItem Region_Title(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//h1[@id='adm-title']"), "Наименование страницы в админке", Driver);
        }

        /// <summary>
        /// Кнопка Сохранить
        /// </summary>
        public static WebItem Button_Save(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='save' and @class='adm-btn-save']"), "Кнопка Сохранить", Driver);
        }

        /// <summary>
        /// Кнопка Сохранить
        /// </summary>
        public static WebItem Button_Update(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='Update' and @class='adm-btn-save']"), "Кнопка Сохранить", Driver);
        }

        /// <summary>
        /// Область сообщения в админке
        /// </summary>
        public static WebItem Region_InfoMsg(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='adm-info-message']"), "Область сообщения в админке", Driver);
        }

        /// <summary>
        /// меню таб в админке
        /// </summary>
        /// <param name="tab_menu">наименование таб меню</param>
        public static WebItem Button_TabMenu(string tab_menu, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[contains(@id,'tabs')]//span[contains(text(), '" + tab_menu + "')]"), "меню таб " + tab_menu, Driver);
        }

        /// <summary>
        /// меню таб во внешнем контейнере
        /// </summary>
        /// <param name="tab_menu">наименование таб меню</param>
        public static WebItem Button_TabMenu_Container(string tab_menu, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@class='bx-core-adm-dialog-tabs']//span[contains(text(), '" + tab_menu + "')]"),
                "меню таб " + tab_menu + " во внешнем контейнере", Driver);
        }

        /// <summary>
        /// Кнопка удалить
        /// </summary>
        public static WebItem Button_Delete(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[@id='action_delete_button']"), "Кнопка удалить", Driver);
        }

        /// <summary>
        /// кнопка из меню действия
        /// </summary>
        /// <param name="action">наименование кнопки</param>
        public static WebItem Button_ActionMenu(string action, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='bx-admin-prefix' and contains(@style, 'display: block;')]//span[contains(text(), '" + action + "')]"), "кнопка из меню действия " + action, Driver);
        }

        /// <summary>
        /// кнопка удалить модуль в списке модулей
        /// </summary>
        /// <param name="module">наименование модуля</param>
        public static WebItem Button_UninstallModule(string module, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//b[contains(text(), '" + module + "')]//..//..//input[@name='uninstall']"), "кнопка удалить модуль " + module, Driver);
        }

        /// <summary>
        /// кнопка установить модуль в списке модулей
        /// </summary>
        /// <param name="module">наименование модуля</param>
        public static WebItem Button_InstallModule(string module, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//b[contains(text(), '" + module + "')]//..//..//input[@name='install']"), "кнопка установить модуль " + module, Driver);
        }

        /// <summary>
        /// Чекбокс Скопировать публичные файлы и шаблон для сайта
        /// </summary>
        public static WebItem CheckBox_CopyPublic(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//label[@for='id_install_public']"), "Чекбокс Скопировать публичные файлы и шаблон для сайта", Driver);
        }

        /// <summary>
        /// Чекбокс Переписывать существующие файлы
        /// </summary>
        public static WebItem CheckBox_PublicRewrite(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='id_public_rewrite']"), "Чекбокс Переписывать существующие файлы", Driver);
        }

        /// <summary>
        /// Чекбокс все Юнит Тесты
        /// </summary>
        public static WebItem CheckBox_AllUnitTests(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='phpunit-tests-bxtest']"), "Чекбокс все Юнит Тесты", Driver);
        }

        /// <summary>
        /// Чекбокс Юнит Теста
        /// </summary>
        /// <param name="TestName">Имя теста</param>
        public static WebItem CheckBox_UnitTests(string TestName, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='" + TestName + "']"), "Чекбокс Юнит Теста " + TestName, Driver);
        }

        /// <summary>
        /// Кнопка открытия Юнит Теста
        /// </summary>
        /// <param name="TestName">Имя теста</param>
        public static WebItem Button_OpenUnitTests(string TestName, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='" + TestName + "']//..//a"), "Кнопка открытия Юнит Теста " + TestName, Driver);
        }

        /// <summary>
        /// Кнопка Run
        /// </summary>
        public static WebItem Button_Run(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@type='button' and @value='Run']"), "Кнопка Run", Driver);
        }

        /// <summary>
        /// Кнопка удалить модуль
        /// </summary>
        public static WebItem Button_DeleteModule(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@type='submit' and @value='Удалить модуль']"), "Кнопка удалить модуль ", Driver);
        }

        /// <summary>
        /// Чекбокс Сохранить таблицы
        /// </summary>
        public static WebItem CheckBox_SaveTables(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='savedata']"), "Чекбокс сохранить таблицы", Driver);
        }

        /// <summary>
        /// Чекбокс Сохранить таблицы включен
        /// </summary>
        public static WebItem CheckBox_SaveTablesON(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='savedata' and @checked='']"), "Чекбокс сохранить таблицы включен", Driver);
        }

        /// <summary>
        /// Чекбокс Сохранить типы и шаблоны сообщений
        /// </summary>
        /// 
        public static WebItem CheckBox_SaveTemplates(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='saveemails']"), "Чекбокс Сохранить типы и шаблоны сообщений", Driver);
        }

        /// <summary>
        /// Чекбокс Сохранить типы и шаблоны сообщений включен
        /// </summary>
        /// 
        public static WebItem CheckBox_SaveTemplatesON(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='saveemails' and @checked='']"), "Чекбокс Сохранить типы и шаблоны сообщений включен", Driver);
        }

        /// <summary>
        /// Кнопка установить модуль общая
        /// </summary>
        public static WebItem Button_InstallModuleGeneral(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@type='submit' and @value='Установить модуль']"), "Кнопка установить модуль общая ", Driver);
        }

        /// <summary>
        /// Кнопка Вернуться к списку модулей
        /// </summary>
        public static WebItem Button_ReturnToList(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@type='submit' and @value='Вернуться в список']"), "Кнопка Вернуться к списку модулей", Driver);
        }

        /// <summary>
        /// Выпадающий список условий фильтрации
        /// </summary>
        public static WebItem Dropdown_Filter(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//select[@class ='adm-select' and @name='find_type']"), "Выпадающий список условий фильтрации", Driver);
        }

        /// <summary>
        /// поле найти
        /// </summary>
        public static WebItem Textbox_FilterValue(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@class ='adm-input' and @title='Введите строку для поиска']"), "поле найти", Driver);
        }

        /// <summary>
        /// кнопка Найти
        /// </summary>
        public static WebItem Button_Find(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name='set_filter']"), "кнопка Найти", Driver);
        }

        /// <summary>
        /// кнопка Найти
        /// </summary>
        public static WebItem Button_FindGood(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@class='adm-s-search-submit']"), "кнопка Найти", Driver);
        }

        /// <summary>
        /// Кнопка установить новые обновления
        /// </summary>
        public static WebItem Button_NewUpdates(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='install_updates_button' and not(@disabled='')]"), "Кнопка установить новые обновления", Driver);
        }

        /// <summary>
        /// Кнопка установить обновления
        /// </summary>
        public static WebItem Button_NewUpdates_Detail(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='install_updates_sel_button' and not(@disabled='')]"), "Кнопка установить обновления", Driver);
        }

        /// <summary>
        /// Чекбокс все модули
        /// </summary>
        public static WebItem CheckBox_InstallAllModules(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//label[@class='adm-designed-checkbox-label' and @for='id_select_all']"), "Чекбокс все модули", Driver);
        }

        /// <summary>
        /// Чекбокс установить модуль
        /// </summary>
        /// <param name="Module">Модуль</param>
        public static WebItem CheckBox_InstallModule(string Module, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//label[@class='adm-designed-checkbox-label' and @for='" + Module + "']"), "Чекбокс установить модуль " + Module);
        }

        /// <summary>
        /// Чекбокс Модуль "1С-Битрикс: сайт 1С-Франчайзи"
        /// </summary>
        public static WebItem CheckBox_InstallFranchiseModule(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//label[@class='adm-designed-checkbox-label' and @for='id_select_module_franchise']"), "Чекбокс Модуль \"1С-Битрикс: сайт 1С-Франчайзи\"", Driver);
        }

        /// <summary>
        /// Таб системы обновлений
        /// </summary>
        /// <param name="TabName">Имя закладки</param>
        public static WebItem Button_UpdateTab(string TabName, IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='tabControl_tabs']//span[contains(text(), '" + TabName + "')]"), "Таб системы обновлений" + TabName);
        }

        /// <summary>
        /// Кнопка Открыть лицензионное соглашение
        /// </summary>
        public static WebItem Button_OpenLicense(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name = 'agree_licence_btn']"), "Кнопка Открыть лицензионное соглашение", Driver);
        }

        /// <summary>
        /// Кнопка Обновить систему SiteUpdate
        /// </summary>
        public static WebItem Button_NewUpdateSystem(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@name = 'updateupdate_btn']"), "Кнопка Обновить систему SiteUpdate", Driver);
        }

        /// <summary>
        /// Кнопка применить
        /// </summary>
        public static WebItem Button_AcceptLicense(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id = 'licence_agree_button']"), "Кнопка применить", Driver);
        }

        /// <summary>
        /// чекбокс Я принимаю лицензионное соглашение
        /// </summary>
        public static WebItem CheckBox_AgreeLicense(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id = 'agree_license_id']"), "чекбокс Я принимаю лицензионное соглашение", Driver);
        }

        /// <summary>
        /// Текст об успешной установке обновлений
        /// </summary>
        public static WebItem Region_UpdateResult(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='upd_success_div_text' and contains(text(), 'Успешно установлено обновлений:')]"), "Текст об успешной установке обновлений", Driver);
        }

        /// <summary>
        /// Прогресс бар обновления
        /// </summary>
        public static WebItem Region_UpdateProgress(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[contains(@style, 'position:relative')]"), "Прогресс бар обновления", Driver);
        }

        /// <summary>
        /// Область ошибки апдейта
        /// </summary>
        public static WebItem Region_UpdateError(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//div[@id='upd_error_div_text']"), "Область ошибки апдейта", Driver);
        }

        /// <summary>
        /// Кнопка Журнал обновлений
        /// </summary>
        public static WebItem Button_UpdateLog(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[@id='btn_update_log']"), "Кнопка Журнал обновлений", Driver);
        }

        /// <summary>
        /// Кнопка Проверить обновления
        /// </summary>
        public static WebItem Button_CheckUpdate(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//a[@id='btn_update']"), "Кнопка Проверить обновления", Driver);
        }

        /// <summary>
        /// Значени мета тега http-equiv=Content-Type
        /// </summary>
        public static WebItem MetaTagHttpEq(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//meta[@http-equiv='Content-Type']"), "Значени мета тега http-equiv=Content-Type", Driver);
        }

        /// <summary>
        /// Вкладка Настройка управляемого кеширования 
        /// </summary>
        public static WebItem Button_SelectableCasheTab(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//span[contains(@title, 'Настройка управляемого кеширования')]"), "Вкладка Настройка управляемого кеширования", Driver);
        }

        /// <summary>
        /// Вкладка Очистка файлов кеша
        /// </summary>
        public static WebItem Button_СasheResetTab(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//span[contains(@title, 'Очистка файлов кеша')]"), "Вкладка Очистка файлов кеша", Driver);
        }

        /// <summary>
        /// Переключатель все
        /// </summary>
        public static WebItem Button_СasheAll(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@value='all']"), "Переключатель все", Driver);
        }

        /// <summary>
        /// Кнопка начать
        /// </summary>
        public static WebItem Button_StartClearCashe(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@id='start_button']"), "Кнопка начать", Driver);
        }

        /// <summary>
        /// Кнопка включить/выключить управляемый кэш
        /// </summary>
        public static WebItem Button_SelectableCashe(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[contains(@value, 'управляемый кеш')]"), "Кнопка включить/выключить управляемый кэш", Driver);
        }

        /// <summary>
        /// Область включенного управляемого кэша
        /// </summary>
        public static WebItem Region_SelectableCasheOn(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//b[text()='Управляемый кеш компонентов включен.']"), "Область включенного управляемого кэша", Driver);
        }

        /// <summary>
        /// Область отключенного управляемого кэша
        /// </summary>
        public static WebItem Region_SelectableCasheOff(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//b[text()='Управляемый кеш компонентов выключен (не рекомендуется).']"), "Область отключенного управляемого кэша", Driver);
        }

        /// <summary>
        /// Флаг Больше не показывать это сообщение
        /// </summary>
        public static WebItem CheckBox_NetworkDontshow(IWebDriver Driver = null)
        {
            return new WebItem(By.XPath("//input[@class='ss-network-dontshow-checkbox']"), "Флаг Больше не показывать это сообщение", Driver);
        }
    }
}