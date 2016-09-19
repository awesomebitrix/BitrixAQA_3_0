using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using BitrixAQA.General;
using BitrixAQA.Selenium.General;
using System.IO;

namespace BitrixAQA
{    
    /// <summary>
    /// Класс формы настроек
    /// </summary>
    public partial class OptionsForm : Form
    {
        /// <summary>
        /// Форма настроек
        /// </summary>
        public static OptionsForm form;

        /// <summary>
        /// Форма настроек
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
            form = this;
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            Options.OptionsRead();
        }

        /// <summary>
        /// Метод вставляет в передаваемый текстбокс выбранную в файловом диалоге папку в формате "D:\BX\PHP5.UTF\wwwSOLUTIONS_mysql\"
        /// </summary>
        /// <param name="tb">имя текстбокса</param>
        public void PasteTextToTextBox(TextBox tb)
        {
            var folderBD = new FolderBrowserDialog();

            if (folderBD.ShowDialog() == DialogResult.OK)
            {
                tb.Text = (System.IO.Path.GetFullPath(folderBD.SelectedPath).Substring(System.IO.Path.GetFullPath(folderBD.SelectedPath).Length - 1) != @"\" ? tb.Text = System.IO.Path.GetFullPath(folderBD.SelectedPath) + @"\" : tb.Text = System.IO.Path.GetFullPath(folderBD.SelectedPath));
            }
        }

        /// <summary>
        /// Метод вставляет в передаваемый текстбокс выбранную в файловом диалоге папку в формате "D:\BX\PHP5.UTF\wwwSOLUTIONS_mysql\"
        /// </summary>
        /// <param name="tb">имя текстбокса</param>
        public void PasteTextToTextBoxFile(TextBox tb)
        {
            var file = new System.Windows.Forms.OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                tb.Text = file.FileName;
            }
        }
        
        #region кнопки диалогов
        private void bSelectMySQLPath_bb_Click(object sender, EventArgs e)
        { 
            PasteTextToTextBox(tbPathBB_mysql);
        }

        private void bSaveOptions_Click(object sender, EventArgs e)
        {
            Options.OptionsWrite();
            Close();
        }

        private void bAcceptOptions_Click(object sender, EventArgs e)
        {
            Options.OptionsWrite();
        }

        private void bCancelOptions_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
