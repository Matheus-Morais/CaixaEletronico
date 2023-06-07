namespace CaixaEletronico.Api.Models;

public class Conta
{
    public int Id { get; set; }
    public double Saldo { get; set; }

    public Conta()
    {
        Id = 1;
    }

    public void Deposito(double valor)
    {
        if (valor <= 0) return;

        Saldo += valor;
    }

    public void Saque(double valor)
    {
        if (valor <= 0) return;
        Saldo -= valor;
    }
}
