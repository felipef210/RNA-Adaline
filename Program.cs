// Nomes: Felipe Miranda e Neemias Vieira - RA: 152799 e 170550
class Program
{
    static void Main()
    {
        Console.WriteLine("---Bem vindo ao treinamento RNA Adalaine---" + "\n");
        Adaline adaline = new Adaline();
        adaline.Inicializar();
        adaline.Treinar();
        Console.Write("Pressione qualquer tecla para encerrar o programa...");
        Console.ReadLine();
    }
}

/*---Sugestões de valores nos inputs---
Sugestão 1:
    nrCasos: 16
    taxaAprendizado: 0.0001
    x0: 1
    x1: 25 22 30 27 4 6 10 3 26 33 2 0 29 5 1 28
    x2: 34 37 33 37 40 38 44 42 31 30 47 45 29 43 41 30
    w0: 0
    w1: 0.02
    w2: 0.01
    input: -1 -1 -1 -1 1 1 1 1 -1 -1 1 1 -1 1 1 -1

Sugestão 2:
    nrCasos: 8
    taxaAprendizado: 0.0001
    x0: 1
    x1: 25 22 30 27 4 6 10 3
    x2: 34 37 33 37 40 38 44 42
    w0: 0
    w1: 0.02
    w2: 0.01
    input: -1 -1 -1 -1 1 1 1 1
*/