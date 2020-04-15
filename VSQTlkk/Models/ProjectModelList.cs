using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSQTlkk.Models
{
    class ProjectModelList : List<ProjectModel>
    {
        public ProjectModel Contains(string projectname)
        {
            ProjectModel dummy = new ProjectModel("false");

            if (this.Count == 0) return dummy;
            foreach (var x in this)
            {
                if(x.projectName == projectname)
                {
                    return x;
                }
            }
            return dummy;
        }
    }
}
