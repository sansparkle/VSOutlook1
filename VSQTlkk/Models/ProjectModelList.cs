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
        public bool Contains(string projectname)
        {
            foreach (var x in this)
            {
                if(x.projectName == projectname)
                {
                    return true;
                }
                //find in list of objects -  object with property = string 
            }
            return false;

            //var a = this;
            //var b = this.ElementAt(0);

            //Debug.Write(a);
            //Debug.Write(b);
        }
    }
}
