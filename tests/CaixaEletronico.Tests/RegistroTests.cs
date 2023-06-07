using CaixaEletronico.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico.Tests;

public class RegistroTests
{
    [Fact]
    public void IniciarRegistro_IdMaiorQueZero()
    {
        var registro = new Registro();

        Assert.True(registro.Id >= 1);
    }

    [Fact]
    public void IniciarRegistro_Data()
    {
        var registro = new Registro();

        Assert.True(DateTime.Equals(registro.Data, DateTime.Today));
    }

    [Fact]
    public void IniciarRegistro_Valor()
    {
        var registro = new Registro("Depósito", 1000);

        Assert.Equal(1000, registro.Valor);
    }

    [Theory]
    [InlineData("Depósito")]
    [InlineData("Saque")]
    public void IniciarRegistro_Tipo(string tipo)
    {
        var registro = new Registro(tipo, 1000);

        Assert.Equal(tipo, registro.Tipo);
    }

    [Fact]
    public void IniciarRegistro_Tipo_DiferenteSaqueOuDeposito()
    {
        var action = () => new Registro("Emprestimo", 1000);

        Assert.Throws<ArgumentException>(action);
    }
}
