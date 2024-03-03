

using System;
using System.Collections.Generic;
using System.Text;

namespace Speedrun_CSharp.Objetos
{
    class Pessoa
    {
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string NomeCompleto
        {
            get
            {
                return this.Nome + " " + this.SobreNome;
            }
        }

        public DateTime DataDeNascimento { get; set; }

        public byte NumeroDoCalcado { get; set; }
    }
}
