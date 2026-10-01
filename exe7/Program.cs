using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Dados da primeira matriz:");
        int linhasA = LerTamanho("Digite o numero de linhas: ");
        int colunasA = LerTamanho("Digite o numero de colunas: ");

        Console.WriteLine();
        Console.WriteLine("Dados da segunda matriz:");
        int linhasB = LerTamanho("Digite o numero de linhas: ");
        int colunasB = LerTamanho("Digite o numero de colunas: ");

        int[,] matrizA = GerarMatriz(linhasA, colunasA);
        int[,] matrizB = GerarMatriz(linhasB, colunasB);

        Console.WriteLine();
        Console.WriteLine("Primeira matriz:");
        ImprimirMatriz(matrizA);

        Console.WriteLine();
        Console.WriteLine("Segunda matriz:");
        ImprimirMatriz(matrizB);

        Console.WriteLine();
        SomarMatrizes(matrizA, matrizB);
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

    static int[,] GerarMatriz(int linhas, int colunas)
    {
        int[,] matriz = new int[linhas, colunas];
        Random sorteio = new Random();

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matriz[i, j] = sorteio.Next(0, 10);
            }
        }

        return matriz;
    }

    static void SomarMatrizes(int[,] matrizA, int[,] matrizB)
    {
        if (matrizA.GetLength(0) != matrizB.GetLength(0) || matrizA.GetLength(1) != matrizB.GetLength(1))
        {
            Console.WriteLine("Nao e possivel somar: as matrizes nao sao da mesma ordem.");
            return;
        }

        int linhas = matrizA.GetLength(0);
        int colunas = matrizA.GetLength(1);
        int[,] resultado = new int[linhas, colunas];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                resultado[i, j] = matrizA[i, j] + matrizB[i, j];
            }
        }

        Console.WriteLine("Soma das matrizes:");
        ImprimirMatriz(resultado);
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
