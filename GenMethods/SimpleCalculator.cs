using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenMethods.Crossers;
using GenMethods.Mytators;
using GenMethods.Screeners;
using GenMethods.Selectors;
using ZedGraph;

namespace GenMethods
{
    public class SimpleCalculator:FormulaCalculator
    {
        public SimpleCalculator(Dictionary<string, dynamic> options) : base(options)
        {
            Min = GetOption("population_min", 0);
            Max = GetOption("population_max", 100);
            Gens = GetOption("population_genscount", 6);
            StartCount = GetOption("population_startcount", 200);
            Generations = GetOption("population_generations", 100);
            Selector = GetOption("selector", new TurnirSelector());
            Crosser = GetOption("crosser", new ClassicCrosser());
            Mytator = GetOption("mytator", new ClassicMytator());
            Screener = GetOption("screener", new SelectionScreener());
        }
        public override Unit CalculateFitnes(Unit osob,Population population)
        {
            osob.Function = 0;
            foreach (var gen in osob.Gens)
            {
                osob.Function += osob.BinToDec(gen);
            }
            return osob;
        }
        public override Dictionary<double, double> Start()
        {
            Form1 f= GetOption("form", null);
            var resultt = new Dictionary<double, double>();
            double y = 0;

            var pop = new Population(this);
            f.progressBar1.Minimum = 0;
            f.progressBar1.Maximum = pop.Formula.Generations;
            for (int i = 0; i < Generations; i++)
            {
                pop.OneGeneration(Selector,Crosser,Mytator,Screener);
                var max=pop.GetMax();
                y = y + 1;
                resultt.Add(y,max);
                f.progressBar1.Value = i;
                Application.DoEvents();
            }
            return resultt;
        }
    }
}
