using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProjeto.Class
{
    public abstract class Pessoa : Endereco
    {
        public string? nome { get; set; }

        public Endereco? endereco { get; set; }

        public float salario { get; set; }

        public float rendimento { get; set; }

        public abstract double PagarImposto(float salario);


        public void VerificarPastaArquivos(string caminho)
        {
            string pasta = caminho.Split("/")[0];
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            if (!File.Exists(caminho))
            {
                using (File.Create(caminho)) { }
            }
        }
    }
}