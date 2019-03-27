using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsUndDelegates
{
    public partial class Form1 : Form
    {
        Länderliste _liste;

        public Form1()
        {
            InitializeComponent();
            _liste = new Länderliste(3);
            _liste.Error += ShowErrorMessage;
            
            listBox1.DataSource = _liste;
        }

        private void Logging(object sender, string e)
        {
            //TODO: Logging
        }

        private void ShowErrorMessage(object sender, string errorMessage)
        {
            MessageBox.Show(errorMessage);    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hauptstadt = textBoxHauptstadt.Text;
            int einwohner = int.Parse(textBoxEinwohner.Text);
            Land neuesLand = new Land(hauptstadt, einwohner);

            _liste.Add(neuesLand);
        }
    }
}
