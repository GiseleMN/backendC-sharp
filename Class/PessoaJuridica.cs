using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendProjeto.Class
{
    public class PessoaJuridica : Pessoa
    {
        public string? cnpj { get; set; }

        public string? razaoSocial { get; set; }

        public PessoaJuridica Ler(string nameArquivo)
        {
            PessoaJuridica PJ = new PessoaJuridica();

            using (StreamReader sr = new StreamReader($"{nameArquivo}.txt"))
            {
                string[] atributos = sr.ReadLine()!.Split(",");

                PJ.nome = atributos[0];
                PJ.cnpj = atributos[1];
                PJ.razaoSocial = atributos[2];
                PJ.endereco.logradouro = atributos[3];
                PJ.endereco.numero = atributos[4];


            }
            return PJ;
        }
        public void Inserir(PessoaJuridica PJ)
        {
            using (StreamWriter sw = new StreamWriter($"{PJ.nome}.txt"))
            {
                sw.WriteLine($"{PJ.nome},{PJ.rendimento},{PJ.cnpj},{PJ.endereco.logradouro},{PJ.endereco.numero}");
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