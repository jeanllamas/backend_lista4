using System;

namespace backend_lista4
{
    class Lista4
    {
        static void Main(string[] args)
        {
            int ligado = 1; //"Liga" o programa
            do
            {
                Console.Clear();
                Console.WriteLine("Jean Augusto - Lista 4" + Environment.NewLine);

                for (int i = 1; i <= 8; i++)
                {
                    Console.WriteLine($"{i} - Exercício {i}");
                }
                Console.WriteLine(Environment.NewLine + "Sair - Encerrar programa");
                Console.WriteLine(Environment.NewLine + "Selecione um número para acessar o exercício (Ex.: '4' para exercício 4):");

                var entrada = Console.ReadLine();

                switch (entrada) //Encerra quando o usuário escolher a opção de sair
                {
                    case "sair":
                    case "Sair":
                        ligado = 0; //"Desliga" o programa
                        continue;
                }

                bool checagem = int.TryParse(entrada, out int num_exercicio); /*Retorna verdadeiro se a conversão da entrada para inteiro der certo
                                                                                e move o número correspondente ao exercício para uma int */
                if (checagem)
                {
                    if (num_exercicio >= 1 && num_exercicio <= 8)
                    {
                        Console.Clear();
                        Exercicios(num_exercicio); //Encaminha para o exercício escolhido
                    }
                    else
                    {
                        Console.WriteLine(Environment.NewLine + $"Não há Exercício {num_exercicio}. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Opção inválida. Tente novamente.");
                }

                //Mensagem para retornar ou encerrar
                Console.WriteLine(Environment.NewLine + "Voltar ao início? (S/N)");
                var voltar = Console.ReadLine();

                switch (voltar)
                {
                    case "S":
                    case "s":
                        continue; //Mantém o programa "ligado"
                    default:
                        ligado = 0; //"Desliga" o programa
                        continue;
                }

            } while (ligado == 1);
        }

        public static List<int> LerEntradas(int NumeroDeEntradas)
        {
            List<int> entradas = new List<int>();

            for (int i = 0; i < NumeroDeEntradas; i++)
            {
                Console.Write("Digite um número: ");
                entradas.Add(Convert.ToInt32(Console.ReadLine()));
            }

            return entradas;
        }

        public static void ImprimirEntradas(List<int> arrayNumeros)
        {
            foreach (int numero in arrayNumeros)
            {
                Console.WriteLine(numero);
            }
        }

        public static List<int> GerarEntradas(int NumerosAleatorios)
        {
            Random r = new Random();
            List<int> NumerosGerados = new List<int>();

            for (int i = 0; i < NumerosAleatorios; i++)
            {
                NumerosGerados.Add(r.Next(0, 100));
            }
            return NumerosGerados;
        }

        static void Exercicios(int escolha)
        {
            switch (escolha)
            {
                case 1: //Exercício 1
                    {
                        ImprimirEntradas(LerEntradas(10));
                        break;
                    }

                case 2: //Exercício 2
                    {
                        List<int> matriculas = new List<int>();

                        Console.WriteLine("Matrículas de Alunos");

                        while (matriculas.Count < 10)
                        {
                            Console.WriteLine($"Digite o nº da matrícula do aluno {matriculas.Count + 1}: ");
                            int matricula = Convert.ToInt32(Console.ReadLine());

                            if (matriculas.Contains(matricula))
                            {
                                Console.WriteLine("Essa matrícula já foi inserida!" + Environment.NewLine);
                            }
                            else
                            {
                                matriculas.Add(matricula);
                            }
                        }

                        Console.WriteLine(Environment.NewLine + "===== Matrículas =====");

                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"Aluno {i + 1} = {matriculas[i]}");
                        }
                        break;
                    }

                case 3: //Exercício 3
                    {
                        List<int> lista = new List<int>();
                        int numero = 0;

                        while (numero != 999)
                        {
                            Console.Write("Digite um número (999 para sair): ");
                            numero = Convert.ToInt32(Console.ReadLine());
                            if (numero != 999)
                            {
                                lista.Add(numero);
                            }
                        }

                        Console.Write("Números digitados na ordem inversa: ");

                        for (int i = lista.Count - 1; i >= 0; i--)
                        {
                            Console.Write(lista[i] + " ");
                        }

                        break;
                    }

                case 4: //Exercício 4
                    {
                        //4A
                        Console.WriteLine("Matrículas");
                        List<int> matriculas = LerEntradas(10);

                        Console.WriteLine("Verificar matrícula:");

                        int matricula = Convert.ToInt32(Console.ReadLine());

                        if (LerMatricula(matricula, matriculas))
                        {
                            Console.WriteLine($"Matrícula {matricula} já inserida");
                        }
                        else
                        {
                            Console.WriteLine($"Não há matrícula {matricula}");
                        }

                        //4B
                        static bool LerMatricula(int matricula, List<int> matriculas)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (matriculas[i] == matricula)
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                        break;
                    }

                case 5: //Exercício 5
                    {
                        List<double> primeiraProva = new List<double>();
                        List<double> segundaProva = new List<double>();
                        List<double> medias = new List<double>();

                        double nota1 = 0;

                        while (nota1 != -1)
                        {
                            Console.Write($"Nota da 1ª prova do aluno {primeiraProva.Count + 1} (-1 para sair): ");
                            nota1 = Convert.ToDouble(Console.ReadLine());

                            if (nota1 != -1)
                            {
                                Console.Write($"Nota da 2ª prova do aluno {segundaProva.Count + 1}: ");
                                double nota2 = Convert.ToDouble(Console.ReadLine());

                                double media = (nota1 + nota2) / 2;
                                primeiraProva.Add(nota1);
                                segundaProva.Add(nota2);
                                medias.Add(media);
                            }
                        }

                        Console.WriteLine();

                        for (int i = 0; i < primeiraProva.Count; i++)
                        {
                            Console.Write($"Aluno {i + 1}: {primeiraProva[i]:0.00} | {segundaProva[i]:0.00} | {medias[i]:0.00} | ");
                            if (medias[i] >= 6)
                            {
                                Console.WriteLine("APROVADO");
                            }
                            else
                            {
                                Console.WriteLine("REPROVADO");
                            }
                        }

                        break;
                    }

                case 6: //Exercício 6
                    {
                        List<int> lista = LerEntradas(10);
                        int somaImpares = 0;

                        for (int i = 0; i < 10; i++)
                        {
                            if (lista[i] % 2 != 0)
                            {
                                somaImpares += lista[i];
                            }
                        }
                        Console.WriteLine("A soma dos números ímpares na lista é: " + somaImpares);

                        break;
                    }

                case 7: //Exercício 7
                    {
                        List<int> valores = LerEntradas(10);
                        List<int> moda = new();
                        int contagem = 0;

                        foreach (int valor in valores)
                        {
                            int repeticoes = valores.Count(numero => numero == valor);
                            if (repeticoes > contagem)
                            {
                                contagem = repeticoes;
                                moda.Clear();
                                moda.Add(valor);
                            }
                            else if (repeticoes == contagem && !moda.Contains(valor))
                            {
                                moda.Add(valor);
                            }
                        }

                        Console.Write(Environment.NewLine + "A moda dentre o conjunto numérico é ");
                        foreach (int num in moda) { Console.Write(num + " "); }
                        break;
                    }

                case 8: //Exercício 8
                    {
                        List<string> convidados = new List<string>();

                        string opcao = "";
                        while (opcao != "sair")
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Convidados");
                            Console.WriteLine("1 - Cadastrar");
                            Console.WriteLine("2 - Remover");
                            Console.WriteLine("3 - Exibir lista");
                            Console.WriteLine("sair - Encerrar programa");
                            Console.Write("Digite uma opção: ");

                            opcao = Console.ReadLine();

                            switch (opcao)
                            {
                                case "1": //Cadastrar
                                    Console.Write("Digite o nome do(a) convidado(a): ");
                                    string nome = Console.ReadLine();
                                    convidados.Add(nome);
                                    Console.WriteLine("Convidado(a) cadastrado com sucesso!");
                                    Console.ReadKey();
                                    break;

                                case "2": //Remover
                                    Console.Write("Digite o nome do(a) convidado(a) que deseja remover: ");
                                    nome = Console.ReadLine();
                                    bool removido = convidados.Remove(nome);
                                    if (removido)
                                    {
                                        Console.WriteLine("Convidado(a) removido(a)!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Convidado(a) não está na lista.");
                                    }
                                    Console.ReadKey();
                                    break;

                                case "3": //Exibir
                                    Console.WriteLine("Convidados na lista:");
                                    foreach (string convidado in convidados)
                                    {
                                        Console.WriteLine(convidado);
                                    }
                                    Console.ReadKey();
                                    break;

                                case "sair":
                                    break;

                                default:
                                    Console.WriteLine("Opção inválida!");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    }
            }
        }
    }
}