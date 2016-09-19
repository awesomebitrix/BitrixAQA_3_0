using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace BitrixAQA.General
{
    /// <summary>
    /// Класс работы с файлом настроек
    /// </summary>
    class Options
    {
        /// <summary>
        /// Метод считывает все значения опций с формы OptionsForm и записывает в options.xml
        /// </summary>
        public static void OptionsWrite()
        {
            XmlWriterSettings settings = new XmlWriterSettings();

            // включаем отступ для элементов XML документа
            // (позволяет наглядно изобразить иерархию XML документа)
            settings.Indent = true;
            settings.IndentChars = "    "; // задаем отступ, здесь у меня 4 пробела

            // задаем переход на новую строку
            settings.NewLineChars = "\n";

            // Нужно ли опустить строку декларации формата XML документа
            // речь идет о строке вида "<?xml version="1.0" encoding="utf-8"?>"
            settings.OmitXmlDeclaration = false;

            using (XmlWriter output = XmlWriter.Create("options.xml", settings))
            {
                output.WriteStartElement("Options");
                #region Пути к установкам, куда будем распаковывать архивы дистров
                output.WriteStartElement("PathToFolderWhereToInstall");
                output.WriteStartElement("edition"); output.WriteAttributeString("title", "BB");
                output.WriteElementString("mysql", OptionsForm.form.tbPathBB_mysql.Text);
                output.WriteEndElement();
                output.WriteEndElement();
                #endregion

                #region Урлы установок
                output.WriteStartElement("URLS");
                output.WriteStartElement("edition"); output.WriteAttributeString("title", "BB");
                output.WriteElementString("mysql", OptionsForm.form.tbURL_BB_mysql.Text.Trim());
                output.WriteEndElement();
                output.WriteEndElement();
                #endregion

                #region строки подключения к базам
                output.WriteStartElement("ConnectionString");
                output.WriteElementString("mysql", OptionsForm.form.tbConString_mysql.Text.Trim());
                output.WriteElementString("mysql_port", OptionsForm.form.tbConString_mysql_port.Text.Trim());
                output.WriteEndElement();
                #endregion

                //данные последнего проверенного урла
                output.WriteStartElement("CheckUrls_options");
                output.WriteElementString("url", MainForm.form.tbCheckUrlsUrlToCheck.Text.Trim());
                output.WriteElementString("login", MainForm.form.tbCheckUrlsLogin.Text.Trim());
                output.WriteElementString("password", MainForm.form.tbCheckUrlsPass.Text.Trim());
                output.WriteEndElement();

                #region пользователи
                output.WriteStartElement("users");
                output.WriteStartElement("user"); output.WriteAttributeString("profile", "Admin");
                output.WriteElementString("Name", OptionsForm.form.tb_usr_Admin_Name.Text.Trim());
                output.WriteElementString("LastName", OptionsForm.form.tb_usr_Admin_LastName.Text.Trim());
                output.WriteElementString("Email", OptionsForm.form.tb_usr_Admin_Email.Text.Trim());
                output.WriteElementString("Login", OptionsForm.form.tb_usr_Admin_Login.Text.Trim());
                output.WriteElementString("Password", OptionsForm.form.tb_usr_Admin_Password.Text.Trim());
                output.WriteElementString("Avatar", OptionsForm.form.tb_usr_Admin_Ava.Text.Trim());
                output.WriteEndElement();
                output.WriteStartElement("user"); output.WriteAttributeString("profile", "Intra1");
                output.WriteElementString("Name", OptionsForm.form.tb_usr_Intra1_Name.Text.Trim());
                output.WriteElementString("LastName", OptionsForm.form.tb_usr_Intra1_LastName.Text.Trim());
                output.WriteElementString("Email", OptionsForm.form.tb_usr_Intra1_Email.Text.Trim());
                output.WriteElementString("Login", OptionsForm.form.tb_usr_Intra1_Login.Text.Trim());
                output.WriteElementString("Password", OptionsForm.form.tb_usr_Intra1_Password.Text.Trim());
                output.WriteElementString("Avatar", OptionsForm.form.tb_usr_Intra1_Ava.Text.Trim());
                output.WriteEndElement();
                output.WriteStartElement("user"); output.WriteAttributeString("profile", "Intra2");
                output.WriteElementString("Name", OptionsForm.form.tb_usr_Intra2_Name.Text.Trim());
                output.WriteElementString("LastName", OptionsForm.form.tb_usr_Intra2_LastName.Text.Trim());
                output.WriteElementString("Email", OptionsForm.form.tb_usr_Intra2_Email.Text.Trim());
                output.WriteElementString("Login", OptionsForm.form.tb_usr_Intra2_Login.Text.Trim());
                output.WriteElementString("Password", OptionsForm.form.tb_usr_Intra2_Password.Text.Trim());
                output.WriteElementString("Avatar", OptionsForm.form.tb_usr_Intra2_Ava.Text.Trim());
                output.WriteEndElement();
                output.WriteEndElement();
                #endregion

                output.WriteEndDocument();

                // Сбрасываем буферизированные данные
                output.Flush();
                // Закрываем файл, с которым связан output
                output.Close();
            }
        }

        /// <summary>
        /// Метод читает все опции из options.xml и записывает их в форму OptionsForm
        /// </summary>
        public static void OptionsRead()
        {
            XmlDocument reader = new XmlDocument();
            reader.Load("options.xml");

            if (File.Exists("options.xml") == false)
                File.Create("options.xml");

            #region Пути к установкам
            //пути к установкам BB
            foreach (XmlElement el in reader.DocumentElement.SelectNodes("/Options/PathToFolderWhereToInstall/edition[@title='BB']"))
            {
                OptionsForm.form.tbPathBB_mysql.Text = el.SelectSingleNode("mysql") != null ? el.SelectSingleNode("mysql").InnerText : "";
            }

            #endregion

            #region Урлы установок
            //BB
            foreach (XmlElement el in reader.DocumentElement.SelectNodes("/Options/URLS/edition[@title='BB']"))
            {
                OptionsForm.form.tbURL_BB_mysql.Text = el.SelectSingleNode("mysql") != null ? el.SelectSingleNode("mysql").InnerText : "";
            }

            #endregion

            //строки подключения к базам
            OptionsForm.form.tbConString_mysql.Text = reader.GetValue("/Options/ConnectionString/mysql");
            OptionsForm.form.tbConString_mysql_port.Text = reader.GetValue("/Options/ConnectionString/mysql_port");

            #region пользователи
            foreach (XmlElement el in reader.DocumentElement.SelectNodes("/Options/users/user[@profile='Admin']"))
            {
                OptionsForm.form.tb_usr_Admin_Name.Text = el.SelectSingleNode("Name").InnerText != "" ? el.SelectSingleNode("Name").InnerText : "";
                OptionsForm.form.tb_usr_Admin_LastName.Text = el.SelectSingleNode("LastName").InnerText != "" ? el.SelectSingleNode("LastName").InnerText : "";
                OptionsForm.form.tb_usr_Admin_Email.Text = el.SelectSingleNode("Email").InnerText != "" ? el.SelectSingleNode("Email").InnerText : "";
                OptionsForm.form.tb_usr_Admin_Login.Text = el.SelectSingleNode("Login").InnerText != "" ? el.SelectSingleNode("Login").InnerText : "admin";
                OptionsForm.form.tb_usr_Admin_Password.Text = el.SelectSingleNode("Password").InnerText != "" ? el.SelectSingleNode("Password").InnerText : "111111";
                OptionsForm.form.tb_usr_Admin_Ava.Text = el.SelectSingleNode("Avatar").InnerText != "" ? el.SelectSingleNode("Avatar").InnerText : "";
            }
            foreach (XmlElement el in reader.DocumentElement.SelectNodes("/Options/users/user[@profile='Intra1']"))
            {
                OptionsForm.form.tb_usr_Intra1_Name.Text = el.SelectSingleNode("Name").InnerText != "" ? el.SelectSingleNode("Name").InnerText : "Семен";
                OptionsForm.form.tb_usr_Intra1_LastName.Text = el.SelectSingleNode("LastName").InnerText != "" ? el.SelectSingleNode("LastName").InnerText : "Синичкин";
                OptionsForm.form.tb_usr_Intra1_Email.Text = el.SelectSingleNode("Email").InnerText != "" ? el.SelectSingleNode("Email").InnerText : "";
                OptionsForm.form.tb_usr_Intra1_Login.Text = el.SelectSingleNode("Login").InnerText != "" ? el.SelectSingleNode("Login").InnerText : "semen";
                OptionsForm.form.tb_usr_Intra1_Password.Text = el.SelectSingleNode("Password").InnerText != "" ? el.SelectSingleNode("Password").InnerText : "111111";
                OptionsForm.form.tb_usr_Intra1_Ava.Text = el.SelectSingleNode("Avatar").InnerText != "" ? el.SelectSingleNode("Avatar").InnerText : "avatar_semen.jpg";
            }
            foreach (XmlElement el in reader.DocumentElement.SelectNodes("/Options/users/user[@profile='Intra2']"))
            {
                OptionsForm.form.tb_usr_Intra2_Name.Text = el.SelectSingleNode("Name").InnerText != "" ? el.SelectSingleNode("Name").InnerText : "Иван";
                OptionsForm.form.tb_usr_Intra2_LastName.Text = el.SelectSingleNode("LastName").InnerText != "" ? el.SelectSingleNode("LastName").InnerText : "Иванов";
                OptionsForm.form.tb_usr_Intra2_Email.Text = el.SelectSingleNode("Email").InnerText != "" ? el.SelectSingleNode("Email").InnerText : "";
                OptionsForm.form.tb_usr_Intra2_Login.Text = el.SelectSingleNode("Login").InnerText != "" ? el.SelectSingleNode("Login").InnerText : "ivan";
                OptionsForm.form.tb_usr_Intra2_Password.Text = el.SelectSingleNode("Password").InnerText != "" ? el.SelectSingleNode("Password").InnerText : "111111";
                OptionsForm.form.tb_usr_Intra2_Ava.Text = el.SelectSingleNode("Avatar").InnerText != "" ? el.SelectSingleNode("Avatar").InnerText : "avatar_ivan.jpg";
            }
            #endregion

            //последний проверенный урл
            MainForm.form.tbCheckUrlsUrlToCheck.Text = reader.GetValue("/Options/CheckUrls_options/url");
            MainForm.form.tbCheckUrlsLogin.Text = reader.GetValue("/Options/CheckUrls_options/login");
            MainForm.form.tbCheckUrlsPass.Text = reader.GetValue("/Options/CheckUrls_options/password");
        }

        /// <summary>
        /// Метод получает значение опции из файла options.xml
        /// </summary>
        /// <param name="Node">Путь к опции в формате XPath</param>
        /// <param name="NoSignal">Оключение логирования об ошибке</param>
        /// <returns>Значение опции</returns>
        public static string GetOption(string Node, bool NoSignal = false)
        {
            XmlDocument reader = new XmlDocument();
            reader.Load("options.xml");
            //Мало ли кто укажет лишнюю / в конце пути до ноды
            if (Node.Substring(Node.Length - 1, 1) == "/")
                Node = Node.Substring(0, Node.Length - 1);

            XmlNode node = reader.DocumentElement.SelectSingleNode(Node);
            if (node == null)
            {
                if(!NoSignal)
                    Log.MesError("Такой опции не существует " + Node);
                return "";
            }

            return node.InnerText;
        }
    }

    /// <summary>
    /// Класс работы с опциями
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Метод возвращает значение опции из xml файла. Если опция не найдена вернется пустая строка
        /// </summary>
        /// <param name="doc">Документ XML</param>
        /// <param name="xpath">путь к ноде в формате xpath</param>
        /// <returns>значение опции</returns>
        public static string GetValue(this XmlDocument doc, string xpath)
        {
            if (doc.DocumentElement.SelectSingleNode(xpath) != null)
                return doc.SelectSingleNode(xpath).InnerText;
            else
                return "";
        }
    }
}
