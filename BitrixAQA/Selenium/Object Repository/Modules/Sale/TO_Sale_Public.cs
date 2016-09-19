using BitrixAQA.Selenium.Framework;
using OpenQA.Selenium;

namespace BitrixAQA.Selenium.Object_Repository
{
    /// <summary>
    /// Класс объектов в публичке магазина
    /// </summary>
    class TO_Sale_Public
    {
        /// <summary>
        /// Поле Местоположение (Выбор)
        /// </summary>
        public static WebItem TextBox_PlacementAddress
        {
            get
            {
                return new WebItem(By.XPath("//form//input[@class='bx-ui-combobox-fake']"), "Поле Местоположение (Выбор)");
            }
        }

        /// <summary>
        /// Поле Местоположение (Поиск)
        /// </summary>
        public static WebItem TextBox_PlacementAddressSearch
        {
            get
            {
                return new WebItem(By.XPath("//form//input[@class='bx-ui-sls-fake']"), "Поле Местоположение (Поиск)");
            }
        }
    }
}
