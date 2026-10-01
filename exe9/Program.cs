using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int regioes = LerTamanho("Digite o numero de regioes: ");
        int cidades = LerTamanho("Digite o numero de cidades por regiao: ");

        int[,] tropas = new int[regioes, cidades];

        PreencherMatriz(tropas);

        Console.WriteLine();
        ExibirMatriz(tropas);

        Console.WriteLine();
        ExibirForcaTotal(tropas);
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

    static void PreencherMatriz(int[,] tropas)
    {
        Random sorteio = new Random();

        for (int i = 0; i < tropas.GetLength(0); i++)
        {
            for (int j = 0; j < tropas.GetLength(1); j++)
            {
                tropas[i, j] = sorteio.Next(0, 101);
            }
        }
    }

    static void ExibirMatriz(int[,] tropas)
    {
        Console.WriteLine("Matriz das Tropas (Quantidade de Tropas por Cidade):");

        for (int i = 0; i < tropas.GetLength(0); i++)
        {
            Console.Write("Região " + (i + 1) + ": ");

            for (int j = 0; j < tropas.GetLength(1); j++)
            {
                Console.Write(tropas[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static int CalcularForcaRegiao(int[,] tropas, int regiao)
    {
        int soma = 0;

        for (int j = 0; j < tropas.GetLength(1); j++)
        {
            soma = soma + tropas[regiao, j];
        }

        return soma;
    }

    static void ExibirForcaTotal(int[,] tropas)
    {
        Console.WriteLine("Força Total das Regiões:");

        for (int i = 0; i < tropas.GetLength(0); i++)
        {
            int soma = CalcularForcaRegiao(tropas, i);
            Console.WriteLine("Região " + (i + 1) + ": " + soma + " tropas");
        }
    }
}
