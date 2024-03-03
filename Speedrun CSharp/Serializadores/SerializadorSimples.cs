
using System;
using System.Collections.Generic;
using System.IO;

using Speedrun_CSharp.Objetos;

namespace Speedrun_CSharp.Serializadores
{
    static class SerializadorSimples
    {
        private static string CaminhoDoArquivo
        {
            get
            {
                string caminho = Directory.GetCurrentDirectory();

                caminho = Path.Combine(caminho, "dados");

                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                caminho = Path.Combine(caminho, "dadosSimples.txt");

                return caminho;
            }
        }

        public static void Serializar(Pessoa pessoa)
        {
            string conteudo = "";

            conteudo += "Nome: " + pessoa.Nome + Environment.NewLine;
            conteudo += "SobreNome: " +pessoa.SobreNome + Environment.NewLine;
            conteudo += "Data de Nascimento: " +pessoa.DataDeNascimento + Environment.NewLine;
            conteudo += "Calçado: " +pessoa.NumeroDoCalcado + Environment.NewLine;

            conteudo += Environment.NewLine;

            File.AppendAllText(CaminhoDoArquivo, conteudo);
        }

        public static List<Pessoa> LerDados()
        {
            var lista = new List<Pessoa>();
            
            if (File.Exists(CaminhoDoArquivo))
            {
                Pessoa pessoa = null;

                var dadosDoArquivo = new List<string>(File.ReadAllLines(CaminhoDoArquivo));

                for (int l = 0; l < dadosDoArquivo.Count; l++)
                {
                    if (pessoa == null)
                        pessoa = new Pessoa();

                    var linha = dadosDoArquivo[l];

                    // "Nome: luci"
                    // pessoa.Nome = "luci";

                    var propValor = linha.Split(':');

                    //propValor[0] = "Nome"
                    //propValor[1] = " luci"

                    if (propValor.Length > 0)
                    {
                        if (propValor[0] == "Nome") 
                            pessoa.Nome = propValor[1].Trim();
                        
                        if (propValor[0] == "SobreNome") 
                            pessoa.SobreNome = propValor[1].Trim();

                        // "Data de Nascimento: 01/01/2001 00:00:00".indexOf(':')

                        // substring(18 + 2)

                        if (propValor[0] == "Data de Nascimento")
                        {
                            var valorData = linha.Substring(linha.IndexOf(':') + 2);

                            pessoa.DataDeNascimento = DateTime.Parse(valorData);
                        }

                        if (propValor[0] == "Calçado") 
                            pessoa.NumeroDoCalcado = Convert.ToByte(propValor[1].Trim());

                        if (propValor[0] == "")
                        {
                            lista.Add(pessoa);

                            pessoa = new Pessoa();
                        }
                    }
                }
            }
            else
            {
                // deu ruim
            }

            return lista;
        }
    }
}
