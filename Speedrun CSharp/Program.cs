

using System;
using System.IO;
using System.Collections.Generic;

using Speedrun_CSharp.Objetos;
using Speedrun_CSharp.Serializadores;

namespace Speedrun_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string querSair = "n";

            while(querSair != "S")
            {
                Console.WriteLine("Bem-Vinda ao cadastro de clientes!");

                Console.WriteLine("Digite C para cadastrar ou qualquer coisa para listagem");

                var opcao = Console.ReadLine().ToUpper();

                if (opcao == "C")
                {
                    RealizarCadastro();
                }
                else
                {
                    RealizarLeitura();
                }

                querSair = Console.ReadLine().ToUpper();
            }
        }

        static void RealizarCadastro()
        {
            Pessoa usuaria = new Pessoa();

            Console.WriteLine("Qual o nome da cliente?");

            usuaria.Nome = Console.ReadLine().Replace(",", "");

            Console.WriteLine("Qual o sobrenome?");

            usuaria.SobreNome = Console.ReadLine().Replace(",", "");

            Console.WriteLine($"Cadastrando { usuaria.NomeCompleto }. Qual a data de nascimento?");

            try
            {
                usuaria.DataDeNascimento = DateTime.Parse(Console.ReadLine());
                
                if (usuaria.DataDeNascimento > DateTime.Now)
                {
                    Console.WriteLine("Cliente nasceu no futuro, data será ignorada.");

                    usuaria.DataDeNascimento = new DateTime();
                }
                else
                {
                    Console.WriteLine("Ok legal.");
                }
            }
            catch
            {
                Console.WriteLine("Data inválida, ignorando...");
            }

            Console.WriteLine("Qual numero do calçado?");

            try
            {
                usuaria.NumeroDoCalcado = Convert.ToByte(Console.ReadLine());

                if (usuaria.NumeroDoCalcado > 40)
                {
                    Console.WriteLine("Atenção! Não temos calçado tamanho " + usuaria.NumeroDoCalcado);
                }
                else
                {
                    Console.WriteLine("Show!");
                }
            }
            catch 
            {
                Console.WriteLine("Esse número parece errado, ignorando...");
            }

            //SerializadorSimples.Serializar(usuaria);

            //SerializadorCSV.Serializar(usuaria);

            SerializadorJSON.Serializar(usuaria);

            Console.Write("Gravamos os dados da cliente. Obrigada! Deseja sair (s/n)? ");
        }

        static void RealizarLeitura()
        {
            //var lista = SerializadorSimples.LerDados();
            //var lista = SerializadorCSV.LerDados();

            var lista = SerializadorJSON.LerDados();

            if (lista.Count > 0)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine(
                        lista[i].NomeCompleto + 
                        " nascida em " + lista[i].DataDeNascimento +
                        " calça " + lista[i].NumeroDoCalcado
                    );
                }
            }
            else
            {
                Console.WriteLine("Nao existem clientes cadastradas.");
            }
        }
    }
}
