namespace CaixaEletronico.Api.Models;

public class Conta : IConta
{

    public int Id { get; set; }
    public double Saldo { get; set; }
    public List<Registro> Extrato { get; set; }

    public Conta()
    {
        Random random = new Random();
        Id = random.Next(1, 20000);
        Extrato = new List<Registro>();
    }

    public Conta(double saldoInicial) : this()
    {
        Saldo = saldoInicial;
    }
}
