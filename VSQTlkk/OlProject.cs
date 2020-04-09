using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSQTlkk
{
    class OlProject
    {
        int index,projectDuration;
        float[] cwHours = new float[55];
        List<String> workPackages;
        String projectName, projectAlias;

        public OlProject(String name)
        {
            this.projectName = name;
        }
    }
}
