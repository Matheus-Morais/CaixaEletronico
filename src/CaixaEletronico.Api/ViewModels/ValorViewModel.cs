using System.Text.Json.Serialization;

namespace CaixaEletronico.Api.ViewModels;

public class ValorViewModel
{
    [JsonPropertyName("valor")]
    public double Valor { get; set; }
}
