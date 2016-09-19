using BitrixAQA.General;
using BitrixAQA.Selenium.Framework;
using BitrixAQA.Selenium.Object_Repository;
using BitrixAQA.Selenium.Test_Cases;

namespace BitrixAQA.Selenium.General
{
    /// <summary>
    /// Класс вспомогательных методов для теста магазина
    /// </summary>
    class Case_Sale_Helper
    {
        /// <summary>
        /// Удаление данных магазина
        /// </summary>
        public static void DeleteAllData()
        {
            BitrixFramework.Wait(3);
            string PHPCommand =
            Case_Sale_Helper.DeleteInnerAccounts(true) +
            Case_Sale_Helper.DeleteTaxRate(true);
            GM.RunPHPCommand(PHPCommand);
        }

        #region Методы удаления сущностей PHP скриптами
        /// <summary>
        /// метод удаляет все ставки налогов
        /// </summary>
        /// <param name="JustReturn">Если true - возврощает только текст PHP команды, но не выполняет её</param>
        public static string DeleteTaxRate(bool JustReturn = false)
        {
            string PHPCommand = "CModule::IncludeModule(\"sale\");$dbTax = CSaleTaxRate::GetList(array());" +
                "while ($arTax = $dbTax->Fetch()){CSaleTaxRate::Delete($arTax[\"ID\"]);}";
            if (!JustReturn)
                GM.RunPHPCommand(PHPCommand);
            return PHPCommand;
        }

        /// <summary>
        /// метод удаляет все продления подписки
        /// </summary>
        /// <param name="JustReturn">Если true - возврощает только текст PHP команды, но не выполняет её</param>
        public static string DeleteInnerAccounts(bool JustReturn = false)
        {
            string PHPCommand = "CModule::IncludeModule(\"sale\");$dbAccounts = CSaleUserAccount::GetList(array(), array(), false, array(), array());" +
                "while ($arAccounts = $dbAccounts->Fetch()){CSaleUserAccount::Delete($arAccounts[\"ID\"]);}";
            if (!JustReturn)
                GM.RunPHPCommand(PHPCommand);
            return PHPCommand;
        }
        #endregion

        /// <summary>
        /// Проверка типа выбора местоположения
        /// </summary>
        /// <param name="isList">Список или поиск</param>
        public static void ValidatePlacementSelectType(bool isList)
        {
            Case_Main.OpenSale();
            TO_AdminLeftMenu.Region_Admin_Menu("Заказы").ClickAndWait();
            TO_Sale_Admin.Button_Add.ClickAndWait();
            if (TO_Sale_Admin.Button_UnpinOrder.Exists())
                TO_Sale_Admin.Button_UnpinOrder.ClickAndWait();
            if (isList)
                TO_Sale_Public.TextBox_PlacementAddress.Displayed("В заказе местоположения выбираются через выпадающие списки", "В заказе местоположения не выбираются через выпадающие списки");
            else
                TO_Sale_Public.TextBox_PlacementAddressSearch.Displayed("В заказе местоположения выбираются через строку поиска", "В заказе местоположения не выбираются через строку поиска");
        }

        /// <summary>
        /// Смена типа выбора местоположения
        /// </summary>
        /// <param name="isList">Список или поиск</param>
        public static void ChangePlacementSelectType(bool isList)
        {
            Case_Main.OpenAdmin();
            BitrixFramework.Wait(2);
            Case_Main.OpenSettings();
            Case_Main.OpenSettings();
            Case_Main.AdminLeftSubMenu("Настройки продукта", "Настройки модулей");
            Case_Main.AdminLeftSubSubMenu("Настройки модулей", "Интернет-магазин");
            TO_Sale_Placements.Region_Placements.Scroll();
            if (isList)
            {
                TO_Sale_Placements.DropDown_PlacementsSelectType.SendKeys(OpenQA.Selenium.Keys.Home, false);
                Log.MesPass("Установлен тип выбора местоположения выпадающие списки");
            }
            else
            {
                TO_Sale_Placements.DropDown_PlacementsSelectType.SendKeys(OpenQA.Selenium.Keys.End, false);
                Log.MesPass("Установлен тип выбора местоположения выпадающие строка поиска");
            }
            TO_Main.Button_Update().ClickAndWait();
            BitrixFramework.Wait(5);
        }
    }
}
