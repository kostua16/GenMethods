using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Mytators
{
    public abstract class MytatorBase:Modificator
    {
        protected string Mutate(string value, int position)
        {
            var res = "";
            if (position > 0 && position < Population.Length)
            {
                var before = value.Substring(0, position);
                var after = value.Substring(position + 1);
                var current = value.Substring(position, 1);
                res = before + Invert(current) + after;
            }
            if (position == 0)
            {
                var current = value.Substring(position, 1);
                var after = value.Substring(position + 1);
                res = Invert(current) + after;
            }
            if (position == Population.Length)
            {
                var before = value.Substring(0, position);
                var current = value.Substring(position, 1);
                res = before + Invert(current);
            }
            return res;
        }
        protected static string Invert(string symbol)
        {
            switch (symbol)
            {
                case "1":
                    return "0";
                case "0":
                    return "1";
                default:
                    return "0";
            }
        }
        protected bool CheckMutateChance(double min, double max,int afterdot)
        {
            return GetRandom(min, 1f, afterdot) <= max;
        }
        public override void OnCreate()
        {
            Type=ModificatorType.Mutator;
            //throw new NotImplementedException();
        }
    }
}
