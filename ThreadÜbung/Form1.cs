using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadÜbung
{
    public partial class Form1 : Form
    {
       
        MyTimer _timer;
        MyTimer _buttonTimer;

        public Form1()
        {
            InitializeComponent();
            _timer = new MyTimer(1000, () => {
                labelCountdown.Text = $"{9 - _timer.Steps} verbleiben!";
                //InvokeGUIThread(() => labelCountdown.Text = $"{9 - _timer.Steps} verbleiben!");
            },10,() => MessageBox.Show("Fertig"));
            _buttonTimer = new MyTimer(10, () =>
            {
                button1.Left += 2;
                button2.Left += 2;
            }, 1000);
            _buttonTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Countdown runterzählen (unsichtbar) und beim Erreichen der 0 MessageBox anzeigen

            Thread t1 = new Thread(() =>
            {
                //Auszuführender Code im Thread
                for (int i = 10; i >= 0; i--)
                {
                    Thread.Sleep(200);
                    InvokeGUIThread(() => labelCountdown.Text = $"{i} verbleiben!");
                    //labelCountdown.Invoke(new Action( () => labelCountdown.Text = $"{i} verbleiben!"), "Sekunden");
                }
                MessageBox.Show("Fertig!");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_timer.IsRunning)
                return;

            _buttonTimer.Stop();
            _timer.Start();
        }

        private void InvokeGUIThread(Action action)
        {
            this.Invoke(action);
        }
    }
}
