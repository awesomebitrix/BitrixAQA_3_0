using BitrixAQA.Selenium.Framework;
using OpenQA.Selenium;

namespace BitrixAQA.Selenium.Object_Repository
{
    /// <summary>
    /// Класс объектов для местоположений
    /// </summary>
    class TO_Sale_Placements
    {
        /// <summary>
        /// Выпадающий список Тип виджета местоположений
        /// </summary>
        public static WebItem DropDown_PlacementsSelectType
        {
            get
            {
                return new WebItem(By.XPath("//select[@name='sale_location_selector_appearance']"), "Выпадающий список Тип виджета местоположений");
            }
        }

        /// <summary>
        /// Опция выпадающего списка
        /// </summary>
        /// <param name="option">Опция</param>
        public static WebItem Button_Option(string option)
        {
            return new WebItem(By.XPath("//option[@value='" + option + "']"), "Опция выпадающего списка");
        }

        /// <summary>
        /// Область местоположений
        /// </summary>
        public static WebItem Region_Placements
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(), 'Настройки местоположений')]"), "Область местоположений");
            }
        }
        
    }
}
