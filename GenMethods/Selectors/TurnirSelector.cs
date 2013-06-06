using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Selectors
{
    public class TurnirSelector:SelectorBase
    {
        public override Population Run()
        {
            var m = GetOption("select_count", Math.Ceiling((double) (Population.Osobi.Count/20)));
            if (Population.Osobi.Count < m) return Population;
            var groups =new List < List<Unit> >();
            var tempc = 0;
            var templ = new List<Unit>();
            for (int i = 0; i < Population.Osobi.Count; i++)
            {
                var unit = Population.Osobi[i];
                if (tempc>=m)
                {
                    groups.Add(templ);
                    templ=new List<Unit>();
                    tempc = 0;
                }
                templ.Add(unit);
                tempc++;

            }
            if (templ.Count > 0) { groups.Add(templ);templ=new List<Unit>();}

            var goods=groups.SelectMany(u => u.Where(u1 => u1.Function == u.Max(u2 => u2.Function)));
            Population.TempPopulation = goods.Select(u=>u.Id).ToList();
            return Population;
        }
    }
}
