using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using VSQTlkk.Models;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace VSQTlkk
{
    class OutlookReader : MainWindow
    {
        private ProjectModelList _olProjectList = new ProjectModelList();
        public ProjectModelList olProjectList
        {
            get { return _olProjectList; }
            set { _olProjectList = value; }
        }



        public OutlookReader(DateTime start, DateTime end)
        {
            Outlook.Application application = new Outlook.Application();
            Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");

            

            Outlook.MAPIFolder oCalendar = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
            Outlook.Items allCalendarItems = oCalendar.Items;

            allCalendarItems.Sort("[Start]");
            allCalendarItems.IncludeRecurrences = true;

            string filterrule; //= "[Start] >= '01/04/2020' AND [Start] <= '12/04/2020'";
            filterrule = "[Start] >= '" + start.Day + "/" + start.Month + "/" + start.Year + "'"
                + " and [Start] <= '" + end.Day + "/" + end.Month + "/" + end.Year + "'";
            Outlook.Items resCalendarItems = allCalendarItems.Restrict(filterrule);

            var i = 0;
            foreach (Outlook.AppointmentItem x in resCalendarItems)
            {
                if (x.Categories != null)
                {
                    var itemcats = x.Categories;
                    //ProjectModel prj = new ProjectModel(x.Categories);
                    //_olProjectList.Add(prj);
                    if (itemcats.Contains(";"))
                    {
                        List<string> itemCatsList = Regex.Split(x.Categories, "; ").ToList<string>();
                        foreach (var itemCat in itemCatsList)
                        {
                            if (_olProjectList.Contains(itemCat).projectName=="false")
                            {
                                ProjectModel prj = new ProjectModel(itemCat, x.Start, x.Duration/itemCatsList.Count);
                                _olProjectList.Add(prj);
                            }
                            else
                            {
                                _olProjectList.Contains(itemCat).SetCwHours(x.Start, x.Duration/itemCatsList.Count);
                            }
                        }
                    }
                    
                    
                }
            }
        }
    }
}