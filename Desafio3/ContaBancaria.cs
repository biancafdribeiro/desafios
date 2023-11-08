using Desafio3;
using System.Collections.Generic;
using System;

public class ContaBancaria : IConta
{
    private double saldo;
    private double salario;

    public ContaBancaria(double saldoInicial, double salario)
    {
        saldo = saldoInicial; //permite que especifique um valor inicial de saldo ao criar um objeto
        this.salario = salario;
    }

    public List<int> Notas { get; } = new List<int> { 100, 50, 20, 10, 5, 2 }; //lista de inteiros com somente
                                                                               //leitura

    public bool Saca(double valor)
    {
        //verifica se o valor do saque é menor ou igual ao dobro do salário
        if (valor > salario * 2)
        {
            Console.WriteLine("Limite de empréstimo excedido.");
            return false;
        }

        if (saldo >= valor)
        {
            saldo -= valor;
            return true; //indica que o saque foi bem sucedido
        }
        return false; //executado se nenhuma das opções for satisfeita
    }
}
