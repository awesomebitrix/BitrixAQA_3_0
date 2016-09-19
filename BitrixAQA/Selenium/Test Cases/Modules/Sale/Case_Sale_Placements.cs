using BitrixAQA.General;
using BitrixAQA.Selenium.General;
using BitrixAQA.Selenium.Framework;

namespace BitrixAQA.Selenium.Test_Cases
{
    /// <summary>
    /// Методы проверки местоположений
    /// </summary>
    class Case_Sale_Placements
    {
        /// <summary>
        /// Проверка типа выбора местоположения
        /// </summary>
        public static void CheckSelectType()
        {
            Log.NodeOpen("Проверка типа выбора местоположения");
            Case_Sale_Helper.ChangePlacementSelectType(false);
            Case_Sale_Helper.ValidatePlacementSelectType(false);
            BitrixFramework.Refresh();
            Case_Sale_Helper.ChangePlacementSelectType(true);
            Case_Sale_Helper.ValidatePlacementSelectType(true);
            Log.NodeClose();
        }
    }
}
