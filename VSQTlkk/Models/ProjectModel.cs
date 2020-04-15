using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSQTlkk
{
    class ProjectModel
    {
        private float[] _cwHours = new float[55];
        public float[] cwHours
        {
            get { return _cwHours; }
            set { _cwHours = value; }
        }


        private string _projectName;
        public string projectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        private string _projectAlias;
        public string projectAlias
        {
            get { return _projectAlias; }
            set { _projectAlias = value; }
        }



        List<string> workPackages;

        public ProjectModel(String name, DateTime wpstart, float duration)
        {
            CultureInfo cul = CultureInfo.CurrentCulture;
            int cwindex = cul.Calendar.GetWeekOfYear(wpstart, CalendarWeekRule.FirstDay,
             DayOfWeek.Monday);

            this.projectName = name;
            _cwHours[cwindex] = duration;

            Debug.WriteLine("Create");
            Debug.WriteLine(name);
            Debug.WriteLine(duration);
        }

        public ProjectModel(string name)
        {
            this.projectName = name;
        }

        public void SetCwHours(DateTime wpstart, float duration)
        {
            CultureInfo cul = CultureInfo.CurrentCulture;
            int cwindex = cul.Calendar.GetWeekOfYear(wpstart, CalendarWeekRule.FirstDay,
             DayOfWeek.Monday);

            this._cwHours[cwindex] = duration;

            Debug.WriteLine("Update");
            Debug.WriteLine(wpstart);
            Debug.WriteLine(duration);
        }
    }
}
