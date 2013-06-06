using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods
{
     public interface IFormulaCalculator
     {
         Population Calculate(Population p);
         int Min { get; }
         int Max { get; }
         int Gens { get; }
         int StartCount { get; }
         int Generations { get; }
         IModificator Selector { get; }
         IModificator Crosser { get; }
         IModificator Mytator { get; }
         IModificator Screener { get; }

     }
     public abstract class FormulaCalculator:IFormulaCalculator
    {
         protected FormulaCalculator(Dictionary<string, dynamic> options)
         {
             Options = options;
         }
         protected Dictionary<string,dynamic> Options;
         public int Min  { get; set; }
         public int Max  { get; set; }
         public int Gens { get; set; }
         public int StartCount { get; set; }
         public int Generations { get; set; }
         public IModificator Selector { get; set; }
         public IModificator Crosser { get; set; }
         public IModificator Mytator { get; set; }
         public IModificator Screener { get; set; }
         protected dynamic GetOption(string index, dynamic defaultvalue)
         {
             try
             {
                 return Options[index] ?? defaultvalue;
             }
             catch
             {
                 return defaultvalue;
             }
         }
         public abstract Dictionary<double,double> Start();
         public abstract Unit CalculateFitnes(Unit osob, Population population);
         public virtual Population Calculate(Population p)
         {
             for (int i = 0; i < p.Osobi.Count; i++)
             {
                 var vvv = p.Osobi[i];
                 p.Change(CalculateFitnes(vvv, p));
             }
             for (int i = 0; i < p.Pars.Count; i++)
             {
                 var para = p.Pars[i];
                 para.Father = CalculateFitnes(para.Father, p);
                 para.Mother = CalculateFitnes(para.Mother, p);
                 for (int i2 = 0; i2 < para.Children.Count; i2++)
                 {
                     para.Children[i2] = CalculateFitnes(para.Children[i2], p);
                 }
             }

             return p;
         }
    }
     

}
