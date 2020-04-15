using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSQTlkk.Models
{
    class ProjectModelList<T> : List<T>
    {
        public void Contains(string projectname)
        {
            //foreach (string x in this)
            //{
            //    //find in list of objects -  object with property = string 
            //}

            var a = this;
            var b = this.ElementAt(0);

            Debug.Write(a);
            Debug.Write(b);
        }
    }
}
