namespace BitrixAQA
{
    partial class OptionsForm
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
            this.bSelectMySQLPath_bb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bSaveOptions = new System.Windows.Forms.Button();
            this.bCancelOptions = new System.Windows.Forms.Button();
            this.bAcceptOptions = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.tbConString_mysql = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label64 = new System.Windows.Forms.Label();
            this.tbConString_mysql_port = new System.Windows.Forms.TextBox();
            this.tbURL_BB_mysql = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tpOptions_PathWhereToInstall = new System.Windows.Forms.TabPage();
            this.label34 = new System.Windows.Forms.Label();
            this.tbPathBB_mysql = new System.Windows.Forms.TextBox();
            this.tpOptions_Urls = new System.Windows.Forms.TabPage();
            this.label35 = new System.Windows.Forms.Label();
            this.tpOptions_Other = new System.Windows.Forms.TabPage();
            this.tpOptions_Users = new System.Windows.Forms.TabPage();
            this.label126 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_usr_Intra2_Name = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra2_LastName = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra2_Email = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra2_Login = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra2_Password = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra2_Ava = new System.Windows.Forms.TextBox();
            this.lbl_usr_Intra2 = new System.Windows.Forms.Label();
            this.lbl_usr_Admin = new System.Windows.Forms.Label();
            this.tb_usr_Admin_Name = new System.Windows.Forms.TextBox();
            this.tb_usr_Admin_LastName = new System.Windows.Forms.TextBox();
            this.tb_usr_Admin_Email = new System.Windows.Forms.TextBox();
            this.tb_usr_Admin_Login = new System.Windows.Forms.TextBox();
            this.tb_usr_Admin_Password = new System.Windows.Forms.TextBox();
            this.tb_usr_Admin_Ava = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra1_Name = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra1_LastName = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra1_Email = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra1_Login = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra1_Password = new System.Windows.Forms.TextBox();
            this.tb_usr_Intra1_Ava = new System.Windows.Forms.TextBox();
            this.lbl_usr_Intra1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.tcOptions.SuspendLayout();
            this.tpOptions_PathWhereToInstall.SuspendLayout();
            this.tpOptions_Urls.SuspendLayout();
            this.tpOptions_Other.SuspendLayout();
            this.tpOptions_Users.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSelectMySQLPath_bb
            // 
            this.bSelectMySQLPath_bb.Location = new System.Drawing.Point(480, 56);
            this.bSelectMySQLPath_bb.Name = "bSelectMySQLPath_bb";
            this.bSelectMySQLPath_bb.Size = new System.Drawing.Size(26, 20);
            this.bSelectMySQLPath_bb.TabIndex = 7;
            this.bSelectMySQLPath_bb.Text = "...";
            this.bSelectMySQLPath_bb.UseVisualStyleBackColor = true;
            this.bSelectMySQLPath_bb.Click += new System.EventHandler(this.bSelectMySQLPath_bb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тестовая установка";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bSaveOptions
            // 
            this.bSaveOptions.Location = new System.Drawing.Point(298, 581);
            this.bSaveOptions.Name = "bSaveOptions";
            this.bSaveOptions.Size = new System.Drawing.Size(75, 23);
            this.bSaveOptions.TabIndex = 6;
            this.bSaveOptions.Text = "Сохранить";
            this.bSaveOptions.UseVisualStyleBackColor = true;
            this.bSaveOptions.Click += new System.EventHandler(this.bSaveOptions_Click);
            // 
            // bCancelOptions
            // 
            this.bCancelOptions.Location = new System.Drawing.Point(488, 581);
            this.bCancelOptions.Name = "bCancelOptions";
            this.bCancelOptions.Size = new System.Drawing.Size(75, 23);
            this.bCancelOptions.TabIndex = 7;
            this.bCancelOptions.Text = "Отмена";
            this.bCancelOptions.UseVisualStyleBackColor = true;
            this.bCancelOptions.Click += new System.EventHandler(this.bCancelOptions_Click);
            // 
            // bAcceptOptions
            // 
            this.bAcceptOptions.Location = new System.Drawing.Point(393, 581);
            this.bAcceptOptions.Name = "bAcceptOptions";
            this.bAcceptOptions.Size = new System.Drawing.Size(75, 23);
            this.bAcceptOptions.TabIndex = 8;
            this.bAcceptOptions.Text = "Применить";
            this.bAcceptOptions.UseVisualStyleBackColor = true;
            this.bAcceptOptions.Click += new System.EventHandler(this.bAcceptOptions_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(46, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "MySQL";
            // 
            // tbConString_mysql
            // 
            this.tbConString_mysql.Location = new System.Drawing.Point(92, 23);
            this.tbConString_mysql.Name = "tbConString_mysql";
            this.tbConString_mysql.Size = new System.Drawing.Size(431, 20);
            this.tbConString_mysql.TabIndex = 11;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label64);
            this.groupBox5.Controls.Add(this.tbConString_mysql_port);
            this.groupBox5.Controls.Add(this.tbConString_mysql);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Location = new System.Drawing.Point(7, 91);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(976, 82);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Строки подключения к базам";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(529, 28);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(32, 13);
            this.label64.TabIndex = 23;
            this.label64.Text = "Порт";
            // 
            // tbConString_mysql_port
            // 
            this.tbConString_mysql_port.Location = new System.Drawing.Point(577, 23);
            this.tbConString_mysql_port.Name = "tbConString_mysql_port";
            this.tbConString_mysql_port.Size = new System.Drawing.Size(393, 20);
            this.tbConString_mysql_port.TabIndex = 22;
            // 
            // tbURL_BB_mysql
            // 
            this.tbURL_BB_mysql.Location = new System.Drawing.Point(133, 57);
            this.tbURL_BB_mysql.Name = "tbURL_BB_mysql";
            this.tbURL_BB_mysql.Size = new System.Drawing.Size(397, 20);
            this.tbURL_BB_mysql.TabIndex = 9;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 60);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(110, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Тестовая установка";
            // 
            // tcOptions
            // 
            this.tcOptions.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcOptions.Controls.Add(this.tpOptions_PathWhereToInstall);
            this.tcOptions.Controls.Add(this.tpOptions_Urls);
            this.tcOptions.Controls.Add(this.tpOptions_Other);
            this.tcOptions.Controls.Add(this.tpOptions_Users);
            this.tcOptions.Location = new System.Drawing.Point(1, 2);
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(1067, 554);
            this.tcOptions.TabIndex = 14;
            // 
            // tpOptions_PathWhereToInstall
            // 
            this.tpOptions_PathWhereToInstall.AutoScroll = true;
            this.tpOptions_PathWhereToInstall.Controls.Add(this.label34);
            this.tpOptions_PathWhereToInstall.Controls.Add(this.tbPathBB_mysql);
            this.tpOptions_PathWhereToInstall.Controls.Add(this.label1);
            this.tpOptions_PathWhereToInstall.Controls.Add(this.bSelectMySQLPath_bb);
            this.tpOptions_PathWhereToInstall.Location = new System.Drawing.Point(4, 25);
            this.tpOptions_PathWhereToInstall.Name = "tpOptions_PathWhereToInstall";
            this.tpOptions_PathWhereToInstall.Padding = new System.Windows.Forms.Padding(3);
            this.tpOptions_PathWhereToInstall.Size = new System.Drawing.Size(1059, 525);
            this.tpOptions_PathWhereToInstall.TabIndex = 0;
            this.tpOptions_PathWhereToInstall.Text = "Пути к установкам";
            this.tpOptions_PathWhereToInstall.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(7, 18);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(129, 13);
            this.label34.TabIndex = 16;
            this.label34.Text = "Пути к папкам на диске";
            // 
            // tbPathBB_mysql
            // 
            this.tbPathBB_mysql.Location = new System.Drawing.Point(133, 57);
            this.tbPathBB_mysql.Name = "tbPathBB_mysql";
            this.tbPathBB_mysql.Size = new System.Drawing.Size(341, 20);
            this.tbPathBB_mysql.TabIndex = 0;
            // 
            // tpOptions_Urls
            // 
            this.tpOptions_Urls.Controls.Add(this.label35);
            this.tpOptions_Urls.Controls.Add(this.label24);
            this.tpOptions_Urls.Controls.Add(this.tbURL_BB_mysql);
            this.tpOptions_Urls.Location = new System.Drawing.Point(4, 25);
            this.tpOptions_Urls.Name = "tpOptions_Urls";
            this.tpOptions_Urls.Padding = new System.Windows.Forms.Padding(3);
            this.tpOptions_Urls.Size = new System.Drawing.Size(1059, 525);
            this.tpOptions_Urls.TabIndex = 1;
            this.tpOptions_Urls.Text = "Урлы установок";
            this.tpOptions_Urls.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(7, 18);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(149, 13);
            this.label35.TabIndex = 18;
            this.label35.Text = "Урлы установок. Без http://";
            // 
            // tpOptions_Other
            // 
            this.tpOptions_Other.Controls.Add(this.groupBox5);
            this.tpOptions_Other.Location = new System.Drawing.Point(4, 25);
            this.tpOptions_Other.Name = "tpOptions_Other";
            this.tpOptions_Other.Size = new System.Drawing.Size(1059, 525);
            this.tpOptions_Other.TabIndex = 3;
            this.tpOptions_Other.Text = "Разное";
            this.tpOptions_Other.UseVisualStyleBackColor = true;
            // 
            // tpOptions_Users
            // 
            this.tpOptions_Users.Controls.Add(this.label126);
            this.tpOptions_Users.Controls.Add(this.label125);
            this.tpOptions_Users.Controls.Add(this.label124);
            this.tpOptions_Users.Controls.Add(this.label123);
            this.tpOptions_Users.Controls.Add(this.label122);
            this.tpOptions_Users.Controls.Add(this.label121);
            this.tpOptions_Users.Controls.Add(this.panel1);
            this.tpOptions_Users.Location = new System.Drawing.Point(4, 25);
            this.tpOptions_Users.Name = "tpOptions_Users";
            this.tpOptions_Users.Padding = new System.Windows.Forms.Padding(3);
            this.tpOptions_Users.Size = new System.Drawing.Size(1059, 525);
            this.tpOptions_Users.TabIndex = 9;
            this.tpOptions_Users.Text = "Пользователи";
            this.tpOptions_Users.UseVisualStyleBackColor = true;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(766, 15);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(43, 13);
            this.label126.TabIndex = 173;
            this.label126.Text = "Аватар";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(658, 15);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(45, 13);
            this.label125.TabIndex = 172;
            this.label125.Text = "Пароль";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(518, 15);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(38, 13);
            this.label124.TabIndex = 171;
            this.label124.Text = "Логин";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(385, 15);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(35, 13);
            this.label123.TabIndex = 170;
            this.label123.Text = "E-mail";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(245, 15);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(56, 13);
            this.label122.TabIndex = 169;
            this.label122.Text = "Фамилия";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(137, 15);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(29, 13);
            this.label121.TabIndex = 168;
            this.label121.Text = "Имя";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.tb_usr_Intra2_Name);
            this.panel1.Controls.Add(this.tb_usr_Intra2_LastName);
            this.panel1.Controls.Add(this.tb_usr_Intra2_Email);
            this.panel1.Controls.Add(this.tb_usr_Intra2_Login);
            this.panel1.Controls.Add(this.tb_usr_Intra2_Password);
            this.panel1.Controls.Add(this.tb_usr_Intra2_Ava);
            this.panel1.Controls.Add(this.lbl_usr_Intra2);
            this.panel1.Controls.Add(this.lbl_usr_Admin);
            this.panel1.Controls.Add(this.tb_usr_Admin_Name);
            this.panel1.Controls.Add(this.tb_usr_Admin_LastName);
            this.panel1.Controls.Add(this.tb_usr_Admin_Email);
            this.panel1.Controls.Add(this.tb_usr_Admin_Login);
            this.panel1.Controls.Add(this.tb_usr_Admin_Password);
            this.panel1.Controls.Add(this.tb_usr_Admin_Ava);
            this.panel1.Controls.Add(this.tb_usr_Intra1_Name);
            this.panel1.Controls.Add(this.tb_usr_Intra1_LastName);
            this.panel1.Controls.Add(this.tb_usr_Intra1_Email);
            this.panel1.Controls.Add(this.tb_usr_Intra1_Login);
            this.panel1.Controls.Add(this.tb_usr_Intra1_Password);
            this.panel1.Controls.Add(this.tb_usr_Intra1_Ava);
            this.panel1.Controls.Add(this.lbl_usr_Intra1);
            this.panel1.Location = new System.Drawing.Point(7, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 485);
            this.panel1.TabIndex = 126;
            // 
            // tb_usr_Intra2_Name
            // 
            this.tb_usr_Intra2_Name.Location = new System.Drawing.Point(133, 59);
            this.tb_usr_Intra2_Name.Name = "tb_usr_Intra2_Name";
            this.tb_usr_Intra2_Name.Size = new System.Drawing.Size(102, 20);
            this.tb_usr_Intra2_Name.TabIndex = 14;
            this.tb_usr_Intra2_Name.Text = "Иван";
            // 
            // tb_usr_Intra2_LastName
            // 
            this.tb_usr_Intra2_LastName.Location = new System.Drawing.Point(241, 59);
            this.tb_usr_Intra2_LastName.Name = "tb_usr_Intra2_LastName";
            this.tb_usr_Intra2_LastName.Size = new System.Drawing.Size(135, 20);
            this.tb_usr_Intra2_LastName.TabIndex = 15;
            this.tb_usr_Intra2_LastName.Text = "Иванов";
            // 
            // tb_usr_Intra2_Email
            // 
            this.tb_usr_Intra2_Email.Location = new System.Drawing.Point(381, 59);
            this.tb_usr_Intra2_Email.Name = "tb_usr_Intra2_Email";
            this.tb_usr_Intra2_Email.Size = new System.Drawing.Size(127, 20);
            this.tb_usr_Intra2_Email.TabIndex = 16;
            // 
            // tb_usr_Intra2_Login
            // 
            this.tb_usr_Intra2_Login.Location = new System.Drawing.Point(514, 59);
            this.tb_usr_Intra2_Login.Name = "tb_usr_Intra2_Login";
            this.tb_usr_Intra2_Login.Size = new System.Drawing.Size(134, 20);
            this.tb_usr_Intra2_Login.TabIndex = 17;
            this.tb_usr_Intra2_Login.Text = "Ivan";
            // 
            // tb_usr_Intra2_Password
            // 
            this.tb_usr_Intra2_Password.Location = new System.Drawing.Point(654, 59);
            this.tb_usr_Intra2_Password.Name = "tb_usr_Intra2_Password";
            this.tb_usr_Intra2_Password.Size = new System.Drawing.Size(102, 20);
            this.tb_usr_Intra2_Password.TabIndex = 18;
            this.tb_usr_Intra2_Password.Text = "111111";
            // 
            // tb_usr_Intra2_Ava
            // 
            this.tb_usr_Intra2_Ava.Location = new System.Drawing.Point(762, 59);
            this.tb_usr_Intra2_Ava.Name = "tb_usr_Intra2_Ava";
            this.tb_usr_Intra2_Ava.Size = new System.Drawing.Size(148, 20);
            this.tb_usr_Intra2_Ava.TabIndex = 19;
            this.tb_usr_Intra2_Ava.Text = "avatar_semen.jpg";
            // 
            // lbl_usr_Intra2
            // 
            this.lbl_usr_Intra2.AutoSize = true;
            this.lbl_usr_Intra2.Location = new System.Drawing.Point(20, 62);
            this.lbl_usr_Intra2.Name = "lbl_usr_Intra2";
            this.lbl_usr_Intra2.Size = new System.Drawing.Size(89, 13);
            this.lbl_usr_Intra2.TabIndex = 20;
            this.lbl_usr_Intra2.Text = "Пользователь 2";
            // 
            // lbl_usr_Admin
            // 
            this.lbl_usr_Admin.AutoSize = true;
            this.lbl_usr_Admin.Location = new System.Drawing.Point(20, 12);
            this.lbl_usr_Admin.Name = "lbl_usr_Admin";
            this.lbl_usr_Admin.Size = new System.Drawing.Size(40, 13);
            this.lbl_usr_Admin.TabIndex = 6;
            this.lbl_usr_Admin.Text = "Админ";
            // 
            // tb_usr_Admin_Name
            // 
            this.tb_usr_Admin_Name.Location = new System.Drawing.Point(133, 9);
            this.tb_usr_Admin_Name.Name = "tb_usr_Admin_Name";
            this.tb_usr_Admin_Name.Size = new System.Drawing.Size(102, 20);
            this.tb_usr_Admin_Name.TabIndex = 0;
            // 
            // tb_usr_Admin_LastName
            // 
            this.tb_usr_Admin_LastName.Location = new System.Drawing.Point(241, 9);
            this.tb_usr_Admin_LastName.Name = "tb_usr_Admin_LastName";
            this.tb_usr_Admin_LastName.Size = new System.Drawing.Size(135, 20);
            this.tb_usr_Admin_LastName.TabIndex = 1;
            // 
            // tb_usr_Admin_Email
            // 
            this.tb_usr_Admin_Email.Location = new System.Drawing.Point(381, 9);
            this.tb_usr_Admin_Email.Name = "tb_usr_Admin_Email";
            this.tb_usr_Admin_Email.Size = new System.Drawing.Size(127, 20);
            this.tb_usr_Admin_Email.TabIndex = 2;
            // 
            // tb_usr_Admin_Login
            // 
            this.tb_usr_Admin_Login.Location = new System.Drawing.Point(514, 9);
            this.tb_usr_Admin_Login.Name = "tb_usr_Admin_Login";
            this.tb_usr_Admin_Login.Size = new System.Drawing.Size(134, 20);
            this.tb_usr_Admin_Login.TabIndex = 3;
            // 
            // tb_usr_Admin_Password
            // 
            this.tb_usr_Admin_Password.Location = new System.Drawing.Point(654, 9);
            this.tb_usr_Admin_Password.Name = "tb_usr_Admin_Password";
            this.tb_usr_Admin_Password.Size = new System.Drawing.Size(102, 20);
            this.tb_usr_Admin_Password.TabIndex = 4;
            // 
            // tb_usr_Admin_Ava
            // 
            this.tb_usr_Admin_Ava.Location = new System.Drawing.Point(762, 9);
            this.tb_usr_Admin_Ava.Name = "tb_usr_Admin_Ava";
            this.tb_usr_Admin_Ava.Size = new System.Drawing.Size(148, 20);
            this.tb_usr_Admin_Ava.TabIndex = 5;
            // 
            // tb_usr_Intra1_Name
            // 
            this.tb_usr_Intra1_Name.Location = new System.Drawing.Point(133, 35);
            this.tb_usr_Intra1_Name.Name = "tb_usr_Intra1_Name";
            this.tb_usr_Intra1_Name.Size = new System.Drawing.Size(102, 20);
            this.tb_usr_Intra1_Name.TabIndex = 7;
            this.tb_usr_Intra1_Name.Text = "Семен";
            // 
            // tb_usr_Intra1_LastName
            // 
            this.tb_usr_Intra1_LastName.Location = new System.Drawing.Point(241, 35);
            this.tb_usr_Intra1_LastName.Name = "tb_usr_Intra1_LastName";
            this.tb_usr_Intra1_LastName.Size = new System.Drawing.Size(135, 20);
            this.tb_usr_Intra1_LastName.TabIndex = 8;
            this.tb_usr_Intra1_LastName.Text = "Синичкин";
            // 
            // tb_usr_Intra1_Email
            // 
            this.tb_usr_Intra1_Email.Location = new System.Drawing.Point(381, 35);
            this.tb_usr_Intra1_Email.Name = "tb_usr_Intra1_Email";
            this.tb_usr_Intra1_Email.Size = new System.Drawing.Size(127, 20);
            this.tb_usr_Intra1_Email.TabIndex = 9;
            // 
            // tb_usr_Intra1_Login
            // 
            this.tb_usr_Intra1_Login.Location = new System.Drawing.Point(514, 35);
            this.tb_usr_Intra1_Login.Name = "tb_usr_Intra1_Login";
            this.tb_usr_Intra1_Login.Size = new System.Drawing.Size(134, 20);
            this.tb_usr_Intra1_Login.TabIndex = 10;
            this.tb_usr_Intra1_Login.Text = "semen";
            // 
            // tb_usr_Intra1_Password
            // 
            this.tb_usr_Intra1_Password.Location = new System.Drawing.Point(654, 35);
            this.tb_usr_Intra1_Password.Name = "tb_usr_Intra1_Password";
            this.tb_usr_Intra1_Password.Size = new System.Drawing.Size(102, 20);
            this.tb_usr_Intra1_Password.TabIndex = 11;
            this.tb_usr_Intra1_Password.Text = "111111";
            // 
            // tb_usr_Intra1_Ava
            // 
            this.tb_usr_Intra1_Ava.Location = new System.Drawing.Point(762, 35);
            this.tb_usr_Intra1_Ava.Name = "tb_usr_Intra1_Ava";
            this.tb_usr_Intra1_Ava.Size = new System.Drawing.Size(148, 20);
            this.tb_usr_Intra1_Ava.TabIndex = 12;
            this.tb_usr_Intra1_Ava.Text = "avatar_semen.jpg";
            // 
            // lbl_usr_Intra1
            // 
            this.lbl_usr_Intra1.AutoSize = true;
            this.lbl_usr_Intra1.Location = new System.Drawing.Point(20, 38);
            this.lbl_usr_Intra1.Name = "lbl_usr_Intra1";
            this.lbl_usr_Intra1.Size = new System.Drawing.Size(89, 13);
            this.lbl_usr_Intra1.TabIndex = 13;
            this.lbl_usr_Intra1.Text = "Пользователь 1";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 642);
            this.Controls.Add(this.tcOptions);
            this.Controls.Add(this.bAcceptOptions);
            this.Controls.Add(this.bCancelOptions);
            this.Controls.Add(this.bSaveOptions);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tcOptions.ResumeLayout(false);
            this.tpOptions_PathWhereToInstall.ResumeLayout(false);
            this.tpOptions_PathWhereToInstall.PerformLayout();
            this.tpOptions_Urls.ResumeLayout(false);
            this.tpOptions_Urls.PerformLayout();
            this.tpOptions_Other.ResumeLayout(false);
            this.tpOptions_Users.ResumeLayout(false);
            this.tpOptions_Users.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSelectMySQLPath_bb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bSaveOptions;
        private System.Windows.Forms.Button bCancelOptions;
        private System.Windows.Forms.Button bAcceptOptions;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label24;
        /// <summary>
        /// Урл установки
        /// </summary>
        public System.Windows.Forms.TextBox tbURL_BB_mysql;
        /// <summary>
        /// Строка подключения к БД mysql
        /// </summary>
        public System.Windows.Forms.TextBox tbConString_mysql;
        private System.Windows.Forms.TabControl tcOptions;
        private System.Windows.Forms.TabPage tpOptions_PathWhereToInstall;
        private System.Windows.Forms.TabPage tpOptions_Urls;
        private System.Windows.Forms.TabPage tpOptions_Other;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label64;
        /// <summary>
        /// Поле порта для подключения к БД mysql
        /// </summary>
        public System.Windows.Forms.TextBox tbConString_mysql_port;
        private System.Windows.Forms.TabPage tpOptions_Users;
        /// <summary>
        /// Поле почты админа
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Admin_Email;
        /// <summary>
        /// Поле фамилии админа
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Admin_LastName;
        /// <summary>
        /// Поле имени админа
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Admin_Name;
        /// <summary>
        /// Поле пароля админа
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Admin_Password;
        private System.Windows.Forms.Label lbl_usr_Intra1;
        /// <summary>
        /// Поле аватара польязователя 1
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra1_Ava;
        /// <summary>
        /// Поле пароля пользователя 1
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra1_Password;
        /// <summary>
        /// Поле логина пользователя 1
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra1_Login;
        /// <summary>
        /// Поле почты пользователя 1
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra1_Email;
        /// <summary>
        /// Поле фамилии пользователя 1
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra1_LastName;
        /// <summary>
        /// Поле имения пользователя 1
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra1_Name;
        private System.Windows.Forms.Label lbl_usr_Admin;
        /// <summary>
        /// Поле автара админа
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Admin_Ava;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Panel panel1;
        /// <summary>
        /// Поле логина админа
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Admin_Login;
        /// <summary>
        /// Поле имени пользователя 2
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra2_Name;
        /// <summary>
        /// Поле фамилии пользователя 2
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra2_LastName;
        /// <summary>
        /// Поле почты пользователя 2
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra2_Email;
        /// <summary>
        /// Поле логина пользователя 2
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra2_Login;
        /// <summary>
        /// Поле пароля пользователя 2
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra2_Password;
        /// <summary>
        /// Поле автара пользователя 2
        /// </summary>
        public System.Windows.Forms.TextBox tb_usr_Intra2_Ava;
        private System.Windows.Forms.Label lbl_usr_Intra2;
        /// <summary>
        /// Путь к установке на диске
        /// </summary>
        public System.Windows.Forms.TextBox tbPathBB_mysql;
    }
}