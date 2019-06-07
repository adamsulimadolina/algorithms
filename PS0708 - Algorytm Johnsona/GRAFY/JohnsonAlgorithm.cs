using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GRAFY
{
    public class JohnsonAlgorithm
    {
        private int[] d = new int[7];
        private static int infinity = 99999;
        private static int[,] G = new int[1, 1];
        private void InputData(StreamReader read)
        {
            int topCounter = int.Parse(read.ReadLine());
            G = new int[topCounter+1, topCounter+1];
            for (int i = 0; i < G.GetLength(0); i++)
            {
                for(int j=0; j< G.GetLength(0); j++)
                {
                    if (i != 0) G[i, j] = infinity;
                    else G[i, j] = 0;
                }
            }
            string line;
            while((line=read.ReadLine())!=null)
            {
                string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string aux = tmp[0];
                int actualTop = Convert.ToInt32(aux[1])-48;
                for(int i=1; i<tmp.Length;i++)
                {
                    char[] edge = tmp[i].ToCharArray();
                    int top = Convert.ToInt32(edge[0])-48;
                    int weight;
                    if (edge[2] != '-')
                    {
                        weight = Convert.ToInt32(edge[2]) - 48;
                    }
                    else
                    {
                        weight = Convert.ToInt32(edge[3]) - 48;
                        weight *= -1;
                    }
                    G[actualTop, top] = weight;
                }
            }
        }
        private void BellmanFord(int s,  StreamWriter save)
        {

            for (int j = 0; j < G.GetLength(0); j++) d[j] = infinity;
            d[0] = 0;
            for (int i = 0; i < G.GetLength(0)-1; i++)
            {
                for (int j = 0; j < G.GetLength(0); j++)
                {
                    for (int k = 0; k < G.GetLength(0); k++)
                    {
                        if (d[k] > d[j] + G[j, k] && G[j, k] != infinity && j != k)
                        {
                            d[k] = d[j] + G[j, k];
                        }
                    }
                }
            }
            for (int i = 0; i < G.GetLength(0)-1; i++)
            {
                save.Write($"{d[i]} ");
            }
            save.WriteLine();
        }
        private int[,] GenerateGPrim(StreamWriter save)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (G[i, j] != infinity)
                    {
                        G[i, j] = G[i, j] + d[i] - d[j];
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                save.Write($"[{i}] ");
                for (int j = 0; j < 7; j++)
                {
                    if (G[i, j] < infinity)
                    {
                        save.Write($"{j}({G[i, j]}) ");
                    }
                }
                save.WriteLine();
            }
            return G;
        }
        private int minIndex(bool[] CheckedTab, int[] DistTab)
        {
            int index = 1, min = infinity;
            for (int i = 1; i < DistTab.Length; i++)
            {
                if (DistTab[i] < min && CheckedTab[i] != true)
                {
                    min = DistTab[i];
                    index = i;
                }
            }
            return index - 1;
        }
        private void DikstraAlgorithm(int TopCounter, int StartPoint, StreamWriter save)
        {
            int[] DistTab = new int[TopCounter];
            int[] PredTab = new int[TopCounter];
            bool[] IsCheckedTab = new bool[TopCounter];
            int min = -1, max = infinity;
            for (int i = 0; i < DistTab.Length; i++)
            {

                DistTab[i] = max;
                PredTab[i] = min;
                IsCheckedTab[i] = false;

            }
            int counter = 0;
            DistTab[StartPoint] = 0;
            for (int i = StartPoint; i < TopCounter; i++)
            {
                for (int j = 1; j < TopCounter; j++)
                {
                    if (DistTab[j] > G[i, j] + DistTab[i] && G[i, j] != infinity)
                    {
                        DistTab[j] = G[i, j] + DistTab[i];
                        PredTab[j] = i;
                    }
                }
                IsCheckedTab[i] = true;
                counter++;
                if (counter == TopCounter) break;
                i = minIndex(IsCheckedTab, DistTab);
            }

            save.Write("Delta^[{0}][", StartPoint);
            for (int i = 1; i < DistTab.Length; i++)
            {
                if (DistTab[i] < 9999) save.Write("{0} ", DistTab[i]);
                else save.Write("∞ ");
            }
            save.Write("], ");

            GenerateDMatrix(DistTab, StartPoint, save);
        }
        private void GenerateDMatrix(int[] DistTab, int StartPoint, StreamWriter save)
        {
            int[] TempTab = new int[DistTab.Length];
            for (int i = 1; i < TempTab.Length; i++)
            {
                TempTab[i] = DistTab[i] + d[i] - d[StartPoint];
            }
            save.Write($"D[{StartPoint}][");
            for (int i = 1; i < TempTab.Length; i++)
            {
                if (DistTab[i] < 9999) save.Write($"{TempTab[i]} ");
                else save.Write("∞ ");
            }
            save.Write("]");
            save.WriteLine();
        }
        public void Johnson()
        {
            StreamWriter output = new StreamWriter("Out0502.txt");
            StreamReader input = new StreamReader("In0502.txt");
            JohnsonAlgorithm x = new JohnsonAlgorithm();
            x.InputData(input);
            x.BellmanFord(0, output);
            G = x.GenerateGPrim(output);
            for (int i = 1; i < G.GetLength(0); i++)
            {
                x.DikstraAlgorithm(7, i, output);
            }
            output.Close();
        }
    }
}

