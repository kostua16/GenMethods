using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Screeners
{
    class RandomScreeener:ScreenerBase
    {
        public override Population Run()
        {
            Population.Osobi.Clear();
            foreach (var para in Population.Pars)
            {
                var id = GetRandom(0, 1);
                switch (id)
                {
                    case 0: Population.Osobi.AddRange(new[] { para.Father, para.Children[0] });break;
                    case 1: Population.Osobi.AddRange(new[] { para.Mother, para.Children[0] }); break;
                }
                
            }
            Population.Osobi.AddRange(GetNoParentsFromBase());
            return Population;
        }
    }
}
