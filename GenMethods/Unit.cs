using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenMethods
{
    static class IdManager
    {
        private static decimal _last;
        public static decimal GetNew()
        {
            return ++_last;
        }
    }
    public class Unit
    {
        public List<String> Gens { get; set; }
        public double Function { get; set; }
        public decimal Id { get; set; }
        public Unit()
        {
            Id = IdManager.GetNew();
            Gens = new List<String>();
        }
        public Unit(int countgens,int len,int min,int max):this()
        {
            Generate(countgens,len,min,max);
        }
        public void Generate(int countgens,int len, int min, int max)
        {
            var r = new Random();
            
            for (var i = 0; i < countgens; i++)
            {
                var temp = r.Next(min, max);
                var result = DecToBin(temp - min, len);
                Gens.Add(result);
            }
        }
        public static string DecToBin(Int32 a, int tolength = 0)
        {
            string b = "";
            while (a != 0)
            {
                b = (Convert.ToInt16(a % 2)).ToString(CultureInfo.InvariantCulture) + b;
                a /= 2;
            }
            if (tolength > 0)
            {
                b = b.PadLeft(tolength, '0');
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
