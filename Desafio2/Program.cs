using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Desafio2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string inputFile = "TEXTOINPUT.txt";
            string outputFile = "TEXTOUTPUT.txt";

            // Lê o arquivo de entrada
            string texto = File.ReadAllText(inputFile);

            // Processa o texto para criar o conteúdo Txt
            string conteudoTxt = ProcessarTextoTxt(texto);

            // Escreve o conteúdo Txt no arquivo de saída
            File.WriteAllText(outputFile, conteudoTxt);

            Console.ReadKey();
        }

        static string ProcessarTextoTxt(string texto)
        {
            // Divide o texto em linhas
            string[] linhas = texto.Split('\n');

            int mesCorrente = DateTime.Now.Month;
            List<string> aniversariantes = new List<string>();

            foreach (string linha in linhas)
            {
                // Dividir a linha em campos usando o pipeline como separador
                string[] campos = linha.Split('|');

                if (campos.Length >= 3)
                {
                    string nome = campos[0].Trim();
                    string email = campos[1].Trim();
                    string dataNascimento = campos[2].Trim();

                    if (DateTime.TryParse(dataNascimento, out DateTime data))
                    {
                        int mesNascimento = data.Month;

                        if (mesNascimento == mesCorrente)
                        {
                            aniversariantes.Add($"Nome: {nome}, Email: {email}, Mês de Nascimento: {mesNascimento}");
                        }
                    }
                }
            }

            // Cria o início do conteúdo Txt
            string conteudoTxt = "A ModalGR parabeniza os seguintes colaboradores:\n";
            conteudoTxt += string.Join("\n", aniversariantes);

            return conteudoTxt;
        }
    }
}
