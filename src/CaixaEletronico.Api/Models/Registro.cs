namespace CaixaEletronico.Api.Models;

public class Registro
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Tipo { get; set; }
    public double Valor { get; set; }

    public Registro()
    {
        Id = 1;
        Data = DateTime.Today;
    }

    public Registro(string tipo, double valor) : this()
    {
        if (tipo != "Depósito" && tipo != "Saque") throw new ArgumentException("Tipo inválido", nameof(tipo));

        Tipo = tipo;
        Valor = valor;
    }
}
