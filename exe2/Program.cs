using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int linhas = LerTamanho("Digite o numero de linhas: ");
        int colunas = LerTamanho("Digite o numero de colunas: ");

        int[,] matriz = new int[linhas, colunas];
        Random sorteio = new Random();

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matriz[i, j] = sorteio.Next(-50, 51);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Matriz gerada:");
        ImprimirMatriz(matriz);

        int menor = EncontrarMenor(matriz);

        Console.WriteLine();
        Console.WriteLine("O menor valor da matriz e: " + menor);
    }

    static int LerTamanho(string mensagem)
    {
        int tamanho = 0;

        while (tamanho <= 0)
        {
            Console.Write(mensagem);
            tamanho = int.Parse(Console.ReadLine());

            if (tamanho <= 0)
            {
                Console.WriteLine("Valor invalido. Digite um numero maior que zero.");
            }
        }

        return tamanho;
    }

    static int EncontrarMenor(int[,] matriz)
    {
        int menor = matriz[0, 0];

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (matriz[i, j] < menor)
                {
                    menor = matriz[i, j];
                }
            }
        }

        return menor;
    }

    static void ImprimirMatriz(int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j].ToString().PadLeft(5));
            }
            Console.WriteLine();
        }
    }
}
