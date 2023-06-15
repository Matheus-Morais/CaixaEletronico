namespace CaixaEletronico.Api.Models;

public interface IConta
{
    int Id { get; set; }
    double Saldo { get; set; }
    List<Registro> Extrato { get; set; } // PErguntar sobre Private set

    public void Deposito(double valor);
    public void Saque(double valor);

}
