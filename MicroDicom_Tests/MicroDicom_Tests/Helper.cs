using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.WPFUIItems;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.ListBoxItems;

namespace MicroDicom_Tests
{
    public class Helper : HelperBase
    {
        public Helper(ApplicationManager manager) : base(manager)
        {
        }

        string path = @"C:\bmode.dcm";
        //string path = @"C:\Users\dyal\Downloads\39419238\20010101\MR3\10496";
        internal bool CheckFileIsLoaded()
        {
            OpenFile(path);
            try
            {
                var dialog = manager.MainWindow.ModalWindows().First();
                var a = dialog.Get<Label>();
                if (a.Text.Contains("Could not open"))
                {
                    return false;
                }
                return true;
            }

            catch (WhiteException e)
            {
                return false;
            }
            return true;
        }

        private void OpenFile(string path)
        {

            Panel p = manager.MainWindow.Get(SearchCriteria.ByAutomationId("59392")) as Panel; //ищем панель с кнопкой открытия файла
            p.Get(SearchCriteria.ByControlType((ControlType.MenuItem))).Click();//кликем по кнопке с открытием
            List<Window> modalWindows = manager.MainWindow.ModalWindows();//ловим модальный диалог  
            var combobox = modalWindows.First().Get(SearchCriteria.ByAutomationId("1148"));
            var textbox = combobox.Get<TextBox>("1148");
            textbox.SetValue(path);// вводим путь в поле
            manager.MainWindow.Get(SearchCriteria.ByText("Открыть")).Click();//жмем открыть
        }

        internal string SearchPatientId()
        {
            List<Window> modalWindows = manager.MainWindow.ModalWindows(); // ищем модальное окно со снимком
            var panel = modalWindows.First().Get<Panel>(SearchCriteria.ByAutomationId("200")); // панель с тэгами
            var tab = panel.Get<Tab>(SearchCriteria.ByAutomationId("1")); // вкладка с данными пациента
            var list = tab.Get<TestStack.White.UIItems.ListView>(SearchCriteria.ByAutomationId("1")); // список с данными
            var patientid = list.Rows[1].Cells[1].Text; // нам нужен второй элемент со вторым значение
            return patientid;
        }

        internal void AddAnnotation()
        {
           var panel =  manager.MainWindow.Get<Panel>(SearchCriteria.ByAutomationId("59419")); 
            var panel2 = panel.Get<Panel>(SearchCriteria.ByAutomationId("131")); // ищем панель с кнопкой добавления аннотации
            panel2.Get<Button>(SearchCriteria.ByText("Text")).Click(); // кликаем по кнопке

            List<Window> modalwindows = manager.MainWindow.ModalWindows();  //ищем модальное окно со снимком
            modalwindows.First().Get<Panel>(SearchCriteria.ByAutomationId("59648")).Click(); //на окне делаем клик
            var anndialog = manager.MainWindow.ModalWindow("Text annotation properties"); // ищем модальное окно с добавлением аннотации
            anndialog.Get<Button>(SearchCriteria.ByAutomationId("1")).Click(); // жмем ОК

        }
    }
}
