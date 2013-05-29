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
        //public List<string> Osobi;
        public Dictionary<int, string> Osobi;
        public int Min=0;
        public int Max=999;
        public int Length=0;
        public int Count = 0;
        public List<int> Pars;
        public Population(int min,int max)
        {
            Osobi = new Dictionary<int, string>();//new List<string>();
            Pars = new List<int>();
            Min = min;
            Max = max;
            GenerateLen();
        }
        public void GenerateNew(int count)
        {
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                var temp = r.Next(Min, Max);
                var result = DecToBin(temp - Min,Length);
                Osobi.Add(i,result);
                Count++;
            }
        }
        public void GenerateLen()
        {
            //Addin = Max - Min;
            var minLen = (int)Math.Ceiling(Math.Log((double)(Max - Min),2));
            Length = minLen;
        }
        public void MakeSelection(ISelector selector,int counpars=2)
        {
            selector.Init(this);
            var selection = selector.Select(counpars);
            GenerateFrom(selection);
        }
        public void MakeCross(ICrossing crossing, int counpars = 2)
        {
            crossing.Init(this);
            var cross = crossing.Cross(counpars);
            GenerateFrom(cross);
        }
        public void GenerateFrom(Population p, Dictionary<int,string> data = null)
        {
            this.Length = p.Length;
            this.Max = p.Max;
            this.Min = p.Min;
            this.Osobi = p.Osobi;
            this.Count = p.Count;
            this.Pars = p.Pars;
            if (data != null) {
                this.Osobi = data;
                this.Count = data.Count;
            }
        }
        public string DecToBin(Int32 a,int tolength=0)
        {
            string b = "";
            while (a != 0)
            {
                b=(Convert.ToInt16(a % 2)).ToString() + b;
                a /= 2;
            }
            if (tolength > 0)
            {
                b=b.PadLeft(tolength, '0');
            }
            return b;
        }
        public int BinToDec(string a)
        {
            double b = 0;
            for (double i = a.Length - 1; i >= 0; i--)
                b += Convert.ToDouble(a.Substring(Convert.ToInt16(i), 1)) * Math.Pow(2, i);

            return Convert.ToInt32(b);
        }
    }
}
