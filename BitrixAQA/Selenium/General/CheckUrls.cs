using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BitrixAQA.General;
using BitrixAQA.Selenium.Framework;
using BitrixAQA.Selenium.Object_Repository;
using BitrixAQA.Selenium.Test_Cases;

namespace BitrixAQA.Selenium.General
{
    /// <summary>
    /// Класс проверки урлов
    /// </summary>
    class CheckUrls
    {
        public static System.Collections.Generic.List<Tuple<string, int>> checkMasks = new System.Collections.Generic.List<Tuple<string, int>>();
        public static System.Collections.Generic.List<Tuple<bool, string, string>> Links = new System.Collections.Generic.List<Tuple<bool, string, string>>();
        public static List<string> lbDoubles = new List<string>();
        //список проверить один раз
        static List<string> lCheckOnes = new List<string>();
        //сколько всего урлов в коллекции
        public static int countTotalUrl = 0;
        //сколько урлов по маске собирать
        public static int urlsToCollect = 0;

        /// <summary>
        /// страница, на котором была найдена проверяемая ссылка
        /// </summary>
        public static string sourceUrl = "";

        /// <summary>
        /// Метод запуска проверки урлов
        /// </summary>
        /// <param name="urlToCheck">Проверяемый урл</param>
        /// <param name="isAdmin">Признак проверки в админке или публичке</param>
        public static void Run(string urlToCheck, string isAdmin = "false")
        {
            Log.Gap();
            Log.MesNormal("Проверка всех урлов на наличие ошибок на сайте " + urlToCheck);

            lCheckOnes = new List<string>(MainForm.form.tbCheckOnce.Text.Replace("\r", "").Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList());

            if (Directory.Exists(urlToCheck + "CTest"))
                BitrixFramework.OpenURL(urlToCheck, false, false);
            else
                BitrixFramework.OpenURL(urlToCheck, false);
            try
            {
                if (isAdmin == "true")
                    Case_Main.OpenAdmin();
                if (MainForm.form.tbCheckUrlsLogin.Text.Trim() != "" && MainForm.form.tbCheckUrlsPass.Text.Trim() != "" && !urlToCheck.Contains(".bitrix24."))
                    Case_General_Login.LoginAdminArea(MainForm.form.tbCheckUrlsLogin.Text.Trim(), MainForm.form.tbCheckUrlsPass.Text.Trim());
            }
            catch { }

            BitrixFramework.OpenURL(urlToCheck, false);
            if (isAdmin == "true")
                Case_Main.OpenAdmin();
            else
                Case_Main.OpenPublic();
            
            var queueToCheck = new Queue<string>();
            queueToCheck.Enqueue(urlToCheck);

            FillCheckMasksCollection();

            //очищаем список ссылок
            Links.Clear();

            while (queueToCheck.Count > 0)
            {
                CheckAllUrls(queueToCheck, urlToCheck, queueToCheck.Dequeue(), isAdmin);
            }

            //выводим в лог все пройденные ссылки
            Log.NodeOpen("Ссылки:", collapsed: false);
            for (int link = 0; link < Links.Count; link++)
            {
                Log.MesNormal(Links[link].Item2);
            }
            Log.NodeClose();

            Log.Gap();
            Log.MesNormal("Проверка завершена");
        }

        /// <summary>
        /// Коллекция масок для проверки урлов
        /// </summary>
        public static void FillCheckMasksCollection()
        {
            checkMasks.Add(new Tuple<string, int>("company/personal/user/\\d+/$", 0));
            checkMasks.Add(new Tuple<string, int>("company/personal/user/\\d+/tasks/$", 0));
        }

        /// <summary>
        /// Метод получает все урлы сайта
        /// </summary>
        /// <param name="queueToCheck">линки для проверки</param>
        /// <param name="host">хост в формате http://host.ru</param>
        /// <param name="UrlTocheck">урл для проверки в формате http://host.ru/ </param>
        /// <param name="isAdmin">Признак настройки правил для админки или публички</param>
        public static void CheckAllUrls(Queue<string> queueToCheck, string host, string UrlTocheck, string isAdmin = null)
        {
            string checkHost = host;
            int countStart = countTotalUrl;
            Uri tmpUtl;

            //подставляем в проверяемый урл http:// если его не было
            if (host.IndexOf("http://") < 0 && host.IndexOf("https://") < 0 && host.IndexOf("ftp://") < 0)
                host = "http://" + host;

            if (host.Replace("//", "").IndexOf("/") < 0)
                host = host + "/";

            //получаем чистый хост без http
            string pattern = "[a-z]+://([^/]+)/.*";
            string replacement = "$1";
            Regex rgx = new Regex(pattern);
            string clearHost = rgx.Replace(host, replacement);

            //получаем в sourceUrl урл страницы, на которой нашли проверяемый урл
            for (int link = 0; link < Links.Count; link++)
            {
                if (Links[link].Item2 == UrlTocheck)
                    //в сурс урл передаем страницу, на которой ищем урлы
                    sourceUrl = Links[link].Item3;
            }

            //проверяем опцию проверки страницы на наличие ошибок
            if (MainForm.form.cbUrlsCheckPageOnErrors.Checked)
            {
                BitrixFramework.CheckJSErrors();
                BitrixFramework.OpenURL(UrlTocheck, false);
            }
            else
            {
                BitrixFramework.CheckJSErrors();
                BitrixFramework.OpenURL(UrlTocheck, false, false);
            }
            string html = TO_General.Region_AllPage().innerHTML;

            if (html == null)
                html = "";
            string HRefPattern = @"(?i)<\s*?a\s+[\S\s\x22\x27\x3d]*?href=[\x22\x27]?([^\s\x22\x27<>]+)[\x22\x27]?.*?>";
            string ImgPattern = @"(?i)<[\S\s\x22\x27\x3d]*?img src=[\x22\x27]?([^\s\d\x22\x27<>]+)[\x22\x27]?.*?>";
            string Img1Pattern = @"(?i)<[\S\s\x22\x27\x3d]*?background-image: url[\x28]?([^\x28\x29<>]+)[\x29]?.*?>";
            string Img2Pattern = @"(?i)<[\S\s\x22\x27\x3d]*?background: url[\x28]?[\x27]?([^\x27<>]+)[\x27]?[\x29]?.*?>";
            Match m;
            string[] Patterns;
            //В зависимости от флага на форме проверяем или нет картинки
            if (MainForm.form.cbCheckImages1.Checked)
                Patterns = new[] { HRefPattern, ImgPattern, Img1Pattern, Img2Pattern };
            else
                Patterns = new[] { HRefPattern };
            foreach (string Pattern in Patterns)
            {
                m = Regex.Match(html, Pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

                //смотрим, подходит ли нам найденный урл
                while (m.Success)
                {
                    //дубль
                    bool foundDouble = false;
                    //внешняя ссылка
                    bool externalLink = false;
                    //уже добавленный в коллекцию урл, после проверки на маски
                    #pragma warning disable 0219
                    bool addedAfterMasks = false;
                    #pragma warning restore 0219
                    string workString = null;
                    workString = m.Groups[1].Value;

                    #region Условия и ограничения
                    Dictionary<string, bool> Permissions = new Dictionary<string, bool>();
                    Permissions.Add("javascript:void(0)", false);
                    Permissions.Add("javascript:", false);
                    Permissions.Add("rss", false);
                    Permissions.Add("/bitrix/rk.php", false);
                    Permissions.Add("/bitrix/redirect.php", false);
                    Permissions.Add("trackback", false);
                    Permissions.Add("ACTION=SET_BE_READ", false);
                    Permissions.Add("manual.zip", false);
                    Permissions.Add("lang=en", false);
                    Permissions.Add("mode=excel", false);
                    Permissions.Add("?EXCEL=Y", false);
                    Permissions.Add("excel=yes", false);
                    Permissions.Add("fileman_admin.php", false);
                    Permissions.Add("month", false);
                    Permissions.Add("login", false);
                    Permissions.Add("sessid", false);
                    Permissions.Add("logout", false);
                    //Permissions.Add("register", false);
                    //Permissions.Add("bitrix_include_areas", false);
                    Permissions.Add("change_password", false);
                    Permissions.Add("forgot_password", false);
                    Permissions.Add("print=", false);
                    Permissions.Add("clear_cache", false);
                    Permissions.Add("/webdav_bizproc_history_get/", false);
                    Permissions.Add("show_include_exec_time", false);
                    Permissions.Add("show_page_exec_time", false);
                    Permissions.Add("show_sql_stat", false);
                    Permissions.Add("show_link_stat", false);
                    Permissions.Add("action", false);
                    Permissions.Add("#message", false);
                    Permissions.Add("tags", false);
                    Permissions.Add(".flv", false);
                    Permissions.Add(".xlsx", false);
                    Permissions.Add(".xls", false);
                    Permissions.Add(".docx", false);
                    Permissions.Add(".ppt", false);
                    Permissions.Add(".pptx", false);
                    Permissions.Add(".txt", false);
                    Permissions.Add(".png", false);
                    //Permissions.Add(".jpg", false);
                    Permissions.Add(".doc", false);
                    Permissions.Add(".csv", false);
                    Permissions.Add(".exe", false);
                    Permissions.Add(".config", false);
                    Permissions.Add(".xml", false);
                    Permissions.Add(".html", false);
                    Permissions.Add(".htm", false);
                    Permissions.Add(".ascx", false);
                    Permissions.Add(".log", false);
                    Permissions.Add(".asax", false);
                    Permissions.Add(".ico", false);
                    Permissions.Add(".odt", false);
                    Permissions.Add(".mp3", false);
                    Permissions.Add(".tar.gz", false);
                    Permissions.Add("ajax_meeting.php?fileId=", false);
                    Permissions.Add("FileManDownload.ashx", false);
                    Permissions.Add(".zip", false);
                    Permissions.Add("#", false);
                    Permissions.Add("callto:", false);
                    Permissions.Add("/chat/", false);
                    Permissions.Add("?RELOAD=Y", false);
                    Permissions.Add("&FILTERS=", false);
                    Permissions.Add("?FILTERS=", false);
                    Permissions.Add("/historyget/", false);
                    Permissions.Add("&company_search_LAST_NAME=", false);
                    Permissions.Add("getSample=csv", false);
                    Permissions.Add("tasks/?VIEW=", false);
                    Permissions.Add("show_file.php", false);
                    Permissions.Add("bitrix_include_areas=N", false);
                    Permissions.Add("bitrix_include_areas=Y", false);
                    Permissions.Add("company_search_LAST_NAME=", false);
                    Permissions.Add("users_LAST_NAME=", false);
                    Permissions.Add("contacts_search_LAST_NAME=", false);
                    Permissions.Add("FileMan.aspx?path=", false);
                    Permissions.Add("perfmon_tables.php", false);
                    Permissions.Add("?print_course=Y&COURSE_ID=", false);
                    Permissions.Add("perfmon_php.php?lang=ru", false);
                    Permissions.Add("perfmon_db_server.php", false);
                    Permissions.Add("update_system_market.php?module=", false);
                    Permissions.Add("site_mm", false);
                    Permissions.Add("sale_location_node", false);
                    //Permissions.Add("/communication/learning/", false);
                    Permissions.Add("learning/course", false);
                    Permissions.Add("learning/course.php?COURSE_ID=2&TYPE=Y", false);
                    Permissions.Add("__author_url__", false);
                    Permissions.Add("__post_url__", false);
                    Permissions.Add("www.firefox.com", false);
                    Permissions.Add("www.opera.com", false);
                    Permissions.Add("www.google.com", false);
                    Permissions.Add("www.microsoft.com", false);
                    Permissions.Add("www.doroga.tv", false);
                    Permissions.Add("/information/road/", false);
                    Permissions.Add("/personl/", false);
                    Permissions.Add("?PAGEN_1=2", false);
                    Permissions.Add("company/events.php", false);
                    Permissions.Add("ctest/", false);
                    Permissions.Add("week_start=", false);
                    Permissions.Add("mailto:", false);
                    Permissions.Add("www.1c-bitrix.ru", false);                    
                    if (isAdmin == "true")
                        Permissions.Add("/bitrix/admin/", true);
                    if (isAdmin == "false")
                        Permissions.Add("/bitrix/admin/", false);
                    #endregion

                    bool Condition = true;
                    foreach (KeyValuePair<string, bool> Pair in Permissions)
                    {
                        if (Pair.Value)
                            Condition = Shared.Validate(Condition && Shared.Validate(workString.IndexOf(Pair.Key) >= 0));
                        else
                            Condition = Shared.Validate(Condition && Shared.Validate(workString.IndexOf(Pair.Key) < 0));

                        if (!Condition)
                            break;
                    }
                    if (Condition)
                    {
                        //если есть &amp; заменяем на &
                        string ampPattern = @"&amp;";
                        Match ampM;
                        ampM = Regex.Match(workString, ampPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

                        workString = Regex.Replace(workString, ampPattern, "&", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);

                        //очищаем параметр бэкурл
                        if (workString.IndexOf("back_url") >= 0)
                            workString = workString.Replace(workString.Substring(workString.IndexOf("back_url") - 1), "");

                        if (workString.IndexOf("backurl") >= 0)
                            workString = workString.Replace(workString.Substring(workString.IndexOf("backurl") - 1), "");

                        if (workString.IndexOf("www.") >= 0 && workString.IndexOf(clearHost) < 0)
                            externalLink = true;

                        //комбинируем урл
                        try
                        {
                            if (Uri.TryCreate(new Uri(UrlTocheck), workString, out tmpUtl))
                            {
                                workString = tmpUtl.ToString();
                            }
                        }
                        catch
                        {
                            workString = (UrlTocheck + workString).Replace("//", "/");
                        }

                        //если ссылка не содержит проверяемый хост, то пропускаем ее, она внешняя
                        if (workString.IndexOf(checkHost) != 0)
                            externalLink = true;

                        if (Links.Count == 0 && !externalLink)
                            Links.Add(new Tuple<bool, string, string>(false, workString, UrlTocheck));

                        //проверяем найденный урл, не дублируется ли он
                        for (int link = 0; link < Links.Count; link++)
                        {
                            if (workString == Links[link].Item2)
                            {
                                foundDouble = true;
                                break;
                            }
                        }

                        //проверяем урл на соответствие маскам и добавляем новый уникальный урл в коллекцию для проверки
                        //if (!foundDouble && !externalLink)
                        //{
                        //    //проверяем урл на соответствие маскам
                        //    for (int mask = 0; mask < checkMasks.Count; mask++)
                        //    {
                        //        string maskPatter = host.Replace(".", "\\.") + checkMasks[mask].Item1;
                        //        Match maskMatch = Regex.Match(workString, maskPatter, RegexOptions.IgnoreCase | RegexOptions.Compiled);

                        //        //если урл удовлетворяет маске и количество таких урлов в не превышает urlsToCollect, то добавляем уникальный урл в коллекцию для проверки
                        //        if (maskMatch.Success && checkMasks[mask].Item2 < urlsToCollect)
                        //        {
                        //            //запоминаем данные из тюплы
                        //            string sourceMask = checkMasks[mask].Item1; //отработанная маска
                        //            int sourceCount = checkMasks[mask].Item2; //количество урлов по данной маске

                        //            //удаляем тюплу
                        //            checkMasks.Remove(checkMasks[mask]);

                        //            //добавляем тюплу со старой маской и увеличенным на 1 количество урлов по данной маске
                        //            checkMasks.Add(new Tuple<string, int>(sourceMask, sourceCount + 1));

                        //            Links.Add(new Tuple<bool, string, string>(false, workString, UrlTocheck));
                        //            countTotalUrl++;
                        //            addedAfterMasks = true;
                        //        }

                        //        //если тюпла с маской уже заполнена - не добавляем урл
                        //        if (maskMatch.Success && checkMasks[mask].Item2 >= urlsToCollect)
                        //            addedAfterMasks = true;
                        //    }
                        //}

                        //если ссылка не внешняя и не дубликат и не была добавлена по маскам, то добавляем в коллекцию на проверку
                        //if (!foundDouble && !externalLink && !addedAfterMasks)
                        if (!foundDouble && !externalLink)
                        {
                            Links.Add(new Tuple<bool, string, string>(false, workString, UrlTocheck));
                            countTotalUrl++;
                        }
                    }

                    m = m.NextMatch();

                    //выводим все урлы
                    //for (int link = 0; link < Links.Count; link++)
                    //{
                    //    Log.MesNormal(Links[link].Item2);
                    //}

                    //код очистки списка урлов по задданому вхождению
                    //for (int link = 0; link < Links.Count; link++)
                    //{
                    //    if (Links[link].Item2.Contains("?PAGEN_1=2"))
                    //    {
                    //        Links.Remove(Links[link]);
                    //    }
                    //}

                    ////ищем урлы по вхождению
                    //for (int link = 0; link < Links.Count; link++)
                    //{
                    //    if (Links[link].Item2.Contains("site_mm"))
                    //    {
                    //        //string whereWasFound = Links[link].Item3;
                    //        Links.Remove(Links[link]);
                    //    }
                    //}
                }
            }

            //помечаем ссылку как проверенную на наличие урлов
            for (int link = 0; link < Links.Count; link++)
            {
                if (Links[link].Item2 == UrlTocheck)
                {
                    //запоминаем данные из тюплы
                    string checkedUrl = Links[link].Item2; //проверенная только что ссылка
                    string sourceUrl = Links[link].Item3; //страница, где была найдена только что проверенная ссылка

                    //удаляем тюплу
                    Links.Remove(Links[link]);

                    //добавляем тюплу со старым урлом и новым параметров - false, то есть помечаем урл, как проверенный на наличие новых урлов
                    Links.Add(new Tuple<bool, string, string>(true, checkedUrl, sourceUrl));
                }

                //выводим найденные линки в отчет
                //Log.MesNormal(Links[link].Item2);
            }

            //if (c > countStart)
            //if (c == 1500)
            //  Misc.AddToLog(c.ToString());

            for (int link = 0; link < Links.Count; link++)
            {
                //System.Threading.Thread.Sleep(1 * 1000);
                if (!Links[link].Item1)
                {
                    //CheckAllUrls(checkHost, Links[link].Item2);
                    if (!queueToCheck.Contains(Links[link].Item2))
                        queueToCheck.Enqueue(Links[link].Item2);
                }
            }
        }
    }
}