using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Mytators
{
    public class ClassicMytator:MytatorBase
    {
        public override Population Run()
        {
            var max = (double) GetOption(0, 0.01f);
            var min = (double) GetOption(1, 0.001f);
            var afterdots = (int)GetOption(2, 3);
            foreach (var os in Population.Osobi)
            {
                if (!CheckMutateChance(min, max, afterdots)) continue;

                var position = GetRandom(0, Population.Length);
                Population.Osobi[os.Key] = Mutate(os.Value,position);
            }
            return Population;
        }
        
    }
}
