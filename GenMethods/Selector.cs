using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods
{
    public interface ISelector
    {
        void Init(Population p);
        Population Select(int count);
    }
    public abstract class Selector:ISelector
    {
        protected Population Population;
        public Selector()
        {
        }
        public void Init(Population p)
        {
            Population = p;
        }
        abstract public Population Select(int count);// {
            /*if (Population.Count > count-1)
            {
                var temp= new List<string>();
                for (int i = 0; i < count; i++)
                {
                    temp.Add(Population.Osobi[i]);
                }
                Population.Pars = temp;
                return Population;
            }
            return Population;
            */
        //}
    }
}
