using BitrixAQA.General;

namespace BitrixAQA.Selenium.General
{
    /// <summary>
    /// Класс содержит переменные с данными тестовых пользователей - Имя, Фамилия, Email
    /// </summary>
    class TestUsers
    {
        /// <summary>
        /// стандартный общий пароль для всех
        /// </summary>
        public static string GeneralPassword = "";

        /// <summary>
        /// стандартный общий логин админа для БУС
        /// </summary>
        public static string GeneralBUSAdmin = "";

        /// <summary>
        /// Админ сайта
        /// </summary>
        public static readonly TestUsers Admin = new TestUsers("/Options/users/user[@profile='Admin']");

        /// <summary>
        /// Пользователь 1
        /// </summary>
        public static TestUsers Semen = new TestUsers("/Options/users/user[@profile='Intra1']");

        /// <summary>
        /// Петр Петров
        /// </summary>
        public static readonly TestUsers Petr = new TestUsers("/Options/users/user[@profile='Intra2']");


        #region Конструкторы
        /// <summary>
        /// Конструктор для пользователя, данные которого задаются в переменных выше
        /// </summary>
        public TestUsers()
        {
        }

        /// <summary>
        /// Конструктор для пользователя, данные которого задаются в файле опций
        /// </summary>
        /// <param name="path">Путь до ключа в файле опций с параметрами пользователя, например /Options/admin_settings</param>
        public TestUsers(string path)
        {
            this.Name = Options.GetOption(path + "/Name");
            this.LastName = Options.GetOption(path + "/LastName");
            this.Email = Options.GetOption(path + "/Email");
            this.Login = Options.GetOption(path + "/Login");
            this.Password = Options.GetOption(path + "/Password");
            this.Avatar = Shared.TestFiles(Options.GetOption(path + "/Avatar"));
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имя Фамилия, например, Семен Синичкин
        /// </summary>
        public string Name_LastName { get { return Name + " " + LastName; } }
        /// <summary>
        /// Фамилия Имя, например, Синичкин Семен
        /// </summary>
        public string LastName_Name { get { return LastName + " " + Name; } }
        /// <summary>
        /// Формат имени и фамилии в зависимости от настроек
        /// </summary>
        public string Format_Name
        {
            get
            {
                string fio = Options.GetOption("/Options/admin_settings/formatName");
                if (fio != null)
                {
                    switch (fio)
                    {
                        case "Имя Фамилия":
                            return Name + " " + LastName;
                        case "Фамилия Имя":
                            return LastName + " " + Name;
                    }
                }
                return fio;
            }
        }
        /// <summary>
        /// Формат имени и фамилии для ИМа. По умолчанию LastName Name
        /// </summary>
        public string IM_Format_Name { get { return Name + " " + LastName; } }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Аватар
        /// </summary>
        public string Avatar { get; set; }
        #endregion
    }
}
