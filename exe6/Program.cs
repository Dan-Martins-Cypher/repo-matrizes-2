using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int linhas = LerTamanho("Digite o numero de linhas: ");
        int colunas = LerTamanho("Digite o numero de colunas: ");

        double[,] matrizA = GerarMatriz(linhas, colunas);
        double[,] matrizB = GerarMatriz(linhas, colunas);

        ExecutarMenu(matrizA, matrizB);
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

    static void ExecutarMenu(double[,] matrizA, double[,] matrizB)
    {
        string opcao = "";

        while (opcao != "e")
        {
            Console.WriteLine();
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("(a) Somar as duas matrizes");
            Console.WriteLine("(b) Subtrair a primeira matriz da segunda");
            Console.WriteLine("(c) Adicionar uma constante as duas matrizes");
            Console.WriteLine("(d) Imprimir as matrizes");
            Console.WriteLine("(e) Sair");
            Console.Write("Escolha uma opcao: ");
            opcao = Console.ReadLine().ToLower();

            if (opcao == "a")
            {
                double[,] matrizC = SomarMatrizes(matrizA, matrizB);
                Console.WriteLine();
                Console.WriteLine("Resultado da soma (matriz 1 + matriz 2):");
                ImprimirMatriz(matrizC);
            }
            else if (opcao == "b")
            {
                double[,] matrizC = SubtrairMatrizes(matrizB, matrizA);
                Console.WriteLine();
                Console.WriteLine("Resultado da subtracao (matriz 2 - matriz 1):");
                ImprimirMatriz(matrizC);
            }
            else if (opcao == "c")
            {
                Console.Write("Digite o valor da constante: ");
                double constante = double.Parse(Console.ReadLine());
                AdicionarConstante(matrizA, constante);
                AdicionarConstante(matrizB, constante);
                Console.WriteLine("Constante adicionada nas duas matrizes.");
            }
            else if (opcao == "d")
            {
                Console.WriteLine();
                Console.WriteLine("Matriz 1:");
                ImprimirMatriz(matrizA);
                Console.WriteLine();
                Console.WriteLine("Matriz 2:");
                ImprimirMatriz(matrizB);
            }
            else if (opcao == "e")
            {
                Console.WriteLine("Encerrando o programa...");
            }
            else
            {
                Console.WriteLine("Opcao invalida.");
            }
        }
    }

    static double[,] GerarMatriz(int linhas, int colunas)
    {
        double[,] matriz = new double[linhas, colunas];
        Random sorteio = new Random();

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                matriz[i, j] = sorteio.Next(0, 101) / 10.0;
            }
        }

        return matriz;
    }

    static double[,] SomarMatrizes(double[,] matrizA, double[,] matrizB)
    {
        int linhas = matrizA.GetLength(0);
        int colunas = matrizA.GetLength(1);
        double[,] resultado = new double[linhas, colunas];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                resultado[i, j] = matrizA[i, j] + matrizB[i, j];
            }
        }

        return resultado;
    }

    static double[,] SubtrairMatrizes(double[,] matrizA, double[,] matrizB)
    {
        int linhas = matrizA.GetLength(0);
        int colunas = matrizA.GetLength(1);
        double[,] resultado = new double[linhas, colunas];

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                resultado[i, j] = matrizA[i, j] - matrizB[i, j];
            }
        }

        return resultado;
    }

    static void AdicionarConstante(double[,] matriz, double constante)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                matriz[i, j] = matriz[i, j] + constante;
            }
        }
    }

    static void ImprimirMatriz(double[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write(matriz[i, j].ToString("F1").PadLeft(8));
            }
            Console.WriteLine();
        }
    }
}
