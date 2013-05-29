using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods.Selectors
{
    public abstract class SelectorBase:Modificator
    {
        public override void OnCreate()
        {
            Type=ModificatorType.Selector;
            //throw new NotImplementedException();
        }

    }
}
