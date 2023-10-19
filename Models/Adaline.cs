using System.Globalization;
public class Adaline
{
    // Declaraçao de variaveis.
    private double[] x1;
    private double[] x2;
    private double[] target;
    private double[] saidaIntermediaria;
    private double[] saida;

    private double x0;
    private double w0;
    private double w1;
    private double w2;

    private int nrCasos;
    private double taxaAprendizado;

    public Adaline()
    {
        // Construtor vazio para possibilitar a instância da classe em outros programas.
    }

    // Inicializa o terminal de inserção de informações de treinamento da RNA.

    /* A biblioteca System.Globalization e utilizado para que nao ocorra erro na conversao
       de string para double.*/
    public void Inicializar()
    {
        // Captura do número de casos e taxa de aprendizado
        // Validação de entradas com tratamento de exceção.
        Console.Write("Digite o número de casos: ");
        if (!int.TryParse(Console.ReadLine(), out nrCasos) || nrCasos <= 0)
        {
            throw new Exception("Número de casos inválido. Certifique-se de inserir um número inteiro positivo.");
        }
        
        Console.Write("Digite a taxa de aprendizado: ");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out taxaAprendizado) || taxaAprendizado <= 0.0)
        {
            throw new Exception("Taxa de aprendizado inválida. Certifique-se de inserir um número decimal positivo.");
        }
    
        saidaIntermediaria = new double[nrCasos];
        saida = new double[nrCasos];

        Console.Write("Digite o valor de X0: ");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out x0))
        {
            throw new Exception("Valor de X0 inválido. Certifique-se de inserir um número decimal válido.");
        }

        x1 = new double[nrCasos];
        Console.Write($"Digite {nrCasos} valores de X1 separados por espaços: ");
        string[] inputX1 = Console.ReadLine().Split();

        if (inputX1.Length < nrCasos)
        {
            throw new Exception($"Digite {nrCasos} valores de X1!");
        }

        for (int i = 0; i < nrCasos; i++)
        {
            if (!double.TryParse(inputX1[i], NumberStyles.Float, CultureInfo.InvariantCulture, out x1[i]))
            {
                throw new Exception($"Valor de X1 inválido. Certifique-se de inserir um número decimal válido para o {i + 1}º caso.");
            }
        }

        x2 = new double[nrCasos];
        Console.Write($"Digite {nrCasos} valores de X2 separados por espaços: ");
        string[] inputX2 = Console.ReadLine().Split();

        if (inputX2.Length < nrCasos)
        {
            throw new Exception($"Digite {nrCasos} valores de X2!");
        }

        for (int i = 0; i < nrCasos; i++)
        {
            if (!double.TryParse(inputX2[i], NumberStyles.Float, CultureInfo.InvariantCulture, out x2[i]))
            {
                throw new Exception($"Valor de X1 inválido. Certifique-se de inserir um número decimal válido para o {i + 1}º caso.");
            }
        }

        Console.Write("Digite o valor de W0: ");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out w0))
        {
            throw new Exception("Valor de W0 inválido. Certifique-se de inserir um número decimal válido.");
        }

        Console.Write("Digite o valor de W1: ");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out w1))
        {
            throw new Exception("Valor de W1 inválido. Certifique-se de inserir um número decimal válido.");
        }

        Console.Write("Digite o valor de W2: ");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out w2))
        {
            throw new Exception("Valor de W2 inválido. Certifique-se de inserir um número decimal válido.");
        }

        target = new double[nrCasos];
        Console.Write($"Digite {nrCasos} valores de target separados por espaços: ");
        string[] inputTarget = Console.ReadLine().Split();

        if (inputTarget.Length < nrCasos)
        {
            throw new Exception($"Digite {nrCasos} valores de input!");
        }

        for (int i = 0; i < nrCasos; i++)
        {
            if (!double.TryParse(inputTarget[i], NumberStyles.Float, CultureInfo.InvariantCulture, out target[i]))
            {
                throw new Exception($"Valor de target inválido. Certifique-se de inserir um número decimal válido para o {i + 1}º caso.");
            }
        }
    
    }
    // Realiza o calculo da saida intermediaria da RNA. (Metodo)
    private void CalculaSaidaIntermediaria()
    {
        // Realiza o cálculo da saída intermediária para cada caso.
        for (int i = 0; i < nrCasos; i++)
        {
            saidaIntermediaria[i] = x0 * w0 + x1[i] * w1 + x2[i] * w2;
            saida[i] = (saidaIntermediaria[i] > 0.0) ? 1.0 : -1.0;
        }
    }
    // Realiza o treinamento da RNA Adaline.
    public void Treinar()
    {
        // Inicialização de variáveis para controle do treinamento.
        int nTreinos = 0;
        int nAcertos = 0;
        double erro = 0.0;

        // Loop de treinamento com ajuste de pesos.
        do
        {
            nTreinos += 1;
            nAcertos = 0;

            for (int i = 0; i < nrCasos; i++)
            {
                CalculaSaidaIntermediaria();

                if (saida[i] == target[i])
                {
                    nAcertos++;
                }

                Console.WriteLine($"Treino: {nTreinos}, acertos: {nAcertos}");

                if (nAcertos == nrCasos)
                {
                    break;
                }
                else
                {
                    erro = target[i] - saidaIntermediaria[i];
                    double xQuadrado = x0 * x0 + x1[i] * x1[i] + x2[i] * x2[i];
                    w0 += taxaAprendizado * erro * (x0 / xQuadrado);
                    w1 += taxaAprendizado * erro * (x1[i] / xQuadrado);
                    w2 += taxaAprendizado * erro * (x2[i] / xQuadrado);
                }
            }
        } while (nAcertos < nrCasos);

        Console.WriteLine($"W1-Final: {w1}, W2-Final: {w2}");
    }
}