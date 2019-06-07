using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace Dikstra
{
    public class DjikstraAlgorithm
    {
        public int minIndex(bool[] CheckedTab, int[] DistTab)
        {
            int index = 0, min = 9999;
            for(int i=0; i<DistTab.Length;i++)
            {
                if(DistTab[i]<min && CheckedTab[i]!=true)
                {
                    min = DistTab[i];
                    index = i;
                }
            }
            return index;
        }
        public void DijkstraAlgorithm(int TopCounter, int FinishPoint, int[,] weightTab, StreamWriter save)
        {
            int[] DistTab = new int[TopCounter];
            int[] PredTab = new int[TopCounter];
            bool[] IsCheckedTab = new bool[TopCounter];
            int min = -1, max = 9999;
            for (int i = 0; i < DistTab.Length; i++)
            {

                DistTab[i] = max;
                PredTab[i] = min;
                IsCheckedTab[i] = false;

            }
            int counter = 0;
            DistTab[FinishPoint - 1] = 0;
            for (int i = 0; i < TopCounter;)
            {
                for (int j = 0; j < TopCounter; j++)
                {
                    if (DistTab[j] > weightTab[j, i] + DistTab[i])
                    {
                        DistTab[j] = weightTab[j, i] + DistTab[i];
                        PredTab[j] = i + 1;
                    }
                }
                IsCheckedTab[i] = true;
                counter++;
                if (counter == TopCounter) break;
                i = minIndex(IsCheckedTab, DistTab);
            }

            save.Write("dist[");
            for (int i = 0; i < DistTab.Length; i++)
            {
                save.Write(" {0} ", DistTab[i]);
            }
            save.Write("]");
            save.WriteLine();
            save.Write("pred[");
            for (int i = 0; i < DistTab.Length; i++)
            {
                save.Write(" {0} ", PredTab[i]);
            }
            save.Write("]");
            save.WriteLine();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int TopCounter = 0, FinishTop = 0, j = 0;
            StreamReader read = new StreamReader("In0305.txt");
            StreamWriter write = new StreamWriter("Out0305.txt");
            string line;
            if((line=read.ReadLine())!=null)
            {
                string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                TopCounter = int.Parse(tmp[0]);
                FinishTop = int.Parse(tmp[1]);
            }
            int[,] Data = new int[TopCounter,TopCounter];
            while ((line=read.ReadLine())!=null)
            {
                string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for(int i=0; i<TopCounter;i++)
                {
                    Data[j, i] = int.Parse(tmp[i]);
                }
                j++;
            }
            DjikstraAlgorithm alg = new DjikstraAlgorithm();
            alg.DijkstraAlgorithm(TopCounter, FinishTop, Data, write);
            read.Close();
            write.Close();
        }
    }
}
