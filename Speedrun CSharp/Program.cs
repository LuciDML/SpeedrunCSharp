

using System;
using System.IO;
using System.Collections.Generic;

namespace Speedrun_CSharp
{
    class Pessoa
    {
        public string Nome;
        public string SobreNome;
        public DateTime DataDeNascimento;
        public byte NumeroDoCalcado;
    }
     
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa usuaria = new Pessoa();

            /*
            usuaria.Nome = "luciana";
            usuaria.DataDeNascimento = new DateTime(2001, 11, 30);
            usuaria.NumeroDoCalcado = 32;
            */

            Console.WriteLine("Ola, qual seu nome?");

            usuaria.Nome = Console.ReadLine();
            
            Console.WriteLine("Ola, qual seu sobrenome?");

            usuaria.SobreNome = Console.ReadLine();

            Console.WriteLine($"Opa { usuaria.Nome }, beleza? Qual sua data de nascimento?");

            try
            {
                usuaria.DataDeNascimento = DateTime.Parse(Console.ReadLine());
                
                if (usuaria.DataDeNascimento > DateTime.Now)
                {
                    Console.WriteLine("Vc nasceu no futuro, nao rola...");

                    usuaria.DataDeNascimento = new DateTime();
                }
                else
                {
                    Console.WriteLine("Ok legal.");
                }
            }
            catch
            {
                Console.WriteLine("Olha nao entendi a data mas beleza...");
            }

            Console.WriteLine("Qual numero vc calca?");

            try
            {
                usuaria.NumeroDoCalcado = Convert.ToByte(Console.ReadLine());

                if (usuaria.NumeroDoCalcado > 40)
                {
                    Console.WriteLine("Desculpa mas não temos calçado tamanho " + usuaria.NumeroDoCalcado);
                }
                else
                {
                    Console.WriteLine("Show!");
                }
            }
            catch 
            {
                Console.WriteLine("Esse número parece errado mas ok...");
            }

            string conteudo = "";

            conteudo = conteudo + usuaria.Nome + Environment.NewLine;
            conteudo = conteudo + usuaria.SobreNome + Environment.NewLine;
            conteudo = conteudo + usuaria.DataDeNascimento + Environment.NewLine;
            conteudo = conteudo + usuaria.NumeroDoCalcado + Environment.NewLine;

            File.WriteAllText(@"E:\projetos\TIcomLuci\02 - Speedrun CSharp\Speedrun CSharp\Speedrun CSharp\dados.txt", conteudo);
            
            Console.WriteLine("Gravamos seus dados. Obrigada!");

            Console.ReadLine();
        }
    }
}
