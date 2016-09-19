using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using BitrixAQA.General;
using BitrixAQA.Selenium.General;
using BitrixAQA.Selenium.Test_Cases;
using System.Collections.Generic;
using System.Diagnostics;
using BitrixAQA.Selenium.Framework;

namespace BitrixAQA
{
    public partial class MainForm : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        
        /// <summary>
        /// главная форма
        /// </summary>
        public static MainForm form;

        /// <summary>
        /// лог
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="timeStamp">временная отметка</param>
        public delegate void LogDelegate(string text, bool timeStamp);

        /// <summary>
        /// Инициализируем главную форму
        /// </summary>
        /// <param name="args">аргументы прилдожения</param>
        public MainForm(string[] args = null)
        {
            //Инициализируем нашу форму. Отрисовываем все органы управления
            InitializeComponent();
            form = this;
            //Создаем экземляр формы настроек
            OptionsForm optionsForm = new OptionsForm();
            //По умолчанию выставляем браузер Firefox
            cbBrowsers.SelectedIndex = cbBrowsers.FindString("FireFox");
            //Обработчики
            tcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tc_TabSelect_Log);
            cbUrlsCheckPageOnErrors.CheckedChanged += new System.EventHandler(this.cbCheckUrl1_VisibleChild);
            cmbboxConnType.TextChanged += new System.EventHandler(this.cmbboxConnType_TextChanged);
            cmbboxConnType.TextChanged += new System.EventHandler(this.cmbboxConnType_TextChanged1);
            //Значение по умолчанию для типа подключения на закладке SQL
            cmbboxConnType.SelectedIndex = 0;
            //По умолчанию лог включен а DataGridView выключен
            dataGVResult.Visible = false;
            tbLog.Visible = true;
            //Дописываем последний лог в файл-архив
            if (File.Exists(Shared.StartupPath + "log.html"))
            {
                File.AppendAllText(Shared.StartupPath + "ArchiveLog.html", File.ReadAllText(Shared.StartupPath + "log.html"));
                File.Delete(Shared.StartupPath + "log.html");
            }

            //начинаем работу
            //выводим в лог информацию о запуске
            Log.PlainTextToHTMLLog("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
            Log.PlainTextToHTMLLog("<div style=\"margin: 50px 0px 0px 50px;\"></div>");
            Log.PlainTextToHTMLLog("<head><style>.plus, .minus { display: inline-block; padding-left: 20px;}.plus { background: url(plus.gif) no-repeat 5px 5px;} .minus { background: url(minus.gif) no-repeat 5px 5px; }</style><script>function collapse(id, link){var block = document.getElementById(id); if (block.style.display == \"none\"){block.style.display = \"block\";link.className = \"minus\";	}else{block.style.display = \"none\";link.className = \"plus\";}return false;}function collapseSpan(id, link){var block = document.getElementById(id);if (block.style.display == \"none\"){block.style.display = \"block\";}else{block.style.display =\"none\";}return false;}</script></head>");
            Log.MesNormal("============ новая сессия " + DateTime.Now + " ============", false);
            Log.Gap();

            //Читаем файл с настройками
            XmlDocument reader = new XmlDocument();
            reader.Load("options.xml");
            //Если файла с настройками нет, создадим пустой файл
            if (File.Exists("options.xml") == false)
                File.Create("options.xml");

            //Выводим на форму несколько параметров для урлчекера из файла с настройками
            MainForm.form.tbCheckUrlsUrlToCheck.Text = reader.GetValue("/Options/CheckUrls_options/url");
            MainForm.form.tbCheckUrlsLogin.Text = reader.GetValue("/Options/CheckUrls_options/login");
            MainForm.form.tbCheckUrlsPass.Text = reader.GetValue("/Options/CheckUrls_options/password");
        }

        /// <summary>
        /// Нажатие на кнопку запуска тестов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bDo_Click(object sender, EventArgs e)
        {

            var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var threads = new List<Thread>();
            //Отключаем перехват вызовов в ошибочном потоке
            //ToDo: сделать нормальную многопоточность для записи в лог на форме.
            Control.CheckForIllegalCrossThreadCalls = false;
            //проверка всех урлов сайта
            string address = null;
            if (tcMain.SelectedTab == tcMain.TabPages["tpVarious"] && cbCheckAllSite.Checked)
            {
                if (tbCheckUrlsUrlToCheck.Text != "")
                {
                    string[] siteList = tbCheckUrlsUrlToCheck.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int siteID = 0; siteID < siteList.Length; siteID++)
                    {
                        address = siteList[siteID];
                        threads.Add(new Thread(() => CheckUrls.Run(address.Trim())));
                    }
                }
                else
                    Log.MesError("Введите урл для проверки");
            }

            //проверка всех компонентов установки
            if (tcMain.SelectedTab == tcMain.TabPages["tpComponents"] && cbCheckAllComponents.Checked)
                threads.Add(new Thread(() => ComponentsTest.Run("BB", "mysql")));

            #region БУС
            //Для каждого из отмеченных тестов добавляем поток в пул потоков
            if (tcMain.SelectedTab == tcMain.TabPages["tpBUS"])
            {
                if (cbMainTest.Checked)
                    threads.Add(new Thread(() => Case_Main_Run.Run()));
                if (cbSaleTest.Checked)
                    threads.Add(new Thread(() => Case_Sale_Run.Run()));
            }
            #endregion
            //Запускаем потоки из пула
            foreach (var thread in threads)
            {
                thread.Start();
                thread.Join();
            }
            //Завершаем тест и закрываем браузер и связанные с ним сущности
            BitrixFramework.WebDriver.Quit();
        }


        #region Обработчики
        /// <summary>
        /// Обработчик прокрутки лога при добавлении записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            tbLog.SelectionStart = tbLog.Text.Length;
            tbLog.ScrollToCaret();
        }

        /// <summary>
        /// Обработчик открытия настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bOptions_Click(object sender, EventArgs e)
        {
            OptionsForm.form.ShowDialog();
        }

        /// <summary>
        /// Обработчик очистки лога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bClearLog_Click(object sender, EventArgs e)
        {
            tbLog.Text = "";
        }

        /// <summary>
        /// Обработчик открытия ссылки из лога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbLog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        /// <summary>
        /// обработчик переключения табконтрола. скрывает лог и открывает датагрид и наоборот
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tc_TabSelect_Log(object sender, TabControlEventArgs e)
        {
            if (tcMain.SelectedTab == tpSQL)
            {
                dataGVResult.Visible = true;
                tbLog.Visible = false;
            }
            else
            {
                dataGVResult.Visible = false;
                tbLog.Visible = true;
            }
        }

        /// <summary>
        /// Обработчик смены табконтрола. Блокирует\активирует контролы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbboxConnType_TextChanged1(object sender, EventArgs e)
        {

            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.Text == "Свои настроки")
            {
                cmbboxDBType.Enabled = true;
                rtextboxConnectionString.ReadOnly = false;
                btnSetConnSettings.Enabled = true;
            }
            else
            {
                cmbboxDBType.Enabled = false;
                rtextboxConnectionString.ReadOnly = true;
                btnSetConnSettings.Enabled = false;
            }
        }

        /// <summary>
        /// Обработчик видимости зависимых чекбоксов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCheckUrl1_VisibleChild(object sender, EventArgs e)
        {
            CheckBox senderCheckBox = (CheckBox)sender;
            cbCheckImages1.Visible = senderCheckBox.Checked;
        }

        /// <summary>
        /// Обработчик смены значения комбобокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbboxConnType_TextChanged(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            SQLExecutor.OnCmbChange(senderComboBox.Text);
        }
        #endregion

        /// <summary>
        /// Выполнить SQL скрипт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (SQLExecutor.ConnectionStringTest())
                SQLExecutor.Execute(rtextboxSQLQuery.Text);
            else
                MessageBox.Show("Нет соединения с базой данных.\r\nПроверьте строку подключения.", "Невозможно выполнить запрос.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Применить кастомные sql настрйоки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetConnSettings_Click(object sender, EventArgs e)
        {
            SQLExecutor.SetConnectionString();
            SQLExecutor.CheckConnection();
        }
    }
}
