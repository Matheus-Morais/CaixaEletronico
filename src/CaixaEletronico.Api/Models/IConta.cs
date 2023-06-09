namespace CaixaEletronico.Api.Models;

public interface IConta
{
    int Id { get; set; }
    double Saldo { get; set; }
    List<Registro> Extrato { get; set; } // PErguntar sobre Private set
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
