// See https://aka.ms/new-console-template for more information

using CalculoDistribuidora3.Objetos;

// pacote utilizado para trabalhar com JSON
using Newtonsoft;
using Newtonsoft.Json;

List<Faturamento> faturamentos = LerJson("../../../dados.json");
EscreveMenorFaturamento(faturamentos);
EscreveMaiorFaturamento(faturamentos);
EscreveNumerosDeDiasSuperiorDaMedia(faturamentos);

Console.ReadLine();

// Metodo que converte JSON em objeto
List<Faturamento> LerJson(string caminhoArquivo)    
{
    using (StreamReader r = new StreamReader(caminhoArquivo))
    {
        var json = r.ReadToEnd();
        var items = JsonConvert.DeserializeObject<List<Faturamento>>(json);

        return items;
    }
}

void EscreveMenorFaturamento(List<Faturamento> faturamentos)
{
    // Pegando o maior valor da lista pra poder usar nas condicionais
    Faturamento faturamentoMenor = new Faturamento() { Valor = faturamentos.Select(x => x.Valor).Max() };
    foreach (Faturamento fat in faturamentos)
    {
        // Fins de semana e feriados nao entram no calculo
        if (fat.Valor != 0)
        {
            if (faturamentoMenor.Valor > fat.Valor)
            {
                faturamentoMenor = fat;
            }
        }
    }

    Console.WriteLine("O dia com menor faturamento foi: " + faturamentoMenor.Dia + ". O valor foi: R$ " + faturamentoMenor.Valor.ToString("N2") + ".");
}

void EscreveMaiorFaturamento(List<Faturamento> faturamentos)
{
    Faturamento faturamentoMaior = new Faturamento();
    foreach (Faturamento fat in faturamentos)
    {
        // Fins de semana e feriados nao entram no calculo
        if (fat.Valor != 0)
        {
            if (faturamentoMaior.Valor < fat.Valor)
            {
                faturamentoMaior = fat;
            }
        }
    }

    Console.WriteLine("O dia com menor faturamento foi: " + faturamentoMaior.Dia + ". O valor foi: R$ " + faturamentoMaior.Valor.ToString("N2") + ".");
}

/*
 Numero de dias no mes em que o valor de faturamento diario foi superior a media mensal
 Foi solicitado APENAS a quantidade de dias
 */
void EscreveNumerosDeDiasSuperiorDaMedia(List<Faturamento> faturamentos)
{
    int quantDias = 0;
    decimal valorMedio = CalculoValorMedio(faturamentos);
    foreach (Faturamento fat in faturamentos)
    {
        if (fat.Valor > valorMedio)
        {
            quantDias++;
        }
    }
    Console.WriteLine("A quantidade de dias com o faturamento diario superior a media mensal foi: " + quantDias + ".");
}

// Valor medio do mes, tirando feriados e fins de semana
decimal CalculoValorMedio(List<Faturamento> faturamentos)
{
    decimal valor = 0;
    int quantDias = 0;
    // Evitando usar metodos prontos, entao faco manualmente
    foreach (Faturamento fat in faturamentos)
    {
        if (fat.Valor > 0)
        {
            quantDias++;
            valor += fat.Valor;
        }
    }

    return valor / quantDias;
}