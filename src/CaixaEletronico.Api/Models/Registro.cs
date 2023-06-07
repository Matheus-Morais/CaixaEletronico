namespace CaixaEletronico.Api.Models;

public class Registro
{
    public int Id { get; set; }
    public DateTime data { get; set; }
    public string Tipo { get; set; }
    public float valor { get; set; }
}
