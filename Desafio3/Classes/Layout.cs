using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio3.Classes
{
    public class Layout
    {
        //armazenar a opção do usuário no menu
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

            //converte em int porque o usuário vai digitar números (1)
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    bool criarOutraConta = TelaCriarConta(); //variável é atribuida com o valor de retorno do método
                    if (!criarOutraConta)
                    {
                        Environment.Exit(0); //sai completamente do programa caso o usuário não queira
                                             //criar outra conta
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
            Console.WriteLine("          Digite seu ano de admissão:          ");
            int anoadmissao = int.Parse(Console.ReadLine());

            //os colaboradores precisam ter tempo de casa superior a cinco anos
            if (anoadmissao <= 2018)
            {
                Console.WriteLine("Você é apto para o programa.");
            }
            else
            {
                Console.WriteLine("Agradecemos seu interesse, mas você não atende os requisitos mínimos do programa.");
                Console.WriteLine("Pressione 'C' para criar outra conta ou qualquer tecla para sair.");
                var key = Console.ReadKey();

                //converte o caractere em maiúscula, então mesmo se ele digitar 'c', o programa vai entender
                if (char.ToUpper(key.KeyChar) == 'C')
                {
                    return TelaCriarConta(); //cria outra conta
                }
                else
                {
                    return false; //volta para o método de criar outra conta, e no caso, como o usuário
                                  //não quer, o programa será fechado
                }
            }

            Console.WriteLine("_______________________________________________");
            Console.WriteLine("           Digite seu salário atual:           ");
            double salarioatual = double.Parse(Console.ReadLine());

            double emprestimo;
            bool emprestimoValido = false; //caso o empréstimo seja inválido

            while (!emprestimoValido)
            {
                Console.WriteLine("___________________________________________");
                Console.WriteLine("   Digite o empréstimo que deseja fazer:   ");
                emprestimo = double.Parse(Console.ReadLine());

                //lógica do empréstimo: no máximo o dobro do salário e precisa ser par
                if (emprestimo <= salarioatual * 2 && emprestimo % 2 == 0)
                {
                    Console.WriteLine("Valor válido para empréstimo");
                    emprestimoValido = true;
                }
                else
                {
                    Console.WriteLine("Insira um valor válido para o empréstimo (até 2 vezes o salário e valor par).");
                }
            }

            //criando uma instância de uma classe que implementa a interface (ContaBancaria) e 
            //atribuindo o valor à variável conta
            IConta conta = new ContaBancaria(1000, 5000);
            MenuSaque.MostrarOpcoesSaque(conta); //chamando o método da classe MenuSaque

            return true; //retorna true para continuar criando outra conta
        }
    }
}
