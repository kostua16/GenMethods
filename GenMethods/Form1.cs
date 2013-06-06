using System.Globalization;
using GenMethods.Screeners;
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
using ZedGraph;

namespace GenMethods
{
    public partial class Form1 : Form
    {
        Population Population;
        LineItem met1 = new LineItem("");
        LineItem met2 = new LineItem("");
        LineItem met3 = new LineItem("");
        LineItem met4 = new LineItem("");
        private TimeSpan time1;
        private TimeSpan time2;
        private TimeSpan time3;
        private TimeSpan time4;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            met1.Clear();
            met1.Tag = "";
            var settings1 = GetSettings(new RuletteSelector(), new SelectionScreener());  
            var calc1 = new SimpleCalculator(settings1);
            var d1 = DateTime.Now;
            var curve1V=calc1.Start();
            time1 = DateTime.Now.Subtract(d1);
            label12.Text = Math.Round(time1.TotalSeconds, 3).ToString(CultureInfo.InvariantCulture);
            met1 = zedGraphControl1.GraphPane.AddCurve("Метод1", new double[] { 0 }, new double[] { 0 }, Color.Red);
            foreach (var d in curve1V) { met1.AddPoint(d.Key, d.Value); }
            zedGraphControl1.AxisChange(); zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            met2.Clear();
            met2.Tag = "";
            var settings2 = GetSettings(new TurnirSelector(), new RandomScreeener()); 
            var calc2 = new SimpleCalculator(settings2);
            var d1 = DateTime.Now;
            var curve2V = calc2.Start();
            time2 = DateTime.Now.Subtract(d1);
            label13.Text = Math.Round(time2.TotalSeconds, 3).ToString(CultureInfo.InvariantCulture);
            met2 = zedGraphControl1.GraphPane.AddCurve("Метод2", new double[] { 0 }, new double[] { 0 }, Color.Blue);
            foreach (var d in curve2V) { met2.AddPoint(d.Key, d.Value); }
            zedGraphControl1.AxisChange(); zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            met3.Clear();
            met3.Tag = "";
            var settings3 = GetSettings(new TurnirSelector(), new SelectionScreener());
            var calc3 = new SimpleCalculator(settings3);
            var d1 = DateTime.Now;
            var curve3V = calc3.Start();
            time3 = DateTime.Now.Subtract(d1);
            label14.Text = Math.Round(time3.TotalSeconds, 3).ToString(CultureInfo.InvariantCulture);
            met3 = zedGraphControl1.GraphPane.AddCurve("Метод3", new double[] { 0 }, new double[] { 0 }, Color.Green);
            foreach (var d in curve3V) { met3.AddPoint(d.Key, d.Value); }
            zedGraphControl1.AxisChange(); zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            met4.Clear();
            met4.Tag = "";
            var settings4 = GetSettings(new RuletteSelector(), new RandomScreeener());
            var calc4 = new SimpleCalculator(settings4);
            var d1 = DateTime.Now;
            var curve4V = calc4.Start();
            time4 = DateTime.Now.Subtract(d1);
            label15.Text = Math.Round(time4.TotalSeconds,3).ToString(CultureInfo.InvariantCulture);
            met4 = zedGraphControl1.GraphPane.AddCurve("Метод4", new double[] { 0 }, new double[] { 0 }, Color.Purple);
            foreach (var d in curve4V) { met4.AddPoint(d.Key, d.Value); }
            zedGraphControl1.AxisChange(); zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
        }
        private Dictionary<string, dynamic> GetSettings(IModificator selector,IModificator screener)
        {
            
                var settings = new Dictionary<string, dynamic>
                {
                    {"form",this},
                    {"selector",selector},
                    {"screener",screener},
                    {"population_min",(int)numericUpDown1.Value},
                    {"population_max",(int)numericUpDown2.Value},
                    {"population_genscount",(int)numericUpDown3.Value},
                    {"population_startcount",(int)numericUpDown4.Value},
                    {"population_generations",(int)numericUpDown5.Value}
                };
            return settings;
        }
        

        
    }
}
