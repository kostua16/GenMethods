using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods
{
    class RandomCrossing:Crossing
    {
        private Dictionary<int, string> Values = new Dictionary<int, string>();
        public override Population Cross( int count)
        {
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                var r1=r.Next(0, Population.Pars.Count - 1);
                var r2 = r.Next(0, Population.Pars.Count - 1);
                var p1=this.Population.Pars[r1];
                var p2 = this.Population.Pars[r2];
                var v1 = this.Population.Osobi[p1];
                var v2 = this.Population.Osobi[p2];
                var razrer = r.Next(0, Population.Length);
                var temp1 = v1.Substring(0, razrer) + v2.Substring(razrer);
                var temp2 = v2.Substring(0, razrer) + v1.Substring(razrer);

                if (Values.ContainsKey(p1)) { Values[p1] = temp1; } else { Values.Add(p1, temp1); }
                if (Values.ContainsKey(p2)) { Values[p2] = temp2; } else { Values.Add(p2, temp2); }
            }
            foreach (var item in Values)
            {
                this.Population.Osobi[item.Key] = item.Value;
            }
            return this.Population;
            //throw new NotImplementedException();
        }
    }
}
