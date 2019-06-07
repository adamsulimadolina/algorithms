using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace Kruskal2
{
    public class Item
    {
        public int value;
        public int weight;
        public Item()
        {
            value = 0;
            weight = 0;

        }
    }
    public class ValueTab
    {
        public int value;
        public bool taken;
        public ValueTab()
        {
            value = 0;
            taken = false;
        }
    }
    public class BackpackProblem
    {
        public void BPP(Item[] tab, int maxW, StreamWriter write)
        {
            ValueTab[,] valuetab = new ValueTab[maxW + 1, tab.Length];
            int max = 0, counter = 0;
            bool was = false;
            for (int i = 0; i < maxW + 1; i++)
            {
                for (int j = 0; j < tab.Length; j++)
                {
                    valuetab[i, j] = new ValueTab();
                }
            }
            for (int i = 0; i < maxW + 1; i++)
            {
                for (int j = 1; j < tab.Length; j++)
                {
                    if (i < tab[j].weight && i != 0)
                    {
                        valuetab[i, j].value = valuetab[i, j - 1].value;
                        valuetab[i, j].taken = false;
                    }
                    else if (i >= tab[j].weight)
                    {
                        if (valuetab[i, j - 1].value > valuetab[i - tab[j].weight, j - 1].value + tab[j].value)
                        {
                            valuetab[i, j].value = valuetab[i, j - 1].value;
                            valuetab[i, j].taken = false;
                        }
                        else
                        {
                            valuetab[i, j].value = valuetab[i - tab[j].weight, j - 1].value + tab[j].value;
                            valuetab[i, j].taken = true;
                            if (max == valuetab[i, j].value) counter++;
                            else
                            {
                                counter = 0;
                                max = valuetab[i, j].value;
                            }
                        }
                    }
                }
            }
            List<string> answers = new List<string>();
            for (int i = maxW; i >= 0; i--)
            {
                for (int j = tab.Length - 1; j >= 0; j--)
                {
                    was = false;
                    if (valuetab[i, j].value == max && valuetab[i,j].taken == true)
                    {
                        int p1 = i, p2 = j;
                        string answer = "";
                        while (p1 != 0 && p2 != 0)
                        {
                            if (valuetab[p1, p2].taken == false) p2--;
                            else
                            {
                                answer = " " + Convert.ToString(p2) + answer;
                                p1 -= tab[p2].weight;
                                p2--;
                            }
                        }
                        foreach(string x in answers)
                        {
                            if (x.Equals(answer))
                            {
                                was = true;
                                break;
                            }
                        }
                        if (was == false)
                        {
                            answers.Add(answer);
                            write.Write("{0} ", answer);
                        }
                        write.WriteLine();
                    }
                }
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader("In0302.txt");
            StreamWriter write = new StreamWriter("Out0302.txt");
            string line;
            int maxWeight = 0, itemCounter = 0, i = 1;
            if ((line = read.ReadLine()) != null)
            {
                string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                maxWeight = int.Parse(tmp[1]);
                itemCounter = int.Parse(tmp[0]);
            }
            Item[] table = new Item[itemCounter + 1];
            for (int j = 0; j < itemCounter + 1; j++)
            {
                table[j] = new Item();
            }
            while ((line = read.ReadLine()) != null)
            {
                string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                table[i].value = int.Parse(tmp[0]);
                table[i++].weight = int.Parse(tmp[1]);
            }
            BackpackProblem bp = new BackpackProblem();
            bp.BPP(table, maxWeight,write);
            read.Close();
            write.Close();
        }
    }
}
