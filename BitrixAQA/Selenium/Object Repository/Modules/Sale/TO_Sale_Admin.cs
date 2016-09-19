using BitrixAQA.Selenium.Framework;
using OpenQA.Selenium;

namespace BitrixAQA.Selenium.Object_Repository
{
    /// <summary>
    /// Класс объектов в админке магазина
    /// </summary>
    class TO_Sale_Admin
    {
        /// <summary>
        /// выпадающий список Статус заказа
        /// </summary>
        public static WebItem Dropdown_Status
        {
            get
            {
                return new WebItem(By.XPath("//select[@id='STATUS_ID']"), "выпадающий список Статус заказа");
            }
        }

        /// <summary>
        /// Чекбокс отменен
        /// </summary>
        public static WebItem CheckBox_Cancelled
        {
            get
            {
                return new WebItem(By.XPath("//label[@for='CANCELED']"), "Чекбокс отменен");
            }
        }

        /// <summary>
        /// Чекбокс отменен(отмеченный)
        /// </summary>
        public static WebItem CheckBox_Cancelled_Checked
        {
            get
            {
                return new WebItem(By.XPath("//label[@for='CANCELED']//..//input[@checked='']"), "Чекбокс отменен(отмеченный)");
            }
        }

        /// <summary>
        /// Чекбокс доставка разрешена
        /// </summary>
        public static WebItem CheckBox_AllowDelivery
        {
            get
            {
                return new WebItem(By.XPath("//label[@for='ALLOW_DELIVERY']"), "Чекбокс доставка разрешена");
            }
        }

        /// <summary>
        /// Чекбокс доставка разрешена(отмеченный)
        /// </summary>
        public static WebItem CheckBox_AllowDelivery_Checked
        {
            get
            {
                return new WebItem(By.XPath("//label[@for='ALLOW_DELIVERY']//..//input[@checked='']"), "Чекбокс доставка разрешена(отмеченный)");
            }
        }

        /// <summary>
        /// Область заказ оплачен
        /// </summary>
        public static WebItem Region_Payed
        {
            get
            {
                return new WebItem(By.XPath("//span[contains(@id, 'BUTTON_PAID_')]"), "Область заказ оплачен");
            }
        }

        /// <summary>
        /// Область заказ оплачен
        /// </summary>
        public static WebItem Region_PayedChange
        {
            get
            {
                return new WebItem(By.XPath("//span[contains(@id, 'BUTTON_PAID_')]//..//span[@class='triangle']"), "Область заказ оплачен");
            }
        }

        /// <summary>
        /// Область Доставка разрешена
        /// </summary>
        public static WebItem Region_DeliveredChange
        {
            get
            {
                return new WebItem(By.XPath("//span[contains(@id, 'BUTTON_ALLOW_DELIVERY_')]//..//span[@class='triangle']"), "Область Доставка разрешена");
            }
        }

        /// <summary>
        /// Область Отгрузка
        /// </summary>
        public static WebItem Region_DeductedChange
        {
            get
            {
                return new WebItem(By.XPath("//span[contains(@id, 'BUTTON_DEDUCTED_')]//..//span[@class='triangle']"), "Область Отгрузка");
            }
        }

        /// <summary>
        /// Кнопка редактирования оплаты
        /// </summary>
        public static WebItem Button_EditPayed
        {
            get
            {
                return new WebItem(By.XPath("//div[@class='adm-bus-component-title' and contains(text(), 'Оплата')]//..//..//div[@class='adm-bus-pay-section-action']" +
                    "//a[contains(text(), 'Редактировать')]"), "Кнопка редактирования оплаты");
            }
        }

        /// <summary>
        /// Кнопка редактирования доставки
        /// </summary>
        public static WebItem Button_EditDelivered
        {
            get
            {
                return new WebItem(By.XPath("//div[@class='adm-bus-component-title' and contains(text(), 'Отгрузка')]//..//..//div[@class='adm-bus-pay-section-action']" +
                    "//a[contains(text(), 'Редактировать')]"), "Кнопка редактирования доставки");
            }
        }

        /// <summary>
        /// Чекбокс заказ оплачен
        /// </summary>
        public static WebItem CheckBox_Payed
        {
            get
            {
                return new WebItem(By.XPath("//label[@class='adm-designed-checkbox-label' and @for='PAYED']"), "Чекбокс заказ оплачен");
            }
        }

        /// <summary>
        /// Чекбокс заказ оплачен(отмеченный)
        /// </summary>
        public static WebItem CheckBox_Payed_Checked
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(), 'Заказ оплачен')]//..//input[@name='PAYED' and @checked='']"), "Чекбокс заказ оплачен(отмеченный)");
            }
        }

        /// <summary>
        /// Чекбокс Оплатить с личного счета
        /// </summary>
        public static WebItem CheckBox_PayedCurrent
        {
            get
            {
                return new WebItem(By.XPath("//label[@class='adm-designed-checkbox-label' and @for='PAY_CURRENT_ACCOUNT']"), "Чекбокс Оплатить с личного счета");
            }
        }

        /// <summary>
        /// Чекбокс Вернуть средства на внутренний счет
        /// </summary>
        public static WebItem CheckBox_PayBack
        {
            get
            {
                return new WebItem(By.XPath("//label[@class='adm-designed-checkbox-label' and @for='PAY_FROM_ACCOUNT_BACK']"), "Чекбокс Вернуть средства на внутренний счет");
            }
        }

        /// <summary>
        /// Чекбокс отгрузить заказ
        /// </summary>
        public static WebItem CheckBox_Deducted
        {
            get
            {
                return new WebItem(By.XPath("//label[@for='DEDUCTED']"), "Чекбокс отгрузить заказ");
            }
        }

        /// <summary>
        /// Чекбокс отгрузить заказ(отмеченный)
        /// </summary>
        public static WebItem CheckBox_Deducted_Checked
        {
            get
            {
                return new WebItem(By.XPath("//label[@for='DEDUCTED']//..//input[@checked='']"), "Чекбокс отгрузить заказ(отмеченный)");
            }
        }

        /// <summary>
        /// Кнопка Добавить заказ
        /// </summary>
        public static WebItem Button_Add
        {
            get
            {
                return new WebItem(By.XPath("//a[@id='btn_new']"), "Кнопка Добавить");
            }
        }

        /// <summary>
        /// Кнопка Развернуть товар
        /// </summary>
        /// <param name="Product">Товар</param>
        public static WebItem Button_ShowProduct(string Product)
        {
            return new WebItem(By.XPath("//td[contains(text(), '" + Product + "')]//..//input[contains(@name, 'btn_show_sku_')]"), "Кнопка Развернуть товар " + Product);
        }

        /// <summary>
        /// Кнопка Развернуть
        /// </summary>
        public static WebItem Button_SKUExpand
        {
            get
            {
                return new WebItem(By.XPath("//a[@class='expand-sku']"), "Кнопка Развернуть");
            }
        }

        /// <summary>
        /// Кнопка Выбрать товар
        /// </summary>
        /// <param name="Product">Товар</param>
        public static WebItem Button_SelectProductMenu(string Product)
        {
            return new WebItem(By.XPath("//a[@class='adm-list-table-link' and contains(text(), '" + Product + "')]//..//..//div[@class='adm-list-table-popup' and @title='Действия']"),
                "Кнопка Выбрать товар " + Product);
        }

        /// <summary>
        /// Кнопка Выбрать SKU
        /// </summary>
        /// <param name="Product">Товар</param>
        public static WebItem Button_SelectSKUMenu(string Product)
        {
            return new WebItem(By.XPath("//div[@class='sku-item-name' and contains(text(), ': " + Product + "')]//..//..//div[@class='adm-list-table-popup' and @title='Действия']"),
                "Кнопка Выбрать SKU " + Product);
        }

        /// <summary>
        /// Кнопка закрыть
        /// </summary>
        public static WebItem Button_ClosePage
        {
            get
            {
                return new WebItem(By.XPath("//div[@id='bx-admin-prefix' and contains(@style, 'display: block;')]//span[@class='bx-core-adm-icon-close']"), "Кнопка закрыть");
            }
        }

        /// <summary>
        /// Кнопка Выбрать товар
        /// </summary>
        /// <param name="Product">Товар</param>
        public static WebItem Button_SelectProduct(string Product)
        {
            return new WebItem(By.XPath("//td[contains(text(), '" + Product + "')]//..//input[@class='addBtn']"), "Кнопка Выбрать товар " + Product);
        }

        /// <summary>
        /// Кнопка Выбрать SKU
        /// </summary>
        /// <param name="SKU">Товар</param>
        public static WebItem Button_SelectSKU(string SKU)
        {
            return new WebItem(By.XPath("//tr[@class='adm-list-table-row border_sku']//td[contains(text(), '" + SKU + "')]//..//input[@class='addBtn']"),
                "Кнопка Выбрать SKU " + SKU);
        }

        /// <summary>
        /// выпадающий список тип плательщика в заказе
        /// </summary>
        public static WebItem Dropdown_PayerType
        {
            get
            {
                return new WebItem(By.XPath("//select[@id='PERSON_TYPE_ID']"), "выпадающий список тип плательщика в заказе");
            }
        }

        /// <summary>
        /// страна в выпадающием списке
        /// </summary>
        /// <param name="Country">Валюта</param>
        public static WebItem Region_OptionCountry(string Country)
        {
            return new WebItem(By.XPath("//select[@name='ORDER_PROP_6CITY_ORDER_PROP_6']//option[contains(text(),'" + Country + "')]"), "страна в выпадающием списке");
        }

        /// <summary>
        /// город в выпадающием списке
        /// </summary>
        /// <param name="City">Город</param>
        public static WebItem Region_OptionCity(string City)
        {
            return new WebItem(By.XPath("//select[@name='CITY_ORDER_PROP_6']//option[contains(text(),'" + City + "')]"), "город в выпадающием списке");
        }

        /// <summary>
        /// выпадающий список город
        /// </summary>
        public static WebItem Dropdown_OptionCity
        {
            get
            {
                return new WebItem(By.XPath("//select[@name='CITY_ORDER_PROP_6']"), "выпадающий список город");
            }
        }

        /// <summary>
        /// Кнопка Сохранить поставщика
        /// </summary>
        public static WebItem Button_Save
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='save']"), "Кнопка Сохранить");
            }
        }

        /// <summary>
        /// Кнопка Добавить товар
        /// </summary>
        public static WebItem Button_AddProduct
        {
            get
            {
                return new WebItem(By.XPath("//div[contains(text(), 'Состав заказа')]//span[@class='adm-btn adm-btn-green adm-btn-add']"), "Кнопка Добавить товар");
            }
        }

        /// <summary>
        /// Кнопка Добавить товар
        /// </summary>
        public static WebItem Button_AddProduct_ToOrder
        {
            get
            {
                return new WebItem(By.XPath("//td[text()='Состав заказа']//..//a[@class='adm-btn adm-btn-green adm-btn-add']"), "Кнопка Добавить товар");
            }
        }

        /// <summary>
        /// Кнопка Найти покупателя
        /// </summary>
        public static WebItem Button_FindBuyer
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='FIND_BUYER']"), "Кнопка Найти покупателя");
            }
        }

        /// <summary>
        /// Кнопка меню покупателя
        /// </summary>
        /// <param name="Name">Покупатель</param>
        public static WebItem Button_MenuBuyer(string Name)
        {
            return new WebItem(By.XPath("//td[contains(text(), '" + Name + "')]//..//td[@class='adm-list-table-cell adm-list-table-popup-block']"), "Кнопка меню покупателя "+ Name);
        }

        /// <summary>
        /// текстовое поле Название
        /// </summary>
        public static WebItem Textbox_DiscountNameInFilter
        {
            get
            {
                return new WebItem(By.XPath("//input[@id='tbl_product_search_discount_query']"), "текстовое поле Название");
            }
        }

        /// <summary>
        /// текстовое поле Название
        /// </summary>
        public static WebItem Textbox_NameInFilter
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='filter_product_name']"), "текстовое поле Название");
            }
        }

        /// <summary>
        /// текстовое поле Название
        /// </summary>
        public static WebItem Textbox_NameInFilter_Doc
        {
            get
            {
                return new WebItem(By.XPath("//input[@id='tbl_product_search_storeDocs_query']"), "текстовое поле Название");
            }
        }

        /// <summary>
        /// текстовое поле Название
        /// </summary>
        public static WebItem Textbox_NameInFilter_Order
        {
            get
            {
                return new WebItem(By.XPath("//input[@id='tbl_product_search_order_edit_query']"), "текстовое поле Название");
            }
        }

        /// <summary>
        /// Поле количество на складе
        /// </summary>
        public static WebItem CheckBox_DeductAmount
        {
            get
            {
                return new WebItem(By.XPath("//div[contains(@id, 'store_amount_wrapper_')]//input"), "Поле количество на складе");
            }
        }

        /// <summary>
        /// текстовое поле Название
        /// </summary>
        public static WebItem Textbox_FindName
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='find_name']"), "текстовое поле Название");
            }
        }


        /// <summary>
        /// область с добавленными товарами в заказе
        /// </summary>
        public static WebItem Region_BasketOrder
        {
            get
            {
                return new WebItem(By.XPath("//table[contains(@id, '_product_table')]"), "область с добавленными товарами в заказе");
            }
        }

        /// <summary>
        /// область с cуммой в заказе
        /// </summary>
        public static WebItem Region_OrderSummary
        {
            get
            {
                return new WebItem(By.XPath("//table[@class='adm-s-result-container-itog-table']"), "область с cуммой в заказе");
            }
        }

        /// <summary>
        /// Кнопка развернуть
        /// </summary>
        /// <param name="Complect">Комплект</param>
        public static WebItem Button_OpenHidden(string Complect)
        {
            return new WebItem(By.XPath("//a[@class='name-link ' and contains(text(), '" + Complect + "')]//..//a[@class='dashed-link show-set-link']"), "Кнопка развернуть");
        }

        /// <summary>
        /// Кнопка развернуть
        /// </summary>
        public static WebItem Button_OpenHiddenComlect
        {
            get
            {
                return new WebItem(By.XPath("//a[@class='dashed-link show-set-link' and text()='Развернуть']"), "Кнопка развернуть");
            }
        }

        /// <summary>
        /// область с товарами в заказе
        /// </summary>
        public static WebItem Region_ProDuctInOrder
        {
            get
            {
                return new WebItem(By.XPath("//table[contains(@id, '_product_table')]"), "область с товарами в заказе");
            }
        }

        /// <summary>
        /// текствое поле количество товара в заказе
        /// </summary>
        /// <param name="nameProduct">Товар</param>
        public static WebItem Textbox_Quantity(string nameProduct)
        {
            return new WebItem(By.XPath("//table[contains(@id, '_product_table')]//a[contains(text(), '" + nameProduct + "')]//..//..//input[contains(@name, '[QUANTITY]')]"),
                "текствое поле количество товара '" + nameProduct + "' в заказе");
        }

        /// <summary>
        /// выпадающий список Служба доставки
        /// </summary>
        public static WebItem Dropdown_Delivery
        {
            get
            {
                return new WebItem(By.XPath("//select[contains(@id, 'DELIVERY')]"), "выпадающий список Служба доставки");
            }
        }

        /// <summary>
        /// текстовое поле Стоимость доставки
        /// </summary>
        public static WebItem Textbox_PriceDelivery
        {
            get
            {
                return new WebItem(By.XPath("//input[@id='DELIVERY_ID_PRICE']"), "текстовое поле Стоимость доставки");
            }
        }

        /// <summary>
        /// текстовое поле Промо код
        /// </summary>
        public static WebItem Textbox_Coupon
        {
            get
            {
                return new WebItem(By.XPath("//input[@id='sale-admin-order-coupons']"), "текстовое поле Промо код");
            }
        }

        /// <summary>
        /// Кнопка добавить
        /// </summary>
        public static WebItem Button_AddCoupon
        {
            get
            {
                return new WebItem(By.XPath("//input[@class='bx-adm-pc-input-submit']"), "Кнопка добавить");
            }
        }

        /// <summary>
        /// текстовое поле Адрес доставки
        /// </summary>
        public static WebItem Textbox_ShippingAddress
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(),'Адрес доставки')]//..//textarea"), "текстовое поле Адрес доставки");
            }
        }

        /// <summary>
        /// выпадающий список страна
        /// </summary>
        public static WebItem Dropdown_Country
        {
            get
            {
                return new WebItem(By.XPath("//select[@name='ORDER_PROP_6CITY_ORDER_PROP_6']"), "выпадающий список регион");
            }
        }

        /// <summary>
        /// выпадающий список страна
        /// </summary>
        public static WebItem Dropdown_Country_Company
        {
            get
            {
                return new WebItem(By.XPath("//select[@name='ORDER_PROP_18CITY_ORDER_PROP_18']"), "выпадающий список регион");
            }
        }

        /// <summary>
        /// выпадающий список регион
        /// </summary>
        public static WebItem Dropdown_Region
        {
            get
            {
                return new WebItem(By.XPath("//select[@name='REGION_ORDER_PROP_6CITY_ORDER_PROP_6']"), "выпадающий список регион");
            }
        }

        /// <summary>
        /// выпадающий список город
        /// </summary>
        public static WebItem Dropdown_City
        {
            get
            {
                return new WebItem(By.XPath("//select[contains(@name, 'CITY_') and @onchange='fChangeLocationCity();']"), "выпадающий список город");
            }
        }

        /// <summary>
        /// выпадающий список Способ оплаты
        /// </summary>
        public static WebItem Dropdown_PaySystem
        {
            get
            {
                return new WebItem(By.XPath("//select[contains(@id, 'PAY_SYSTEM_ID')]"), "выпадающий список Способ оплаты");
            }
        }

        /// <summary>
        /// текстовое поле Ф.И.О.
        /// </summary>
        public static WebItem Textbox_FIO
        {
            get
            {
                return new WebItem(By.XPath("//table[@class='adm-detail-content-table edit-table']//td[contains(text(), 'Ф.И.О.')]//..//input"), "текстовое поле Ф.И.О.");
            }
        }

        /// <summary>
        /// текстовое поле E-Mail
        /// </summary>
        public static WebItem Textbox_Email
        {
            get
            {
                return new WebItem(By.XPath("//table[@class='adm-detail-content-table edit-table']//td[contains(text(), 'E-Mail')]//..//input"), "текстовое поле E-Mail");
            }
        }

        /// <summary>
        /// текстовое поле E-Mail
        /// </summary>
        public static WebItem Textbox_EmailDelivery
        {
            get
            {
                return new WebItem(By.XPath("//table[@class='adm-detail-content-table edit-table']//td[contains(text(), 'E-Mail')]//..//input[@name='PROPERTIES[13]']"), "текстовое поле E-Mail");
            }
        }

        /// <summary>
        /// текстовое поле Телефон
        /// </summary>
        public static WebItem Textbox_Phone
        {
            get
            {
                return new WebItem(By.XPath("//table[@class='adm-detail-content-table edit-table']//td[contains(text(), 'Телефон')]//..//input"), "текстовое поле Телефон");
            }
        }

        /// <summary>
        /// текстовое поле Название компании
        /// </summary>
        public static WebItem Textbox_CompanyName
        {
            get
            {
                return new WebItem(By.XPath("//table[@class='adm-detail-content-table edit-table']//td[contains(text(), 'Название компании')]//..//input"), "текстовое поле Название компании");
            }
        }

        /// <summary>
        /// текстовое поле Контактное лицо
        /// </summary>
        public static WebItem Textbox_ContactPerson
        {
            get
            {
                return new WebItem(By.XPath("//table[@class='adm-detail-content-table edit-table']//td[contains(text(), 'Контактное лицо')]//..//input"), "текстовое поле Контактное лицо");
            }
        }

        /// <summary>
        /// Кнопка изменить заказ
        /// </summary>
        public static WebItem Button_EditOrder
        {
            get
            {
                return new WebItem(By.XPath("//a[@class='adm-btn' and contains(text(), 'Изменить заказ')]"), "Кнопка изменить заказ");
            }
        }

        /// <summary>
        /// Кнопка печать заказа
        /// </summary>
        public static WebItem Button_PrintOrder
        {
            get
            {
                return new WebItem(By.XPath("//a[text()='Печать заказа']"), "Кнопка печать заказа");
            }
        }

        /// <summary>
        /// Область с сообщением
        /// </summary>
        public static WebItem Region_Message
        {
            get
            {
                return new WebItem(By.XPath("//div[@class='adm-info-message-title']"), "Область с сообщением");
            }
        }

        /// <summary>
        /// текстовое поле новое имя
        /// </summary>
        public static WebItem Textbox_NewName
        {
            get
            {
                return new WebItem(By.XPath("//input[@name ='BREAK_NAME']"), "текстовое поле новое имя");
            }
        }

        /// <summary>
        /// текстовое поле новая фамилия
        /// </summary>
        public static WebItem Textbox_NewLastName
        {
            get
            {
                return new WebItem(By.XPath("//input[@name ='BREAK_LAST_NAME']"), "текстовое поле новая фамилия");
            }
        }

        /// <summary>
        /// текстовое поле новое отчество
        /// </summary>
        public static WebItem Textbox_NewSecondName
        {
            get
            {
                return new WebItem(By.XPath("//input[@name ='BREAK_SECOND_NAME']"), "текстовое поле новое отчество");
            }
        }

        /// <summary>
        /// текстовое поле новая почта
        /// </summary>
        public static WebItem Textbox_NewEmail
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(), 'E-Mail')]//..//input"), "текстовое поле новая почта");
            }
        }

        /// <summary>
        /// текстовое поле новый телефон
        /// </summary>
        public static WebItem Textbox_NewPhone
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(), 'Телефон')]//..//input"), "текстовое поле новый телефон");
            }
        }

        /// <summary>
        /// текстовое поле новое название компании
        /// </summary>
        public static WebItem Textbox_NewCompanyName
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(), 'Название компании')]//..//input"), "текстовое поле новое название компании");
            }
        }

        /// <summary>
        /// текстовое поле новое имя
        /// </summary>
        public static WebItem Textbox_NewName_Buyer
        {
            get
            {
                return new WebItem(By.XPath("//input[@name ='BREAK_NAME_BUYER']"), "текстовое поле новое имя");
            }
        }

        /// <summary>
        /// Кнопка Настроить интеграцию с CRM
        /// </summary>
        public static WebItem Button_IntegrateCRM
        {
            get
            {
                return new WebItem(By.XPath("//a[text()='Настроить интеграцию с CRM']"), "Кнопка Настроить интеграцию с CRM");
            }
        }

        /// <summary>
        /// Выпадающий список Адрес сайта CRM
        /// </summary>
        public static WebItem DropDown_UrlScheme
        {
            get
            {
                return new WebItem(By.XPath("//select[@name='CRM_URL_SCHEME']"), "Выпадающий список Адрес сайта CRM");
            }
        }

        /// <summary>
        /// текстовое поле Адрес сайта CRM
        /// </summary>
        public static WebItem Textbox_CRMUrlServer
        {
            get
            {
                return new WebItem(By.XPath("//input[@name ='CRM_URL_SERVER']"), "текстовое поле Адрес сайта CRM");
            }
        }

        /// <summary>
        /// текстовое поле Логин администратора CRM
        /// </summary>
        public static WebItem Textbox_CRMUserLogin
        {
            get
            {
                return new WebItem(By.XPath("//input[@name ='CRM_LOGIN']"), "текстовое поле Логин администратора CRM");
            }
        }

        /// <summary>
        /// текстовое поле Пароль администратора CRM
        /// </summary>
        public static WebItem Textbox_CRMUserPassword
        {
            get
            {
                return new WebItem(By.XPath("//input[@name ='CRM_PASSWORD']"), "текстовое поле Пароль администратора CRM");
            }
        }

        /// <summary>
        /// Кнопка Настроить интеграцию
        /// </summary>
        public static WebItem Button_SetIntegration
        {
            get
            {
                return new WebItem(By.XPath("//a[text()='Настроить интеграцию']"), "Кнопка Настроить интеграцию");
            }
        }

        /// <summary>
        /// Кнопка Настроить параметры и импортировать данные
        /// </summary>
        public static WebItem Button_SetIntegrationProperties
        {
            get
            {
                return new WebItem(By.XPath("//a[text()='Настроить параметры и импортировать данные']"), "Кнопка Настроить параметры и импортировать данные");
            }
        }

        /// <summary>
        /// Кнопка Далее
        /// </summary>
        public static WebItem Button_Next
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='btn-next']"), "Кнопка Далее");
            }
        }

        /// <summary>
        /// Область соообщения об импорте
        /// </summary>
        public static WebItem Region_ImportMessagge
        {
            get
            {
                return new WebItem(By.XPath("//form[@method='post']"), "Область соообщения об импорте");
            }
        }

        /// <summary>
        /// Кнопка сбросить статистику
        /// </summary>
        public static WebItem Button_IntegrationReset
        {
            get
            {
                return new WebItem(By.XPath("//a[@class='crm-admin-reset']"), "Кнопка сбросить статистику");
            }
        }

        /// <summary>
        /// Поле количество
        /// </summary>
        public static WebItem Textbox_AmountInPrint
        {
            get
            {
                return new WebItem(By.XPath("//input[contains(@name, 'QUANTITY_')]"), "Поле количество");
            }
        }

        /// <summary>
        /// Поле Итого
        /// </summary>
        public static WebItem Textbox_TotalInPrint
        {
            get
            {
                return new WebItem(By.XPath("//td[contains(text(), 'Итого:')]//..//td[@align='left']"), "Поле Итого");
            }
        }

        /// <summary>
        /// Выпадающий список Шаблон документа
        /// </summary>
        public static WebItem DropDown_SelectPrint
        {
            get
            {
                return new WebItem(By.XPath("//select[contains(@name, 'REPORT_ID')]"), "Выпадающий список Шаблон документа");
            }
        }

        /// <summary>
        /// Кнопка печать
        /// </summary>
        public static WebItem Button_Print
        {
            get
            {
                return new WebItem(By.XPath("//input[@class='button' and @value='Печать']"), "Кнопка печать");
            }
        }

        /// <summary>
        /// Кнопка сохранить
        /// </summary>
        public static WebItem Button_PayOrder
        {
            get
            {
                return new WebItem(By.XPath("//div[@id='сохранить']//span[text()='Сохранить']"), "Кнопка сохранить");
            }
        }

        /// <summary>
        /// Поле Фамилия
        /// </summary>
        public static WebItem Textbox_LastName
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='NEW_BUYER_LAST_NAME']"), "Поле Фамилия");
            }
        }

        /// <summary>
        /// Поле Имя
        /// </summary>
        public static WebItem Textbox_Name
        {
            get
            {
                return new WebItem(By.XPath("//input[@name='NEW_BUYER_NAME']"), "Поле Имя");
            }
        }

        /// <summary>
        /// Кнопка Открепить панель в заказе
        /// </summary>
        public static WebItem Button_UnpinOrder
        {
            get
            {
                return new WebItem(By.XPath("//div[@class='adm-detail-pin-btn-tabs' and @title='Открепить панель']"), "Кнопка Открепить панель в заказе");
            }
        }
    }
}
