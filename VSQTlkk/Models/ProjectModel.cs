using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSQTlkk
{
    class ProjectModel
    {
        private List<float> _cwHours;
        public List<float> cwHours
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

        public ProjectModel(String name)
        {
            this.projectName = name;
        }
    }
}
