using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curse
{
    public partial class Form2 : Form
    {
        Form1 owner;
        public Form2()
        {
            InitializeComponent();
        }

        private void addMoney_Click(object sender, EventArgs e)
        {
            int mon = 0;

            try
            {
                mon = Convert.ToInt32(moneyBox.Text);
            }
            catch { }

            if (moneyBox.Text != "" && owner.SelIndex > -1)
            {
                owner.bank.AddMoney(owner.SelIndex, mon);
                owner.FullUpdate();
                textBox1.Text = owner.Selected;
            }
        }

        private void takeMoney_Click(object sender, EventArgs e)
        {
            int mon = 0;

            try
            {
                mon = Convert.ToInt32(moneyBox.Text);
            }
            catch { }

            if (moneyBox.Text != "" && owner.SelIndex > -1)
            {
                owner.bank.TakeMoney(owner.SelIndex, mon);
                owner.FullUpdate();
                textBox1.Text = owner.Selected;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            owner = this.Owner as Form1;
            textBox1.Text = owner.Selected;
        }
    }
}
