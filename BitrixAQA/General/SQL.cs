using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BitrixAQA.Selenium.General;
using BitrixAQA.Selenium.Framework;
using MySql.Data.MySqlClient;

namespace BitrixAQA.General
{
    /// <summary>
    /// Класс работы с SQL
    /// </summary>
    class SQL
    {
        /// <summary>
        /// Для запросов к базе локальных установок КП и БУС: mysql, mssql, oracle
        /// </summary>
        public static string dbType = "";

        /// <summary>
        /// Метод возвращает имя базы текущей установки
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="dbType">Тип базы</param>
        /// <returns>Имя базы</returns>
        public static string GetDBname(string edition, string dbType)
        {
            string DBName = "";
            string fileName = Options.GetOption("/Options/PathToFolderWhereToInstall/edition[@title='" + edition + "']/" + dbType) + "\\bitrix\\php_interface\\dbconn.php";

            if (File.Exists(fileName) == true)
            {
                StreamReader streamReader = new StreamReader(fileName, Encoding.Default);
                string workText = streamReader.ReadToEnd();
                streamReader.Close();

                //смотрим, если тип базы Оракл
                string toReplaceDBType = @"^.*\$DBType = ""oracle"";.*$";

                if (Regex.IsMatch(workText, toReplaceDBType, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline))
                {
                    string toReplaceOracle = @"^.*\$DBLogin = ""([^""]*)"";.*$";
                    string replacement = @"${1}";

                    if (Regex.IsMatch(workText, toReplaceOracle, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        DBName = Regex.Replace(workText, toReplaceOracle, replacement, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    else
                    {
                        System.Windows.Forms.DialogResult result = MessageBox.Show("Невозможно получить имя базы отсюда \r\n" + fileName + "\r\n\r\n Выполнение теста прервано",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            Log.MesError("Невозможно получить имя базы для устаноки " + edition + "_" + dbType + "\r\nВыполнение теста прервано");
                            return null;
                        }
                    }
                }
                else
                {
                    string toReplace = @"^.*\$DBName = ""(.*)"";.*$";
                    string replacement = @"${1}";

                    if (Regex.IsMatch(workText, toReplace, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        DBName = Regex.Replace(workText, toReplace, replacement, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    else
                    {
                        System.Windows.Forms.DialogResult result = MessageBox.Show("Невозможно получить имя базы отсюда \r\n" + fileName + "\r\n\r\n Выполнение теста прервано",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            Log.MesError("Невозможно получить имя базы для устаноки " + edition + "_" + dbType + "\r\nВыполнение теста прервано");
                            return null;
                        }
                    }
                }
            }
            else
            {
                System.Windows.Forms.DialogResult result = MessageBox.Show("Не найден файл \r\n" + fileName + "\r\n\r\n Выполнение теста прервано",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Log.MesError("Не найден файл " + fileName + "\r\nВыполнение теста прервано");
                    return null;
                }
            }

            return DBName;
        }

        /// <summary>
        /// Метод возвращает пароль базы текущей установки
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="dbType">Тип базы</param>
        /// <returns>пароль от бд</returns>
        public static string GetDBPassword(string edition, string dbType)
        {
            string DBPassword = "";
            string fileName = Options.GetOption("/Options/PathToFolderWhereToInstall/edition[@title='" + edition + "']/" + dbType) + "\\bitrix\\php_interface\\dbconn.php";

            if (File.Exists(fileName) == true)
            {
                StreamReader streamReader = new StreamReader(fileName, Encoding.Default);
                string workText = streamReader.ReadToEnd();
                streamReader.Close();

                //смотрим, если тип базы Оракл
                string toReplaceDBType = @"^.*\$DBType = ""oracle"";.*$";

                if (Regex.IsMatch(workText, toReplaceDBType, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline))
                {
                    string toReplaceOracle = @"^.*\$DBPassword = ""([^""]*)"";.*$";
                    string replacement = @"${1}";

                    if (Regex.IsMatch(workText, toReplaceOracle, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        DBPassword = Regex.Replace(workText, toReplaceOracle, replacement, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    else
                    {
                        System.Windows.Forms.DialogResult result = MessageBox.Show("Невозможно получить пароль от базы отсюда \r\n" + fileName + "\r\n\r\n Выполнение теста прервано",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            Log.MesError("Невозможно получить пароль базы для устаноки " + edition + "_" + dbType + "\r\nВыполнение теста прервано");
                            return null;
                        }
                    }
                }
                else
                {
                    string toReplace = @"^.*\$DBPassword = ""(.*)"";.*$";
                    string replacement = @"${1}";

                    if (Regex.IsMatch(workText, toReplace, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        DBPassword = Regex.Replace(workText, toReplace, replacement, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    else
                    {
                        System.Windows.Forms.DialogResult result = MessageBox.Show("Невозможно получить имя базы отсюда \r\n" + fileName + "\r\n\r\n Выполнение теста прервано",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            Log.MesError("Невозможно получить имя базы для устаноки " + edition + "_" + dbType + "\r\nВыполнение теста прервано");
                            return null;
                        }
                    }
                }
            }
            else
            {
                System.Windows.Forms.DialogResult result = MessageBox.Show("Не найден файл \r\n" + fileName + "\r\n\r\n Выполнение теста прервано",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Log.MesError("Не найден файл " + fileName + "\r\nВыполнение теста прервано");
                    return null;
                }
            }

            return DBPassword;
        }

        /// <summary>
        /// Метод реализует выполнение SQL запросов к базе данных. Возвращает результат выполнения запроса
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="dbType">Тип базы данных</param>
        /// <param name="query">SQL запрос</param>
        /// <returns>Результат выполнения запроса</returns>
        public static string SQLQuery(string edition, string dbType, string query)
        {
            string result = "";

            switch (dbType)
            {
                case "mysql":
                    result = mysqlQuery(edition, dbType, query);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Возвращает результат sql запроса в виде двухмерного строкового массива
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="DBType">Тип базы</param>
        /// <param name="query">SQL запрос</param>
        /// <returns> Строковый массив с результатом запроса.</returns>
        public static string[,] mysqlQueryArray(string edition, string DBType, string query)
        {
            string ConnectionString = null;
            ConnectionString = "SERVER=" + Options.GetOption("/Options/ConnectionString/mysql") + ";" +
                       "port=" + Options.GetOption("/Options/ConnectionString/mysql_port") + ";" +
                       "DATABASE=" + GetDBname(edition, DBType) + ";" +
                       "UID=root;" +
                       "PASSWORD=;";

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            //Открываем sql соединение
            connection.Open();
            //Читаем результат выпонения запроса в reader
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            //Тут мы читаем ридер, чтобы узнать его глубину. Иначе никак.
            int i = 0;
            while (dataReader.Read())
                i++;
            //И полученную глубину ридера используем для задания размерности массива при его объявлении
            string[,] valuesList = new string[i, dataReader.FieldCount];
            //Закрываем ридер
            dataReader.Close();

            //Повторно считываем результат запроса, но теперь заносим его в проинициилизированый массив
            dataReader = command.ExecuteReader();
            i = 0;
            while (dataReader.Read())
            {
                for (int j = 0; j < dataReader.FieldCount; j++)
                    valuesList[i, j] = dataReader[j].ToString();
                i++;
            }
            //Закрываем ридер и соединение
            dataReader.Close();
            connection.Close();
            //Возвращаем наш массив
            return valuesList;
        }

        /// <summary>
        /// Метод реализует выполнение запросов к базе mysql
        /// </summary>
        /// <param name="edition">Редакция</param>
        /// <param name="DBType">Тип базы</param>
        /// <param name="query">SQL запрос</param>
        /// <returns>Результат выполнения запроса</returns>
        public static string mysqlQuery(string edition, string DBType, string query)
        {
            string result = null;
            string ConnectionString = null;
            ConnectionString = "SERVER=" + Options.GetOption("/Options/ConnectionString/mysql") + ";" +
                       "port=" + Options.GetOption("/Options/ConnectionString/mysql_port") + ";" +
                       "DATABASE=" + GetDBname(edition, DBType) + ";" +
                       "UID=root;" +
                       "PASSWORD=;";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    connection.Open();

                    var results = new List<string>();
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {
                        bool first = true;

                        while (Reader.Read())
                        {
                            var sb = new StringBuilder();
                            for (int i = 0; i < Reader.FieldCount; i++)
                                sb.AppendLine(Reader.GetValue(i).ToString());
                            results.Add(sb.ToString());

                            if (first)
                            {
                                result = Reader.GetValue(0).ToString();
                                first = false;
                            }
                        }
                    }

                    if (results.Count > 1)
                    {
                        string Return = null;
                        foreach (var r in results)
                            Return = Return + r + " ";
                        string spanID = DateTime.Now.Ticks.ToString();
                        Log.MesQuestion("<div style=\"margin: 0px 0px 0px 50px;\"><font size=\"2\" face=\"Verdana\"><a class=\"plus\"" +
                            " href=\"\" onclick=\"return collapse('" + spanID + "', this)\">" + "Результат выполнения запроса " + query + " содержит больше чем одно поле. Все поля: " +
                            " </a></font></div><br><span style=\"display:none;\" id=\"" + spanID + "\">" + Return);
                    }
                }
                connection.Close();
            }
            return result;
        }
    }
}
