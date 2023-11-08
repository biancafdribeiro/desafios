using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio3.Classes
{
    public class Layout
    {
        private static int opcao = 0;
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("                                               ");
            Console.WriteLine("       Bem vindo, digite 1 para começar        ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                1 - Criar conta                ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                                               ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    bool criarOutraConta = TelaCriarConta();
                    if (!criarOutraConta)
                    {
                        Environment.Exit(0); // Sai completamente do programa
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        private static bool TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("               Digite seu nome:                ");
            string nome = Console.ReadLine();
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("               Digite seu CPF:                 ");
            string cpf = Console.ReadLine();
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("               Digite sua senha:               ");
            string senha = Console.ReadLine();

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("          Digite seu ano de admissão:          ");
            int anoadmissao = int.Parse(Console.ReadLine());

            if (anoadmissao <= 2018)
            {
                Console.WriteLine("Você é apto para o programa.");
            }
            else
            {
                Console.WriteLine("Agradecemos seu interesse, mas você não atende os requisitos mínimos do programa.");
                Console.WriteLine("Pressione 'S' para criar outra conta ou qualquer tecla para sair.");
                var key = Console.ReadKey();

                if (key.Key != ConsoleKey.S)
                {
                    return false; // Não cria outra conta, retorna para a tela principal
                }
            }

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("           Digite seu salário atual:           ");
            double salarioatual = double.Parse(Console.ReadLine());
            Console.WriteLine("_______________________________________________");
            Console.WriteLine(      "Digite o empréstimo que deseja fazer:    ");
            double empréstimo = double.Parse(Console.ReadLine());

            if (empréstimo <= salarioatual * 2 && empréstimo % 2 == 0)
            {
                Console.WriteLine("Valor válido para empréstimo");
                IConta conta = new ContaBancaria(1000);
                MenuSaque.MostrarOpcoesSaque(conta);
            }
            else
            {
                Console.WriteLine("Insira um valor válido!");
            }
            return true; // Retorna true para continuar criando outra conta
        }

    }
}
