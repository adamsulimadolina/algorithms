using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace NWP1
{
    public class LongestSubstring
    {
        public int[,] tab;
        public int LCS(string s1, string s2)
        {
            tab = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i < s1.Length + 1; i++)
            {
                for (int j = 0; j < s2.Length + 1; j++)
                {
                    tab[i, j] = 0;
                }
            }
            for (int i = 1; i < s1.Length + 1; i++)
            {
                for (int j = 1; j < s2.Length + 1; j++)
                {
                    if (s1[i - 1] == s2[j - 1]) tab[i, j] = tab[i - 1, j - 1] + 1;
                    else if (tab[i - 1, j] >= tab[i, j - 1]) tab[i, j] = tab[i - 1, j];
                    else if (tab[i, j - 1] > tab[i - 1, j]) tab[i, j] = tab[i, j - 1];
                }
            }
            return tab[s1.Length, s2.Length];
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader("In0301.txt");
            StreamWriter write = new StreamWriter("Out0301.txt");
            string s1, s2, line;
            int param = 0, pointer = 0, ans = 0;
            if ((line = read.ReadLine()) != null) param = int.Parse(line);
            string[,] stringtab = new string[param, 2];
            while ((s1 = read.ReadLine()) != null && (s2 = read.ReadLine()) != null)
            {
                stringtab[pointer, 0] = s1;
                stringtab[pointer, 1] = s2;
                pointer++;
            }
            LongestSubstring answer = new LongestSubstring();
            for (int i = 0; i < pointer; i++)
            {
                ans = answer.LCS(stringtab[i, 0], stringtab[i, 1]);
                write.WriteLine(ans);
            }
            write.Close();
            read.Close();
        }
    }
}
