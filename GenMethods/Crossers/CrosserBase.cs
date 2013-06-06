using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Crossers
{
    public abstract class CrosserBase:Modificator
    {
        public override void OnCreate()
        {
            Type=ModificatorType.Crossing;
        }
        public string[] SimpleCross(string inp1, string inp2, int razrez)
        {
            var res = new List<string>();
            if (razrez < 1 || razrez > inp1.Length || razrez > inp2.Length) return res.ToArray();
            res.Add(inp1.Substring(0, razrez));
            res.Add(inp1.Substring(razrez));
            res.Add(inp2.Substring(0, razrez));
            res.Add(inp2.Substring(razrez));
            res.Add(res[0] + res[3]);
            res.Add(res[2] + res[1]);
            return res.ToArray();
        }
        private Unit _GetRandomParentOrNull(List<Unit> existsParents = null)
        {
            var temp = _getRandomParent();
            return 
                existsParents != null && existsParents.Any(parent => temp.Id == parent.Id) ? null : temp;
        }
        private Unit _getRandomParent()
        {
            if (Population.TempPopulation.Count > 1)
            {
                var p1 = Population.TempPopulation[GetRandom(0, Population.TempPopulation.Count - 1)];
                return Population.GetById(p1);
            }
            if (Population.TempPopulation.Count == 1)
            {
                var p1 = Population.TempPopulation[0];
                return Population.GetById(p1);
            }
            return null;

        }
        public Unit GetRandomParent(List<Unit> existsParents = null)
        {
            if (existsParents == null || existsParents.Count<=1 || existsParents.Count==Population.TempPopulation.Count)
            {
                return _GetRandomParentOrNull(existsParents);
            }
            else
            {
                var resultt = _GetRandomParentOrNull(existsParents);
                while (resultt==null)
                {
                    resultt = _GetRandomParentOrNull(existsParents);
                }
                return resultt;
            }
        }
    }
}
