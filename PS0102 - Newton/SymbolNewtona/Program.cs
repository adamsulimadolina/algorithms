using System;

namespace SymbolNewtona
{
    public class Wywolanie
    {
        int n, k;
        int wynik;
        int stan;
        public Wywolanie(int a, int b, int w, int s)
        {
            n = a;
            k = b;
            stan = s;
            wynik = w;
        }
        public void Show()
        {
            Console.WriteLine("n: {0}, k: {1}, wynik: {2}, stan: {3}", n, k, wynik, stan);
        }
    }
    public class Program
    {
        static int Newton(int n, int k)
        {
            if (n == k) return 1;
            if (k == 0) return 1;
            return Newton(n - 1, k - 1) + Newton(n - 1, k);
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
        }
    }
}
