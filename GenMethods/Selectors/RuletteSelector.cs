using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Selectors
{
    public class RuletteValue
    {
        public double Persent;
        public string Value;
        public int Id;
        public RuletteValue(double persent, string value,int id)
        {
            Persent = persent;
            Value = value;
            Id = id;
        }
    }
    public class RuletteSelector:Selector
    {
        Dictionary<int, string> values;
        List<RuletteValue> Values;
        double Max;
        public RuletteSelector():base()
        {
            values = new Dictionary<int, string>();
            Values = new List<RuletteValue>();
            Max = 0;
        }
        public override Population Select(int countpars)
        {
            Random r = new Random();
            Population.Pars.Clear();
            
            GenerateRulette();
            //foreach (var item in Values)
            //{
            //    Population.Pars.Add(string.Format("{0}-{1}", item.Value, item.Persent));
            //}
           // return Population;
            for (int i = 0; i < countpars*2; i++)
            {
                var value = r.Next(0, 100);
                double sum=0;
                double current = 0;
                foreach (var item in Values)
                {
                    current = Values.IndexOf(item);
                    sum+=item.Persent;
                    
                    if (sum >= value)
                    {
                        Population.Pars.Add(item.Id);
                        break;
                    }
                }
                

            }
            return Population;
        }
        public double Formula(string item)
        {
            var value = Population.BinToDec(item);
            double temp = (double)((double)value / (double)Max);
            double res = temp*100;
            return res;
        }
        public void GenerateMax()
        {
            Max = 0;
            foreach (var item in Population.Osobi)
            {
                Max += Population.BinToDec(item.Value);
            }
        }
        public void GenerateRulette()
        {
            double max = 0;
            GenerateMax();
            var startValues = new List<RuletteValue>();
            foreach (var item in Population.Osobi)
            {
                var value=Formula(item.Value);
                startValues.Add(new RuletteValue(value, item.Value,item.Key));
                max += value;
            }
            Values = startValues;
        }
    }
}
