using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aqua.Selenium.SeleniumFramework;
using OpenQA.Selenium;
using Aqua.General;


namespace Aqua.Selenium.Object_Repository
{
    class TO_Reports
    {
        /// <summary>
        /// Кнопка Создать типовые отчеты
        /// </summary>
        public static WebItem Button_CreateReports
        {
            get
            {
                return new WebItem(By.XPath("//input[@class='adm-btn-save' and @value='Создать типовые отчеты']"), "Кнопка Создать типовые отчеты");
            }
        }

        /// <summary>
        /// Кнопка открыть отчёт
        /// </summary>
        public static WebItem Button_OpenReport(string ReportName)
        {
            return new WebItem(By.XPath("//td[contains(@class, 'adm-list-table-cell')]//a[starts-with(text(),'" + ReportName + "')]//..//..//div[@class='adm-list-table-popup']"), "Кнопка открыть отчёт " + ReportName);
        }

        /// <summary>
        /// Список фильтрации по складам
        /// </summary>
        public static WebItem Dropdown_StoreFilter
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(),'Склад \"равно\":')]//..//select"), "Список фильтрации по складам");
            }
        }

        /// <summary>
        ///Кнопка Найти
        /// </summary>
        public static WebItem Button_FilterFind
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='set_filter']"), "Кнопка Найти");
            }
        }

        /// <summary>
        ///Строка в отчете
        /// </summary>
        public static WebItem Region_ReportDataRow(int Index)
        {
            return new WebItem(By.XPath("//div[@class='reports-grouping-table-wrap']//tr[@class='adm-list-table-header reports-grouping-data-row'][" + Index + "]"), "Строка в отчете");
        }
    }
}
