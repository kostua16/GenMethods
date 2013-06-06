using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Selectors
{
    public class RuletteSelector:SelectorBase
    {
        private readonly Dictionary<decimal, double> Values;
        double _max;
        public RuletteSelector()
        {
            Values = new Dictionary<decimal, double>();
            _max = 0;
        }
        public double Formula(Unit item)
        {
            var value = item.Function;
            var temp = (double)((double)value / (double)_max);
            var res = temp*100;
            return res;
        }
        public void GenerateMax()
        {
            _max = 0;
            foreach (var item in Population.Osobi)
            {
                _max += item.Function;
            }
        }
        public void GenerateRulette()
        {
            GenerateMax();
            Values.Clear();
            foreach (var item in Population.Osobi)
            {
                var value=Formula(item);
                if(!Values.ContainsKey(item.Id)) Values.Add(item.Id,value);
            }
        }

        public override Population Run()
        {
            var pars = GetOption("selector_pars", Population.Osobi.Count/4);
            Population.TempPopulation.Clear();
            GenerateRulette();
            for (int i = 0; i < pars*2; i++)
            {
                var value = Randomizer.Next(0, 100);
                double sum = 0;
                foreach (var pair in Values)
                {
                    sum += pair.Value;
                    if (sum >= value) { Population.TempPopulation.Add(pair.Key);break;}
                }
            }
            return Population;
        }
    }
}
