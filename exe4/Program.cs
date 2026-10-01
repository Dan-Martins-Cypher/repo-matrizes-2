using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int ordem = LerOrdem();

        int[,] matriz = new int[ordem, ordem];
        Random sorteio = new Random();

        for (int i = 0; i < ordem; i++)
        {
            for (int j = 0; j < ordem; j++)
            {
                matriz[i, j] = sorteio.Next(0, 100);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Matriz gerada:");
        ImprimirMatriz(matriz);

        Console.WriteLine();
        ImprimirDiagonalSecundaria(matriz);
    }

    static int LerOrdem()
    {
        int ordem = 0;

        while (ordem < 1 || ordem > 100)
        {
            Console.Write("Digite a ordem da matriz (1 a 100): ");
            ordem = int.Parse(Console.ReadLine());

            if (ordem < 1 || ordem > 100)
            {
                Console.WriteLine("Valor invalido. A ordem deve estar entre 1 e 100.");
            }
        }

        return ordem;
    }

    static void ImprimirDiagonalSecundaria(int[,] matriz)
    {
        Console.WriteLine("Diagonal secundaria:");

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            Console.Write(matriz[i, matriz.GetLength(0) - 1 - i] + " ");
        }

        Console.WriteLine();
    }

    static void ImprimirMatriz(int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}
