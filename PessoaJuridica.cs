using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProjeto
{
    public class PessoaJuridica : Pessoa
    {
        public string? cnpj { get; set; }

        public string? razaoSocial { get; set; }

        public PessoaJuridica Ler(string nameArquivo)
        {
            PessoaJuridica pj = new PessoaJuridica();

            using (StreamReader sr = new StreamReader($"{nameArquivo}.txt"))
            {
                string[] atributos = sr.ReadLine()!.Split(",");

                pj.nome = atributos[0];
                pj.cnpj = atributos[1];
                pj.razaoSocial = atributos[2];


            }
            return pj;
        }
        public void Inserir(PessoaJuridica pj)
        {
            using (StreamWriter sw = new StreamWriter($"{pj.nome}.txt"))
            {
                sw.WriteLine($"{pj.nome},{pj.rendimento},{pj.cnpj}");
            }
        }
        public override double PagarImposto(float rendimento)
        {

            if (rendimento <= 5000)
            {

                return rendimento * .06;

            }
            else if (rendimento > 5000 && rendimento <= 10000)
            {

                return rendimento * .08;

            }
            else
            {
                return (rendimento / 100) * 10;
            }
        }


        public bool ValidarCNPJ(string cnpj)
        {

            if (cnpj.Length >= 14 && cnpj.Substring(cnpj.Length - 6, 4) == "0001")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}