using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BitrixAQA.Selenium.General;
using MySql.Data.MySqlClient;

namespace BitrixAQA.General
{
    /// <summary>
    /// Класс для работы с SQL запросами из интерфейса автотеста
    /// </summary>
    class SQLExecutor
    {
        static string ConnectionType = "Custom";
        static string ConnectionString = "";
        static string DBType = "";
        static System.Collections.Generic.List<Tuple<CheckBox, string, string>> baseToInstall = new System.Collections.Generic.List<Tuple<CheckBox, string, string>>();

        /// <summary>
        /// Обработчик изменения значения комбобокса
        /// </summary>
        /// <param name="cmbValue">Значение</param>
        public static void OnCmbChange(string cmbValue)
        {
            switch (cmbValue)
            {
                case "Свои настроки": ConnectionType = "Custom"; break;
                default: ConnectionType = "Settings"; break;
            }
            SetConnectionString();
            FillConnectionInfo();
            CheckConnection();
        }

        /// <summary>
        /// Формируем ConnectionString
        /// </summary>
        public static void SetConnectionString()
        {
            switch (ConnectionType)
            {
                case "Custom": ConnectionString = GetCustomConnectionString(); break;
                default: break;
            }
        }

        /// <summary>
        /// Заполняем параметры кастомного соединения с формы
        /// </summary>
        /// <returns></returns>
        private static string GetCustomConnectionString()
        {
            DBType = MainForm.form.cmbboxDBType.Text;
            return MainForm.form.rtextboxConnectionString.Text;
        }

        /// <summary>
        /// Заполняем инфо о подключении к БД на форму
        /// </summary>
        public static void FillConnectionInfo()
        {
            if (DBType == "MYSQL")
                MainForm.form.cmbboxDBType.SelectedIndex = 0;
            MainForm.form.rtextboxConnectionString.Text = ConnectionString;
        }

        /// <summary>
        /// Проверяем подключение к БД и пишем об этом на форму
        /// </summary>
        /// <returns></returns>
        public static bool CheckConnection()
        {
            if (ConnectionStringTest())
            {
                MainForm.form.lblConnStatus.Text = "Соединение с БД успешно";
                MainForm.form.lblConnStatus.ForeColor= System.Drawing.Color.Green;
                return true;
            }
            else
            {
                MainForm.form.lblConnStatus.Text = "Нет соединения с БД. Проверьте параметры";
                MainForm.form.lblConnStatus.ForeColor = System.Drawing.Color.Red;
                return false;
            }
        }

        /// <summary>
        /// Тестовое подключение и отключение используя сформированный ConnectionString
        /// </summary>
        /// <returns></returns>
        public static bool ConnectionStringTest()
        {
            bool Connect = false;
            try
            {
                if (DBType == "MYSQL")
                {
                    MySqlConnection Connection = new MySqlConnection(ConnectionString);
                    Connection.Open();
                    Connection.Close();
                }
                else
                    return false;
                Connect = true;
            }
            catch (Exception)
            {
                Connect = false;
            }
            return Connect;
        }

        /// <summary>
        /// Выполняем sql запрос
        /// </summary>
        /// <param name="Query">тело запроса</param>
        public static void Execute(string Query)
        {
            switch (DBType)
            {
                case "MYSQL": ExecuteMYSQL(Query); break;
                default: MessageBox.Show("Неверный тип БД.\r\n\nСтранная проблема.\r\nНет типа БД, или он работает некорректно.\r\n\nСообщить автору.", "Грусть и печаль"); break;
            }
        }

        /// <summary>
        /// Выполняем MYSQL запрос
        /// </summary>
        /// <param name="Query">запрос</param>
        public static void ExecuteMYSQL(string Query)
        {
            try
            {
                MySqlConnection Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Query, Connection);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                MainForm.form.dataGVResult.DataSource = table;
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выполнении запрса возникли ошибки.\r\nПроверьте правильность запроса.\r\n\n " + ex.Message, "Запрос не выполнен.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выполняем MSSQL запрос
        /// </summary>
        /// <param name="Query">запрос</param>
        public static void ExecuteMSSQL(string Query)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, Connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                MainForm.form.dataGVResult.DataSource = table;
                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выполнении запроса возникли ошибки.\r\nПроверьте правильность запроса.\r\n\n " + ex.Message, "Запрос не выполнен.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
