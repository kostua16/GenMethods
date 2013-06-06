using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Screeners
{
    public abstract class ScreenerBase:Modificator
    {
        public override void OnCreate()
        {
            Type=ModificatorType.Screener;
        }
        public List<Unit> GetNoParentsFromBase()
        {
            var goods=new List<Unit>();
            foreach (var unit in Population.Osobi)
            {
                var good = Population.Pars.All(para => unit.Id != para.Father.Id && unit.Id != para.Mother.Id);
                if (good)
                {
                    goods.Add(unit);
                }
            }
            return goods;
        }
        public List<Unit> GetNoParentsFromTemp()
        {
            var goods = new List<Unit>();
            foreach (var unit in Population.TempPopulation)
            {
                var good = Population.Pars.All(para => unit != para.Father.Id && unit != para.Mother.Id);
                if (good && Population.GetById(unit)!=null )
                {
                    goods.Add(Population.GetById(unit));
                }
            }
            return goods;
        }
        
    }
}
