using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods
{
    public interface ICrossing
    {
        void Init(Population p);
        Population Cross(int count);
    }
    public abstract class Crossing:ICrossing
    {
        protected Population Population;
        public Crossing()
        {

        }
        public void Init(Population p)
        {
            Population = p;
        }
        public abstract Population Cross(int count);
        /*{
            return Population;
        }*/
    }
}
