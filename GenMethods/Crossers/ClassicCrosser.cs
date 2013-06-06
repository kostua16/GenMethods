using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Crossers
{
    public class ClassicCrosser:CrosserBase
    {
        public override Population Run()
        {
            var count = GetOption("crosser_count", Population.TempPopulation.Count/2);
            Population.Pars.Clear();
            if (Population.Length < 1) return Population;
            for (var i = 0; i < count; i++)
            {
                var father = GetRandomParent();
                var mother = GetRandomParent(new List<Unit> {father});
                var nF = father == null;
                var nM = mother == null;
                if (father == null || mother == null) continue;
                var child1 = new Unit(); var child2 = new Unit();
                for (var ind = 0; ind < Population.GensCount; ind++)
                {

                    var razrez = GetRandom(1, Population.Length - 1);
                    var dd = SimpleCross(father.Gens[ind], mother.Gens[ind],razrez );
                    child1.Gens.Add(dd[4]); child2.Gens.Add(dd[5]);
                }
                var para = new Para {Father = father, Mother = mother, Children = new List<Unit> {child1, child2}};
                Population.Pars.Add(para);
            }
            return Population;

        }
    }
}
