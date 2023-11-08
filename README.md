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
