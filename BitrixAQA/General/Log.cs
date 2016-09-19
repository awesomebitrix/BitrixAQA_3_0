using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using BitrixAQA.Selenium.General;

namespace BitrixAQA.General
{
    /// <summary>
    /// Класс с методами для работы с логом
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Путь к директории программы
        /// </summary>
        public static readonly string ExecutablePath = Assembly.GetExecutingAssembly().Location;
        /// <summary>
        /// Путь для лога
        /// </summary>
        public static readonly string StartupPath = Path.GetDirectoryName(ExecutablePath) + Path.DirectorySeparatorChar;

        /// <summary>
        /// Тип сообщения
        /// </summary>
        public enum setMessageType 
        { 
            /// <summary>
            /// нормальный
            /// </summary>
            normal, 
            /// <summary>
            /// ошибка
            /// </summary>
            error, 
            /// <summary>
            /// успешно
            /// </summary>
            pass, 
            /// <summary>
            /// вопрос
            /// </summary>
            question,
            /// <summary>
            /// длинная js ошибка
            /// </summary>
            longJSerror
        };

        /// <summary>
        /// Метод пишет текст в лог, в форму и в файл log.log. Запись времени опциональна
        /// </summary>
        /// <param name="mType">Тип Сообщения</param>
        /// <param name="text">Текст, который будет записан в лог</param>
        /// <param name="addTimeStamp">Добавить дату и время к записи, true - добавить, false - не добавлять</param>
        private static void Add(setMessageType mType, string text, bool addTimeStamp = true)
        {
            string textToWrite = 
                addTimeStamp == true ?
                String.Format("[{0}]   {1} \r\n", DateTime.Now.ToString("HH:mm:ss"), text) : 
                String.Format("                                      {0}\r\n ", text);

            string textToHTML = textToWrite;
            System.Drawing.Color Color = System.Drawing.Color.Black;
            switch (mType)
            {
                case setMessageType.normal:
                    Color = System.Drawing.Color.Black;
                    textToHTML = "<font size=\"2\" face=\"Verdana\">" + textToWrite + "</font>";
                    break;
                case setMessageType.error:
                    Color = System.Drawing.Color.Red;
                    textToHTML = "<font size=\"2\" face=\"Verdana\" color=\"red\">" + textToWrite + "</font><br/><a href=\"" + ScreenCapture.Printscreen() + "\" target=\"_blank\">скриншот</a><br/><br/>";
                    textToWrite += "\r\n" + "file:/" + StartupPath + ScreenCapture.Printscreen().Replace("/", "\\") + " \r\n\r\n";
                    break;
                case setMessageType.pass:
                    Color = System.Drawing.Color.Green;
                    textToHTML = "<font size=\"2\" face=\"Verdana\" color=\"green\">" + textToWrite + "</font>";
                    break;
                case setMessageType.question:
                    Color = System.Drawing.Color.Goldenrod;
                    textToHTML = "<font size=\"2\" face=\"Verdana\" color=\"goldenrod\">" + textToWrite + "</font>";
                    break;
                case setMessageType.longJSerror:
                    string spanID = DateTime.Now.Ticks.ToString();
                    Log.MesError("<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\"" +
                    " href=\"\" onclick=\"return collapse('" + spanID + "', this)\">" + textToWrite + "-> JS ошибка </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" +
                    text + "</span>");
                    break;
            }

                MainForm.form.tbLog.SelectionColor = Color;
                MainForm.form.tbLog.AppendText(textToWrite);
                MainForm.form.tbLog.Refresh();

            File.AppendAllText(StartupPath + "log.html", "<pre style=\"margin: 0px 0px 0px 50px;\">" + textToHTML + "</pre>", Encoding.UTF8);
        }

        #region Типы сообщений
        /// <summary>
        /// Запись в лог с типом нормальный текст, запись времени опциональна
        /// </summary>
        /// <param name="text">Текст, который будет записан в лог</param>
        /// <param name="addTimeStamp">Добавить дату и время к записи, true - добавить, false - не добавлять</param>
        public static void MesNormal(string text, bool addTimeStamp = true)
        {
            Add(Log.setMessageType.normal, text, addTimeStamp);
        }

        /// <summary>
        /// Запись в лог с типом ошибка, запись времени опциональна
        /// </summary>
        /// <param name="text">Текст, который будет записан в лог</param>
        /// <param name="addTimeStamp">Добавить дату и время к записи, true - добавить, false - не добавлять</param>
        public static void MesError(string text, bool addTimeStamp=true)
        {
            Add(Log.setMessageType.error, text, addTimeStamp);
        }

        /// <summary>
        /// Запись в лог с типом ошибка, запись времени опциональна
        /// </summary>
        /// <param name="text">Текст, который будет записан в лог</param>
        /// <param name="addTimeStamp">Добавить дату и время к записи, true - добавить, false - не добавлять</param>
        public static void MesLongError(string text, bool addTimeStamp = true)
        {
            Add(Log.setMessageType.longJSerror, text, addTimeStamp);
        }

        /// <summary>
        /// Запись в лог с типом успешно, запись времени опциональна
        /// </summary>
        /// <param name="text">Текст, который будет записан в лог</param>
        /// <param name="addTimeStamp">Добавить дату и время к записи, true - добавить, false - не добавлять</param>
        public static void MesPass(string text, bool addTimeStamp = true)
        {
            Add(Log.setMessageType.pass, text, addTimeStamp);
        }

        /// <summary>
        /// Запись в лог с типом вопрос, запись времени опциональна
        /// </summary>
        /// <param name="text">Текст, который будет записан в лог</param>
        /// <param name="addTimeStamp">Добавить дату и время к записи, true - добавить, false - не добавлять</param>
        public static void MesQuestion(string text, bool addTimeStamp = true)
        {
            Add(Log.setMessageType.question, text, addTimeStamp);
        }

        /// <summary>
        /// Запись в лог с типом заданный, запись времени опциональна
        /// </summary>
        /// <param name="text">Текст, который будет записан в лог</param>
        /// <param name="addTimeStamp">Добавить дату и время к записи, true - добавить, false - не добавлять</param>
        /// <param name="color">Цвет текста</param>
        public static void MesCustom(string text, Color color, bool addTimeStamp = true)
        {
            string textToWrite = String.Format("[{0}]   {1} \r\n", DateTime.Now.ToString("HH:mm:ss"), text);
            string textToHTML = textToWrite;
            
            MainForm.form.tbLog.SelectionColor = color;
            textToHTML = "<font size=\"2\" face=\"Verdana\" color=\"" + ColorTranslator.ToHtml(color) + "\">" + text + "</font>";

            MainForm.form.tbLog.AppendText(textToWrite);
            MainForm.form.tbLog.Refresh();

            File.AppendAllText(StartupPath + "log.html", "<pre style=\"margin: 0px 0px 0px 50px;\">" + textToHTML + "</pre>", Encoding.UTF8);
        }
        #endregion

        /// <summary>
        /// Добавляет в лог HTML открывающую ноду - контейнер, в который будет помещен весь нижеидущий текст. По умолчанию контейнер открытый
        /// </summary>
        /// <param name="nodeCaption">Название контейнера, которое будет выводится в логе</param>
        /// <param name="collapsed">Скрытый или открытый контейнер. true - открытый, false - скрытый</param>
        public static void NodeOpen(string nodeCaption, bool collapsed = true)
        {
            string spanID = DateTime.Now.Ticks.ToString();

            if (collapsed)
                Log.PlainTextToHTMLLog("<div style=\"margin: 7px 0px 0px 46px;\"><font size=\"2\" face=\"Verdana\"> <a class=\"minus\" href=\"\" onclick=\"return collapse('" +
                spanID + "', this)\">" + nodeCaption + "</a></font></div><br><span id=\"" + spanID + "\">"); //ondblclick=\"return collapseSpan('" + spanID + "', this)\"
            else
                Log.PlainTextToHTMLLog("<div style=\"margin: 7px 0px 0px 46px;\"><font size=\"2\" face=\"Verdana\"> <a class=\"plus\" href=\"\" onclick=\"return collapse('" +
                    spanID + "', this)\">" + nodeCaption + "</a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">"); //ondblclick=\"return collapseSpan('" + spanID + "', this)\"
        }

        /// <summary>
        /// Закрываем ноду
        /// </summary>
        public static void NodeClose()
        {
            Log.PlainTextToHTMLLog("</span>");
        }

        /// <summary>
        /// Пустая строка в лог
        /// </summary>
        public static void Gap()
        {
            MainForm.form.tbLog.AppendText("\r\n");
            MainForm.form.tbLog.Refresh();
            File.AppendAllText(StartupPath + "log.html", "<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\" color=\"black\">&emsp;</font></div>");
        }

        /// <summary>
        /// Запись только в лог-файл log.html без какого либо html или иного форматирования
        /// </summary>
        /// <param name="text">Текст</param>
        public static void PlainTextToHTMLLog(string text)
        {
            File.AppendAllText(StartupPath + "log.html", text);
        }

       
    }
}
