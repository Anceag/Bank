using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace curse
{
    public partial class Form1 : Form
    {
        public Bank bank;
        public string Selected;
        public int SelIndex;
        List<string> curList = new List<string>();
        List<int> searchList = new List<int>();

        int left = 0;

        public Form1()
        {
            InitializeComponent();

            bank = new Bank("1.txt");

            curList.AddRange(bank.Depositors);
            refreshListBox();
        }

        public void refreshListBox() // updates listbox with new information
        {
            listBox1.Items.Clear();
            for (int i = 0; i < curList.Count; i++)
            {
                listBox1.Items.Add(Depositor.GetName(curList[i]) + " "
                    + Depositor.GetSurname(curList[i]) + " | "
                    + Depositor.GetPersNum(curList[i]));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = bank.Interval;
            t.Tick += new EventHandler(addPercent);
            t.Start();

            System.Windows.Forms.Timer sec = new System.Windows.Forms.Timer();
            sec.Interval = 1000;
            sec.Tick += new EventHandler(seconds);
            sec.Start();
            left = (bank.Interval / 1000) - 1;
        }

        private void addPercent(object sender, EventArgs e) // adds money to users' money equivalent to their category and time left
        {
            bank.AddPercent();
            FullUpdate();
            left = bank.Interval / 1000;
        }

        private void seconds(object sender, EventArgs e) // runs every second
        {
            timer.Text = left-- + "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                updateSelected();
                textBox1.Text = Selected;
                SelIndex = bank.StraightSearch(curList[listBox1.SelectedIndex]);
            }
        }

        // dynamic update
        public void FullUpdate()
        {
            updateCurList();
            if(listBox1.SelectedIndex != -1)
                updateSelected();
            if(Selected != "")
                textBox1.Text = Selected;
        }
        public void updateCurList()
        {
            curList.Clear();
            if (nameBox.Text == "" && surnameBox.Text == "" && persNumBox.Text == "")
                curList.AddRange(bank.Depositors);
            else
            {
                for (int i = 0; i < searchList.Count; i++)
                    curList.Add(bank.Depositors[searchList[i]]);
            }
        }
        private void updateSelected()
        {
            Selected = "Name: " + Depositor.GetName(curList[listBox1.SelectedIndex])
                    + "\r\nSurname: " + Depositor.GetSurname(curList[listBox1.SelectedIndex])
                    + "\r\nPersonal Number: " + Depositor.GetPersNum(curList[listBox1.SelectedIndex])
                    + "\r\nCategory: " + Depositor.GetCategory(curList[listBox1.SelectedIndex])
                    + "%\r\nMoney: " + Depositor.GetMoney(curList[listBox1.SelectedIndex])
                    + "\r\nLast Date: " + Depositor.GetLastDate(curList[listBox1.SelectedIndex]);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //bank.Delete(bank.StraightSearch(curList[listBox1.SelectedIndex]));
                curList.Remove(bank.Delete(bank.StraightSearch(curList[listBox1.SelectedIndex])));
                textBox1.Text = "";
                refreshListBox();
            }
        }

        private void moreBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1) {
                Form2 f = new Form2();
                f.Owner = this;
                f.ShowDialog();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            search();
            updateCurList();
            refreshListBox();
        }

        private void search()
        {
            searchList = bank.MainSearch(nameBox.Text, surnameBox.Text, persNumBox.Text);
            Selected = "";
            textBox1.Text = "";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Owner = this;
            f.ShowDialog();
        }
    }
}
