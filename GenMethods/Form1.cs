using GenMethods.Selectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GenMethods
{
    public partial class Form1 : Form
    {
        Population Population;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Population = new Population(0,99); //создаем условия популяции (мин-0 макс-99)
            Population.GenerateNew(15); // генерируем популяцию из 15 особей
            DrawPopulation();
        }
        private void DrawPopulation()
        {
            listBox1.Items.Clear();
            foreach (var item in Population.Osobi)
            {
                listBox1.Items.Add(item.Value);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // while (true)
           // {
                Population.MakeSelection(new RuletteSelector(), 6); // отбираем 6 пар
                Population.MakeCross(new RandomCrossing(), 4); //кроссинговер 4 пар
                DrawPopulation();
            //    Thread.Sleep(50);
            //}
            /*foreach (var item in Population.Pars)
            {
                listBox1.Items.Add(item);
            }
             */
            
        }

        
    }
}
