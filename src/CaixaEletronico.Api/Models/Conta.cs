namespace CaixaEletronico.Api.Models;

public class Conta
{

    public int Id { get; set; }
    public double Saldo { get; set; }
    public List<Registro> Extrato { get; private set; }

    public Conta()
    {
        Id = 1;
        Extrato = new List<Registro>();
    }

    public Conta(double saldoInicial) : this()
    {
        Saldo = saldoInicial;
    }

    public void Deposito(double valor)
    {
        if (valor <= 0) return;

        Saldo += valor;

        RegistrarMovimentacao("Depósito", valor);
    }

    public void Saque(double valor)
    {
        if (valor <= 0 || valor > Saldo) return;

        Saldo -= valor;

        RegistrarMovimentacao("Saque", valor);
    }

    private void RegistrarMovimentacao(string tipo, double valor)
    {
        try
        {
            var registro = new Registro(tipo, valor);

            Extrato.Add(registro);
        }
        catch
        {
            throw;
        }

    }
}
