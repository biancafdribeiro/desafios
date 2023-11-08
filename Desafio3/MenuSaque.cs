using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio3
{
    public class MenuSaque
    {
        public static void MostrarOpcoesSaque(IConta conta)
        {
            bool sair = false; // Adicione uma variável para controlar o loop

            while (!sair)
            {
                Console.WriteLine("Opções de saque:");
                Console.WriteLine("1 - Notas de maior valor:");
                Console.WriteLine("2 - Notas de menor valor");
                Console.WriteLine("3 - Notas meio a meio");
                Console.WriteLine("4 - Sair");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            SacarNotas(conta, conta.Notas.OrderByDescending(n => n).ToList());
                            break;
                        case 2:
                            SacarNotas(conta, conta.Notas.ToList());
                            break;
                        case 3:
                            List<int> notasMeioAMeio = new List<int>();
                            for (int i = 0; i < conta.Notas.Count; i++)
                            {
                                if (i % 2 == 0)
                                    notasMeioAMeio.Add(conta.Notas[i]);
                            }
                            SacarNotas(conta, notasMeioAMeio);
                            break;
                        case 4:
                            Console.WriteLine("Saindo do menu de saque.");
                            sair = true; // Define a variável 'sair' como verdadeira para sair do loop
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


        private static void SacarNotas(IConta conta, List<int> notas)
        {
            Console.WriteLine("Informe o valor a sacar:");
            int valorSaque = int.Parse(Console.ReadLine());

            Dictionary<int, int> notasSaque = new Dictionary<int, int>();

            foreach (int nota in notas)
            {
                if (valorSaque >= nota)
                {
                    int quantidade = valorSaque / nota;
                    notasSaque.Add(nota, quantidade);
                    valorSaque -= nota * quantidade;
                }
            }

            if (valorSaque == 0)
            {
                // Verificar se o valor do empréstimo sacado é par
                int valorEmprestimo = notasSaque.Sum(kvp => kvp.Key * kvp.Value);
                if (valorEmprestimo % 2 == 0)
                {
                    Console.WriteLine("Notas sacadas com sucesso:");
                    foreach (var kvp in notasSaque)
                    {
                        Console.WriteLine($"{kvp.Value} nota(s) de R$ {kvp.Key}");
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
