using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int n = LerTamanho("Digite o tamanho N da matriz (N x N): ");

        int[,] mapa = new int[n, n];

        PreencherMapa(mapa);

        Console.WriteLine();
        ExibirMapa(mapa);

        int somaPrincipal = SomarDiagonalPrincipal(mapa);
        int somaSecundaria = SomarDiagonalSecundaria(mapa);

        Console.WriteLine();
        Console.WriteLine("Soma da Diagonal Principal: " + somaPrincipal);
        Console.WriteLine("Soma da Diagonal Secundária: " + somaSecundaria);
        Console.WriteLine();

        IndicarMaiorTesouro(somaPrincipal, somaSecundaria);
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

    static void PreencherMapa(int[,] mapa)
    {
        Random sorteio = new Random();

        for (int i = 0; i < mapa.GetLength(0); i++)
        {
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                mapa[i, j] = sorteio.Next(1, 101);
            }
        }
    }

    static void ExibirMapa(int[,] mapa)
    {
        Console.WriteLine("Mapa do Tesouro (Quantidade de Moedas em Cada Região):");

        for (int i = 0; i < mapa.GetLength(0); i++)
        {
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                Console.Write(mapa[i, j].ToString().PadRight(4));
            }
            Console.WriteLine();
        }
    }

    static int SomarDiagonalPrincipal(int[,] mapa)
    {
        int soma = 0;

        for (int i = 0; i < mapa.GetLength(0); i++)
        {
            soma = soma + mapa[i, i];
        }

        return soma;
    }

    static int SomarDiagonalSecundaria(int[,] mapa)
    {
        int soma = 0;
        int n = mapa.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            soma = soma + mapa[i, n - 1 - i];
        }

        return soma;
    }

    static void IndicarMaiorTesouro(int somaPrincipal, int somaSecundaria)
    {
        if (somaPrincipal > somaSecundaria)
        {
            Console.WriteLine("O maior tesouro está na diagonal principal, vamos para lá!");
        }
        else if (somaSecundaria > somaPrincipal)
        {
            Console.WriteLine("O maior tesouro está na diagonal secundária, vamos para lá!");
        }
        else
        {
            Console.WriteLine("As duas diagonais têm a mesma quantidade de moedas, podem escolher qualquer uma!");
        }
    }
}
