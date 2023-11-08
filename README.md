# Desafio 1: Criptografia de Senhas

Este é um programa desenvolvido em C# que demonstra a criptografia de senhas usando o algoritmo AES (Advanced Encryption Standard).

## Visão Geral

O programa permite ao usuário inserir três senhas diferentes e as criptografa individualmente. As senhas são criptografadas usando uma chave secreta comum, mas cada senha é associada a um vetor de inicialização (IV) exclusivo. O IV é gerado aleatoriamente para cada senha, tornando o processo de criptografia mais seguro.

## Passos de Execução

1. **Chave Secreta**: O programa começa definindo uma chave secreta que será usada para criptografar e descriptografar os dados. A chave secreta é uma string que é convertida em um array de bytes e ajustada para ter um tamanho de 32 bytes.

2. **Entrada do Usuário**: O usuário é solicitado a inserir três senhas distintas (senha1, senha2 e senha3).

3. **Vetores de Inicialização (IV)**: Para cada senha, um vetor de inicialização (IV) de 16 bytes é gerado aleatoriamente. Isso adiciona um nível de aleatoriedade ao processo de criptografia, garantindo que a mesma senha criptografada seja diferente toda vez.

4. **Criptografia**: O programa utiliza o algoritmo AES para criptografar cada senha individualmente. Ele cria um objeto AES com a chave secreta e o IV correspondente. O algoritmo AES é usado para criar um encryptor baseado na chave e no IV. Em seguida, as senhas são convertidas em arrays de bytes e criptografadas usando o IV e a chave.

5. **Exibição dos Resultados**: Após a criptografia, o programa exibe as senhas originais e suas versões criptografadas como strings base64.


# Desafio 2: Processamento de Aniversariantes

Este é um programa desenvolvido em C# que lê informações de colaboradores a partir de um arquivo de entrada, identifica os colaboradores que fazem aniversário no mês atual e cria um arquivo de saída com as informações dos respectivos aniversariantes.

## Leitura e Processamento de Dados

- O arquivo de entrada é lido utilizando a função `File.ReadAllText()` e o conteúdo é armazenado em uma string.

- O programa processa as informações para identificar os colaboradores que fazem aniversário no mês atual.

- O resultado é armazenado em uma lista chamada "aniversariantes", que contém strings formatadas com nome, e-mail e mês de nascimento dos colaboradores.

## Escrita de Dados

- O programa cria o conteúdo do arquivo de saída ("TEXTOUTPUT.txt") concatenando strings.

- É utilizada a função `File.WriteAllText()` para escrever o conteúdo no arquivo de saída.

- O arquivo de saída conterá uma mensagem de parabéns e a lista de aniversariantes.


# Desafio 3: Programa de Empréstimo

Este programa desenvolvido em C# é um sistema de empréstimo onde os usuários podem criar contas, sacar dinheiro em diferentes combinações de notas e verificar a adequação do valor do saque às regras do banco.

## Program

O programa começa na classe `Program`. O método `Main` inicia o programa chamando `Layout.TelaPrincipal()`, que é a função principal que exibe o menu inicial para o usuário.

## Layout

A classe `Layout` lida com a interface do usuário. Ela exibe mensagens, obtém entradas do usuário e toma decisões com base nas escolhas do usuário. Os principais componentes desta classe são:

- `TelaPrincipal()`: Exibe o menu principal para o usuário, permitindo a criação de contas ou a saída do programa.

- `TelaCriarConta()`: Guia o usuário na criação de uma nova conta bancária, coletando informações como nome, CPF, ano de admissão e salário. Verifica se o usuário atende aos requisitos mínimos para criar uma conta e fazer o empréstimo.

## IConta

A interface `IConta` define um contrato para as contas bancárias. Define que uma conta deve ter uma lista de notas disponíveis e um método para sacar dinheiro.

## ContaBancaria

A classe `ContaBancaria` implementa a interface `IConta`. Ela representa uma conta bancária com saldo, notas disponíveis e regras de saque. O método `Saca` permite sacar dinheiro da conta, verificando o limite de empréstimo e o saldo disponível.

## MenuSaque

A classe `MenuSaque` fornece um menu interativo para sacar dinheiro em diferentes combinações de notas. Permite ao usuário escolher notas de maior valor, de menor valor, ou uma combinação. O programa verifica se o valor do saque é par e se é possível atender ao valor desejado com as notas disponíveis.
