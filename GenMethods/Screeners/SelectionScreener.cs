using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Screeners
{
    class SelectionScreener:ScreenerBase
    {
        public override Population Run()
        {
            var aver = AverageFitness();
            var units = GetAll();
            var good = units.Where(unit => unit.Function >= aver).ToList();
            Population.Osobi = good;
            return Population;
        }
    }
}
