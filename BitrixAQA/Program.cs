using System;
using System.Windows.Forms;

namespace BitrixAQA
{
    static class Program
    {
       //public static MainForm mainForm;
        public static OptionsForm optionsForm = null;
        
        [STAThread]
        static void Main(string[] args=null)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
