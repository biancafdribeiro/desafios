using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Desafio1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //chave secreta = usada para criptografar e descriptografar os dados
            //vetor de inicialização = usado para adicionar aleatoriedade ao processo de criptografia

            //transformar a chave secreta em bytes e ajustar o tamanho certo (AES pede por 16, 24 ou 32 bytes)
            string chaveSecreta = "#modalGR#GPTW#top#maiorEmpresaTecnologia#baixadaSantista";
            byte[] chaveBytes = Encoding.UTF8.GetBytes(chaveSecreta);
            Array.Resize(ref chaveBytes, 32);

            string senha1, senha2, senha3;

            Console.WriteLine("Digite a senha 1:");
            senha1 = Console.ReadLine();
            Console.WriteLine("Digite a senha 2:");
            senha2 = Console.ReadLine();
            Console.WriteLine("Digite a senha 3:");
            senha3 = Console.ReadLine();

            //certificando que o vetor de inicialização tenha um tamanho de 16 bytes
            byte[] iv1 = new byte[16];
            byte[] iv2 = new byte[16];
            byte[] iv3 = new byte[16];

            //gerando IVs aleatórios pra cada senha
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv1);
                rng.GetBytes(iv2);
                rng.GetBytes(iv3);
            }

            //criando variáveis em bytes
            byte[] senhaCriptografada1 = EncryptStringToBytes_Aes(senha1, chaveBytes, iv1);
            byte[] senhaCriptografada2 = EncryptStringToBytes_Aes(senha2, chaveBytes, iv2);
            byte[] senhaCriptografada3 = EncryptStringToBytes_Aes(senha3, chaveBytes, iv3);

            //transformando os bytes em strings
            Console.WriteLine($"Senha 1: {senha1}");
            Console.WriteLine($"Senha Criptografada 1: {Convert.ToBase64String(senhaCriptografada1)}");

            Console.WriteLine($"Senha 2: {senha2}");
            Console.WriteLine($"Senha Criptografada 2: {Convert.ToBase64String(senhaCriptografada2)}");

            Console.WriteLine($"Senha 3: {senha3}");
            Console.WriteLine($"Senha Criptografada 3: {Convert.ToBase64String(senhaCriptografada3)}");

            Console.ReadKey();
        }

        //passar string, chave e iv como parâmetros
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            //criando um objeto Aes com a chave e o iv
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                //criando um encryptor com base na chave e no iv 
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                //streams necessários para a criptografia
                using (MemoryStream msEncrypt = new MemoryStream()) //armazena
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) //escreve
                    {
                        using (BinaryWriter bwEncrypt = new BinaryWriter(csEncrypt)) //executa a criptografia
                        {
                            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText); //converte a string em byte
                            bwEncrypt.Write(plainBytes); //escrevendo no CryptoStream
                        }
                    }
                    return msEncrypt.ToArray(); //retornam como array de bytes
                }
            }
        }
    }
}
