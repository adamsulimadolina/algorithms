using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace _1c
{
    class Program
    {
        static void MergeSort(int[] table, int begin, int end)
        {
            if (end > begin)
            {
                int middle = (begin + end) / 2;
                MergeSort(table, begin, middle);
                MergeSort(table, middle + 1, end);
                Merge(table, begin, middle, end);
            }
        }
        static void Merge(int[] table, int begin, int mid, int end)
        {
            int i = begin;
            int j = mid + 1;
            int index = begin;
            int num = end - begin + 1;
            int[] tab = new int[(table.Length)];
            while (i <= mid && j <= end)
            {
                if (table[i] < table[j])
                {
                    tab[index++] = table[i++];
                }
                else
                {
                    tab[index++] = table[j++];
                }
            }
            while (i <= mid)
            {
                tab[index++] = table[i++];
            }
            while (j <= end)
            {
                tab[index++] = table[j++];
            }
            for (int k = 0; k < num; k++)
            {
                table[end] = tab[end];
                end--;
            }
        }
        static void Main(string[] args)
        {
            string line, size;
            int sizer;
            StreamReader read = new StreamReader("In0201.txt");
            StreamWriter write = new StreamWriter("Out0201.txt");
            int[] table = new int[1];
            size = read.ReadLine();
            line = read.ReadLine();
            sizer = int.Parse(size);
            string[] tmp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            table = new int[sizer];
            for (int j = 0; j < sizer; j++)
            {
                table[j] = int.Parse(tmp[j]);
            }

            MergeSort(table, 0, sizer - 1);
            for (int i = 0; i < sizer; i++)
            {
                write.Write("{0} ", table[i]);
            }
            write.Close();
            read.Close();
        }
    }
}
