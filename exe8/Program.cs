using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] listaX = new int[n];
        int[] listaY = new int[n];

        for (int i = 0; i < n; i++)
        {
            string[] partes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            listaX[i] = int.Parse(partes[0]);
            listaY[i] = int.Parse(partes[1]);
        }

        int resultado = VerificarRaioRepetido(listaX, listaY);

        Console.WriteLine(resultado);
    }

    static int VerificarRaioRepetido(int[] listaX, int[] listaY)
    {
        int[,] quadrantes = new int[501, 501];

        for (int i = 0; i < listaX.Length; i++)
        {
            quadrantes[listaX[i], listaY[i]]++;

            if (quadrantes[listaX[i], listaY[i]] > 1)
            {
                return 1;
            }
        }

        return 0;
    }
}
