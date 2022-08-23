/* 
Ter como base um txt com N emails e gerar X arquivos contendo 5e-mails cada arquivo novo, com nome 01.txt,02.txt... 
de acordo com o número de e-mails no arquivo original.
Dentro dos novos arquivos gerados, não pode haver e-mails repetidos. 
*/


using System;
using System.Web;
using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {

            //Caminhos dos arquivos
            string sourcePath = @"C:\Users\leona\OneDrive\Área de Trabalho\shay\EmailsTeste.txt";
            string basePadrao = @"C:\Users\leona\OneDrive\Área de Trabalho\shay\";

            //Variavel para auxiliar no nome do arquivo
            int numeroArquivo = 1;

            string targetPath = basePadrao+"0"+numeroArquivo.ToString()+".txt";

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);

                //Criacao da lista de 5 strings que sera adicionado por arquivo
                List<string> fiveLines = new List<string>();
                
                //Variavel usar para navegar em cada email do arquivo
                int count = 0;
                
                //Variavel auxiliar para escrever exatamente 5 vezes em cada arquivo
                int repet = 0;

                //Todas as linhas
                List<string> lines = File.ReadAllLines(sourcePath).ToList();

                //Emails que ja foram usados
                List<string> usedEmails = new List<string>();

                //Listando todas as linhas, lembrando de tirar o espaco vazio no final
                List<string> separadoDoEspaco = new List<string>();
                foreach (string line in lines)
                {
                    separadoDoEspaco.Add(line.Split(' ').FirstOrDefault());
                }

                //Lista a quantidade de emails que tem no arquivo
                int quantEmail = 0;
                foreach (string linha in separadoDoEspaco.Distinct())
                {
                    if (linha != "") 
                    { 
                        quantEmail++;
                    }
                }

                //Define a quantidade de arquivos que serao criados
                decimal divisaoPorCinco = quantEmail / 5;

                //Adiciona uma unidade de valor extra caso o numero seja quebrado (resto maior que 0)
                if ((quantEmail % 5) > 0)
                {
                    divisaoPorCinco++;
                }


                foreach (string line in separadoDoEspaco.Distinct())
                {
                    //Verifica se ja foi escrito 5 vezes, ou se o numero do contador
                    //e superior ao numero da quantidade de emails
                    if (repet == 5 || count >= lines.Count())
                    {
                        break;
                    }

                    //Verifica se o email esta se repetindo. Se nao estiver
                    //adiciona uma linha.
                    if (!usedEmails.Contains(separadoDoEspaco[count])) 
                    { 
                        fiveLines.Add(separadoDoEspaco[count]);
                        repet++;
                    }
                    usedEmails.Add(separadoDoEspaco[count]);

                    count++;
                }

                repet = 0;
                 
                //Loop na quantidade de txt's que serao criados
                for (int i = 0; i < divisaoPorCinco; i++) { 
                    //Cria ou sobrepõe um novo arquivo com o caminho passado
                    using (StreamWriter sw = File.CreateText(targetPath))
                    {
                        //Escreve as cinco linhas
                        foreach (string line in fiveLines)
                        {
                            sw.WriteLine(line);
                        }
                    }

                    //Sera permitido criar um novo arquivo
                    bool criarArquivo = true;

                    //Resetando as cinco linhas
                    fiveLines = new List<string>();

                    foreach (string line in separadoDoEspaco.Distinct())
                    {
                        //Verifica se ja foi escrito 5 vezes, ou se o numero do contador
                        //e superior ao numero da quantidade de emails
                        if (repet == 5 || count >= lines.Count())
                        {
                            //Verifica se algo foi escrito. Se nao, impedira
                            //de criar um arquivo vazio numa verificao mais a frente.
                            if (fiveLines.Count() == 0)
                            {
                                criarArquivo = false;
                            }
                            break;
                        }

                        //Verifica se o email esta se repetindo. Se nao estiver
                        //adiciona uma linha.
                        if (!usedEmails.Contains(separadoDoEspaco[count]))
                        {
                            fiveLines.Add(separadoDoEspaco[count]);
                            repet++;
                        }

                        usedEmails.Add(separadoDoEspaco[count]);
                        count++;
                    }

                    repet = 0;

                    //Verifica se a linha nao é vazia, para nao criar um arquivo vazio.
                    if (criarArquivo) 
                    { 
                        //O numero do txt aumenta
                        numeroArquivo++;
                        targetPath = basePadrao + "0" + numeroArquivo.ToString() + ".txt";
                    }
                }
            }
            
            //Tratamento de erros gerais
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }

            //Execucao final
            finally
            {
                Console.WriteLine("Programa finalizado");
            }
        }
    }
}
