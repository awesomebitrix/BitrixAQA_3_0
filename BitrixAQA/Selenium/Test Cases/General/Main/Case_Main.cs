using BitrixAQA.General;
using BitrixAQA.Selenium.Framework;
using BitrixAQA.Selenium.Object_Repository;

namespace BitrixAQA.Selenium.Test_Cases
{
    /// <summary>
    /// Общие методы для проверки БУС
    /// </summary>
    class Case_Main
    {
        /// <summary>
        /// Метод для включения/выключения режима правки публичной части
        /// </summary>
        /// <param name="mode">true - включить, false - отключить</param>
        public static void EditMode(bool mode)
        {
            if (mode == true)
            {
                // если режим выключен - включаем
                if (TO_AdminPanel.Button_EditMode().GetAttribute("class") == "bx-panel-toggle-off")
                {
                    Log.MesPass("Включаем режим правки");
                    TO_AdminPanel.Button_EditMode().ClickAndWait();
                }
                // если включен - все хорошо
                else if (TO_AdminPanel.Button_EditMode().GetAttribute("class") == "bx-panel-toggle-on")
                    Log.MesPass("Режим правки уже включен");
            }
            else
            {
                // если режим включен - выключаем
                if (TO_AdminPanel.Button_EditMode().GetAttribute("class") == "bx-panel-toggle-on")
                {
                    Log.MesPass("Выключаем режим правки");
                    TO_AdminPanel.Button_EditMode().ClickAndWait();
                }
                // если выключен - все хорошо
                else if (TO_AdminPanel.Button_EditMode().GetAttribute("class") == "bx-panel-toggle-off")
                    Log.MesPass("Режим правки уже выключен");
            }
        }

        /// <summary>
        /// Метод для получения кода капчи
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="DBType">Тип базы</param>
        /// <param name="captcha_sid">SID капчи для выбора значения</param>
        public static string GetCaptchaCode(string edition, string DBType, string captcha_sid)
        {
            string captcha = SQL.SQLQuery(edition, DBType, "SELECT CODE FROM b_captcha WHERE ID = '" + captcha_sid + "'");
            return captcha;
        }

        #region админ меню
        /// <summary>
        /// Метод для перехода по основным пунктам левого админ меню
        /// </summary>
        /// <param name="item_name">название пункта основного левого админ меню, пример Настройки</param>
        public static void AdminLeftMenu(string item_name)
        {
            TO_AdminLeftMenu.Region_Admin_LeftMenu(item_name).ClickAndWait(5, NoRefresh: true);
        }

        /// <summary>
        /// Метод для перехода в пункт левого админ меню Настройки
        /// </summary>
        public static void OpenSettings()
        {
            TO_AdminLeftMenu.Button_Settings.ClickAndWait(NoRefresh: true);
            BitrixFramework.Wait(5);
        }

        /// <summary>
        /// Метод для перехода по вложеным пунктам подменю админ меню
        /// </summary>
        /// <param name="section_name">название секции</param>
        /// <param name="item_name">название пункта в секции</param>
        /// <param name="globalmenu">Глобальная секция меню</param>
        public static void AdminLeftSubMenu(string section_name, string item_name, string globalmenu = null)
        {
            if (item_name == "0")
            {
                if (TO_AdminLeftMenu.Region_Admin_Menu(section_name).Exists() && TO_AdminLeftMenu.Region_Admin_Menu(section_name).Displayed())
                    TO_AdminLeftMenu.Region_Admin_Menu(section_name).ClickAndWait();
            }
            if (TO_AdminLeftMenu.Region_Admin_TernMenuSection(section_name).Exists() && TO_AdminLeftMenu.Region_Admin_TernMenuSection(section_name).Displayed())
            {
                TO_AdminLeftMenu.Region_Admin_TernMenuSection(section_name).ClickAndWait();
                TO_AdminLeftMenu.Region_Admin_SubMenuItem(item_name).ClickAndWait();
            }
            if (TO_AdminLeftMenu.Region_Admin_TernMenuSection_Store(section_name).Exists() && TO_AdminLeftMenu.Region_Admin_TernMenuSection_Store(section_name).Displayed())
            {
                TO_AdminLeftMenu.Region_Admin_TernMenuSection_Store(section_name).ClickAndWait();
                TO_AdminLeftMenu.Region_Admin_SubMenuItem(item_name).ClickAndWait();
            }
            else if (TO_AdminLeftMenu.Region_Admin_ExpandMenuSection(section_name).Exists() && TO_AdminLeftMenu.Region_Admin_ExpandMenuSection(section_name).Displayed())
                TO_AdminLeftMenu.Region_Admin_SubMenuItem(section_name, item_name).ClickAndWait();
            else if(TO_AdminLeftMenu.Region_Admin_SubMenuItem(item_name).Exists() && TO_AdminLeftMenu.Region_Admin_SubMenuItem(item_name).Displayed())
                TO_AdminLeftMenu.Region_Admin_SubMenuItem(section_name, item_name).ClickAndWait();
        }

        /// <summary>
        /// Метод для перехода в пункт левого админ меню Магазин
        /// </summary>
        public static void OpenSale()
        {
            TO_AdminLeftMenu.Button_Sale().ClickAndWait(NoRefresh: true);
            BitrixFramework.Wait(5);
        }

        /// <summary>
        /// Метод для перехода по вложеным пунктам подменю админ меню
        /// </summary>
        /// <param name="section_name">название секции</param>
        /// <param name="item_name">название пункта в секции</param>
        /// <param name="globalmenu">Глобальная секйия меню</param>
        public static void AdminLeftSubSubMenu(string section_name, string item_name, string globalmenu = null)
        {
            if (globalmenu == null)
            {
                if (TO_AdminLeftMenu.Region_Admin_TernMenuSubSection(section_name).Exists() && TO_AdminLeftMenu.Region_Admin_TernMenuSubSection(section_name).Displayed())
                {
                    TO_AdminLeftMenu.Region_Admin_TernMenuSubSection_Show(section_name).ClickAndWait(1);
                    TO_AdminLeftMenu.Region_Admin_SubSubMenuItem(item_name).ClickAndWait(1);
                }
                else if (TO_AdminLeftMenu.Region_Admin_ExpandMenuSubSection(section_name).Exists())
                    TO_AdminLeftMenu.Region_Admin_SubSubMenuItem(item_name).ClickAndWait(1);
            }
            else
            {
                if (TO_AdminLeftMenu.Region_Admin_TernMenuSubSection(section_name, globalmenu).Exists() && TO_AdminLeftMenu.Region_Admin_TernMenuSubSection(section_name, globalmenu).Displayed())
                {
                    TO_AdminLeftMenu.Region_Admin_TernMenuSubSection_Show(section_name, globalmenu).ClickAndWait(1);
                    TO_AdminLeftMenu.Region_Admin_SubSubMenuItem(item_name, globalmenu).ClickAndWait(1);
                }
                else if (TO_AdminLeftMenu.Region_Admin_ExpandMenuSubSection(section_name, globalmenu).Exists())
                    TO_AdminLeftMenu.Region_Admin_SubSubMenuItem(item_name, globalmenu).ClickAndWait(1);
            }
        }
        #endregion

        /// <summary>
        /// Метод для перехода по вложеным пунктам меню публичной части
        /// </summary>
        /// <param name="section_name">название секции</param>
        /// <param name="item_name">название пункта в секции</param>
        public static void PublicSubMenu(string section_name, string item_name)
        {
            if (TO_General.Button_HorizontalMenuItem(section_name).Exists())
                TO_General.Button_HorizontalMenuItem(section_name).ClickAndWait();
            TO_General.Button_LeftMenuItem(item_name).WaitElementDisplayed(10);
            TO_General.Button_LeftMenuItem(item_name).ClickAndWait(2);
        }

        /// <summary>
        /// Метод открывает закладку "Администрирование"
        /// </summary>
        public static void OpenAdmin()
        {
            if (TO_AdminPanel.Tab_PublicAdminTab().Exists())
                TO_AdminPanel.Tab_PublicAdminTab().ClickAndWait(checkErrors: false);
            else if (TO_AdminPanel.Tab_AdminAdminTab().Exists())
                TO_AdminPanel.Tab_AdminAdminTab().ClickAndWait(checkErrors: false);
        }

        /// <summary>
        /// Метод открывает закладку "Сайт"
        /// </summary>
        public static void OpenPublic()
        {
            if (TO_AdminPanel.Tab_AdminViewTab().Exists())
                TO_AdminPanel.Tab_AdminViewTab().ClickAndWait(checkErrors: false);
            else if (TO_AdminPanel.Tab_PublicViewTab().Exists())
                TO_AdminPanel.Tab_PublicViewTab().ClickAndWait(checkErrors: false);
        }

        /// <summary>
        /// Метод возвращает содержимое мета тега странцы/раздела по его имени
        /// </summary>
        /// <param name="tagName">имя мета тега, пример robots</param>
        public static string GetMetaTag(string tagName)
        {
            return TO_Main.MetaTag(tagName).GetAttribute("content");
        }

        /// <summary>
        /// Метод возвращает кодировку страницы, выдираемую из мета тега странцы/раздела
        /// </summary>
        public static string GetEncodingByMetaTag()
        {
            return TO_Main.MetaTagHttpEq().GetAttribute("content").Substring(19);
        }
    }
}
