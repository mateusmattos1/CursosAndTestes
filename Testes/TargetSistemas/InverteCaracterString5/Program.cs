// See https://aka.ms/new-console-template for more information
var stringNormal = "Digitando qualquer coisa pra fazer o teste";
var stringReversa = "";

// Por ser um codigo mais simples, nao separei em um metodo
for (int i = 0; i < stringNormal.Length; i++)
{
    stringReversa = stringNormal[i] + stringReversa;
}

Console.WriteLine(stringReversa);
Console.ReadLine();