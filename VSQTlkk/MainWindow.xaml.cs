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
using VSQTlkk.Models;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace VSQTlkk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //internal static List<OlProject> GlobProjectList { get => globProjectList; set => globProjectList = value; }

        public MainWindow()
        {

            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime datestart = (DateTime)StartDateCalendar.SelectedDate;
            DateTime dateend = (DateTime)EndDateCalendar.SelectedDate;
            OutlookReader reader = new OutlookReader(datestart,dateend);

            List<ProjectModel> lst = reader.olProjectList;

            foreach (ProjectModel x in lst){
                ListBoxItem itm = new ListBoxItem();
                itm.Content = x.projectName;
                testlist.Items.Add(itm);

            }



        }
    }
}
