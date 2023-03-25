// See https://aka.ms/new-console-template for more information

// Variavel que pode ser modificada
int numero = 2584;
int resultado = VerificaFibonacci(numero);
if (resultado == 0)
{
    Console.WriteLine("O numero " + numero + " esta na sequencia de Fibonacci.");
}
else if (resultado == 1)
{
    Console.WriteLine("O numero " + numero + " nao esta na sequencia de Fibonacci.");
}
Console.ReadLine();

int VerificaFibonacci(int num)
{
    try 
    { 
        int numeroAuxiliar = 0;
        int contadorLista = 0;

        List<int> conjuntoFibonnaci = new List<int>();

        // Incrementa o numero ate que seja maior que o numero informado
        while (numeroAuxiliar < num)
        {
            int resultadoSoma = 0;
            if (conjuntoFibonnaci.Count > 1)
            {
                resultadoSoma = conjuntoFibonnaci[contadorLista-1] + conjuntoFibonnaci[contadorLista-2];
            }
            else
            {
                if (conjuntoFibonnaci.Count == 1)
                {
                    resultadoSoma = 1;
                }
            }
            numeroAuxiliar = resultadoSoma;
            conjuntoFibonnaci.Add(resultadoSoma);
            contadorLista++;
        }
     
        // Percorrendo a lista, visto que nao posso usar funcao pronta
        foreach (int numero in conjuntoFibonnaci)
        {
            if (numero == num)
            {
                return 0;
            }
        }
        return 1;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro na aplicacao: " + ex.ToString());
        return -1;
    }
}

