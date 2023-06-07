using CaixaEletronico.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Tests;

public class ContaTests
{
    [Fact]
    public void IniciarConta_IdMaiorIgualUm()
    {
        var conta = new Conta();
        var id = conta.Id;

        //conta deve ter um id
        Assert.True(id >= 1);
    }

    [Fact]
    public void IniciarConta_SaldoIgualZero()
    {
        var conta = new Conta();
        var saldo = conta.Saldo;

        //conta deve ter saldo 0
        Assert.Equal(0, saldo);
    }

    [Fact]
    public void IniciarConta_Extrato()
    {
        var conta = new Conta();

        Assert.Empty(conta.Extrato);
    }

    [Fact]
    public void DepositoConta()
    {
        var conta = new Conta();

        conta.Deposito(500);

        Assert.Equal(500, conta.Saldo);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void DepositoConta_DepositoMaiorQueZero(double valor)
    {
        //deposito deve ser maior que zero
        var conta = new Conta();
        var saldo = conta.Saldo;

        conta.Deposito(valor);

        Assert.Equal(saldo, conta.Saldo);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void SaqueConta_SaqueMaiorIgualZero(double valor)
    {
        var conta = new Conta();
        var saldo = conta.Saldo;

        conta.Saque(valor);

        Assert.Equal(saldo, conta.Saldo);
    }

    [Theory]
    [InlineData(2000)]
    public void SaqueConta_SaqueMaiorQueSaldo(double valor)
    {
        var conta = new Conta(1000);
        var saldo = conta.Saldo;

        conta.Saque(valor);

        Assert.Equal(saldo, conta.Saldo);
    }

    [Theory]
    [InlineData(1000)]
    [InlineData(600)]
    public void RegistroMovimentacao_Deposito(double valor)
    {
        var conta = new Conta();

        conta.Deposito(valor);

        Assert.NotEmpty(conta.Extrato);
    }
}