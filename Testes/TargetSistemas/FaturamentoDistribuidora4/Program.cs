// See https://aka.ms/new-console-template for more information

// Como fiz o ultimo usando objeto, vou fazer esse usando dicionario para variar
var estadoValor = new Dictionary<string, decimal>()
{
    { "SP", Decimal.Parse("67.836,43") },
    { "RJ", Decimal.Parse("37.678,66") },
    { "MG", Decimal.Parse("29.229,88") },
    { "ES", Decimal.Parse("27.165,48") },
    { "Outros", Decimal.Parse("19.849,53") }
};

EscrevePercentualPorEstado(estadoValor);

Console.ReadLine();

// Pega o valor total e depois faz a porcentagem com o valor a parte do Estado
void EscrevePercentualPorEstado(Dictionary<string, decimal> estadoValor)
{
    decimal valorTotal = ValorTotal(estadoValor.Values.ToList());
    foreach (var item in estadoValor)
    {
        if (item.Key != "Outros")
        {
            Console.WriteLine("O Estado de " + item.Key + " teve participacao percentual, no valor total, de " + CalculoPorcentagem(valorTotal, item.Value).ToString("N2") + "%.");
        }
        else
        {
            Console.WriteLine("Outros Estados tiveram participacao percentual, no valor total, de " + CalculoPorcentagem(valorTotal, item.Value).ToString("N2") + "%.");
        }
    }
}

decimal ValorTotal(List<decimal> valores)
{
    decimal valorTotal = 0;
    foreach (var valor in valores)
    {
        valorTotal += valor;
    }
    return valorTotal;
}

decimal CalculoPorcentagem(decimal valorTotal, decimal valorEstado)
{
    return (valorEstado * 100) / valorTotal;
}
