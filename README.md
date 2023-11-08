

# Desafio 3: Programa de Empréstimo

Este programa é um sistema de empréstimo onde os usuários podem criar contas, sacar dinheiro em diferentes combinações de notas e verificar a adequação do valor do saque às regras do banco.

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
