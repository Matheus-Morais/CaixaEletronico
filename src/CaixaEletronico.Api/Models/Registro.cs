namespace CaixaEletronico.Api.Models;

public class Registro
{
    private static int incrementoId = 1;
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Tipo { get; set; }
    public double Valor { get; set; }

    public Registro()
    {
        Id = incrementoId;
        Data = DateTime.Today;
        incrementoId++;
    }

    public Registro(string tipo, double valor) : this()
    {
        if (tipo != "Depósito" && tipo != "Saque") throw new ArgumentException("Tipo inválido", nameof(tipo));

        Tipo = tipo;
        Valor = valor;
    }
}
