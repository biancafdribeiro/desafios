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

            //lê o arquivo de entrada
            string texto = File.ReadAllText(inputFile);

            //processa o texto para criar o conteúdo Txt
            string conteudoTxt = ProcessarTextoTxt(texto);

            //escreve o conteúdo Txt no arquivo de saída
            File.WriteAllText(outputFile, conteudoTxt);

            Console.ReadKey();
        }

        static string ProcessarTextoTxt(string texto)
        {
            //divide o texto em linhas; cada elemento do array corresponde a uma linha do texto
            string[] linhas = texto.Split('\n');

            int mesCorrente = DateTime.Now.Month; //mês atual
            List<string> aniversariantes = new List<string>(); //lista de aniversariantes

            foreach (string linha in linhas)
            {
                //dividir a linha em campos usando o pipeline como separador
                string[] campos = linha.Split('|');

                if (campos.Length >= 3) //verifica se há pelo menos 3 elementos no array campos
                {
                    //trim remove os espaços em branco
                    string nome = campos[0].Trim();
                    string email = campos[1].Trim();
                    string dataNascimento = campos[2].Trim();

                    //se a análise da data de nascimento for bem sucedida, armazena o resultado na variável
                    // data e retorna true; se falhar, retorna false e data vai conter o valor padrão de DateTime
                    if (DateTime.TryParse(dataNascimento, out DateTime data)) //out armazena na variável data
                    {
                        int mesNascimento = data.Month;

                        if (mesNascimento == mesCorrente)
                        {
                            //a string é adicionada à lista aniversariantes
                            aniversariantes.Add($"Nome: {nome} | Email: {email} | Mês de Nascimento: {mesNascimento}");
                        }
                    }
                }
            }

            // Cria o início do conteúdo Txt
            string conteudoTxt = "A ModalGR parabeniza os seguintes colaboradores:\n";
            conteudoTxt += string.Join("\n", aniversariantes); //join coloca elementos em uma única string
                                                               //que serão delimitados pelo "\n"

            return conteudoTxt;
        }
    }
}
