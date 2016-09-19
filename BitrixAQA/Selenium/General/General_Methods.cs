using System;
using System.Text.RegularExpressions;
using BitrixAQA.General;
using BitrixAQA.Selenium.Object_Repository;
using BitrixAQA.Selenium.Framework;
using OpenQA.Selenium;

namespace BitrixAQA.Selenium.General
{
    /// <summary>
    /// Класс содержит общие вспомогательные методы для автоматизации
    /// </summary>
    class GM
    {
        /// <summary>
        /// Метод проверки контента страницы на ошибки
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void CheckContentOnErrors(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            string input = Driver.PageSource.ToLower();
            bool gotError = false;

            if (input != null)
            {
                //варнинг
                if ((input.Contains("warning") && input.Contains(" on line ")))
                {
                    Log.Gap();
                    Log.MesError("На странице Warning \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                if (input.Contains("ErrorException"))
                {
                    Log.Gap();
                    Log.MesError("На странице ErrorException \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //фатал
                if (input.Contains("fatal error") && input.Contains(" on line "))
                {
                    Log.Gap();
                    Log.MesError("На странице Fatal error. \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //парс еррор
                if (input.Contains("parse error") && input.Contains(" on line "))
                {
                    Log.Gap();
                    Log.MesError("На странице Parse error \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //db error
                if (input.Contains("mssql query error") || input.Contains("mysql query error") || input.Contains("oracle query error"))
                {
                    Log.Gap();
                    Log.MesError("Случилась ошибка базы. \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //деприкейтед
                if (input.Contains("deprecated") && input.Contains(" on line "))
                {
                    Log.Gap();
                    Log.MesError("На странице что-то deprecated \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //is not a component
                if (input.Contains("is not a component"))
                {
                    Log.Gap();
                    Log.MesError("Отсутствует какой-то компонент на странице. \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //404
                if (input.Contains("404 not found"))
                {
                    Log.Gap();
                    Log.MesError("404 not found. \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //ошибка установки
                if (input.Contains("ошибка установки") && !input.Contains("<div id=\"error_text\"></div>") && !input.Contains("исправлена ошибка установки"))
                {
                    Log.Gap();
                    Log.MesError("Ошибка установки. \r\nУрл: " + Driver.Url);
                    string spanID = DateTime.Now.Ticks.ToString();
                    Log.MesNormal(String.Format("{0} ",
                        "<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\" href=\"\" onclick=\"return collapse('" +
                        spanID + "', this)\">input: </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" + input.Replace('<', '[').Replace('>', ']')));
                    gotError = true;
                }

                //раздел не найден
                if (input.Contains("раздел не найден"))
                {
                    Log.Gap();
                    Log.MesError("Раздел не найден. \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //элемент не найден
                if (input.Contains("элемент не найден"))
                {
                    Log.Gap();
                    Log.MesError("Элемент не найден. \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //не найден шаблон
                if (input.Contains("can not find") && input.Contains("template with page"))
                {
                    Log.Gap();
                    Log.MesError("Не найден шаблон компонента \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //не передан ID инфоблока
                if (input.Contains("не передан id инфоблока"))
                {
                    Log.Gap();
                    Log.MesError("Не передан ID инфоблока \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //exception
                if (input.Contains("exception") && !input.Contains("tab_cont_exceptions") && !input.Contains("BadFunctionCallException") && !input.Contains(".exception."))
                {
                    Log.Gap();
                    Log.MesError("Exception \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //server error
                if (input.Contains("server error"))
                {
                    Log.Gap();
                    Log.MesError("Server Error \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //is not installed
                if (input.Contains("is not installed") && !input.Contains("Pspell extension is not installed"))
                {
                    Log.Gap();
                    Log.MesError("что-то is not installed \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //notselectediblock
                if (input.Contains("не выбран инфоблок"))
                {
                    Log.Gap();
                    Log.MesError("где-то не выбран инфоблок \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //Веб-форма не найдена
                if (input.Contains("Веб-форма не найдена"))
                {
                    Log.Gap();
                    Log.MesError("Веб-форма не найдена \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //ошибка при выполнении скрипта
                if (input.Contains("Блог не найден"))
                {
                    Log.Gap();
                    Log.MesError("Блог не найден \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //ошибка при выполнении скрипта
                if (input.Contains("Включить расширенный вывод ошибок можно в файле настроек .settings.php"))
                {
                    Log.Gap();
                    Log.MesError("При выполнении скрипта возникла ошибка. Включить расширенный вывод ошибок можно в файле настроек .settings.php \r\nУрл: " + Driver.Url);
                    gotError = true;
                }

                //если была запущена проверка всех урлов и найдена ошибка, то публикуем в лог страницу, на которой была найдена проверяемая ссылка
                if (CheckUrls.sourceUrl != "" && gotError==true)
                    Log.MesCustom("Страница, где была найдена ссылка: " + CheckUrls.sourceUrl, System.Drawing.Color.Red);
            }
        }

        /// <summary>
        /// Метод выполняет произвольный JavaScript
        /// </summary>
        /// <param name="js">код JavaScript</param>
        public static void RunJS(string js)
        {
            ((IJavaScriptExecutor)BitrixFramework.WebDriver).ExecuteScript(js);
        }

        /// <summary>
        /// Кейс выполнения php команды в админ. части
        /// </summary>
        /// <param name="PhpCommand">текст команды</param>
        public static void RunPHPCommand(string PhpCommand)
        {
            //идем на страницу выполнения php команды
            BitrixFramework.OpenURL(BitrixFramework.Host() + "/bitrix/admin/php_command_line.php");

            //отключаем подсветку синтаксиса
            GM.BacklightCodeSwitcher(false);

            //вставляем команду, выполняем
            TO_General.Textbox_PhpCommand().PasteText(PhpCommand, false, HideMessage: true);
            BitrixFramework.Wait(3);
            TO_General.Button_ExecutePhpCommand().ClickAndWait(checkErrors: false);
            BitrixFramework.BrowserAlert(true);
            BitrixFramework.Wait(3);
        }

        /// <summary>
        /// Метод включает/отключает подсветку кода в редакторе php команды
        /// </summary>
        /// <param name="turnBacklightOn">true - включить подстветку, false - отключить</param>
        public static void BacklightCodeSwitcher(bool turnBacklightOn)
        {
            if (turnBacklightOn)
            {
                if (TO_General.Button_BacklightCodeOff().Exists())
                    TO_General.Button_BacklightCodeOff().Click(true, false);
            }
            else
            {
                if (TO_General.Button_BacklightCodeOn().Exists())
                {
                    TO_General.Button_BacklightCodeOn().Click(true, false);
                    BitrixFramework.Refresh();

                    if (TO_General.Button_BacklightCodeOn().Exists())
                        TO_General.Button_BacklightCodeOn().Click(true, false);
                }
            }
        }

        /// <summary>
        /// Переходим в админский раздел по прямому урлу в /bitrix/admin
        /// </summary>
        public static void Go2AdminArea()
        {
            BitrixFramework.OpenURL(BitrixFramework.Host() + "/bitrix/admin");
        }

        /// <summary>
        /// Метод для вычисления даты от текущей.
        /// <returns>Возвращает строку с датой в заданном формате.</returns>
        /// </summary>
        /// <param name="action">+(плюс) - прибавить n-дней от текущей дате, -(минус) - отнять n-дней от текущей даты</param>
        /// <param name="date_counts">количество дней</param>
        /// <param name="format">формат возвращаемой строки ("dd/MM/yyyy" - вернет 05.10.2012, "dd" - вернет 05, "MM" - вернет 10, "yyyy" - вернет 2012)</param>
        public static string MathDate(string action, int date_counts, string format)
        {
            if (action == "+")
            {
                string math_date = DateTime.Now.AddDays(date_counts).ToString(format);
                return math_date;
            }
            else if (action == "-")
            {
                string math_date = DateTime.Now.AddDays(-date_counts).ToString(format);
                return math_date;
            }
            else
            {
                return "Error";
            }
        }
    }
}