using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;

namespace curse
{
    class Depositor
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Category { get; private set; }
        public string LastDate { get; private set; }
        public double Money { get; private set; }
        public string PersNum { get; private set; }
        public long LastMilliseconds { get; private set; }

        public Depositor(string name, string surname, int category, double money)
        {
            Name = name;
            Surname = surname;
            Category = category;
            Money = money;
            PersNum = setPersNum();
            LastDate = SetLastDate();
            LastMilliseconds = SetLastMilliseconds();
        }
        public Depositor() { }

        string setPersNum()
        {
            string pers = "";
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                pers += r.Next(0, 9);
            }
            return pers;
        }
        public string SetLastDate()
        {
            return LastDate = DateTime.Now.ToString();
        }
        public long SetLastMilliseconds()
        {
            return LastMilliseconds = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
        
        // gets information from file
        public static string GetName(string str)
        {
            return str.Substring(str.IndexOf("name=") + 5, str.IndexOf("surname=") - str.IndexOf("name=") - 6);
        }
        public static string GetSurname(string str)
        {
            return str.Substring(str.IndexOf("surname=") + 8, str.IndexOf("personalnumber=") - str.IndexOf("surname=") - 9);
        }
        public static int GetCategory(string str)
        {
            return Convert.ToInt32(str.Substring(str.IndexOf("category=") + 9, str.IndexOf("mil=") - str.IndexOf("category=") - 10));
        }
        public static string GetLastDate(string str)
        {
            return str.Substring(str.IndexOf("lastdate=") + 9);
        }
        public static double GetMoney(string str)
        {
            return Convert.ToDouble(str.Substring(str.IndexOf("money=") + 6, str.IndexOf("category=") - str.IndexOf("money=") - 7));
        }
        public static string GetPersNum(string str)
        {
            return str.Substring(str.IndexOf("personalnumber=") + 15, str.IndexOf("money=") - str.IndexOf("personalnumber=") - 16);
        }
        public static long GetLastMilliseconds(string str)
        {
            return Convert.ToInt64(str.Substring(str.IndexOf("mil=") + 4, str.IndexOf("lastdate=") - str.IndexOf("mil=") - 5));
        }

        public void SetMoney(double money)
        {
            Money += money;
        }

        public void Update(string str)
        {
            Name = GetName(str);
            Surname = GetSurname(str);
            Category = GetCategory(str);
            LastDate = GetLastDate(str);
            Money = GetMoney(str);
            PersNum = GetPersNum(str);
            LastMilliseconds = GetLastMilliseconds(str);
        }

        // sets information to file
        public override string ToString()
        {
            return "name=" + Name + " surname=" + Surname + " personalnumber=" + PersNum + " money=" + Money + " category=" + Category + " mil=" + LastMilliseconds + " lastdate=" + LastDate;
        }
    }

    public class Bank
    {
        public string[] Depositors;
        public int Interval { get; private set; } = 60000;
        string file;

        public Bank(string file) // opens a file, if it doesn't exist, creates a new one
        {
            this.file = file;
            if (!File.Exists(file))
            {
                FileStream fs = File.Create(file);
                fs.Close();
            }
            Depositors = File.ReadAllLines(file);
        }

        public void Save() // writes the data into the file
        {
            File.WriteAllLines(file, Depositors);
        }

        // different search methods
        public List<int> Search(params string[] keys)
        {
            List<int> arr = new List<int>();
            for (int i = 0; i < Depositors.Length; i++)
            {
                for (int j = 0; j < keys.Length; j++)
                {
                    if (Depositors[i].IndexOf(keys[j]) == -1 || 
                        Depositors[i].IndexOf(keys[j]) == 0 || 
                        Depositors[i][Depositors[i].IndexOf(keys[j]) - 1] != '=')
                    {
                        break;
                    }

                    if(j == keys.Length - 1)
                    {
                        arr.Add(i);
                    }
                }
            }
            return arr;
        }
        public List<int> MainSearch(string nm, string snm, string pnm)
        {
            List<int> arr = new List<int>();
            for (int i = 0; i < Depositors.Length; i++)
            {
                
                if (nm == Depositor.GetName(Depositors[i]) ||
                    snm == Depositor.GetSurname(Depositors[i]) ||
                    pnm == Depositor.GetPersNum(Depositors[i]))
                {
                    arr.Add(i);
                }

                if ((nm != "" && nm != Depositor.GetName(Depositors[i])) ||
                    (snm != "" && snm != Depositor.GetSurname(Depositors[i])) ||
                    (pnm != "" && pnm != Depositor.GetPersNum(Depositors[i])))
                {
                    arr.Remove(i);
                }
            }
            return arr;
        }
        public int StraightSearch(string str)
        {
            for(int i = 0; i < Depositors.Length; i++)
            {
                if (Depositors[i] == str)
                    return i;
            }
            return -1;
        }

        public void AddMoney(int who, double money) // adds money to a users money
        {
            if (who < 0 || who > Depositors.Length || money < 0) return;
            else
            {
                Depositor d = new Depositor();
                d.Update(Depositors[who]);
                d.SetMoney(money);
                d.SetLastDate();
                Depositors[who] = d.ToString();
                Save();
            }

        }

        public void TakeMoney(int who, double money) // takes money from a user
        {
            if (who < 0 || who > Depositors.Length || money < 0) return;
            else
            {
                Depositor d = new Depositor();
                d.Update(Depositors[who]);
                if (d.Money >= money) d.SetMoney(-money);
                d.SetLastDate();
                Depositors[who] = d.ToString();
                Save();
            }
        }

        public void AddDepositor(string name, string surname, int category, double money) // creates a user
        {
            Depositor d = new Depositor(name, surname, category, money);
            Array.Resize(ref Depositors, Depositors.Length + 1);
            Depositors[Depositors.Length - 1] = d.ToString();
            Save();
        }

        public void AddPercent() // adds money to users' money equivalent to their category and time left
        {
            for(int i = 0; i < Depositors.Length; i++)
            {
                Depositor d = new Depositor();
                d.Update(Depositors[i]);
                long delta = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds - d.LastMilliseconds;
                double k = Convert.ToDouble(delta) / Convert.ToDouble(Interval);
                double money = (d.Money * d.Category / 100) * k;
                if (money < 0) continue;
                else
                {
                    d.SetMoney(Math.Round(money, 2));
                }
                d.SetLastMilliseconds();
                Depositors[i] = d.ToString();
            }
            Save();
        }

        public string Delete(int index) // deletes a user from and puts the las one on their place
        {
            string t = Depositors[index];
            Depositors[index] = Depositors[Depositors.Length - 1];
            Array.Resize(ref Depositors, Depositors.Length - 1);
            Save();
            return t;
        }
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
