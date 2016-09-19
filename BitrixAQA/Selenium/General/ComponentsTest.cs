using System.Collections.Generic;
using System.IO;
using BitrixAQA.General;
using BitrixAQA.Selenium.Framework;
using BitrixAQA.Selenium.Test_Cases;

namespace BitrixAQA.Selenium.General
{
    /// <summary>
    /// Содержит методы для тестирования компонентов БУС
    /// </summary>
    class ComponentsTest
    {
        /// <summary>
        /// Метод проверки компонентов
        /// </summary>
        /// <param name="edition">тип редакции установки</param>
        /// <param name="dbType">тип БД</param>
        public static void Run(string edition, string dbType)
        {
            List<DirectoryInfo> folders = new List<DirectoryInfo>();
            string PathToDistr = Options.GetOption("/Options/PathToFolderWhereToInstall/edition[@title='" + edition + "']/" + dbType);
            string urlToCheck = "http://" + Options.GetOption("/Options/URLS/edition[@title='" + edition + "']/" + dbType);
            string searchPrefix = MainForm.form.tbComponentsCheckPrefix.Text.Trim();
            DirectoryInfo targetDir = new DirectoryInfo(PathToDistr + "bitrix\\components\\bitrix\\");

            Log.MesNormal("Проверка всех компонентов установки");

            //получаем все компоненты (имена папок)
            if (searchPrefix != "")
            {
                foreach (DirectoryInfo d in targetDir.GetDirectories("*" + searchPrefix + "*"))
                    folders.Add(d);
            }
            else
            {
                foreach (DirectoryInfo d in targetDir.GetDirectories())
                    folders.Add(d);
            }

            BitrixFramework.OpenURL(urlToCheck, CheckPageOnErrors: false);

            if (MainForm.form.tbCheckComponentsLogin.Text.Trim() !=" " && MainForm.form.tbCheckComponentsPassword.Text.Trim() != "")
                Case_General_Login.LoginAdminArea(MainForm.form.tbCheckUrlsLogin.Text.Trim(), MainForm.form.tbCheckUrlsPass.Text.Trim());

            //для каждого компонента создаем отдельный файл php с именем компонента, в котором размещается код вызова компонента
            foreach (var componentsFolder in folders)
            {
                //создаем папку CTest, если нет
                if (!Directory.Exists(PathToDistr + "CTest"))
                    Directory.CreateDirectory(PathToDistr + "CTest");

                //удалем файл с именем компонента, если есть
                if (File.Exists(PathToDistr + "CTest\\" + componentsFolder.ToString() + ".php"))
                    File.Delete(PathToDistr + "CTest\\" + componentsFolder.ToString() + ".php");

                File.AppendAllText(PathToDistr + "CTest\\" + componentsFolder.ToString() + ".php",
                    "<?require($_SERVER[\"DOCUMENT_ROOT\"].\"/bitrix/header.php\");$APPLICATION->SetTitle(\"Тест компонента без параметров: bitrix:" +
                    componentsFolder.ToString() + "\");?> <?$APPLICATION->IncludeComponent(\"bitrix:" + componentsFolder.ToString() +
                    "\", \"\", Array(), false);?><?require($_SERVER[\"DOCUMENT_ROOT\"].\"/bitrix/footer.php\");?>");
                if (MainForm.form.cbComponentsCheckPageOnErrors.Checked)
                    BitrixFramework.OpenURL(urlToCheck + "/ctest/" + componentsFolder.ToString() + ".php", false);
                else
                {
                    BitrixFramework.OpenURL(urlToCheck + "/ctest/" + componentsFolder.ToString() + ".php", false, false);
                    GM.CheckContentOnErrors();
                }
                Log.MesNormal("компонент - bitrix:" + componentsFolder.ToString() + " проверен");
            }

            Log.Gap();
            Log.MesNormal("Все компоненты проверены. Всего компонентов: " + folders.Count);
        }
    }
}
