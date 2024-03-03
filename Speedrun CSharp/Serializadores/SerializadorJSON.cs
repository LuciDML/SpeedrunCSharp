using Speedrun_CSharp.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace Speedrun_CSharp.Serializadores
{
    static class SerializadorJSON
    {
        private static List<Pessoa> lista = new List<Pessoa>();

        private static string CaminhoDoArquivo
        {
            get
            {
                string caminho = Directory.GetCurrentDirectory();

                caminho = Path.Combine(caminho, "dados");

                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                caminho = Path.Combine(caminho, "dadosJson.json");

                return caminho;
            }
        }
        
        public static void Serializar(Pessoa pessoa)
        {
            if (lista.Count == 0)
                lista = LerDados();

            lista.Add(pessoa);

            string conteudo = JsonSerializer.Serialize(lista, new JsonSerializerOptions() { WriteIndented = true });

            File.WriteAllText(CaminhoDoArquivo, conteudo);
        }

        public static List<Pessoa> LerDados()
        {
            if (File.Exists(CaminhoDoArquivo))
            {
                string conteudo = File.ReadAllText(CaminhoDoArquivo);

                lista = JsonSerializer.Deserialize<List<Pessoa>>(conteudo);
            }

            return lista;
        }

    }
}
