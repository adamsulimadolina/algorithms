using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace WiezeHanoi3
{
    class Program
    {
        static void HanoiTower(int n, char beg, char mid, char end, List<string> tmp)
        {
            if (n > 0)
            {
                HanoiTower(n - 1, beg, end, mid, tmp);
                string x = Convert.ToString(beg) + "->" + Convert.ToString(end);
                tmp.Add(x);
                HanoiTower(n - 1, mid, beg, end, tmp);
            }
        }

        static void Main()
        {
            StreamReader read = new StreamReader("In0203.txt");
            StreamWriter write = new StreamWriter("Out0203.txt");
            string line = read.ReadLine();
            int param = int.Parse(line);
            List<string> result = new List<string>();
            HanoiTower(param, '1', '3', '2', result);
            foreach(string x in result)
            {
                write.Write(x);
                write.Write(", ");
            }
            write.Close();
            read.Close();
        }
    }
}
