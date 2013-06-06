using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods
{
    public interface IModificator
    {
        void Init(Population p);
        Population Modificate(Dictionary<string, dynamic> options);
    }
    public abstract class Modificator:IModificator
    {
        protected Population Population;
        protected Dictionary<string, dynamic> Options;
        protected Random Randomizer;
        public ModificatorType Type { get; set; }

        protected Modificator()
        {
            OnCreate();
        }

        public abstract void OnCreate();
        public void Init(Population p)
        {
            Population = p;
            Randomizer=new Random();
        }

        public Population Modificate(Dictionary<string, dynamic> options)
        {
            Options = options;
            try
            {
                return Run();
            }
            catch
            {
                return Population;
            }
        }
        public abstract Population Run();
        protected dynamic GetOption(string index, dynamic defaultvalue)
        {
            try
            {
                return Options[index];
            }
            catch
            {
                return defaultvalue;
            }
        }
        protected int GetRandom(int min = 0, int max = 100)
        {
            try
            {
                return Randomizer.Next(min, max);
            }
            catch
            {
                return Randomizer.Next(0, 100);
            }
        }
        protected double GetRandom(double min, double max,int afterdot=2)
        {
            var ddot = Math.Pow(10, afterdot);
            try
            {
                
                var mmin = (int) (min*ddot);
                var mmax = (int) (max*ddot);
                var res = GetRandom(mmin, mmax);
                return res/ddot;
            }
            catch 
            { 
                return GetRandom()/ddot;
            }
        }
        public double AverageFitness()
        {
            double based=0;
            if (Population.Osobi.Count > 0)
            {
                based = Population.Osobi.Average(unit => unit.Function);
            }
            
            double pars = 0;
            if (Population.Pars.Count > 0)
            {
                pars = Population.Pars.Average(unit => unit.Children.Average(un => un.Function));
            }
            var aver = new List<double> { based, pars }.Average(unit => unit);
            return aver;
        }
        public List<Unit> GetAll()
        {
            var based = Population.Osobi;
            var news= new List<Unit>();
            if (Population.Pars.Count > 0)
            {
                news = Population.Pars.SelectMany(unit => unit.Children).ToList();
            }
            var res = new List<Unit>();
            res.AddRange(based);
            res.AddRange(news);
            return res;
        }
    }
}
