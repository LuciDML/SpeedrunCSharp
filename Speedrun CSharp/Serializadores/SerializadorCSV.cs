
using System;
using System.Collections.Generic;
using System.IO;
using Speedrun_CSharp.Objetos;

namespace Speedrun_CSharp.Serializadores
{
    static class SerializadorCSV
    {
        private static string CaminhoDoArquivo
        {
            get
            {
                string caminho = Directory.GetCurrentDirectory();

                caminho = Path.Combine(caminho, "dados");

                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                caminho = Path.Combine(caminho, "dadosCSV.csv");

                return caminho;
            }
        }

        public static void Serializar(Pessoa pessoa)
        {
            string conteudo = "";

            conteudo += pessoa.Nome + ",";
            conteudo += pessoa.SobreNome + ",";
            conteudo += pessoa.DataDeNascimento + ",";
            conteudo += pessoa.NumeroDoCalcado + Environment.NewLine;

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
                    pessoa = new Pessoa();

                    var linha = dadosDoArquivo[l];

                    var valores = linha.Split(',');
                    
                    pessoa.Nome = valores[0];
                    pessoa.SobreNome = valores[1];
                    pessoa.DataDeNascimento = DateTime.Parse(valores[2]);
                    pessoa.NumeroDoCalcado = Convert.ToByte(valores[3]);

                    lista.Add(pessoa);
                }
            }
            else
            {
                // sem arquivo ignora
            }

            return lista;
        }
    }
}
