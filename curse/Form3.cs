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
    public partial class Form3 : Form
    {
        Form1 owner;

        public Form3()
        {
            InitializeComponent();
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            double money = -1;
            int category = -1;

            if (moneyBox.Text == "") money = 0;
            if (categoryBox.Text == "") category = 0;

            try
            {
                money = Convert.ToDouble(moneyBox.Text);
                category = Convert.ToInt32(categoryBox.Text);
            }
            catch { }

            if (nameBox.Text == "" || surnameBox.Text == "")
            {
                errorBox.Text = "You must enter your name and surname.";
            }
            else if (money < 0 || category < 0)
            {
                errorBox.Text = "Money or category fields are not valid.";
            }
            else
            {
                owner.bank.AddDepositor(nameBox.Text, surnameBox.Text, category, money);
                owner.updateCurList();
                owner.refreshListBox();
                this.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            owner = this.Owner as Form1;
            errorBox.Text = "Enter your name, surname, money and category.";
        }
    }
}
