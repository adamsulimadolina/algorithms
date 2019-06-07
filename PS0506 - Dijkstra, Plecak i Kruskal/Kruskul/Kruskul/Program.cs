using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace Kruskul
{
    public class Edge
    {
        public int top1;
        public int top2;
        public int weight;
    }
    public class KruskalAlgorithm
    {
        public void Answer(int TopNum, int EdgeNum, List<Edge> EdgeList, StreamWriter write)
        {
            EdgeList.Sort((p, q) => p.weight.CompareTo(q.weight));
            int[] HelpTab = new int[TopNum];
            Edge[] AnswerTab = new Edge[TopNum - 1];
            int counter = 0;
            for (int i = 1; i <= TopNum; i++)
            {
                HelpTab[i - 1] = i;
            }
            foreach (Edge ed in EdgeList)
            {
                if (HelpTab[ed.top1 - 1] != HelpTab[ed.top2 - 1])
                {
                    if (HelpTab[ed.top1 - 1] > HelpTab[ed.top2 - 1])
                    {
                        for (int i = 0; i < TopNum; i++)
                        {
                            if (HelpTab[i] == HelpTab[ed.top2 - 1]) HelpTab[i] = HelpTab[ed.top1 - 1];
                        }
                        write.WriteLine("{0} {1} [{2}]", ed.top1, ed.top2, ed.weight);
                        counter++;
                    }
                    else
                    {
                        for (int i = 0; i < TopNum; i++)
                        {
                            if (HelpTab[i] == HelpTab[ed.top1 - 1]) HelpTab[i] = HelpTab[ed.top2 - 1];
                        }
                        write.WriteLine("{0} {1} [{2}]", ed.top1, ed.top2, ed.weight);
                        counter++;
                    }
                }
                if (counter == TopNum - 1) break;
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader("In0303.txt");
            StreamWriter write = new StreamWriter("Out0303.txt");
            List<Edge> EdgeList = new List<Edge>();
            string InputLine;
            int TopNum = 0, EdgeNum = 0, TopCounter = 0;
            if ((InputLine = read.ReadLine()) != null)
            {
                string[] tmp = InputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                TopNum = int.Parse(tmp[0]);
                EdgeNum = int.Parse(tmp[1]);
            }
            while ((InputLine = read.ReadLine()) != null)
            {
                TopCounter++;
                string[] tmp = InputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tmp.Length; i++)
                {
                    Edge edge = new Edge();
                    edge.top1 = TopCounter;
                    edge.top2 = int.Parse(tmp[i++]);
                    edge.weight = int.Parse(tmp[i]);
                    EdgeList.Add(edge);
                }
            }
            KruskalAlgorithm algor = new KruskalAlgorithm();
            algor.Answer(TopNum, EdgeNum, EdgeList, write);
            read.Close();
            write.Close();
        }
    }
}
