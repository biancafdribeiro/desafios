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
            Console.WriteLine("            Digite a opção desejada:           ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                1 - Criar conta                ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("           2 - Entrar com CPF e senha          ");
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                                               ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaDeLogin();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("                                               ");
            Console.WriteLine("               Digite seu nome:                ");
            string nome = Console.ReadLine();
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("                Digite seu CPF:                ");
            string cpf = Console.ReadLine();
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("               Digite sua senha:               ");
            string senha = Console.ReadLine();
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("           Digite seu ano de admissão:         ");
            int anoadmissao = int.Parse(Console.ReadLine());
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("             Digite seu salário atual:         ");
            double salarioatual = double.Parse(Console.ReadLine());
            Console.WriteLine("                                               ");
        }

        private static void TelaDeLogin()
        {
            Console.Clear();

            Console.WriteLine("                Digite seu CPF:                ");
            string cpf = Console.ReadLine();
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("               Digite sua senha:               ");
            string senha = Console.ReadLine();
            Console.WriteLine("                                               ");
        }
    }
}
