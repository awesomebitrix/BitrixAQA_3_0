using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;

namespace BitrixAQA.General
{
    /// <summary>
    /// Класс работы с почтой по протоколам POP3 и smtp
    /// </summary>
    class Pop
    {      
        /// <summary>
        /// получаем список сообщений из ящика
        /// </summary>
        /// <param name="hostname">хост. Например, pop.yandex.ru</param>
        /// <param name="port">порт. Например, 110</param>
        /// <param name="useSsl">использовать ssl</param>
        /// <param name="username">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>список емейлов</returns>
        public static List<OpenPop.Mime.Message> FetchAllEmailMessages(string hostname, int port, bool useSsl, string username, string password)
        {
            // The client disconnects from the server when being disposed
            using(Pop3Client client = new Pop3Client())
            {
                client.Connect(hostname, port, useSsl);
                client.Authenticate(username, password);
                
                // Get the number of messages in the inbox
                int messageCount = client.GetMessageCount();

                // We want to download all messages
                List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                for(int i = 1; i <= messageCount; i++)
                    allMessages.Add(client.GetMessage(i));

                // Now return the fetched messages
                return allMessages;
            }
        }

        /// <summary>
        /// Возвращает число писем в ящике
        /// </summary>
        /// <param name="userEmail">почтовый ящик</param>
        /// <param name="hostname">хост</param>
        /// <param name="port">порт</param>
        /// <param name="useSsl">использовать ssl</param>
        /// <param name="password">пароль</param>
        /// <returns>количество писем</returns>
        public static int GetYandexEmailCount(string userEmail, string password, string hostname = "pop.yandex.ru", int port = 995, bool useSsl = true)
        {
            return FetchAllEmailMessages(hostname, port, useSsl, userEmail.Substring(0, userEmail.IndexOf("@")), password).Count;
        }

        /// <summary>
        /// ищет письмо с нужной темой
        /// </summary>
        /// <param name="userEmail">email на который стучимся</param>
        /// <param name="Subject">Тема письма, которое нужно прочитать</param>
        /// <param name="Password">Пароль</param>
        /// <returns></returns>
        public static bool GetYandexTextTheme(string userEmail, string Subject, string Password)
        {
            Pop3Client client = new Pop3Client();
            client.Connect("pop.yandex.ru", 995, true);
            client.Authenticate(userEmail.Substring(0, userEmail.IndexOf("@")), Password);

            int messageCount = client.GetMessageCount();
            for (Int32 i = 1; i <= messageCount; i++)
            {
                MessageHeader headers = client.GetMessageHeaders(i);
                RfcMailAddress from = headers.From;
                string subject = headers.Subject;
                //проверяем тему письма, если та что нам надо, добавляем письмо в список писем
                if (subject == Subject)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращаем вложение из письма с заданной темой
        /// </summary>
        /// <param name="hostname">Сервер</param>
        /// <param name="port">Порт</param>
        /// <param name="useSsl">Исользовать ли SSL</param>
        /// <param name="userEmail">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="AttachmentIndex">Индекс вложения</param>
        /// <returns>Вложение</returns>
        public static string GetAttachmentMsg(string hostname, int port, bool useSsl, string userEmail, string Password, string Subject, int AttachmentIndex = 0)
        {
            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(hostname, port, useSsl);
                client.Authenticate(userEmail, Password);

                int messageCount = client.GetMessageCount();
                List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

                Regex rgx = new Regex(Subject, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

                for (int i = 1; i <= messageCount; i++)
                {
                    Match match = rgx.Match(client.GetMessage(i).Headers.Subject);
                    //проверяем тему письма, если та что нам надо, берем нужное вложение
                    if (match.Success && client.GetMessage(i).FindAllAttachments().Count > AttachmentIndex)
                        return client.GetMessage(i).FindAllAttachments()[AttachmentIndex].FileName;
                }
                return "null";
            }
        }

        /// <summary>
        /// Проверка, содержит ли письмо вложение
        /// </summary>
        /// <param name="hostname">Сервер</param>
        /// <param name="port">Порт</param>
        /// <param name="useSsl">Исользовать ли SSL</param>
        /// <param name="userEmail">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="AttachmentName">Имя вложения</param>
        /// <returns>Вложение</returns>
        public static bool GetAttachmentMsg(string hostname, int port, bool useSsl, string userEmail, string Password, string Subject, string AttachmentName)
        {
            try
            {
                using (Pop3Client client = new Pop3Client())
                {

                    client.Connect(hostname, port, useSsl);
                    client.Authenticate(userEmail, Password);

                    int messageCount = client.GetMessageCount();
                    List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

                    Regex rgx = new Regex(Subject, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

                    for (int i = 1; i <= messageCount; i++)
                    {
                        Match match = rgx.Match(client.GetMessage(i).Headers.Subject);
                        //проверяем тему письма, если та что нам надо,ищем вложение
                        if (match.Success)
                        {
                            foreach (MessagePart Attachment in client.GetMessage(i).FindAllAttachments())
                                if (Attachment.FileName == AttachmentName.Split('\\')[AttachmentName.Split('\\').Length - 1])
                                    return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.MesQuestion("Скорее всего превышено количество запросов");
                Log.MesQuestion(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Получаем текст из письма.
        /// </summary>
        /// <param name="hostname">Сервер</param>
        /// <param name="port">Порт</param>
        /// <param name="useSsl">Использовать SSL</param>
        /// <param name="userEmail">email на который стучимся</param>
        /// <param name="Password">пароль</param>
        /// <param name="Subject">Тема письма, которое нужно прочитать</param>
        /// <param name="isEqual">Признак абсолютного соответствия темы</param>
        /// <returns>текст письма</returns>
        public static string GetTextMsg(string hostname, int port, bool useSsl, string userEmail, string Password, string Subject, bool isEqual = false)
        {
            string text = "";
            try
            {
                using (

                    Pop3Client client = new Pop3Client())
                {
                
                    client.Connect(hostname, port, useSsl);
                    client.Authenticate(userEmail, Password);

                    int messageCount = client.GetMessageCount();
                    List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

                    Regex rgx = new Regex(Subject, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

                    for (int i = 1; i <= messageCount; i++)
                    {
                        Match match = rgx.Match(client.GetMessage(i).Headers.Subject);
                        string s = client.GetMessage(i).Headers.Subject;
                        //проверяем тему письма, если та что нам надо, добавляем письмо в список писем
                        if (isEqual)
                        {
                            if (client.GetMessage(i).Headers.Subject == Subject)
                                allMessages.Add(client.GetMessage(i));
                        }
                        else
                        {
                            if (match.Success)
                                allMessages.Add(client.GetMessage(i));
                        }
                    }

                    if (allMessages.Count != 0)
                    {
                        //если письмо типа текст
                        MessagePart plainText = allMessages[0].FindFirstPlainTextVersion();
                        if (plainText != null)
                        {
                            text = plainText.GetBodyAsText();
                        }

                        //если письмо типа HTML
                        MessagePart plainHTML = allMessages[0].FindFirstHtmlVersion();
                        if (plainHTML != null)
                        {
                            text = plainHTML.GetBodyAsText();
                        }
                    }
                    return text;
                }
            }
            catch (Exception ex)
            {
                Log.MesQuestion("Скорее всего превышено количество запросов");
                Log.MesQuestion(ex.Message);
                return "_";
            }
        }

        /// <summary>
        /// Получаем текст из первого письма.
        /// </summary>
        /// <param name="hostname">Сервер</param>
        /// <param name="port">Порт</param>
        /// <param name="useSsl">Использовать SSL</param>
        /// <param name="userEmail">email на который стучимся</param>
        /// <param name="Password">пароль</param>
        /// <returns>текст письма</returns>
        public static string GetYandexTextFirstMsg(string userEmail, string Password, string hostname = "pop.yandex.ru", int port = 995, bool useSsl = true)
        {
            if (userEmail.Contains("@"))
                userEmail = userEmail.Substring(0, userEmail.IndexOf("@"));

            string text = "";
            try
            {
                using (

                    Pop3Client client = new Pop3Client())
                {
                    client.Connect(hostname, port, useSsl);
                    client.Authenticate(userEmail, Password);
                    int messageCount = client.GetMessageCount();
                    Message msg = client.GetMessage(1);
                    if (messageCount != 0)
                    {
                        //если письмо типа текст
                        MessagePart plainText = msg.FindFirstPlainTextVersion();
                        if (plainText != null)
                        {
                            text = plainText.GetBodyAsText();
                        }
                    }
                    return text;
                }
            }
            catch (Exception ex)
            {
                Log.MesQuestion("Скорее всего превышено количество запросов");
                Log.MesQuestion(ex.Message);
                return "_";
            }
        }

        /// <summary>
        /// Получаем ссылку на КП из пригласительного письма. Используются дефолтные данные доступа - pop.yandex.ru, 110, логин от введенного Email (например, bx@bx.ru - логин bx), пароль yabxtest
        /// </summary>
        /// <param name="userEmail">email на который стучимся</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Subject">Тема письма, которое нужно прочитать</param>
        /// <returns>выпарсенная ссылка</returns>
        public static string GetYandexHttp(string userEmail, string Password, string Subject)
        {
            using (
                
                Pop3Client client = new Pop3Client())
            {
                client.Connect("pop.yandex.ru", 995, true);
                client.Authenticate(userEmail.Substring(0, userEmail.IndexOf("@")), Password);

                string readyHTTP = "";
                int messageCount = client.GetMessageCount();
                List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

                for (int i = 1; i <= messageCount; i++)
                {
                    //проверяем тему письма, если та что нам надо, добавляем письмо в список писем
                    if (client.GetMessage(i).Headers.Subject.IndexOf(Subject) >= 0)
                    allMessages.Add(client.GetMessage(i));
                }

                if (allMessages.Count != 0)
                {
                    //если письмо типа текст, то парсим текст
                    MessagePart plainText = allMessages[0].FindFirstPlainTextVersion();
                    if (plainText != null)
                    {
                        string input = plainText.GetBodyAsText();
                        Regex httpRx = new Regex(@"(https|http)://.*\r", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

                        Match matchHttp = httpRx.Match(input);
                        if (matchHttp.Success)
                        {
                            readyHTTP = matchHttp.Value;
                        }
                    }

                    //если письмо типа HTML
                    MessagePart plainHTML = allMessages[0].FindFirstHtmlVersion();
                    if (plainHTML != null)
                    {
                        string input = plainHTML.GetBodyAsText();
                        string HRefPattern = @"(?i)<\s*?a\s+[\S\s\x22\x27\x3d]*?href=[\x22\x27]?([^\s\x22\x27<>]+)[\x22\x27]?.*?>";
                        Match m;
                        m = Regex.Match(input, HRefPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        string workString = m.Groups[1].Value;

                        while (m.Success)
                        {
                            if (workString.IndexOf("/register/reg.php?code=") > 0)
                            {
                                readyHTTP = workString;
                                break;
                            }
                        }
                    }
                }
                return readyHTTP;
            }
        }

        /// <summary>
        /// Удаляет все письма с сервера.
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <param name="Server">POP3 сервер</param>
        /// <param name="Port">порт</param>
        /// <param name="UseSSL">использовать или нет SSL</param>
        public static void DeleteAllEmails(string Login, string Password, string Server, int Port, bool UseSSL)
        {
            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(Server, Port, UseSSL);
                client.Authenticate(Login, Password, AuthenticationMethod.UsernameAndPassword);
                try
                {
                    client.DeleteAllMessages();
                }
                catch (OpenPop.Pop3.Exceptions.PopServerException ex)
                {
                    Log.MesQuestion("Скорее всего превышено количество запросов");
                    Log.MesQuestion(ex.Message);
                }
            }
        }

        /// <summary>
        /// Удаляет все письма с сервера
        /// </summary>
        /// <param name="hostname">хост. Например, pop.yandex.ru</param>
        /// <param name="port">порт. Например, 110</param>
        /// <param name="username">логин</param>
        /// <param name="password">пароль</param>
        public static void DeleteAllEmails(string hostname, int port, string username, string password)
        {
            DeleteAllEmails(username, password, hostname, port, true);
        }

                /// <summary>
        /// Отправка письма на почтовый ящик
        /// </summary>
        /// <param name="Login">Адрес отправителя</param>
        /// <param name="Password">пароль к почтовому ящику отправителя</param>
        /// <param name="Serwer">Сервер</param>
        /// <param name="Port">Порт</param>
        /// <param name="UseSSL">Использовать SSL</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFiles">Присоединенные файлы</param>
        public static void SendMail(string Login, string Password, string Serwer, int Port, bool UseSSL, string mailto, string subject, string message, string[] attachFiles = null)
        {
            SendMail(Login, Password, Serwer, Port, UseSSL, new[] { mailto }, subject, message, attachFiles);
        }

        /// <summary>
        /// Отправка письма на почтовый ящик
        /// </summary>
        /// <param name="Login">Адрес отправителя</param>
        /// <param name="Password">пароль к почтовому ящику отправителя</param>
        /// <param name="Serwer">Сервер</param>
        /// <param name="Port">Порт</param>
        /// <param name="UseSSL">Использовать SSL</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFiles">Присоединенные файлы</param>
        public static void SendMail(string Login, string Password, string Serwer, int Port, bool UseSSL, string[] mailto, string subject, string message, string[] attachFiles = null)
        {
            using (SmtpClient client = new SmtpClient())
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(Login);
                foreach (string recipient in mailto)
                    mail.To.Add(new MailAddress(recipient));
                mail.Subject = subject;
                mail.Body = message;
                if (attachFiles != null)
                {
                    foreach(string attachFile in attachFiles)
                        mail.Attachments.Add(new Attachment(attachFile));
                }

                client.Host = Serwer;
                client.Port = Port;
                client.EnableSsl = UseSSL;
                client.Credentials = new NetworkCredential(Login, Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
        }

        /// <summary>
        /// Отправка письма на почтовый ящик
        /// </summary>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFiles">Присоединенные файлы</param>
        public static void SendMail(string from, string password, string mailto, string subject, string message, string[] attachFiles = null)
        {
            SendYandexMail(from, password, new[] { mailto }, subject, message, attachFiles);
        }

        /// <summary>
        /// Отправка письма на почтовый ящик
        /// </summary>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFiles">Присоединенные файлы</param>
        public static void SendYandexMail(string from, string password, string[] mailto, string subject, string message, string[] attachFiles = null)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(from);
                    foreach (string recipient in mailto)
                        mail.To.Add(new MailAddress(recipient));
                    mail.Subject = subject;
                    mail.Body = message;
                    if (attachFiles != null)
                    {
                        foreach (string attachFile in attachFiles)
                            mail.Attachments.Add(new Attachment(attachFile));
                    }

                    client.Host = "smtp.yandex.ru";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(from.Substring(0, from.IndexOf("@")), password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);
                    mail.Dispose();
                }
            }
            catch(Exception Ex)
            {
                Log.MesError("Вероятно роблемы на стороне smtp.yandex.ru. /r/n " + Ex.Message + "/r/n" + Ex.StackTrace);
            }
        }
    }
}
