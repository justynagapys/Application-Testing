using FunkcjeFinansowe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunkcjeFinansoweGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonWartoscPrzyszla_Click(object sender, EventArgs e)
        {
            Inwestycja inw = new Inwestycja();
            try
            {
                double kwotaPoczatkowa = double.Parse(tbKwotaPoczatkowaWartoscPrzyszla.Text);
                double oprocentowanie = double.Parse(tbOprocentowanieWartoscPrzyszla.Text);
                int liczbaOkresow = int.Parse(tbLiczbaOkresowWartoscPrzyszla.Text);

                tbWynikWartoscPrzyszla.Text = inw.wartoscPrzyszla(kwotaPoczatkowa, oprocentowanie, liczbaOkresow).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonStopaProcentowa_Click(object sender, EventArgs e)
        {
            Inwestycja inw = new Inwestycja();
            try
            {
                double kwotaPoczatkowa = double.Parse(tbKwotaPoczatkowaStopa.Text);
                double kwotaKoncowa = double.Parse(tbKwotaKoncowaStopa.Text);
                int liczbaOkresow = int.Parse(tbLiczbaOkresowStopa.Text);

                tbWynikStopaProcentowa.Text = inw.wyliczStope(kwotaPoczatkowa, kwotaKoncowa, liczbaOkresow).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
