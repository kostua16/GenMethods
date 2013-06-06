using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace GenMethods
{
    public class Population
    {
        public List<Unit> Osobi;
        public int Min=0;
        public int Max=999;
        public int Length=0;
        public int Count = 0;
        public int GensCount = 0;
        public List<decimal> TempPopulation;
        public List<Para> Pars; 

        public IFormulaCalculator Formula;
        public Population(IFormulaCalculator calculator)
        {
            Osobi = new List<Unit>();
            TempPopulation = new List<decimal>();
            Pars=new List<Para>();
            Formula=calculator;
            Min = Formula.Min;
            Max = Formula.Max;
            GensCount = Formula.Gens;
            GenerateLen();
            GenerateNew(Formula.StartCount);
        }
        private void GenerateNew(int count)
        {
           
            for (int i = 0; i < count; i++)
            {
                Osobi.Add(new Unit(GensCount, Length, Min, Max));
                Count++;
            }
        }
        private void GenerateLen()
        {
            var minLen = (int)Math.Ceiling(Math.Log(Max - Min,2));
            Length = minLen;
        }
        public void Modificate(IModificator modificator,Dictionary<string, dynamic> params1)
        {
            modificator.Init(this);
            var population = modificator.Modificate(params1);
            GenerateFrom(population);
        }
        public void OneGeneration(IModificator selector, IModificator crosser, IModificator mytator,IModificator screener,Dictionary<string,dynamic> options=null)
        {
            if (Osobi.Count<5)
            {
                return;
            }
            CalculateFormula();
            Modificate(mytator, options);
            Modificate(selector,options);
            Modificate(crosser,options);
            CalculateFormula();
            Modificate(screener,options);
        }
        public void CalculateFormula()
        {
            var pop = Formula.Calculate(this);
            GenerateFrom(pop);
        }
        public void GenerateFrom(Population p, List<Unit> data = null)
        {
            Length = p.Length;
            Max = p.Max;
            Min = p.Min;
            Osobi = p.Osobi;
            Count = p.Count;
            GensCount = p.GensCount;
            TempPopulation = p.TempPopulation;
            Pars = p.Pars;
            if (data == null) return;
            Osobi = data;
            Count = data.Count;
        }
        public Unit GetById(decimal id)
        {
            return Osobi.FirstOrDefault(unit => unit.Id == id);
        }
        public void ChangeById(decimal id,Unit unit2)
        {
            var unit1=Osobi.Find(unit => unit.Id == id);
            var index = Osobi.IndexOf(unit1);
            Osobi[index] = unit2;
        }
        public void Change(Unit unit1)
        {
            ChangeById(unit1.Id,unit1);
        }
        public double GetMax()
        {
            return Osobi.Count > 0 ? Osobi.Max(u => u.Function) : 0;
        }
        public double GetMin()
        {
            return Osobi.Count > 0 ? Osobi.Min(u => u.Function) : 0;
        }
    }
}
