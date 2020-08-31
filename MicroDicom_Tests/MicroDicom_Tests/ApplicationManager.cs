using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace MicroDicom_Tests
{
    public class ApplicationManager
    {
        public static string WINTITLE = "MicroDicom viewer (64 bit) unlicensed for commercial use";

        private Helper help;

        //открытие приложения
        public ApplicationManager()
        {
            App = Application.Launch(@"C:\Program Files\MicroDicom\mDicom.exe");
            MainWindow = App.GetWindow(WINTITLE);
            help = new Helper(this);
        }

        //закрытие приложения
        public void Stop()
        {
            App.Close();
        }

        public Window MainWindow { get; private set; }
        public Application App { get; set; }

        public Helper Help
        {
            get
            {
                return help;
            }


        }

    }
}

