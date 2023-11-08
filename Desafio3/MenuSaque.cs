using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio3
{
    public class MenuSaque
    {
        public static void MostrarOpcoesSaque(IConta conta)
        {
            bool sair = false;

            while (!sair) //enquanto a variável for verdadeira (! nega o false)
            {
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("            Opções de saque:           ");
                Console.WriteLine("       1 - Notas de maior valor        ");
                Console.WriteLine("       2 - Notas de menor valor        ");
                Console.WriteLine("       3 - Notas meio a meio           ");
                Console.WriteLine("       4 - Sair                        ");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao)) //converte string em int
                                                                 //out passa opcao como referencia
                {
                    switch (opcao)
                    {
                        case 1:
                            SacarNotasDeMaiorValor(conta);
                            break;
                        case 2:
                            SacarNotasDeMenorValor(conta);
                            break;
                        case 3:
                            SacarNotasMeioAMeio(conta);
                            break;
                        case 4:
                            Console.WriteLine("Saindo do menu de saque.");
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
        }

        private static void SacarNotasDeMaiorValor(IConta conta)
        {
            List<int> notasMaiorValor = new List<int> { 100, 50 }; 
            SacarNotas(conta, notasMaiorValor);
        }

        private static void SacarNotasDeMenorValor(IConta conta)
        {
            List<int> notasMenorValor = new List<int> { 20, 10, 5, 2 };
            SacarNotas(conta, notasMenorValor);
        }

        private static void SacarNotasMeioAMeio(IConta conta)
        {
            Console.WriteLine("       Informe o valor a sacar:       ");
            int valorSaque = int.Parse(Console.ReadLine());

            List<int> notasMaiorValor = new List<int> { 100, 50 };
            List<int> notasMenorValor = new List<int> { 20, 10, 5, 2 };

            int valorMaiorValor = valorSaque / 2;
            int valorMenorValor = valorSaque - valorMaiorValor;

            SacarNotas(conta, notasMaiorValor, valorMaiorValor);
            SacarNotas(conta, notasMenorValor, valorMenorValor);
        }

        private static void SacarNotas(IConta conta, List<int> notas)
        {
            Console.WriteLine("       Informe o valor a sacar:       ");
            int valorSaque = int.Parse(Console.ReadLine());
            SacarNotas(conta, notas, valorSaque);
        }

        private static void SacarNotas(IConta conta, List<int> notas, int valorSaque)
        {
            //dicionário armazena pares de chave valor (quantidade de notas, que é a chave, e o valor)
            Dictionary<int, int> notasSaque = new Dictionary<int, int>(); //criando instância do dicionário
            
            //percorre a coleção notas
            foreach (int nota in notas)
            {
                if (valorSaque >= nota)
                {
                    int quantidade = valorSaque / nota; //quantas notas do valor atual vão ser sacadas
                    notasSaque.Add(nota, quantidade); //adiciona as notas ao dicionário e registra quantas notas
                                                      //foram usadas
                    valorSaque -= nota * quantidade; //subtrai o valor das notas usadas
                }
            }

            if (valorSaque == 0) //a quantidade de dinheiro foi satisfeita pelas notas
            {
                //calcula o valor total do dinheiro sacado somando o valor de todas as notas
                //multiplicado pela quantidade de cada nota correspondente
                int valorEmprestimo = notasSaque.Sum(kvp => kvp.Key * kvp.Value); //kvp é variável temporária
                
                //se o valor do empréstimo for par
                if (valorEmprestimo % 2 == 0)
                {
                    Console.WriteLine("Notas sacadas com sucesso:");

                    //percorre o dicionário, e kvp representa cada par
                    foreach (var kvp in notasSaque)
                    {
                        Console.WriteLine($"{kvp.Value} x {kvp.Key} reais;");
                    }
                }
                else
                {
                    Console.WriteLine("O valor do empréstimo sacado não é par. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Não é possível sacar o valor desejado com as notas disponíveis.");
            }
        }
    }
}
