using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BitrixAQA.General;
using BitrixAQA.Selenium.General;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace BitrixAQA.Selenium.Framework
{
    /// <summary>
    /// Тестовый фрэймворк
    /// </summary>
    public class BitrixFramework
    {
        /// <summary>
        /// вебдрайвер
        /// </summary>
        static IWebDriver _WebDriver;
        /// <summary>
        /// Общее количество найденных JS ошибок с начала теста
        /// </summary>
        public static int JSErrorsCount = 0;
        /// <summary>
        /// HTML всей страницы
        /// </summary>
        public static string allPageInnerHTML;
        /// <summary>
        /// Время на поиск элемента
        /// </summary>
        static int implicitlyWait = 5;
        /// <summary>
        /// Время ожидание страницы при задании урла
        /// </summary>
        static int waitForPageLoad = 5;
        /// <summary>
        /// Время ожидание выполненния ассинхроного JavaScript
        /// </summary>
        static int waitForLoad = 50;

        /// <summary>
        /// инициализируем веб-драйвер
        /// </summary>
        public static IWebDriver WebDriver
        {
            get
            {
                //Если драйвер не был инициирован ранее, создадим новый драйвер
                if (_WebDriver == null)
                {
                    Log.MesNormal("Запускаем браузер " +  MainForm.form.cbBrowsers.SelectedItem.ToString());

                    switch (MainForm.form.cbBrowsers.SelectedItem.ToString())
                    {

                        case "FireFox":
                            //Создаем класс опций для Firefox
                            FirefoxOptions OptionsFF = new FirefoxOptions();
                            //Новый чистый профиль для опций браузера
                            OptionsFF.Profile = new FirefoxProfile("");

                            //Экземпляр класса снятия скриншотов.
                            ScreenCapture sc = new ScreenCapture();
                            //Создадим папку для загрузок, если её нет
                            DirectoryInfo dir = new DirectoryInfo(System.IO.Path.Combine(Shared.appdir, "Downloads"));
                            if (!dir.Exists)
                                dir.Create();

                            //Дополнительные параметры браузера
                            OptionsFF.Profile.SetPreference("browser.download.folderList", 2);
                            OptionsFF.Profile.SetPreference("browser.download.dir", System.IO.Path.Combine(Shared.appdir, "Downloads"));
                            OptionsFF.Profile.SetPreference("browser.download.lastDir.savePerSite", false);
                            OptionsFF.Profile.SetPreference("browser.download.manager.showAlertOnComplete", false);
                            OptionsFF.Profile.SetPreference("browser.helperApps.neverAsk.openFile", "application/x-download,application/pdf,application/x-pdf,application/acrobat,application/vnd.pdf,text/pdf,text/x-pdf,image/jpeg,image/pjpeg,image/gif,image/bmp,image/x-windows-bmp,image/tif,image/x-tif,image/tiff,image/x-tiff,application/tif,application/x-tif,application/tiff,application/x-tiff,application/download,application/excel,application/vnd.ms-excel,application/x-xpinstall,application/x-zip,application/x-zip-compressed,application/octet-stream,application/zip,application/pdf,application/msword,text/plain,application/octet,application/force-download,application/rar,application/x-rar,application/stssync,application/octet-stream");
                            OptionsFF.Profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-download,application/pdf,application/x-pdf,application/acrobat,application/vnd.pdf,text/pdf,text/x-pdf,image/jpeg,image/pjpeg,image/gif,image/bmp,image/x-windows-bmp,image/tif,image/x-tif,image/tiff,image/x-tiff,application/tif,application/x-tif,application/tiff,application/x-tiff,application/download,application/excel,application/vnd.ms-excel,application/x-xpinstall,application/x-zip,application/x-zip-compressed,application/octet-stream,application/zip,application/pdf,application/msword,text/plain,application/octet,application/force-download,application/rar,application/x-rar,application/stssync,application/octet-stream");
                            OptionsFF.Profile.SetPreference("pdfjs.disabled", true);
                            OptionsFF.Profile.SetPreference("dom.disable_beforeunload", true);
                            OptionsFF.Profile.SetPreference("plugin.scan.plid.all", false);
                            OptionsFF.Profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
                            OptionsFF.Profile.SetPreference("services.sync.prefs.sync.browser.download.manager.showWhenStarting", false);
                            OptionsFF.Profile.SetPreference("browser.cache.disk.enable", false);
                            OptionsFF.Profile.SetPreference("browser.cache.memory.enable", false);
                            OptionsFF.Profile.SetPreference("browser.cache.offline.enable", false);
                            OptionsFF.Profile.SetPreference("browser.cache.disk.capacity", "5000");

                            //Инициализируем сам драйвер. В данном случае будет использован Marionette driver
                            //Использование RemoteControl признано устаревшим и отсутствует в третьей версии селениума
                            _WebDriver = new FirefoxDriver(OptionsFF);
                            //Выставим основные величины задержек для драйвера
                            _WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, implicitlyWait));
                            _WebDriver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, waitForPageLoad, 0));
                            _WebDriver.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 0, waitForLoad));
                            _WebDriver.Manage().Window.Maximize();
                            break;

                        case "IE":
                            //Для IE используем свой драйвер
                            _WebDriver = new InternetExplorerDriver();
                            _WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, implicitlyWait));
                            _WebDriver.Manage().Window.Maximize();
                            break;

                        case "Chrome":
                            //Для хрома используем свой драйвер
                            ChromeOptions chromeOptions = new ChromeOptions();
                            //используем свое дополнение для поиска JS ошибок
                            chromeOptions.AddExtension(System.IO.Path.Combine(Shared.appdir, "ChromeJSErrorCollector.crx"));

                            _WebDriver = new ChromeDriver(chromeOptions);
                            _WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, implicitlyWait));
                            _WebDriver.Manage().Window.Maximize();

                            break;
                    }
                }
                return _WebDriver;
            }
        }

        /// <summary>
        /// Метод реализует поиск элемента на странице. Аналог WebDriver.FindElement
        /// </summary>
        /// <param name="webItem">"Объект страницы</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns></returns>
        public static IWebElement FindWebElement(WebItem webItem, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (webItem.by != null)
            {
                try
                {
                    return Driver.FindElement(webItem.by);
                }
                catch (StaleElementReferenceException)
                {
                    Wait(2);
                    return Driver.FindElement(webItem.by);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод реализует поиск элемента на странице. Аналог WebDriver.FindElement
        /// </summary>
        /// <param name="by">locating mechanism</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static IWebElement FindWebElement(By by, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                return Driver.FindElement(by);
            }
            catch (StaleElementReferenceException)
            {
                Wait(2);
                return Driver.FindElement(by);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Метод реализует поиск элементов на странице. Аналог WebDriver.FindElements
        /// </summary>
        /// <param name="by">locating mechanism</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns></returns>
        public static List<IWebElement> FindWebElements(By by, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                return Driver.FindElements(by).ToList();
            }
            catch (StaleElementReferenceException)
            {
                Wait(2);
                return Driver.FindElements(by).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Ожидаем загрузку страницы
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void WaitForPageToLoad(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            TimeSpan timeout = new TimeSpan(0, 0, 240);
            WebDriverWait wait = new WebDriverWait(Driver, timeout);

            IJavaScriptExecutor javascript = Driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");
            try
            {
                wait.Until((d) =>
                {
                    try
                    {
                        string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                        return readyState.ToLower() == "complete";
                    }
                    catch (InvalidOperationException e)
                    {
                        return e.Message.ToLower().Contains("unable to get browser");
                    }
                    catch (WebDriverException e)
                    {
                        return e.Message.ToLower().Contains("unable to connect");
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
            }
            catch (TimeoutException Ex)
            {
                Log.MesError(Ex.Message + "\r\n" + Ex.StackTrace);
            }
        }

        /// <summary>
        /// Метод собирает все найденные JS ошибки на странице
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void CheckJSErrors(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            //Firefox
            if (MainForm.form.cbBrowsers.SelectedItem.ToString() == "FireFox")
            {
                string JSerrors = "";
                IList<object> errors = null;

                try
                {
                    errors = ((IJavaScriptExecutor)Driver).ExecuteScript("return window.JSErrorCollector_errors.pump()") as IList<object>;
                }
                catch (Exception)
                {
                    return;
                }

                int JSErrorsCountTMP = errors.Count();

                if (JSErrorsCount > 0)
                {
                    for (int i = 0; i >= JSErrorsCount; i++)
                    {
                        errors.Remove(i);
                    }
                }

                JSErrorsCount = JSErrorsCountTMP;

                if (errors.Count > 0)
                {
                    foreach (var er in errors)
                    {
                        JSerrors += "\r\n\r\n Ошибка: " + ((System.Collections.Generic.IDictionary<string, object>)er)["errorMessage"].ToString() +
                                    "\r\n Строка: " + ((System.Collections.Generic.IDictionary<string, object>)er)["lineNumber"].ToString() +
                                    "\r\n Урл: " + ((System.Collections.Generic.IDictionary<string, object>)er)["sourceName"].ToString();
                    }

                        Log.MesError("Найдены JS ошибки: " + JSerrors + "\r\nНа странице: " + BitrixFramework.WebDriver.Url);                    
                }
            }

            //Chrome
            if (MainForm.form.cbBrowsers.SelectedItem.ToString() == "Chrome")
            {
                string JSerrors = "";
                IList<object> errors = null;

                try
                {
                    errors = ((IJavaScriptExecutor)Driver).ExecuteScript("return window.JSErrorCollector_errors.pump()") as IList<object>;
                }
                catch (Exception)
                {
                    return;
                }

                int JSErrorsCountTMP = errors.Count();

                if (JSErrorsCount > 0)
                {
                    for (int i = 0; i >= JSErrorsCount; i++)
                    {
                        errors.Remove(i);
                    }
                }

                JSErrorsCount = JSErrorsCountTMP;

                if (errors.Count > 0)
                {
                    try
                    {
                        foreach (var er in errors)
                        {
                            JSerrors += "\r\n\r\n Ошибка: " + ((System.Collections.Generic.IDictionary<string, object>)er)["errorMessage"].ToString() +
                                        "\r\n Строка: " + ((System.Collections.Generic.IDictionary<string, object>)er)["lineNumber"].ToString() +
                                        "\r\n Урл: " + ((System.Collections.Generic.IDictionary<string, object>)er)["sourceName"].ToString();
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        return;
                    }

                    Log.Gap();
                    Log.MesError("Найдены JS ошибки: " + JSerrors + "\r\nНа странице: " + Driver.Url);
                }
            }
        }

        /// <summary>
        /// Метод реализует возможность переключения между окнами и фреймами. Аналог WebDriver.SwitchTo()
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns></returns>
        public static ITargetLocator SwitchTo(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            return Driver.SwitchTo();
        }

        /// <summary>
        /// Метод реализует открытие заданного урла
        /// Опционально - делать запись в лог. По умолчаню true - делать
        /// Опционально - проверять страницу после открытия на наличие ошибок. По умолчанию true - делать
        /// </summary>
        /// <param name="URL">адрес URL</param>
        /// <param name="writeToLog">писать ли в лог действие 'Открываем URL'</param>
        /// <param name="CheckPageOnErrors">проверять ли страницу на наличие ошибок после открытия</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void OpenURL(string URL, bool writeToLog = true, bool CheckPageOnErrors = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (URL.IndexOf("http://") < 0 && URL.IndexOf("https://") < 0 && URL.IndexOf("ftp://") < 0)
            {
                URL = "http://" + URL;
            }
            try
            {
                Driver.Navigate().GoToUrl(new System.Uri(URL));
            }
            catch (OpenQA.Selenium.WebDriverException e)
            {
                Log.MesQuestion("Висит страница \r\nMessage: " + e.Message + "\r\nStackTrace: " + e.StackTrace + "\r\n<a href=\"" + ScreenCapture.Printscreen() + "\">скриншот</a>");
                BitrixFramework.Refresh(Driver: Driver);
                BitrixFramework.Wait(5);
            }
            catch (Exception e)
            {
                Log.MesQuestion("Не открыта страница " + URL + "\r\nMessage: " + e.Message + "\r\nStackTrace: " + e.StackTrace + "\r\n<a href=\"" + ScreenCapture.Printscreen() + "\">скриншот</a>");
            }

            if (writeToLog)
                Log.MesNormal(String.Format("Открываем URL {0}", URL));
            Wait(2);
            //если переменная проверка страницы включена - проверяем
            if (CheckPageOnErrors)
            {
                CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Метод обновляет текущую страницу
        /// <param name="checkErrors">Проверить наличие ошибок. По умолчанию true - проверить</param>
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void Refresh(bool checkErrors = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            Driver.Navigate().Refresh();
            Wait(3);
            try
            {
                Log.MesNormal(String.Format("Обновили страницу {0}", Driver.Url));
            }
            catch (UnhandledAlertException)
            {
                Log.MesNormal("Обновили страницу");
            }
            if (checkErrors)
            {
                CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Метод переходит на страницу назад
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void Back(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            Driver.Navigate().Back();
            Log.MesNormal(String.Format("Назад на предыдущую страницу"));

            CheckJSErrors(Driver: Driver);
            GM.CheckContentOnErrors(Driver: Driver);
        }

        /// <summary>
        /// Метод реализует переключение между окнами по их номеру
        /// </summary>
        /// <param name="windowNumber">Номер окна. Нумерация с нуля</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void SwitchToWindow(int windowNumber, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            List<string> handle = new List<string>(Driver.WindowHandles);
            Driver.SwitchTo().Window(handle[windowNumber]);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Метод переключает драйвер на другое окно по его имени
        /// </summary>
        /// <param name="windowName">Имя окна</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void SwitchToWindow(string windowName, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            Driver.SwitchTo().Window(windowName);
        }

        /// <summary>
        /// Метод закрывает окно по его имени
        /// </summary>
        /// <param name="windowName">Имя окна, которое надо закрыть</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void CloseWindow(string windowName, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            Driver.SwitchTo().Window(windowName);
            Driver.Close();
        }

        /// <summary>
        /// Метод закрывает окно по его номеру
        /// </summary>
        /// <param name="windowNumber">Номер окна. Нумерация с нуля</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void CloseWindow(int windowNumber, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            List<string> handle = new List<string>(BitrixFramework.WebDriver.WindowHandles);
            Driver.SwitchTo().Window(handle[windowNumber]);
            Driver.Close();
        }

        /// <summary>
        /// Метод переключает с выбранного ранее фрейма на главную страницу. Аналог WebDriver.SwitchTo().DefaultContent()
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns></returns>
        public static IWebDriver SwitchToDefaultContent(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            return Driver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Обработка браузерного алерта
        /// </summary>
        /// <param name="Button">true - Ок. false - Cancel</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void BrowserAlert(bool Button, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                OpenQA.Selenium.IAlert alert = Driver.SwitchTo().Alert();
                if (Button)
                {
                    alert.Accept();
                    Log.MesNormal("Алерт браузера. Кнопка ОK - клик");
                }
                else
                {
                    alert.Dismiss();
                    Log.MesNormal("Алерт браузера. Кнопка Cancel - клик");
                }
            }
            catch (NoAlertPresentException)
            {
                return;
            }
        }

        /// <summary>
        /// Метод приостанавливает выполнение теста на заданное число времени
        /// </summary>
        /// <param name="Seconds">Сколько секунд</param>
        public static void Wait(int Seconds)
        {
            System.Threading.Thread.Sleep(Seconds * 1000);
        }

        /// <summary>
        /// Метод возвращает хост из текущего урла. С http:// или без
        /// По умолчанию true - с http://
        /// </summary>
        /// <param name="withhttp">true - c http(s)://, false - без</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>хост</returns>
        public static string Host(bool withhttp = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            string pattern = "([a-z]+://[^/]+)/.*";

            if (!withhttp)
                pattern = "[a-z]+://([^/]+)/.*";

            string replacement = "$1";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(Driver.Url, replacement);

            return result;
        }

        /// <summary>
        /// Скроллим фокус к объекту
        /// </summary>
        /// <param name="webItem">Объект к которому скроллим</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void ScrollOnCoords(WebItem webItem, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                Point hoverItem = BitrixFramework.FindWebElement(webItem, Driver: Driver).Location;
                ((IJavaScriptExecutor)Driver).ExecuteScript("return window.title;");
                ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(-10000,-10000);");
                if (hoverItem.Y > 100)
                    ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0," + (hoverItem.Y - 100) + ");");
                else
                    ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0," + (hoverItem.Y) + ");");
            }
            catch (NoSuchElementException)
            {
                Log.MesError("Не найден объект \"" + webItem.description + "\" по пути \"" + webItem.by.ToString() + "\"");
                throw;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Скроллим фокус к объекту
        /// </summary>
        /// <param name="webItem">Объект к которому скроллим</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void ScrollOnCoords(IWebElement webItem, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                Point hoverItem = webItem.Location;
                ((IJavaScriptExecutor)Driver).ExecuteScript("return window.title;");
                ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(-10000,-10000);");
                if (hoverItem.Y > 100)
                    ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0," + (hoverItem.Y - 100) + ");");
                else
                    ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0," + (hoverItem.Y) + ");");
            }
            catch (NoSuchElementException)
            {
                Log.MesError("Не найден объект");
                throw;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Скроллим фокус к объекту
        /// </summary>
        /// <param name="webItem">Объект к которому скроллим</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public static void Scroll(WebItem webItem, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView();", BitrixFramework.FindWebElement(webItem, Driver: Driver));
            }
            catch (NoSuchElementException)
            {
                Log.MesError("Не найден объект \"" + webItem.description + "\" по пути \"" + webItem.by.ToString() + "\"");
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Возвращает коллекцию элементов по общему locating mechanism
        /// </summary>
        /// <param name="by">locating mechanism</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>Лист элементов, или null</returns>
        public static List<IWebElement> GetElements(By by, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                return BitrixFramework.FindWebElements(by, Driver: Driver);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Возвращает элементов по locating mechanism
        /// </summary>
        /// <param name="by">locating mechanism</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>Элемент, или null </returns>
        public static IWebElement GetElement(By by, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                return BitrixFramework.FindWebElement(by, Driver: Driver);
            }
            catch
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Класс включает набор методов и переменных для объектов
    /// </summary>
    public class WebItem
    {
        /// <summary>
        /// Описание объекта WebItem. Используется для записи в лог, как имя объекта. Обязательно для заполнения
        /// </summary>
        public string description;
        /// <summary>
        /// Способ поиска элемента WebItem
        /// </summary>
        public By by;
        /// <summary>
        /// Переменная возвращает InnerText объекта. Аналог WebDriver.FindElement().Text
        /// </summary>
        public string innerText;
        /// <summary>
        /// Переменная возвращает InnerHTML объекта
        /// </summary>
        public string innerHTML;
        /// <summary>
        /// Переменная возвращает value объекта
        /// </summary>
        public string value = "";

        /// <summary>
        /// Метод реализует поиск объекта на странице
        /// </summary>
        /// <param name="by">Механизм поиска объекта. По XPath, Id и т.д.</param>
        /// <param name="description">Описание объекта для лога</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public WebItem(By by, string description, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            this.by = by;
            this.description = description;

            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            if (Element != null)
            {
                try
                {
                    this.innerText = Element.Text;
                }
                catch (Exception ex)
                {
                    this.innerText = ex.Message;
                    return;
                }

                try
                {
                    this.innerHTML = ((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].innerHTML", Element).ToString();
                }
                catch (Exception ex)
                {
                    this.innerHTML = ex.Message;
                    return;
                }

                try
                {
                    this.value = ((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].value", Element).ToString();
                }
                catch (Exception ex)
                {
                    this.value = ex.Message;
                    return;
                }
            }
        }

        /// <summary>
        /// Метод реализует скроллинг страницы до элемента
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns></returns>
        public void Scroll(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView();", BitrixFramework.FindWebElement(this, Driver: Driver));
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Клик по WebItem. Аналог WebDriver.Click()
        /// </summary>
        /// <param name="checkErrors">Проверить наличие ошибок. По умолчанию true - проверить</param>
        /// <param name="ScrollToObject">Меняет скроллирование до объекта(по умолчанию: отключено для админской части и включено для публичной)
        /// Соответственно true включает скролл в адимнке и выключает в публичке</param>
        /// <param name="x">координата x для клика относительно верхнего левого угла объекта</param>
        /// <param name="y">координата y для клика относительно верхнего левого угла объекта</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void Click(bool checkErrors = true, bool ScrollToObject = true, int x = 0, int y = 0, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (ScrollToObject)
                BitrixFramework.ScrollOnCoords(this, Driver: Driver);

            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            if (x != 0 && y != 0)
            {
                OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
                builder.MoveToElement(Element, x, y).Click().Build().Perform();
            }
            else
            {
                try
                {
                    Element.Click();
                }
                catch (NullReferenceException)
                {
                    Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                    throw;
                }
                catch (StaleElementReferenceException)
                {
                    Log.MesQuestion("Изменился DOM страницы, и элемента " + this.description + " больше нет в кеше. Подождем 5 сек и попробуем найти его ещё разок");
                    BitrixFramework.Wait(5);
                    try
                    {
                        Element.Click();
                    }
                    catch
                    {
                        Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                        throw;
                    }
                }
                catch (OpenQA.Selenium.WebDriverException e)
                {
                    Log.MesQuestion("Висит страница \r\nMessage: " + e.Message + "\r\nStackTrace: " + e.StackTrace + "\r\n<a href=\"" + ScreenCapture.Printscreen() + "\">скриншот</a>");
                    BitrixFramework.Refresh(Driver: Driver);
                    BitrixFramework.Wait(5);
                }

            }
            Log.MesNormal(String.Format("'{0}' -> Клик", description));
            if (checkErrors)
            {
                BitrixFramework.CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Клик по WebItem. Аналог WebDriver.Click()
        /// После клика ждет заданное количество времени. Опционально, по умолчанию 1 секунда.
        /// </summary>
        /// <param name="secondsToWait">Время ожидания, секунд</param>
        /// <param name="ScrollToObject">Меняет скроллирование до объекта(по умолчанию: отключено для админской части и включено для публичной)
        /// Соответственно true включает скролл в адимнке и выключает в публичке</param>
        /// <param name="checkErrors">Проверить наличие ошибок. По умолчанию true - проверить</param>
        /// <param name="x">координата x для клика относительно верхнего левого угла объекта</param>
        /// <param name="y">координата y для клика относительно верхнего левого угла объекта</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void RightClickAndWait(int secondsToWait = 1, bool ScrollToObject = true, bool checkErrors = true, int x = 0, int y = 0, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (ScrollToObject)
                BitrixFramework.ScrollOnCoords(this, Driver: Driver);

            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            if (x != 0 && y != 0)
            {
                OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
                builder.MoveToElement(Element, x, y).ContextClick().Build().Perform();
            }
            else
            {
                try
                {
                    OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
                    builder.MoveToElement(Element).ContextClick().Build().Perform();
                }
                catch (NullReferenceException)
                {
                    Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                    throw;
                }
                catch (StaleElementReferenceException)
                {
                    Log.MesQuestion("Изменился DOM страницы, и элемента " + this.description + " больше нет в кеше. Подождем 5 сек и попробуем найти его ещё разок");
                    BitrixFramework.Wait(5);
                    try
                    {
                        OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
                        builder.MoveToElement(Element).ContextClick().Build().Perform();
                    }
                    catch
                    {
                        Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                        throw;
                    }
                }
                catch (OpenQA.Selenium.WebDriverException e)
                {
                    Log.MesQuestion("Висит страница \r\nMessage: " + e.Message + "\r\nStackTrace: " + e.StackTrace + "\r\n<a href=\"" + ScreenCapture.Printscreen() + "\">скриншот</a>");
                    BitrixFramework.Refresh(Driver: Driver);
                    BitrixFramework.Wait(5);
                }
            }
            Log.MesNormal(String.Format("'{0}' -> Правый клик", description));

            BitrixFramework.Wait(secondsToWait);
            if (checkErrors)
            {
                BitrixFramework.CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Клик по WebItem. Аналог WebDriver.Click()
        /// После клика ждет заданное количество времени. Опционально, по умолчанию 1 секунда.
        /// </summary>
        /// <param name="secondsToWait">Время ожидания, секунд</param>
        /// <param name="ScrollToObject">Меняет скроллирование до объекта(по умолчанию: отключено для админской части и включено для публичной)
        /// Соответственно true включает скролл в адимнке и выключает в публичке</param>
        /// <param name="checkErrors">Проверить наличие ошибок. По умолчанию true - проверить</param>
        /// <param name="x">координата x для клика относительно верхнего левого угла объекта</param>
        /// <param name="y">координата y для клика относительно верхнего левого угла объекта</param>
        /// <param name="NoRefresh"> Если задан - рефреш страницы при зависании не производится</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void ClickAndWait(double secondsToWait = 0.5, bool ScrollToObject = true, bool checkErrors = true, int x = 0, int y = 0, bool NoRefresh = false, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (ScrollToObject)
                BitrixFramework.ScrollOnCoords(this);

            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            if (x != 0 && y != 0)
            {
                OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
                builder.MoveToElement(Element, x, y).Click().Build().Perform();
            }
            else
            {
                try
                {
                    Element.Click();
                }
                catch (NullReferenceException)
                {
                    Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                    throw;
                }
                catch (StaleElementReferenceException)
                {
                    Log.MesQuestion("Изменился DOM страницы, и элемента " + this.description + " больше нет в кеше. Подождем 5 сек и попробуем найти его ещё разок");
                    BitrixFramework.Wait(5);
                    try
                    {
                        Element.Click();
                    }
                    catch
                    {
                        Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                        throw;
                    }
                }
                catch (OpenQA.Selenium.WebDriverException e)
                {
                    Log.MesQuestion("Висит страница \r\nMessage: " + e.Message + "\r\nStackTrace: " + e.StackTrace + "\r\n<a href=\"" + ScreenCapture.Printscreen() + "\">скриншот</a>");
                    if(!NoRefresh)
                        BitrixFramework.Refresh(Driver: Driver);
                    BitrixFramework.Wait(5);
                }
            }
            Log.MesNormal(String.Format("'{0}' -> Клик", description));

            System.Threading.Thread.Sleep(Convert.ToInt32(secondsToWait * 1000));
            if (checkErrors)
            {
                BitrixFramework.CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Метод реализует действие двойной клик по WebItem
        /// </summary>
        /// <param name="checkErrors">Проверить наличие ошибок. По умолчанию true - проверить</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void DoubleClick(bool checkErrors = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            //реализуем дабл клик js скриптом
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
            builder.DoubleClick(BitrixFramework.FindWebElement(this, Driver: Driver)).Build().Perform();

            Log.MesNormal(String.Format("'{0}' -> Дабл клик", description));
            if (checkErrors)
            {
                //проверяем страницу на наличие ошибок
                BitrixFramework.CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Метод реализует действие драгндроп от одного элемента до другого
        /// </summary>
        /// <param name="WebItemToDrop">Объект на котором дропаем первый объект</param>
        /// <param name="isAdmin">Признак админки</param>
        /// <param name="ScrollToObject">Скроллить ли до объекта</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void DragAndDrop(WebItem WebItemToDrop, bool isAdmin = false, bool ScrollToObject = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
            builder.DragAndDrop(BitrixFramework.FindWebElement(this, Driver: Driver), BitrixFramework.FindWebElement(WebItemToDrop, Driver: Driver)).Build().Perform();

            Log.MesNormal(String.Format("'{0}' -> Драгндроп до '{1}'", description, WebItemToDrop.description));

            //проверяем страницу на наличие ошибок
            BitrixFramework.CheckJSErrors(Driver: Driver);
            GM.CheckContentOnErrors(Driver: Driver);
        }

        /// <summary>
        /// Метод перетаскивает объект на заданные координаты смещения
        /// </summary>
        /// <param name="ScrollToObject">Скроллить ли до объекта</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void DragAndDropCoords(WebItem Object, bool ScrollToObject = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            BitrixFramework.Scroll(this, Driver: Driver);

            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            Point CurrentPoint = Element.Location;
            Point EndPoint = BitrixFramework.FindWebElement(Object, Driver: Driver).Location;
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
            builder.DragAndDropToOffset(Element, EndPoint.X - CurrentPoint.X, EndPoint.Y - CurrentPoint.Y).Build().Perform();

            Log.MesNormal(String.Format("'{0}' -> смещение к {1}", description, Object.description));

            //проверяем страницу на наличие ошибок
            BitrixFramework.CheckJSErrors(Driver: Driver);
            GM.CheckContentOnErrors(Driver: Driver);
        }

        /// <summary>
        /// Метод реализует действие наведения указателя мыши на WebItem
        /// </summary>
        /// <param name="ScrollToObject">Меняет скроллирование до объекта(по умолчанию: отключено для админской части и включено для публичной)
        /// Соответственно true включает скролл в адимнке и выключает в публичке</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void MouseOver(bool ScrollToObject = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
            OpenQA.Selenium.Interactions.Actions hover = builder.MoveToElement(BitrixFramework.FindWebElement(this, Driver: Driver)).ClickAndHold();
            hover.Build().Perform();

            Log.MesNormal(String.Format("'{0}' -> Наведение указателя мыши", description));

            //проверяем страницу на наличие ошибок
            BitrixFramework.CheckJSErrors(Driver: Driver);
        }

        /// <summary>
        /// Метод реализует действие наведения указателя мыши
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void MouseOverNoHover(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            OpenQA.Selenium.Interactions.Actions builder = new OpenQA.Selenium.Interactions.Actions(Driver);
            builder.MoveToElement(BitrixFramework.FindWebElement(this, Driver: Driver)).Build().Perform();

            Log.MesNormal(String.Format("'{0}' -> Наведение указателя мыши", description));

            //проверяем страницу на наличие ошибок
            BitrixFramework.CheckJSErrors(Driver: Driver);
        }

        /// <summary>
        /// Метод проверяет, что элемент отображается. style="display". Можно задать сообщение в лог если true и если false. По умолчанию в лог ничего не пишется
        /// </summary>
        /// <returns>true - отображается, false - не отображается</returns>
        /// <param name="trueMessage">Сообщение в лог, если элемент отображается (true)</param>
        /// <param name="falseMessage">Сообщение в лог, если элемент не отображается (false)</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public bool Displayed(string trueMessage = "", string falseMessage = "", IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            try
            {
                if (Element != null && Element.Displayed)
                {
                    if (trueMessage != "")
                        Log.MesPass(String.Format(trueMessage));
                    return true;
                }
                else
                {
                    if (falseMessage != "")
                        Log.MesError(String.Format(falseMessage));
                    return false;
                }
            }
            catch (StaleElementReferenceException)
            {
                Log.MesQuestion("Изменился DOM страницы, и элемента " + this.description + " больше нет в кеше. Подождем 5 сек и попробуем найти его ещё разок");
                BitrixFramework.Wait(5);
                try
                {
                    if (Element != null && Element.Displayed)
                    {
                        if (trueMessage != "")
                            Log.MesPass(String.Format(trueMessage));
                        return true;
                    }
                    else
                    {
                        if (falseMessage != "")
                            Log.MesError(String.Format(falseMessage));
                        return false;
                    }
                }
                catch
                {
                    Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                    throw;
                }
            }
        }

        /// <summary>
        /// Метод проверяет, что элемент не отображается. style="display". Можно задать сообщение в лог если true и если false
        /// </summary>
        /// <returns>true - не отображается, false - отображается</returns>
        /// <param name="trueMessage">Сообщение в лог, если элемент не отображается (true)</param>
        /// <param name="falseMessage">Сообщение в лог, если элемент отображается (false)</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public bool NOTDisplayed(string trueMessage = "", string falseMessage = "", IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            if ((Element != null && !Element.Displayed) || Element == null)
            {
                if (trueMessage != "")
                    Log.MesPass(String.Format(trueMessage));
                return true;
            }
            else
            {
                if (falseMessage != "")
                    Log.MesError(String.Format(falseMessage));
                return false;
            }
        }

        /// <summary>
        /// Метод посылает указанный текст в WebItem. Опционально - очищать текст в контроле перед посылом. По умолчанию - true, очищать. Аналог WebDriver.FindElement().SendKeys()
        /// </summary>
        /// <param name="text">Текст, который надо послать в WebItem</param>
        /// <param name="clearBeforeSend">Очистить текст в контроле перед посылом текста. true - очистить, false - нет</param>
        /// <param name="HideMessage">Скрывать ли текс в контейнер</param>
        /// <param name="checkErrors">Проверять или нет ошибки</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void SendKeys(string text, bool clearBeforeSend = true, bool HideMessage = false, bool checkErrors = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
                if (clearBeforeSend)
                    Element.Clear();

                Element.SendKeys(text);
            }
            catch (NullReferenceException)
            {
                Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                throw;
            }
            if (HideMessage)
            {
                string spanID = DateTime.Now.Ticks.ToString();
                Log.MesNormal("<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\"" +
                    " href=\"\" onclick=\"return collapse('" + spanID + "', this)\">" + description + "-> Введен текст </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" +
                    text + "</span>");
            }
            else
                Log.MesNormal(String.Format("'{0}' -> Введен текст '{1}'", description, text));

            if (checkErrors)
                BitrixFramework.CheckJSErrors(Driver: Driver);
        }

        /// <summary>
        /// Метод вставляет указанный текст в WebItem комбинацией клавиш shift+ins. 
        /// Опционально - очищать текст в контроле перед вставкой. По умолчанию true - очищать.
        /// Опционально: скролить фокус к объекту. По умолчанию true - скролить.
        /// </summary>
        /// <param name="text">Вставляемый текст</param>
        /// <param name="ClearBeforePaste">очистить элемент перед вставкой. true - очистить, false - нет</param>
        /// <param name="ScrollToObject">скроллить фокус к объекту. По умолчанию true - скроллить</param>
        /// <param name="HideMessage">Скрывать ли текс в контейнер</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void PasteText(string text, bool ClearBeforePaste = true, bool ScrollToObject = true, bool HideMessage = false, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
                if (ClearBeforePaste)
                    Element.Clear();

                Clipboard.Clear();
                Clipboard.SetText(text);
                Element.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Insert);
                Clipboard.Clear();
            }
            catch (NullReferenceException)
            {
                Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                throw;
            }
            if(HideMessage)
            {
                string spanID = DateTime.Now.Ticks.ToString();
                Log.MesNormal("<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\""+
                    " href=\"\" onclick=\"return collapse('" + spanID + "', this)\">" + description + "-> Вставлен текст </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" +
                    text + "</span>");
            }
            else
                Log.MesNormal(String.Format("'{0}' -> Вставлен текст '{1}'", description, text));
        }

        /// <summary>
        /// Метод выбирает значение из выпадающего списка по тексту. Метод выбирает элемент по найденному вхождению. Аналог SelectElement.SelectByText()
        /// </summary>
        /// <param name="text">Значение списка, которое надо выбрать</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void SelectItemByText(string text, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                var selectElement = new SelectElement(BitrixFramework.FindWebElement(this, Driver: Driver));
                var allOptionsThatHaveText = selectElement.Options.Where(se => se.Text.Equals(text, StringComparison.OrdinalIgnoreCase));
                if (allOptionsThatHaveText.Any())
                {
                    foreach (var option in allOptionsThatHaveText)
                    {
                        try
                        {
                            option.Click();
                        }
                        catch (StaleElementReferenceException)
                        {
                            Log.MesQuestion("Изменился DOM страницы, и элемента " + this.description + " больше нет в кеше. Подождем 5 сек и попробуем найти его ещё разок");
                            BitrixFramework.Wait(5);
                            try
                            {
                                option.Click();
                            }
                            catch
                            {
                                Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                                throw;
                            }
                        }
                    }

                    Log.MesNormal(String.Format("'{0}' -> Выбрано значение '{1}'", description, text));

                    //проверяем страницу на наличие ошибок
                    BitrixFramework.CheckJSErrors(Driver: Driver);
                    GM.CheckContentOnErrors(Driver: Driver);

                    return;
                }

                var optionWithText = selectElement.Options.Where(option => option.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);
                if (optionWithText.Any())
                {
                    foreach (var option in optionWithText)
                    {
                        try
                        {
                            option.Click();
                        }
                        catch (StaleElementReferenceException)
                        {
                            Log.MesQuestion("Изменился DOM страницы, и элемента " + this.description + " больше нет в кеше. Подождем 5 сек и попробуем найти его ещё разок");
                            BitrixFramework.Wait(5);
                            try
                            {
                                option.Click();
                            }
                            catch
                            {
                                Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                                throw;
                            }
                        }
                    }

                    Log.MesNormal(String.Format("'{0}' -> Выбрано значение '{1}'", description, text));

                    //проверяем страницу на наличие ошибок
                    BitrixFramework.CheckJSErrors(Driver: Driver);
                    GM.CheckContentOnErrors(Driver: Driver);

                    return;
                }

                allOptionsThatHaveText = selectElement.Options.Where(se => se.Text.Contains(text));
                if (allOptionsThatHaveText.Any())
                {
                    foreach (var option in allOptionsThatHaveText)
                    {
                        try
                        {
                            option.Click();
                        }
                        catch (StaleElementReferenceException)
                        {
                            Log.MesQuestion("Изменился DOM страницы, и элемента " + this.description + " больше нет в кеше. Подождем 5 сек и попробуем найти его ещё разок");
                            BitrixFramework.Wait(5);
                            try
                            {
                                option.Click();
                            }
                            catch
                            {
                                Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                                throw;
                            }
                        }
                    }

                    Log.MesNormal(String.Format("'{0}' -> Выбрано значение '{1}'", description, text));

                    //проверяем страницу на наличие ошибок
                    BitrixFramework.CheckJSErrors(Driver: Driver);
                    GM.CheckContentOnErrors(Driver: Driver);

                    return;
                }

                throw new NoSuchElementException(string.Format("Нет элементов с вхождением: {0}", text));
            }
            catch { }
        }

        /// <summary>
        /// Метод выбирает значение из выпадающего списка по тексту. Метод выбирает элемент по найденному вхождению. Аналог SelectElement.SelectByText()
        /// </summary>
        /// <param name="text">Значение списка, которое надо выбрать</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void SelectItemByText_Direct(string text, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            var selectElement = new SelectElement(BitrixFramework.FindWebElement(this, Driver: Driver));
            List<IWebElement> Elements = BitrixFramework.GetElements(By.XPath("//option"), Driver: Driver);
            foreach (IWebElement element in Elements)
            {
                var optionWithText = selectElement.Options.Where(option => option.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);
                if (element.Text == text)
                {
                    if (element.Selected == false)
                        element.Click();
                    Log.MesNormal(String.Format("'{0}' -> Выбрано значение '{1}'", description, text));
                    //проверяем страницу на наличие ошибок
                    BitrixFramework.CheckJSErrors(Driver: Driver);
                    GM.CheckContentOnErrors(Driver: Driver);
                    return;
                }
            }

            throw new NoSuchElementException(string.Format("Нет элементов с вхождением: {0}", text));
        }

        /// <summary>
        /// Метод выбирает значение из выпадающего списка по value. Аналог SelectElement.SelectByValue()
        /// </summary>
        /// <param name="value">Значение списка, которое надо выбрать</param>
        /// <param name="checkErrors">Проверять или нет ошибки</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void SelectItemByValue(string value, bool checkErrors = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            var selectElement = new SelectElement(BitrixFramework.FindWebElement(this, Driver: Driver));
            selectElement.SelectByValue(value);
            Log.MesNormal(String.Format("'{0}' -> Выбрано значение '{1}'", description, value));

            //проверяем страницу на наличие ошибок
            if (checkErrors)
            {
                BitrixFramework.CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Метод сбрасывается значение в элемент типа Select. Причём снимает ВСЕ значения даже если хоть одно должно быть.
        /// </summary>
        /// <param name="checkErrors">Проверка на ошибки</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void DeselectItems(bool checkErrors = true, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            var selectElement = new SelectElement(BitrixFramework.FindWebElement(this, Driver: Driver));
            selectElement.DeselectAll();
            Log.MesNormal(String.Format("'{0}' -> сбошены сзначения", description));

            //проверяем страницу на наличие ошибок
            if (checkErrors)
            {
                BitrixFramework.CheckJSErrors(Driver: Driver);
                GM.CheckContentOnErrors(Driver: Driver);
            }
        }

        /// <summary>
        /// Метод переключает на выбранный фрейм. Аналог WebDriver.SwitchTo().Frame()
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void SwitchToFrame(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            try
            {
                BitrixFramework.SwitchTo().Frame(BitrixFramework.FindWebElement(this, Driver: Driver));
            }
            catch (ArgumentNullException)
            {
                Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                throw;
            }
        }

        /// <summary>
        /// Метод проверяет, существует ли объект в данный момент на странице. 
        /// Можно задать сообщения в лог если true и если false. По умолчанию сообщений нет.
        /// </summary>
        /// <returns>true - существует, false - не существует</returns>
        /// <param name="trueMessage">Сообщение в лог, если элемент существует (true)</param>
        /// <param name="falseMessage">Сообщение в лог, если элемент не существует (false)</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public bool Exists(string trueMessage = "", string falseMessage = "", IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (BitrixFramework.FindWebElement(this, Driver: Driver) != null)
            {
                if (trueMessage != "")
                    Log.MesPass(trueMessage);
                return true;
            }
            else
            {
                if (falseMessage != "")
                    Log.MesError(falseMessage);
                return false;
            }
        }

        /// <summary>
        /// Метод проверяет, что объект не существует в данный момент на странице. Можно задать сообщения в лог если true и если false
        /// </summary>
        /// <returns>true - не существует, false - существует</returns>
        /// <param name="trueMessage">Сообщение в лог, если элемент не существует (true)</param>
        /// <param name="falseMessage">Сообщение в лог, если элемент существует (false)</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public bool NOTExists(string trueMessage = null, string falseMessage = null, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (BitrixFramework.FindWebElement(this, Driver: Driver) == null)
            {
                if (trueMessage != null)
                    Log.MesPass(trueMessage);
                return true;
            }
            else
            {
                if (falseMessage != null)
                    Log.MesError(falseMessage);
                return false;
            }
        }

        /// <summary>
        /// Получает значение указанного атрибута WebItem. Аналог WebDriver.GetAttribute()
        /// </summary>
        /// <param name="attributeName">Название атрибута, значение которого надо выбрать</param>
        /// <param name="writeToLog">Записать в лог значение атрибута, true - записать в лог, false (по умолчанию) - не записывать</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public string GetAttribute(string attributeName, bool writeToLog = false, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            string value;
            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            if (Element.GetAttribute(attributeName) != null)
            {
                value = Element.GetAttribute(attributeName);
                if (writeToLog)
                    Log.MesNormal(String.Format("'{0}' Значение атрибута: '{1}'", description, value));
                return value;
            }
            else
            {
                value = null;
                if (writeToLog)
                    Log.MesError(String.Format("Атрибут {0} не найден", attributeName));
                return value;
            }
        }

        /// <summary>
        /// Метод реализует ожидание появления объекта заданное количество времени (секунд)
        /// По умолчанию ожидание - 1 секунда
        /// </summary>
        /// <param name="secondsToWait">Сколько секунд ждать</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>true - элемент появился, false - элемент не появился</returns>
        public bool WaitElementPresent(int secondsToWait = 1, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            int timer = 0;
            bool appeared = true;

            while (BitrixFramework.FindWebElement(this, Driver: Driver) == null)
            {
                if (secondsToWait != timer)
                {
                    timer++;
                    BitrixFramework.Wait(1);
                }
                else
                {
                    return appeared = false;
                }
            }

            return appeared;
        }

        /// <summary>
        /// Метод реализует ожидание отображения объекта (Displayed) заданное количество времени (секунд)
        /// По умолчанию ожидание - 1 секунда.
        /// </summary>
        /// <param name="secondsToWait">Сколько секунд ждать</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>true - элемент отобразился, false - элемент не отобразился</returns>
        public bool WaitElementDisplayed(int secondsToWait = 1, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            int timer = 0;
            bool displayed = true;
            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            while (Element == null && !Element.Displayed)
            {
                if (secondsToWait != timer)
                {
                    timer++;
                    BitrixFramework.Wait(1);
                }
                else
                    return false;
            }
            return displayed;
        }

        /// <summary>
        /// Ждем пока элемент отображается (Displayed). 
        /// Интервал ожидания можно задать в секундах. По умолчанию 1 секунда
        /// </summary>
        /// <param name="waitInterval">интервал ожидания в секундах</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void WaitWhileElementDisplayed(int waitInterval = 1, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            while (BitrixFramework.FindWebElement(this, Driver: Driver) != null && BitrixFramework.FindWebElement(this, Driver: Driver).Displayed)
                BitrixFramework.Wait(waitInterval);
        }

        /// <summary>
        /// Метод реализует ожидание появления текста в объекте заданное количество секунд. Текст приводится к нижнему регистру
        /// </summary>
        /// <param name="text">текст, появление которого ожидаем</param>
        /// <param name="secondsToWait">сколько секунд ждать</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>true - текст появился, false - текст не появился</returns>
        public bool WaitTextPresent(string text, int secondsToWait, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            int timer = 0;
            bool appeared = true;

            while (!BitrixFramework.FindWebElement(this, Driver: Driver).Text.ToLower().Contains(text))
            {
                if (secondsToWait != timer)
                {
                    timer++;
                    BitrixFramework.Wait(1);
                }
                else
                {
                    return appeared = false;
                }
            }

            return appeared;
        }

        /// <summary>
        /// Метод реализует ожидание, пока элемент существует. 
        /// Интервал ожидания можно задать в секундах. По умолчанию 1 секунда
        /// </summary>
        /// <param name="waitInterval">интервал ожидания в секундах</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void WaitWhileElementExists(int waitInterval = 1, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            while (BitrixFramework.FindWebElement(this, Driver: Driver) != null)
                BitrixFramework.Wait(waitInterval);
        }

        /// <summary>
        /// Метод реализует ожидание, пока текст в объекте существует. Интервал ожидания 1 секунда
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        public void WaitWhileTextPresents(string text, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            while (BitrixFramework.FindWebElement(this, Driver: Driver).Text.ToLower().Contains(text))
                BitrixFramework.Wait(1);
        }

        /// <summary>
        /// Возвращает отмеченность объекта (selected). true - выбран (отмечен), false - не выбран (не отмечен). Применим только для чекбоксов и радиобатонов. Аналог WebDriver.Selected()
        /// </summary>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>состояние объекта, true - отмечен, false - не отмечен</returns>
        public bool Selected(IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            bool selected = false;

            BitrixFramework.Scroll(this, Driver: Driver);
            if (BitrixFramework.FindWebElement(this, Driver: Driver).Selected)
                selected = true;

            return selected;
        }

        #region Ассерты
        /// <summary>
        /// Метод проверяет присутствие подстроки в innerText объекта. true - совпадение найдено, false - совпадение не найдено
        /// Можно задать сообщение в лог если true и если false. По умолчанию сообщений нет.
        /// </summary>
        /// <param name="containingString">Строка которую ищем</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение не найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>True - совпадение найдено, false - совпадение не найдено</returns>
        public bool AssertTextContaining(string containingString, string trueMessage = "", string falseMessage = "", IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (BitrixFramework.FindWebElement(this, Driver: Driver) != null)
            {
                if (this.innerText.Contains(containingString))
                {
                    if (trueMessage != "")
                        Log.MesPass(trueMessage);
                    return true;
                }
                else
                {
                    if (falseMessage != "")
                        Log.MesError(String.Format("{0} \r\n\r\nОжидалось: {1} \r\n\r\nНо было: {2}", falseMessage.Replace('<', '[').Replace('>', ']'), containingString, this.innerText));
                    return false;
                }
            }
            else
            {
                Log.MesError("Не найден объект \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                return false;
            }
        }

        /// <summary>
        /// Метод проверяет отсутствие заданной подстроки в innerText объекта. true - подстрока отсутствует, false - подстрока присутствует
        /// </summary>
        /// <param name="notContainingString">Строка которую не должны найти</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение не найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns>True - подстрока отсутствует, false - подстрока присутствует</returns>
        public bool AssertTextNOTContaining(string notContainingString, string trueMessage = "", string falseMessage = "", IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            if (BitrixFramework.FindWebElement(this, Driver: Driver) != null)
            {
                if (!this.innerText.Contains(notContainingString))
                {
                    if (trueMessage != "")
                        Log.MesPass(trueMessage);
                    return true;
                }
                else
                {
                    if (falseMessage != "")
                        Log.MesError(String.Format("{0} \r\n\r\nОжидалось отсутствие строки: {1} \r\n\r\nНо строка присутствует: {2}", falseMessage.Replace('<', '[').Replace('>', ']'),
                            notContainingString, this.innerText));
                    return false;
                }
            }
            else
            {
                Log.MesError("Нет объекта \"" + this.description + "\" по пути \"" + this.by.ToString() + "\"");
                return true;
            }
        }

        /// <summary>
        /// Метод проверяет присутствие подстроки в innerText объекта по заданному регекс-паттерну. true - совпадение найдено, false - совпадение не найдено
        /// Можно задать сообщение в лог если true и если false. По умолчанию сообщений нет.
        /// </summary>
        /// <param name="pattern">Регекс паттерн</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение не найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <returns>true - совпадение найдено, false - совпадение не найдено</returns>
        public bool AssertTextMatching(string pattern, string trueMessage = "", string falseMessage = "")
        {
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            Match match = rgx.Match(this.innerText);

            if (match.Success)
            {
                if (trueMessage != "")
                    Log.MesPass(trueMessage);
                return true;
            }
            else
            {
                if (falseMessage != "")
                    Log.MesError(String.Format("{0} \r\n\r\nОжидалось: {1} \r\n\r\nНо было: {2}", falseMessage.Replace('<', '[').Replace('>', ']'), pattern, this.innerText));
                return false;
            }
        }

        /// <summary>
        /// Метод проверяет отсутствие подстроки в innerText объекта по заданному регекс-паттерну. true - совпадение найдено, false - совпадение не найдено
        /// </summary>
        /// <param name="pattern">Регекс паттерн</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение не найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <returns>true - совпадение не найдено, false - совпадение найдено</returns>
        public bool AssertTextNOTMatching(string pattern, string trueMessage = "", string falseMessage = "")
        {
            if (this.Exists())
            {
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
                Match match = rgx.Match(this.innerText);

                if (!match.Success)
                {
                    if (trueMessage != "")
                        Log.MesPass(trueMessage);
                    return true;
                }
                else
                {
                    if (falseMessage != "")
                        Log.MesError(String.Format("{0} \r\n\r\nОжидалось отсутствие строки: {1} \r\n\r\nНо строка присутствует: {2}", falseMessage.Replace('<', '[').Replace('>', ']'),
                            pattern, this.innerText));
                    return false;
                }
            }
            else
            {
                Log.MesPass(trueMessage);
                return true;
            }
        }

        /// <summary>
        /// Метод проверяет присутствие подстроки в innerHTML объекта по заданному регекс-паттерну. true - совпадение найдено, false - совпадение не найдено
        /// Можно задать сообщение в лог если true и если false. По умолчанию сообщений нет.
        /// </summary>
        /// <param name="pattern">Регекс паттерн</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение не найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <returns>True - совпадение найдено, false - совпадение не найдено</returns>
        public bool AssertHTMLMatching(string pattern, string trueMessage = "", string falseMessage = "")
        {
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            Match match = rgx.Match(this.innerHTML);

            string spanID = DateTime.Now.Ticks.ToString();
            if (match.Success)
            {
                if (trueMessage != "")
                    Log.MesPass(trueMessage);
                return true;
            }
            else
            {
                if (falseMessage != "")
                    Log.MesError(String.Format("{0} \r\n {1} \r\n {2}", falseMessage,
                        "Ожидалось: " + pattern.Replace('<', '[').Replace('>', ']'),
                        "<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\" href=\"\" onclick=\"return collapse('" +
                        spanID + "', this)\">Но было: </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" +
                        this.innerHTML.Replace('<', '[').Replace('>', ']') + "</span>"));
                return false;
            }
        }

        /// <summary>
        /// Метод проверяет отсутствие подстроки в innerHTML объекта по заданному регекс-паттерну. true - совпадение не найдено, false - совпадение найдено
        /// </summary>
        /// <param name="pattern">Регекс паттерн</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение не найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <returns>True - совпадение не найдено, false - совпадение найдено</returns>
        public bool AssertHTMLNOTMatching(string pattern, string trueMessage="", string falseMessage="")
        {
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            Match match = rgx.Match(this.innerHTML);

            string spanID = DateTime.Now.Ticks.ToString();
            if (!match.Success)
            {
                if (trueMessage != "")
                    Log.MesPass(trueMessage);
                return true;
            }
            else
            {
                if (falseMessage != "")
                    Log.MesError(String.Format("{0} \r\n {1} \r\n {2}", falseMessage,
                            "Ожидалось отсутствие строки: " + pattern.Replace('<', '[').Replace('>', ']'),
                            "<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\" href=\"\" onclick=\"return collapse('" +
                            spanID + "', this)\">Но строка присутствует: </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" +
                            this.innerHTML.Replace('<', '[').Replace('>', ']') + "</span>"));
                return false;
            }
        }

        /// <summary>
        /// Метод проверяет присутствие подстроки в innerHTML объекта. true - совпадение найдено, false - совпадение не найдено.
        /// </summary>
        /// <param name="containingString">Строка которую ищем</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение не найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <returns>True - совпадение найдено, false - совпадение не найдено</returns>
        public bool AssertHTMLContaining(string containingString, string trueMessage = "", string falseMessage = "")
        {
            string spanID = DateTime.Now.Ticks.ToString();
            if (this.innerHTML.Contains(containingString))
            {
                if (trueMessage != "")
                    Log.MesPass(trueMessage);
                return true;
            }
            else
            {
                if (falseMessage != "")
                    Log.MesError(String.Format("{0} \r\n {1} \r\n {2}", falseMessage,
                        "Ожидалось: " + containingString.Replace('<', '[').Replace('>', ']'),
                        "<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\" href=\"\" onclick=\"return collapse('" +
                        spanID + "', this)\">Но было: </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" +
                        this.innerHTML.Replace('<', '[').Replace('>', ']') + "</span>"));
                return false;
            }
        }

        /// <summary>
        /// Метод проверяет отстствие подстроки в innerHTML объекта. true - совпадение найдено, false - совпадение не найдено.
        /// </summary>
        /// <param name="containingString">Строка которую ищем</param>
        /// <param name="trueMessage">Сообщение в лог, если совпадение найдено</param>
        /// <param name="falseMessage">Сообщение в лог, если совпадение не найдено. Автоматически добавится скриншот и эксепшн</param>
        /// <returns>True - совпадение найдено, false - совпадение не найдено</returns>
        public bool AssertHTMLNOTContaining(string containingString, string trueMessage = "", string falseMessage = "")
        {
            string spanID = DateTime.Now.Ticks.ToString();
            if (!this.innerHTML.Contains(containingString))
            {
                if (trueMessage != "")
                    Log.MesPass(trueMessage);
                return true;
            }
            else
            {
                if (falseMessage != "")
                    Log.MesError(String.Format("{0} \r\n {1} \r\n {2}", falseMessage,
                        "Ожидалось отсутствие строки: " + containingString.Replace('<', '[').Replace('>', ']'),
                        "<div style=\"margin: 7px 0px 0px 46px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\" href=\"\" onclick=\"return collapse('" +
                        spanID + "', this)\">Но строка присутствует: </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" +
                        this.innerHTML.Replace('<', '[').Replace('>', ']') + "</span>"));
                return false;
            }
        }

        /// <summary>
        /// олучает значение указанного стиля WebItem. Аналог WebDriver.GetCssValue()
        /// </summary>
        /// <param name="CSSName">Название стиля, значение которого надо выбрать</param>
        /// <param name="writeToLog">Записать в лог значение атрибута, true - записать в лог, false (по умолчанию) - не записывать</param>
        /// <param name="Driver">Веб Драйвер(по умолчанию - единственный BitrixFramework.WebDriver)</param>
        /// <returns></returns>
        public string GetCss(string CSSName, bool writeToLog = false, IWebDriver Driver = null)
        {
            if (Driver == null)
                Driver = BitrixFramework.WebDriver;
            string value;
            IWebElement Element = BitrixFramework.FindWebElement(this, Driver: Driver);
            if (Element.GetCssValue(CSSName) != null)
            {
                value = Element.GetCssValue(CSSName);
                if (writeToLog)
                    Log.MesNormal(String.Format("'{0}' Значение стиля: '{1}'", description, value));
                return value;
            }
            else
            {
                value = null;
                if (writeToLog)
                    Log.MesError(String.Format("Стиль {0} не найден", CSSName));
                return value;
            }
        }
        #endregion
    }
}