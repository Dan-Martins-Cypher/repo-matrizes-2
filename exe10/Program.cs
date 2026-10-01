using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] xInicial = new int[n];
        int[] xFinal = new int[n];
        int[] yInicial = new int[n];
        int[] yFinal = new int[n];

        for (int i = 0; i < n; i++)
        {
            string[] partes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            xInicial[i] = int.Parse(partes[0]);
            xFinal[i] = int.Parse(partes[1]);
            yInicial[i] = int.Parse(partes[2]);
            yFinal[i] = int.Parse(partes[3]);
        }

        int area = CalcularAreaCoberta(xInicial, xFinal, yInicial, yFinal);

        Console.WriteLine(area);
    }

    static int CalcularAreaCoberta(int[] xInicial, int[] xFinal, int[] yInicial, int[] yFinal)
    {
        int maiorX = 0;
        int maiorY = 0;

        for (int i = 0; i < xFinal.Length; i++)
        {
            if (xFinal[i] > maiorX)
            {
                maiorX = xFinal[i];
            }

            if (yFinal[i] > maiorY)
            {
                maiorY = yFinal[i];
            }
        }

        bool[,] mar = new bool[maiorX + 1, maiorY + 1];

        for (int i = 0; i < xInicial.Length; i++)
        {
            for (int x = xInicial[i]; x <= xFinal[i]; x++)
            {
                for (int y = yInicial[i]; y <= yFinal[i]; y++)
                {
                    mar[x, y] = true;
                }
            }
        }

        int area = 0;

        for (int x = 0; x <= maiorX; x++)
        {
            for (int y = 0; y <= maiorY; y++)
            {
                if (mar[x, y])
                {
                    area++;
                }
            }
        }

        return area;
    }
}
