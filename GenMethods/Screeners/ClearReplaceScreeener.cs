using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Screeners
{
    public class ClearReplaceScreeener:ScreenerBase
    {
        public override Population Run()
        {
            Population.Osobi.Clear();
            foreach (var para in Population.Pars)
            {
                foreach (var child in para.Children)
                {
                    Population.Osobi.Add(child);
                }
                
            }
            Population.Osobi.AddRange(GetNoParentsFromBase());
            return Population;
        }
    }
}
