using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace VSQTlkk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static List<OlProject> globProjectList;
        //internal static List<OlProject> GlobProjectList { get => globProjectList; set => globProjectList = value; }

        public MainWindow()
        {
            
            InitializeComponent();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Outlook.Application application = new Outlook.Application();
            Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");


            Outlook.MAPIFolder oCalendar = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
            Outlook.Items allCalendarItems = oCalendar.Items;

            string filterrule = "[Start] >= '01/04/2020' AND [Start] <= '18/04/2020'";
            Outlook.Items resCalendarItems = allCalendarItems.Restrict(filterrule);

            resCalendarItems.Sort("[Start]");
            resCalendarItems.IncludeRecurrences = true;

            var i = 0;
            foreach(Outlook.AppointmentItem x in resCalendarItems){
                ListBoxItem itm = new ListBoxItem();
                itm.Content = x.Subject;
                testlist.Items.Insert(i,itm);
                i++;

                
                OlProject prj = new OlProject(x.Categories);

                globProjectList.Add(prj);

            }
        }
    }
}
