using System;
using System.Collections.Generic;
using BitrixAQA.General;
using BitrixAQA.Selenium.Framework;
using BitrixAQA.Selenium.General;

namespace BitrixAQA.Selenium.Test_Cases
{
    /// <summary>
    /// Тест проверки магазина
    /// </summary>
    class Case_Sale_Run
    {
        /// <summary>
        /// Общий раннер класса
        /// </summary>
        public static void Run()
        {
            Log.NodeOpen("тест Интернет-магазина");
            BitrixFramework.OpenURL("http://" + Options.GetOption("/Options/URLS/edition[@title='BB']/mysql"));
            Case_General_Login.Login(TestUsers.Admin.Login, TestUsers.Admin.Password);
            List<Action> TestCases = new List<Action>();
            TestCases.Add(() => Case_Sale_Placements.CheckSelectType());
            Shared.Execute(TestCases);

            Log.NodeClose();
        }
    }
}
