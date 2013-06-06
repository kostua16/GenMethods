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
            var max = (double) GetOption("mytator_max", 0.01f);
            var min = (double) GetOption("mytator_max", 0.001f);
            var afterdots = (int)GetOption("mytator_dots", 3);
            for (int index = 0; index < Population.Osobi.Count; index++)
            {
                var os = Population.Osobi[index];
                var unit1 = os;
                for (var i = 0; i < os.Gens.Count; i++)
                {
                    if (!CheckMutateChance(min, max, afterdots)) continue;
                    var position = GetRandom(0, Population.Length - 1);
                    unit1.Gens[i] = Mutate(os.Gens[i], position);
                }
                Population.Change(unit1);
            }
            return Population;
        }
        
    }
}
