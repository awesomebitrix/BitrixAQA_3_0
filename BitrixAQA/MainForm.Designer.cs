namespace BitrixAQA
{
    /// <summary>
    /// Главная форма
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bDo = new System.Windows.Forms.Button();
            this.bOptions = new System.Windows.Forms.Button();
            this.cbCheckAllSite = new System.Windows.Forms.CheckBox();
            this.tbCheckUrlsUrlToCheck = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bClearLog = new System.Windows.Forms.Button();
            this.cbBrowsers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCheckUrlsLogin = new System.Windows.Forms.TextBox();
            this.tbCheckUrlsPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUrlsCheckPageOnErrors = new System.Windows.Forms.CheckBox();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpBUS = new System.Windows.Forms.TabPage();
            this.cbSaleTest = new System.Windows.Forms.CheckBox();
            this.cbMainTest = new System.Windows.Forms.CheckBox();
            this.tpVarious = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCheckImages1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCheckOnce = new System.Windows.Forms.TextBox();
            this.tpSQL = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.lblConnStatusTitle = new System.Windows.Forms.Label();
            this.lblConnType = new System.Windows.Forms.Label();
            this.cmbboxConnType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.lblDBType = new System.Windows.Forms.Label();
            this.btnSetConnSettings = new System.Windows.Forms.Button();
            this.rtextboxConnectionString = new System.Windows.Forms.RichTextBox();
            this.cmbboxDBType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.rtextboxSQLQuery = new System.Windows.Forms.RichTextBox();
            this.tpComponents = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbComponentsCheckPrefix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCheckComponentsLogin = new System.Windows.Forms.TextBox();
            this.tbCheckComponentsPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCheckAllComponents = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbComponentsCheckPageOnErrors = new System.Windows.Forms.CheckBox();
            this.dataGVResult = new System.Windows.Forms.DataGridView();
            this.tcMain.SuspendLayout();
            this.tpBUS.SuspendLayout();
            this.tpVarious.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpSQL.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tpComponents.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVResult)).BeginInit();
            this.SuspendLayout();
            // 
            // bDo
            // 
            this.bDo.Location = new System.Drawing.Point(4, 87);
            this.bDo.Name = "bDo";
            this.bDo.Size = new System.Drawing.Size(75, 23);
            this.bDo.TabIndex = 0;
            this.bDo.Text = "Делать";
            this.bDo.UseVisualStyleBackColor = true;
            this.bDo.Click += new System.EventHandler(this.bDo_Click);
            // 
            // bOptions
            // 
            this.bOptions.Location = new System.Drawing.Point(4, 116);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(75, 23);
            this.bOptions.TabIndex = 2;
            this.bOptions.Text = "Настройки";
            this.bOptions.UseVisualStyleBackColor = true;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // cbCheckAllSite
            // 
            this.cbCheckAllSite.AutoSize = true;
            this.cbCheckAllSite.Location = new System.Drawing.Point(11, 19);
            this.cbCheckAllSite.Name = "cbCheckAllSite";
            this.cbCheckAllSite.Size = new System.Drawing.Size(125, 17);
            this.cbCheckAllSite.TabIndex = 25;
            this.cbCheckAllSite.Text = "Пройти все ссылки";
            this.cbCheckAllSite.UseVisualStyleBackColor = true;
            // 
            // tbCheckUrlsUrlToCheck
            // 
            this.tbCheckUrlsUrlToCheck.Location = new System.Drawing.Point(41, 43);
            this.tbCheckUrlsUrlToCheck.Multiline = true;
            this.tbCheckUrlsUrlToCheck.Name = "tbCheckUrlsUrlToCheck";
            this.tbCheckUrlsUrlToCheck.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCheckUrlsUrlToCheck.Size = new System.Drawing.Size(344, 65);
            this.tbCheckUrlsUrlToCheck.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Урл";
            // 
            // bClearLog
            // 
            this.bClearLog.Location = new System.Drawing.Point(1069, 391);
            this.bClearLog.Name = "bClearLog";
            this.bClearLog.Size = new System.Drawing.Size(83, 23);
            this.bClearLog.TabIndex = 25;
            this.bClearLog.Text = "Очистить лог";
            this.bClearLog.UseVisualStyleBackColor = true;
            this.bClearLog.Click += new System.EventHandler(this.bClearLog_Click);
            // 
            // cbBrowsers
            // 
            this.cbBrowsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrowsers.FormattingEnabled = true;
            this.cbBrowsers.Items.AddRange(new object[] {
            "FireFox",
            "IE",
            "Chrome"});
            this.cbBrowsers.Location = new System.Drawing.Point(4, 38);
            this.cbBrowsers.Name = "cbBrowsers";
            this.cbBrowsers.Size = new System.Drawing.Size(120, 21);
            this.cbBrowsers.TabIndex = 260;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 270;
            this.label3.Text = "Браузер";
            // 
            // tbCheckUrlsLogin
            // 
            this.tbCheckUrlsLogin.Location = new System.Drawing.Point(41, 127);
            this.tbCheckUrlsLogin.Name = "tbCheckUrlsLogin";
            this.tbCheckUrlsLogin.Size = new System.Drawing.Size(131, 20);
            this.tbCheckUrlsLogin.TabIndex = 28;
            // 
            // tbCheckUrlsPass
            // 
            this.tbCheckUrlsPass.Location = new System.Drawing.Point(229, 127);
            this.tbCheckUrlsPass.Name = "tbCheckUrlsPass";
            this.tbCheckUrlsPass.Size = new System.Drawing.Size(78, 20);
            this.tbCheckUrlsPass.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "логин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "пароль";
            // 
            // cbUrlsCheckPageOnErrors
            // 
            this.cbUrlsCheckPageOnErrors.AutoSize = true;
            this.cbUrlsCheckPageOnErrors.Checked = true;
            this.cbUrlsCheckPageOnErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUrlsCheckPageOnErrors.Location = new System.Drawing.Point(142, 19);
            this.cbUrlsCheckPageOnErrors.Name = "cbUrlsCheckPageOnErrors";
            this.cbUrlsCheckPageOnErrors.Size = new System.Drawing.Size(130, 17);
            this.cbUrlsCheckPageOnErrors.TabIndex = 26;
            this.cbUrlsCheckPageOnErrors.Text = "Проверять страницу";
            this.cbUrlsCheckPageOnErrors.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(0, 448);
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(1158, 313);
            this.tbLog.TabIndex = 272;
            this.tbLog.Text = "";
            this.tbLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbLog_LinkClicked);
            this.tbLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // tcMain
            // 
            this.tcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcMain.Controls.Add(this.tpBUS);
            this.tcMain.Controls.Add(this.tpVarious);
            this.tcMain.Controls.Add(this.tpSQL);
            this.tcMain.Controls.Add(this.tpComponents);
            this.tcMain.Location = new System.Drawing.Point(141, 10);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(889, 432);
            this.tcMain.TabIndex = 273;
            // 
            // tpBUS
            // 
            this.tpBUS.Controls.Add(this.cbSaleTest);
            this.tpBUS.Controls.Add(this.cbMainTest);
            this.tpBUS.Location = new System.Drawing.Point(4, 25);
            this.tpBUS.Name = "tpBUS";
            this.tpBUS.Size = new System.Drawing.Size(881, 403);
            this.tpBUS.TabIndex = 3;
            this.tpBUS.Text = "БУС";
            this.tpBUS.UseVisualStyleBackColor = true;
            // 
            // cbSaleTest
            // 
            this.cbSaleTest.AutoSize = true;
            this.cbSaleTest.Location = new System.Drawing.Point(24, 51);
            this.cbSaleTest.Name = "cbSaleTest";
            this.cbSaleTest.Size = new System.Drawing.Size(134, 17);
            this.cbSaleTest.TabIndex = 282;
            this.cbSaleTest.Text = "Демо-Тест магазина";
            this.cbSaleTest.UseVisualStyleBackColor = true;
            // 
            // cbMainTest
            // 
            this.cbMainTest.AutoSize = true;
            this.cbMainTest.Location = new System.Drawing.Point(24, 28);
            this.cbMainTest.Name = "cbMainTest";
            this.cbMainTest.Size = new System.Drawing.Size(171, 17);
            this.cbMainTest.TabIndex = 281;
            this.cbMainTest.Text = "Демо-Тест главного модуля";
            this.cbMainTest.UseVisualStyleBackColor = true;
            // 
            // tpVarious
            // 
            this.tpVarious.Controls.Add(this.groupBox2);
            this.tpVarious.Location = new System.Drawing.Point(4, 25);
            this.tpVarious.Name = "tpVarious";
            this.tpVarious.Padding = new System.Windows.Forms.Padding(3);
            this.tpVarious.Size = new System.Drawing.Size(881, 403);
            this.tpVarious.TabIndex = 1;
            this.tpVarious.Text = "Урлчекер";
            this.tpVarious.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCheckImages1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbCheckUrlsLogin);
            this.groupBox2.Controls.Add(this.tbCheckUrlsPass);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbCheckOnce);
            this.groupBox2.Controls.Add(this.cbCheckAllSite);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbCheckUrlsUrlToCheck);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbUrlsCheckPageOnErrors);
            this.groupBox2.Location = new System.Drawing.Point(6, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 311);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Проверить все урлы";
            // 
            // cbCheckImages1
            // 
            this.cbCheckImages1.AutoSize = true;
            this.cbCheckImages1.Location = new System.Drawing.Point(274, 19);
            this.cbCheckImages1.Name = "cbCheckImages1";
            this.cbCheckImages1.Size = new System.Drawing.Size(74, 17);
            this.cbCheckImages1.TabIndex = 37;
            this.cbCheckImages1.Text = "Картинки";
            this.cbCheckImages1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Зайти один раз";
            // 
            // tbCheckOnce
            // 
            this.tbCheckOnce.Location = new System.Drawing.Point(11, 191);
            this.tbCheckOnce.Multiline = true;
            this.tbCheckOnce.Name = "tbCheckOnce";
            this.tbCheckOnce.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCheckOnce.Size = new System.Drawing.Size(374, 102);
            this.tbCheckOnce.TabIndex = 27;
            // 
            // tpSQL
            // 
            this.tpSQL.Controls.Add(this.groupBox6);
            this.tpSQL.Controls.Add(this.groupBox5);
            this.tpSQL.Controls.Add(this.groupBox4);
            this.tpSQL.Location = new System.Drawing.Point(4, 25);
            this.tpSQL.Name = "tpSQL";
            this.tpSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tpSQL.Size = new System.Drawing.Size(881, 403);
            this.tpSQL.TabIndex = 4;
            this.tpSQL.Text = "SQL";
            this.tpSQL.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblConnStatus);
            this.groupBox6.Controls.Add(this.lblConnStatusTitle);
            this.groupBox6.Controls.Add(this.lblConnType);
            this.groupBox6.Controls.Add(this.cmbboxConnType);
            this.groupBox6.Location = new System.Drawing.Point(6, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(387, 50);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.Location = new System.Drawing.Point(149, 28);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(0, 13);
            this.lblConnStatus.TabIndex = 6;
            // 
            // lblConnStatusTitle
            // 
            this.lblConnStatusTitle.AutoSize = true;
            this.lblConnStatusTitle.Location = new System.Drawing.Point(149, 12);
            this.lblConnStatusTitle.Name = "lblConnStatusTitle";
            this.lblConnStatusTitle.Size = new System.Drawing.Size(131, 13);
            this.lblConnStatusTitle.TabIndex = 5;
            this.lblConnStatusTitle.Text = "Состояние подключения";
            // 
            // lblConnType
            // 
            this.lblConnType.AutoSize = true;
            this.lblConnType.Location = new System.Drawing.Point(11, 10);
            this.lblConnType.Name = "lblConnType";
            this.lblConnType.Size = new System.Drawing.Size(96, 13);
            this.lblConnType.TabIndex = 4;
            this.lblConnType.Text = "Тип подключения";
            // 
            // cmbboxConnType
            // 
            this.cmbboxConnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbboxConnType.FormattingEnabled = true;
            this.cmbboxConnType.Items.AddRange(new object[] {
            "Свои настроки"});
            this.cmbboxConnType.Location = new System.Drawing.Point(11, 25);
            this.cmbboxConnType.Name = "cmbboxConnType";
            this.cmbboxConnType.Size = new System.Drawing.Size(135, 21);
            this.cmbboxConnType.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblConnectionString);
            this.groupBox5.Controls.Add(this.lblDBType);
            this.groupBox5.Controls.Add(this.btnSetConnSettings);
            this.groupBox5.Controls.Add(this.rtextboxConnectionString);
            this.groupBox5.Controls.Add(this.cmbboxDBType);
            this.groupBox5.Location = new System.Drawing.Point(6, 52);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(388, 176);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.Location = new System.Drawing.Point(8, 53);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(84, 39);
            this.lblConnectionString.TabIndex = 12;
            this.lblConnectionString.Text = "Строка подключения";
            // 
            // lblDBType
            // 
            this.lblDBType.AutoSize = true;
            this.lblDBType.Location = new System.Drawing.Point(8, 22);
            this.lblDBType.Name = "lblDBType";
            this.lblDBType.Size = new System.Drawing.Size(45, 13);
            this.lblDBType.TabIndex = 11;
            this.lblDBType.Text = "Тип БД";
            // 
            // btnSetConnSettings
            // 
            this.btnSetConnSettings.Location = new System.Drawing.Point(98, 145);
            this.btnSetConnSettings.Name = "btnSetConnSettings";
            this.btnSetConnSettings.Size = new System.Drawing.Size(189, 25);
            this.btnSetConnSettings.TabIndex = 9;
            this.btnSetConnSettings.Text = "Задать настройки";
            this.btnSetConnSettings.UseVisualStyleBackColor = true;
            this.btnSetConnSettings.Click += new System.EventHandler(this.btnSetConnSettings_Click);
            // 
            // rtextboxConnectionString
            // 
            this.rtextboxConnectionString.Location = new System.Drawing.Point(98, 48);
            this.rtextboxConnectionString.Name = "rtextboxConnectionString";
            this.rtextboxConnectionString.Size = new System.Drawing.Size(280, 93);
            this.rtextboxConnectionString.TabIndex = 8;
            this.rtextboxConnectionString.Text = "";
            // 
            // cmbboxDBType
            // 
            this.cmbboxDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbboxDBType.FormattingEnabled = true;
            this.cmbboxDBType.Items.AddRange(new object[] {
            "MYSQL"});
            this.cmbboxDBType.Location = new System.Drawing.Point(98, 18);
            this.cmbboxDBType.Name = "cmbboxDBType";
            this.cmbboxDBType.Size = new System.Drawing.Size(116, 21);
            this.cmbboxDBType.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExecute);
            this.groupBox4.Controls.Add(this.rtextboxSQLQuery);
            this.groupBox4.Location = new System.Drawing.Point(6, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 169);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SQL запрос";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(101, 128);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(190, 34);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Выполнить";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // rtextboxSQLQuery
            // 
            this.rtextboxSQLQuery.Location = new System.Drawing.Point(3, 16);
            this.rtextboxSQLQuery.Name = "rtextboxSQLQuery";
            this.rtextboxSQLQuery.Size = new System.Drawing.Size(378, 105);
            this.rtextboxSQLQuery.TabIndex = 1;
            this.rtextboxSQLQuery.Text = "";
            // 
            // tpComponents
            // 
            this.tpComponents.Controls.Add(this.groupBox3);
            this.tpComponents.Location = new System.Drawing.Point(4, 25);
            this.tpComponents.Name = "tpComponents";
            this.tpComponents.Padding = new System.Windows.Forms.Padding(3);
            this.tpComponents.Size = new System.Drawing.Size(881, 403);
            this.tpComponents.TabIndex = 5;
            this.tpComponents.Text = "Компоненты";
            this.tpComponents.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbComponentsCheckPrefix);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbCheckComponentsLogin);
            this.groupBox3.Controls.Add(this.tbCheckComponentsPassword);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbCheckAllComponents);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cbComponentsCheckPageOnErrors);
            this.groupBox3.Location = new System.Drawing.Point(20, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 129);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Проверить все компоненты";
            // 
            // tbComponentsCheckPrefix
            // 
            this.tbComponentsCheckPrefix.Location = new System.Drawing.Point(9, 63);
            this.tbComponentsCheckPrefix.Name = "tbComponentsCheckPrefix";
            this.tbComponentsCheckPrefix.Size = new System.Drawing.Size(100, 20);
            this.tbComponentsCheckPrefix.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Часть имени компонента (например, *forum*)";
            // 
            // tbCheckComponentsLogin
            // 
            this.tbCheckComponentsLogin.Location = new System.Drawing.Point(9, 102);
            this.tbCheckComponentsLogin.Name = "tbCheckComponentsLogin";
            this.tbCheckComponentsLogin.Size = new System.Drawing.Size(131, 20);
            this.tbCheckComponentsLogin.TabIndex = 28;
            // 
            // tbCheckComponentsPassword
            // 
            this.tbCheckComponentsPassword.Location = new System.Drawing.Point(166, 102);
            this.tbCheckComponentsPassword.Name = "tbCheckComponentsPassword";
            this.tbCheckComponentsPassword.Size = new System.Drawing.Size(99, 20);
            this.tbCheckComponentsPassword.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "логин";
            // 
            // cbCheckAllComponents
            // 
            this.cbCheckAllComponents.AutoSize = true;
            this.cbCheckAllComponents.Location = new System.Drawing.Point(9, 19);
            this.cbCheckAllComponents.Name = "cbCheckAllComponents";
            this.cbCheckAllComponents.Size = new System.Drawing.Size(150, 17);
            this.cbCheckAllComponents.TabIndex = 25;
            this.cbCheckAllComponents.Text = "Пройти все компоненты";
            this.cbCheckAllComponents.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "пароль";
            // 
            // cbComponentsCheckPageOnErrors
            // 
            this.cbComponentsCheckPageOnErrors.AutoSize = true;
            this.cbComponentsCheckPageOnErrors.Checked = true;
            this.cbComponentsCheckPageOnErrors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbComponentsCheckPageOnErrors.Location = new System.Drawing.Point(165, 19);
            this.cbComponentsCheckPageOnErrors.Name = "cbComponentsCheckPageOnErrors";
            this.cbComponentsCheckPageOnErrors.Size = new System.Drawing.Size(130, 17);
            this.cbComponentsCheckPageOnErrors.TabIndex = 26;
            this.cbComponentsCheckPageOnErrors.Text = "Проверять страницу";
            this.cbComponentsCheckPageOnErrors.UseVisualStyleBackColor = true;
            // 
            // dataGVResult
            // 
            this.dataGVResult.AllowUserToAddRows = false;
            this.dataGVResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGVResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVResult.Location = new System.Drawing.Point(0, 448);
            this.dataGVResult.Name = "dataGVResult";
            this.dataGVResult.Size = new System.Drawing.Size(1158, 313);
            this.dataGVResult.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 760);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.dataGVResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bClearLog);
            this.Controls.Add(this.cbBrowsers);
            this.Controls.Add(this.bOptions);
            this.Controls.Add(this.bDo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitrix BitrixAQA";
            this.tcMain.ResumeLayout(false);
            this.tpBUS.ResumeLayout(false);
            this.tpBUS.PerformLayout();
            this.tpVarious.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpSQL.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tpComponents.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bDo;
        private System.Windows.Forms.Button bOptions;
        /// <summary>
        /// Флаг Проверять весь сайт
        /// </summary>
        public System.Windows.Forms.CheckBox cbCheckAllSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bClearLog;
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.ComboBox cbBrowsers;
        /// <summary>
        /// Поле логина для урлчекера
        /// </summary>
        public System.Windows.Forms.TextBox tbCheckUrlsLogin;
        /// <summary>
        /// Поле пароля для урлчекера
        /// </summary>
        public System.Windows.Forms.TextBox tbCheckUrlsPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        /// <summary>
        /// Флаг проверок страниц на ошибки урлчекером
        /// </summary>
        public System.Windows.Forms.CheckBox cbUrlsCheckPageOnErrors;
        /// <summary>
        /// Поле урлов, проверяемых урлчекером
        /// </summary>
        public System.Windows.Forms.TextBox tbCheckUrlsUrlToCheck;
        /// <summary>
        /// Область лога
        /// </summary>
        public System.Windows.Forms.RichTextBox tbLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpVarious;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tpBUS;
        private System.Windows.Forms.TabPage tpSQL;
        private System.Windows.Forms.Button btnExecute;
        /// <summary>
        /// Облать результатов SQL запросов
        /// </summary>
        public System.Windows.Forms.DataGridView dataGVResult;
        private System.Windows.Forms.Label lblConnType;
        private System.Windows.Forms.ComboBox cmbboxConnType;
        /// <summary>
        /// Область состояния подключения к БД
        /// </summary>
        public System.Windows.Forms.Label lblConnStatus;
        private System.Windows.Forms.Label lblConnStatusTitle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtextboxSQLQuery;
        private System.Windows.Forms.Button btnSetConnSettings;
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        public System.Windows.Forms.RichTextBox rtextboxConnectionString;
        /// <summary>
        /// Селектор типа БД
        /// </summary>
        public System.Windows.Forms.ComboBox cmbboxDBType;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label lblDBType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label9;
        /// <summary>
        /// Поле урлов для одноразовой проверки
        /// </summary>
        public System.Windows.Forms.TextBox tbCheckOnce;
        /// <summary>
        /// Флаг проверки картинок
        /// </summary>
        public System.Windows.Forms.CheckBox cbCheckImages1;
        private System.Windows.Forms.TabPage tpComponents;
        private System.Windows.Forms.GroupBox groupBox3;
        /// <summary>
        /// Поле части имени компонента для проверки
        /// </summary>
        public System.Windows.Forms.TextBox tbComponentsCheckPrefix;
        private System.Windows.Forms.Label label8;
        /// <summary>
        /// Поле логина для проверки компонентов
        /// </summary>
        public System.Windows.Forms.TextBox tbCheckComponentsLogin;
        /// <summary>
        /// Поле пароля для проверки компонентов
        /// </summary>
        public System.Windows.Forms.TextBox tbCheckComponentsPassword;
        private System.Windows.Forms.Label label6;
        /// <summary>
        /// Флаг Проверить все компоненты
        /// </summary>
        public System.Windows.Forms.CheckBox cbCheckAllComponents;
        private System.Windows.Forms.Label label7;
        /// <summary>
        /// Флаг Проверять страницу на ошибки
        /// </summary>
        public System.Windows.Forms.CheckBox cbComponentsCheckPageOnErrors;
        /// <summary>
        /// Флаг демо-теста магазина
        /// </summary>
        public System.Windows.Forms.CheckBox cbSaleTest;
        /// <summary>
        /// Флаг демо-теста главного модуля
        /// </summary>
        public System.Windows.Forms.CheckBox cbMainTest;
    }
}

