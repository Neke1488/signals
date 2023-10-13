using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSiI_Lab1
{
    public partial class Form1 : Form
    {
        public List<Graph> Data { get; set; }
        public Form1()
        {
            Data = GetGraph();
            InitializeComponent();
        }

        private List<Graph> GetGraph()
        {
            var list = new List<Graph>();

            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string T = this.textBox1.Text, Del = this.textBox2.Text;
            //C = this.textBox3.Text, F = this.textBox4.Text, Fi = this.textBox5.Text;
            List<(decimal, decimal)> n = new List<(decimal, decimal)>();
            decimal x, y, pi = 3.14M;
            decimal[] c = new decimal[5];
            decimal[] f = new decimal[5];
            decimal[] fi = new decimal[5];
            decimal.TryParse(T, out decimal b);
            decimal.TryParse(Del, out decimal del);
            if (b == 0 || del == 0)
            {
                MessageBox.Show("Введите T и Del");
                return;
            }
            for (int rows = 0; rows < this.data.Rows.Count-1; rows++)
            {
                int col = 0;
                
               
                string value = this.data.Rows[rows].Cells[col].Value.ToString();
                decimal.TryParse(value, out c[rows]);
                col++;
                string valu = this.data.Rows[rows].Cells[col].Value.ToString();
                decimal.TryParse(valu, out f[rows]);
                col++;
                string val = this.data.Rows[rows].Cells[col].Value.ToString();
                decimal.TryParse(val, out fi[rows]);
            }
            
            //decimal.TryParse(C, out decimal c);
            //decimal.TryParse(F, out decimal f);
            //decimal.TryParse(Fi, out decimal fi);
            this.chart1.Series[0].Points.Clear();
            for (x = 0; x <= b; x += del)
            {
                y = 0;
                for(int rows = 0; rows < this.data.Rows.Count-1; rows++) { 
                    decimal angle = 2 * pi * f[rows] * x + fi[rows];
                    y += c[rows] * Convert.ToDecimal(Math.Cos(Convert.ToDouble(angle / 180M) * Math.PI));
                }
                n.Add((x, y));
                this.chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string T = this.textBox1.Text, Del = this.textBox2.Text;
            double n, t, del;
            double.TryParse(T, out t);
            double.TryParse(Del, out del);
            n = t / del;
            textBox6.Text = Convert.ToString(n);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double m = 2, n = 2;
            double w = Math.PI * 100;
            double[] C = {0.81, 0.19};
            double[] B = {0.25, 0.75};
            double[] Fi = {0, Math.PI / 4};
            double t = 0.06;
            double x = 0, sum1 = 0, sum2 = 0;

            for (int i = 0; i < m; i++)
            {
                sum1 += B[i] * Math.Cos(w * t + Fi[i]);
            }

            for (int i = 0; i < n; i++)
            {
                sum2 += C[i] * Math.Log10((i + 1) * t);
            }

            x = sum2 - sum1;

            textBox3.Text = Convert.ToString(x);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double n = 3;
            double w = Math.PI * 100;
            double[] A = { 0.5, 0.2, 0.3 };
            double B = 1;
            double Fi = Math.PI / 4;
            double delT = 0.01;
            double x, sum1 = 0, sum2 = 0;

            for (int i = 0; i < n; i++)
            {
                sum1 += A[i] * Math.Exp(- (delT /(i * delT)));
            }

            sum2 += B * Math.Cos(w * delT + Fi);

            x = sum1 - sum2;

            textBox4.Text = Convert.ToString(x);
        }
    }
}
